#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Upload publish folder to kscdn
#
# Prerequsities:
# sudo pip install six pyyaml jmespath

import os
import sys
import signal
from itertools import izip_longest
os.chdir(os.path.dirname(sys.argv[0]))

sys.path.append("./ks3-python-sdk")
sys.path.append("./ksc-sdk-python")

terminated = False
ks3_host = 'ks3-cn-beijing.ksyun.com'
keep_folders = 3
all_files = []

if len(sys.argv) < 7:
    print "Usage: kscdn_deploy.py ak sk bucket publish_dir remote_dir cdn_url"
    # ak = 'AKLTYOlNBpPEQmu4awYApPUSNQ'
    # sk = 'OKLXnVO6Ij41C8QIwn+H+iZPy44OJlOb6E8YQyoRSFWw/nuBzHzU76cieln9lq1rog=='
    # bucket_name = "kfs"
    # remote_dir = "k6/android-123"
    # publish_dir = "../publish/leiting/android"
    # cdn_url = "http://kfscdn.firevale.com/" + remote_dir
    sys.exit(0)
else:
    ak = sys.argv[1]
    sk = sys.argv[2]
    bucket_name = sys.argv[3]
    publish_dir = sys.argv[4]
    remote_dir = sys.argv[5]
    cdn_url = sys.argv[6]

print "bucket_name: " + bucket_name
print "publish_dir: " + publish_dir
print "remote_dir: " + remote_dir
print "cdn_url: " + cdn_url

from ks3.connection import Connection

connection = Connection(ak, sk, host=ks3_host, is_secure=True, domain_mode=False)
bucket = connection.get_bucket(bucket_name)


def upload_file(key_name, filename):
    try:
        key = bucket.new_key(key_name)
        ret = key.set_contents_from_filename(filename, policy="public-read")
        if ret and ret.status == 200:
            return True
    except:
        pass
        return False


def upload_dir(x, dir_name, files):
    for filename in files:
        if terminated:
            return
        path = dir_name + '/' + filename
        if os.path.isfile(path):
            print 'Uploading ' + path + '...'
            fname = path.replace(publish_dir, "")
            key_name = remote_dir + fname
            all_files.append(fname)
            while not upload_file(key_name, path):
                print 'Retrying...'


def refresh_batch(base_url, client, batch):
    try:
        param = {
            "Urls": batch
        }
        print "Refreshing url ", base_url, " batch is", len(batch), "..."
        # print param
        ret = client.preload_caches(**param)
        print "refresh_cdn: ret=", ret
        return True
    except Exception as e:
        print(e)
        print "refresh_cdn: failed!"
        return False


def mygrouper(n, iterable):
    args = [iter(iterable)] * n
    return ([e for e in t if e != None] for t in izip_longest(*args))


def refresh_cdn(base_url):
    from kscore.session import get_session
    session = get_session()
    client = session.create_client("cdn", ks_access_key_id=ak, ks_secret_access_key=sk)
    urls = []
    for fname in all_files:
        urls.append({"Url": base_url + fname})
    batches = list(mygrouper(100, urls))
    print "Refreshing url ", base_url, " total batch", len(batches)
    for batch in batches:
        while not refresh_batch(base_url, client, batch):
            print 'Retrying...'


def delete_old_folders(publish_dir, remote_root, keep):
    all_versions_file = os.path.join(publish_dir, 'all_versions.tmp')
    print "delete_old_folders: looking for " + all_versions_file
    if os.path.isfile(all_versions_file):
        lines = [line.rstrip('\n') for line in open(all_versions_file)]
        print "delete_old_folders: all_versions=", lines
        total_lines = len(lines)
        if total_lines > keep:
            remain_lines = []
            for i, line in enumerate(lines):
                version = line.strip()
                if version == "":
                    continue
                if i >= total_lines - keep:
                    remain_lines.append(version)
                else:
                    print "delete_old_folders: deleting " + version + "..."
                    key_name = remote_root + '/' + version
                    try:
                        keys = bucket.list(key_name)
                        for k in keys:
                            name = k.name
                            print "delete_old_folders: deleting name=" + name
                            bucket.delete_key(name)
                        # bucket.delete_key(key_name)
                        print "delete_old_folders: delete " + key_name + " success!"
                    except Exception as e:
                        print(e)
                        print "delete_old_folders: delete " + key_name + " failed!"
                        remain_lines.append(version)
            print "delete_old_folders: rewriting all_versions_file..."
            remain_lines.append('')
            with open(all_versions_file, "w") as f:
                f.writelines("\n".join(remain_lines))
        else:
            print "delete_old_folders: total versions ", total_lines
    else:
        print "delete_old_folders: all_versions_file not found"


def signal_handler(signal, frame):
    global terminated
    terminated = True
    sys.exit(0)

signal.signal(signal.SIGINT, signal_handler)

if cdn_url == "clean":
    remote_root = remote_dir
    delete_old_folders(publish_dir, remote_root, keep_folders)
else:
    os.path.walk(publish_dir, upload_dir, 0)
    refresh_cdn(cdn_url + "/" + remote_dir)
    remote_root = remote_dir.split('/')[0]
    delete_old_folders(publish_dir, remote_root, keep_folders)
