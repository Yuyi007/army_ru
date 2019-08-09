import unittest
import pytest

from ks3.auth import add_auth_header
from ks3.connection import Connection
from ks3.bucket import Bucket
from ks3.key import Key
from ks3.acl import Policy, ACL, Grant
from ks3.user import User


ak = 'YOUR_ACCESS_KEY'
sk = 'YOUR_SECRET_KEY'
conn = Connection(ak, sk,host="")
test_bucket = 'sdktest123'
test_key = 'test_key'

#------------------------------------Auth relative test------------------------------
class TestAuthToken(unittest.TestCase):
    def test_auth_token(self):
        headers = {}
        method = "POST"
        bucket = test_bucket
        key = test_key
        query_args = {'upload': None}
        add_auth_header(ak, sk, headers, method, bucket, key, query_args)
        print headers['Authorization']

#------------------------------------bucket relative test------------------------------
class TestBucket(unittest.TestCase):

    # Get all buckets
    def test_get_all_buckets(self):
        buckets = conn.get_all_buckets()
        for b in  buckets:
            print b.name
            assert isinstance(b, Bucket)

    # Get keys within specified bucket
    def test_get_bucket(self):
        bucket = conn.get_bucket(test_bucket)
        keys = bucket.list()
        for k in keys:
            print k.name

    # Get bucket location
    def test_get_bucket_location(self):
        loc = conn.get_bucket_location(test_bucket)
        print loc

class TestDeleteBucket(unittest.TestCase):
    """
    test delete bucket
    """
    def test_delete_bucket(self):
        conn.delete_bucket(test_bucket)

class TestCreateBucket(unittest.TestCase):
    # Create one bucket
    def test_create_bucket(self):
        bucket = conn.create_bucket(test_bucket)
        print bucket.name
        #assert "sdktest" == bucket.name

class TestListMulUploads(unittest.TestCase):
    def test_list_multipart_uploads(self):
        bucket = conn.get_bucket(test_bucket)
        parts = bucket.list_multipart_uploads()
        for part in parts:
            print part.to_xml()
            print part

class TestGetBucketLoggingStatus(unittest.TestCase):
    def test_get_bucket_logging_status(self):
        bucket = conn.get_bucket(test_bucket)
        print bucket.get_logging_status()
 
class TestSetBucketLogging(unittest.TestCase):
    def test_set_bucket_logging(self):
        bucket = conn.get_bucket(test_bucket)
        # logging is kind of xml string.
        from ks3.bucketlogging import BucketLogging
        target = test_bucket
        prefix = "test_bucket_access_log"
        grants = Grant()
        logging = BucketLogging(target, prefix, grants).to_xml()
        bucket.set_xml_logging(logging)
        
class TestDisableBucketLogging(unittest.TestCase):
    def test_disable_bucket_logging(self):
        bucket = conn.get_bucket(test_bucket)
        bucket.disable_logging()

class TestEnableBucketLogging(unittest.TestCase):
    def test_enable_bucket_logging(self):
        bucket = conn.get_bucket(test_bucket)
        bucket.enable_logging()

class TestGetBucketAcl(unittest.TestCase):
    def test_get_bucket_acl(self):
        bucket = conn.get_bucket(test_bucket)
        print bucket.get_acl()

class TestSetBucketAcl(unittest.TestCase):
    def test_set_bucket_acl(self):
        bucket = conn.get_bucket(test_bucket)
        p = Policy()
        p.acl = ACL()
        p.owner = User(id='1234567890', display_name='test')
        bucket.set_acl(policy)

#------------------------------------object relative test------------------------------
class TestGetKeyAcl(unittest.TestCase):
    def test_get_acl(self):
        bucket = conn.get_bucket(test_bucket)
        policy = bucket.get_acl()
        #print policy.to_xml()
        for grant in policy.acl.grants:
            print grant.permission, grant.display_name, grant.email_address, grant.id

class TestSetKeyAcl(unittest.TestCase):
    """
    AccessControlPolicy:
    AccessControlList:
    DisplayName:
    Grant: Container for the grantee and his or her permissions.
    Grantee: The subject whose permissions are being set
    ID: ID of the bucket owner, or the ID of the grantee.
    Owner: Container for the bucket owner's display name and ID.
    Permission:[FULL_CONTROL | WRITE | WRITE_ACP | READ | READ_ACP]
    """
    def test_set_acl(self):
        owner = User(id='1234567890', display_name='test')
        acl = ACL()
        grant = Grant()
        grant.permission = "READ"
        grant.display_name = "test"
        grant.email_address = "test@ksc.com"
        acl.add_grant(grant)
        policy = Policy()
        policy.owner = owner
        policy.acl = acl
        bucket = conn.get_bucket(test_bucket)
        #ret = bucket.set_acl("public-read-write", test_key)
        ret = bucket.set_acl(policy, test_key)
        print ret

#------------------------------------upload object test------------------------------
class TestUploadObject(unittest.TestCase):
    # Create a object key in specified bucket
    def test_create_object(self):
        bucket = conn.get_bucket(test_bucket)
        key = bucket.new_key(test_key)
        print key.set_contents_from_filename("/root/KS3SDK_upload_test", policy="public-read-write")

class TestGetObject(unittest.TestCase):
    def test_get_object(self):
        bucket = conn.get_bucket(test_bucket)
        key = bucket.get_key(test_key)
        if key:
            key.get_contents_to_filename("/root/KS3SDK_download_test")
        else:
            print "Object key is NOT exist."

    def test_head_object(self):
        pass

class TestMultipartUploadObject(unittest.TestCase):
    def test_multipart_upload(self):
        import math, os
        import time
        from filechunkio import FileChunkIO
        bucket = conn.get_bucket(test_bucket)

        source_path = '/root/jdk.tar.gz'
        source_size = os.stat(source_path).st_size

        mp = bucket.initiate_multipart_upload(os.path.basename(source_path), policy="public-read-write")
        print mp.id

        #chunk_size = 52428800
        chunk_size = 52428800
        chunk_count = int(math.ceil(source_size / chunk_size))

        for i in range(chunk_count + 1):
            offset = chunk_size * i
            bytes = min(chunk_size, source_size - offset)
            with FileChunkIO(source_path, 'r', offset=offset,
                             bytes=bytes) as fp:
                mp.upload_part_from_file(fp, part_num=i + 1)

        mp.complete_upload()

class TestAbortMultipartUpload(unittest.TestCase):
    def test_abort_multipart_upload(self):
        bucket = conn.get_bucket(test_bucket)
        for p in bucket.get_all_multipart_uploads():
            # delete all parts
            print p.id
            print p.cancel_upload()

class TestListPart(unittest.TestCase):
    def test_list_part(self):
        bucket = conn.get_bucket(test_bucket)
        for p in bucket.get_all_multipart_uploads():
            print p.id

class TestDeleteObject(unittest.TestCase):
    def test_delete_object(self):
        bucket = conn.get_bucket(test_bucket)
        print bucket.delete_key(test_key)


class TestKeyLink(unittest.TestCase):
    def test_key_link(self):
        bucket = conn.get_bucket(test_bucket)
        key = bucket.get_key(test_key)
        #print key.generate_url(expires_in=1435320559, expires_in_absolute=True)
        print key.generate_url(expires_in=10000, expires_in_absolute=False)


if __name__ == '__main__':
    unittest.main()
