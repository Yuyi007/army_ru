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
	print "Usage: python "+sys.argv[0]+" bucket path"
	sys.exit(-10)

bucket = sys.argv[1]
path = sys.argv[2]
bucket = string.strip(bucket, '/')
path = urllib.quote(string.strip(path, '/'), '~/')

statret = cos.statFolder(bucket, path)
if statret['code'] == -166:
	statret = cos.statFile(bucket, path)
	if statret['code'] == -166:
		print bucket+'/'+path+' isnot existent'
		sys.exit(-11)
	elif statret['code'] != 0:
		print statret['message']
		sys.exit(-12)
elif statret['code'] != 0:
	print statret['message']
	sys.exit(-13)

if statret['data'].has_key('sha'):
	delfileret = cos.deleteFile(bucket, path)
	if delfileret['code'] == 0:
		print 'rm '+bucket+'/'+path+' success'
	else:
		print delfileret['message']
	sys.exit(-14)

result = delete_r(bucket, path)
if result == 0:
	print 'rm '+bucket+'/'+path+' success'
	sys.exit()
else:
	print 'rm '+bucket+'/'+path+' fail, try again'
	sys.exit(-15)

