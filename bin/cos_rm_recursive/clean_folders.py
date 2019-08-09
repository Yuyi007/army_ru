# 2016-8-22 lt: help to clean up cos folders
import qcloud_cos as qcloud
import sys
import string
import urllib
import json

with open('./app_conf.json', 'rb') as f:
  config = json.load(f)

appid = config['appid'].encode('utf8')
secret_id = config['secret_id'].encode('utf8')
secret_key = config['secret_key'].encode('utf8')

def list_r(bucket, path, files):

  while True:
    listret = cos.list(bucket, path, 50)
    if listret['code'] != 0:
      print listret['message']
      return -1

    if len(listret['data']['infos']) == 0:
      return 0

    for info in listret['data']['infos']:
      fullpath = path+'/'+info['name'].encode('utf8')
      if info.has_key('name'):
        files.append(info)

    # if listret['has_more']:
    #   ret = list_r(bucket, fullpath, files)
    #   if ret != 0:
    #     return ret
    break

def cmp_ctime(x, y):
  return int(x['ctime']) > int(y['ctime'])

def delete_r(bucket, path):

  while True:
    listret = cos.list(bucket, path, 50)
    if listret['code'] != 0:
      print listret['message']
      return -1

    if len(listret['data']['infos']) == 0:
      if not path:
        return 0
      deldirret = cos.deleteFolder(bucket, path)
      if deldirret['code'] != 0 and deldirret['code'] != -166:
        print deldirret['message']
        return deldirret['code']
      return 0

    for info in listret['data']['infos']:
      fullpath = path+'/'+info['name'].encode('utf8')
      if info.has_key('sha'):
        delfileret = cos.deleteFile(bucket, fullpath)
        if delfileret['code'] != 0 and delfileret['code'] != -166:
          print delfileret['message']
          return delfileret['code']
      else:
        delrret = delete_r(bucket, fullpath)
        if delrret != 0:
          return delrret

cos = qcloud.Cos(appid,secret_id,secret_key)

if len(sys.argv) < 3:
  print "Usage: python "+sys.argv[0]+" bucket keep_latest"
  sys.exit(-10)

bucket = sys.argv[1]
keep_latest = int(sys.argv[2])
bucket = string.strip(bucket, '/')

files = []
list_r(bucket, '/', files)
sfiles = sorted(files, cmp=cmp_ctime)
# print sfiles

for info in sfiles[:-keep_latest]:
  path = info['name'].encode('utf8')
  print 'deleting '+path+'...'
  result = delete_r(bucket, path)
  if result == 0:
    print 'rm '+bucket+'/'+path+' success'
  else:
    print 'rm '+bucket+'/'+path+' fail, try again'
    sys.exit(-15)

sys.exit()
