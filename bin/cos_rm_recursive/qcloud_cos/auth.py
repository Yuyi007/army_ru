# -*- coding: utf-8 -*-

import time
import random
import hmac, hashlib
import binascii
import base64
from urlparse import urlparse
from qcloud_cos import conf

class Auth(object):

    def __init__(self, secret_id, secret_key):
        self.AUTH_URL_FORMAT_ERROR = -1
        self.AUTH_SECRET_ID_KEY_ERROR = -2

        self._secret_id,self._secret_key = secret_id,secret_key

    def app_sign(self, bucket, fileid, expired):
        app_info = conf.get_app_info()
        if not self._secret_id or not self._secret_key or not app_info['appid']:
            return self.AUTH_SECRET_ID_KEY_ERROR

        now = int(time.time())
        rdm = random.randint(0, 999999999)
        plain_text = 'a=' + app_info['appid'] + '&k=' + self._secret_id + '&e=' + str(expired) + '&t=' + str(now) + '&r=' + str(rdm) + '&f=' + fileid + '&b=' + bucket 
        bin = hmac.new(self._secret_key, plain_text, hashlib.sha1)
        s = bin.hexdigest()
        s = binascii.unhexlify(s)
        s = s + plain_text
        signature = base64.b64encode(s).rstrip()    #生成签名
        return signature

    def sign_once(self, bucket, fileid):
	return self.app_sign(bucket, fileid, 0)

    def sign_more(self, bucket, expired):
	return self.app_sign(bucket, '', expired)
