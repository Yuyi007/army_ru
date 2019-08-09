# KS3 SDK for python使用指南
---

## 开发前准备
### 安装依赖模块

	pip install six


### 安装python sdk
1、通过git下载SDK到本地

	git clone https://github.com/ks3sdk/ks3-python-sdk.git


2、进入ks3-python-sdk目录

	cd ks3-python-sdk

3、安装SDK

	python setup.py install

### 初始化connection

    from ks3.connection import Connection
    ak = 'YOUR_ACCESS_KEY'
    sk = 'YOUR_SECRET_KEY'
    c = Connection(ak, sk, host='YOUR_REGION_ENDPOINT', is_secure=False, domain_mode=False)

*常用参数说明*

+ ak：金山云提供的ACCESS KEY ID
+ sk：金山云提供的SECRET KEY ID
+ host：金山云提供的各个Region的域名（例 ks3-cn-beijing.ksyun.com）,具体定义可参考 [API接口文档-Region(区域)](https://docs.ksyun.com/read/latest/65/_book/index.html)
+ is_secure：是否通过HTTPS协议访问Ks3，True:启用  False:关闭
+ domain_mode：是否使用自定义域名访问Ks3（host填写自定义域名），True:是 False:否

### 运行环境
适用于2.6、2.7的Python版本

## SDK介绍及使用
### 资源管理操作
* [List Buckets](#list-buckets) 列出客户所有的Bucket信息
* [Create Bucket](#create-bucket) 创建一个新的Bucket
* [Delete Bucket](#delete-bucket) 删除指定Bucket
* [Get Bucket ACL](#get-bucket-acl) 获取Bucket的ACL
* [Put Bucket ACL](#put-bucket-acl) 设置Bucket的ACL
* [Head Object](#head-object) 获取Object元信息
* [Get Object](#get-object) 下载Object数据
* [Put Object](#put-object) 上传Object数据
* [Delete Object](#delete-object) 删除Object数据
* [List Objects](#list-objects) 列举Bucket内的Object
* [Get Object ACL](#get-object-acl) 获得Bucket的acl
* [Put Object ACL](#put-object-acl) 上传object的acl
* [Upload Part](#upload-part) 上传分块
* [Generate URL](#generate-url) 生成下载外链

### Service操作

#### List Buckets：

*列出客户所有的 Bucket 信息*

    buckets = c.get_all_buckets()
    for b in buckets:
        print b.name

### Bucket操作

#### Create Bucket： 

*创建一个新的Bucket*

在建立了连接后，可以创建一个bucket。bucket在s3中是一个用于储存key/value的容器。用户可以将所有的数据存储在一个bucket里，也可以为不同种类数据创建相应的bucket。

    bucket_name = "YOUR_BUCKET_NAME"
    b = c.create_bucket(bucket_name)

注：这里如果出现409 conflict错误，说明请求的bucket name有冲突，因为bucket name是全局唯一的

#### Delete Bucket:

*删除指定Bucket*

删除一个bucket可以通过delete_bucket方法实现。

    c.delete_bucket(bucket_name)

如果bucket下面存在key，那么需要首先删除所有key

    b = c.get_bucket(bucket_name)
    for k in b.list():
        k.delete()
    c.delete_bucket(bucket_name)

#### Get Bucket ACL:

*获取Bucket的ACL*

    acp = b.get_acl()
    >>> acp
    <Policy: MTM1OTk4ODE= (owner) = FULL_CONTROL>
    >>> acp.acl
    <ks3.acl.ACL object at 0x23cf750>
    >>> acp.acl.grants
    [<ks3.acl.Grant object at 0xf63810>]
    >>> for grant in acp.acl.grants:
    ...   print grant.permission, grant.display_name, grant.email_address, grant.id
    ...

#### Put Bucket ACL:

*设置Bucket的ACL*
  
    #设置bucket的权限, private or public-read or public-read-write
    b.set_acl("public-read")

### Object操作

#### Head Object:
*获取Object元信息*

获取Object元数据信息（大小、最后更新时间等）

	from ks3.connection import Connection
	
	bucket_name = "YOUR_BUCKET_NAME"
	key_name = "YOUR_KEY_NAME"
	b = c.get_bucket(bucket_name)
	try:
	    k = b.get_key(key_name)
	    if k:
	    	print k.name, k.size, k.last_modified
	    	#print k.__dict__
	except:
		pass # 异常处理

#### Get Object：
*下载该Object数据*
 
下载object，并且作为字符串返回

    from ks3.connection import Connection
     
    bucket_name = "YOUR_BUCKET_NAME"
    key_name = "YOUR_KEY_NAME"
    b = c.get_bucket(bucket_name)
    try:
	    k = b.get_key(key_name)
	    s = k.get_contents_as_string()
		print s
    except:
	    pass # 异常处理

下载object，并且保存到文件中

	#保存到文件
	k.get_contents_to_filename("/tmp/KS3SDK_download_test")
	#保存到文件句柄
	f=open("/tmp/test_file","rb")
	k.set_contents_from_file(f)

#### Put Object
*上传Object数据* 

将指定目录的文件上传，同时可以指定文件ACL

    bucket_name = "YOUR_BUCKET_NAME"
    key_name = "YOUR_KEY_NAME"
    try: 
	    b = c.get_bucket(bucket_name)
	    k = b.new_key(key_name)
	    #object policy : 'private' or 'public-read'
	    ret=k.set_contents_from_filename("/root/KS3SDK_upload_test", policy="private")
	    if ret and ret.status == 200:
	    	print "上传成功"
	 except:
	 	pass #异常处理   

将字符串所谓value上传

    k.set_contents_from_string('This is a test of S3')
    
#### Delete Object
*删除Object数据*

	try: 
		b=conn.get_bucket(YOUR_BUCKET_NAME)
		b.delete_key(YOUR_KEY_NAME)
	except:
 		pass #异常处理   
	
#### List Objects
*列举Bucket内的文件或者目录*

	from ks3.prefix import Prefix
	from ks3.key import Key
	
	b = c.get_bucket(bucket_name)
	keys = b.list(delimiter='/')
	for k in keys:
	    if isinstance(k,Key):
	        print 'file:%s' % k.name
	    elif isinstance(k,Prefix):
	        print 'dir:%s' % k.name

*列举Bucket内指定前缀的文件*

    keys = b.list(prefix="PREFIX")

#### Get Object ACL
*获得Object的acl*

    b = c.get_bucket(bucket_name)
    policy = b.get_acl(key_name)
    print policy.to_xml()

#### Put Object ACL

	#object policy : 'private' or 'public-read'
	b.set_acl("public-read", test_key)

#### Upload Part：
*分块上传*

如果你想上传一个大文件，你可以将它分成几个小份，逐个上传，s3会按照顺序把它们合成一个最终的object。整个过程需要几步来完成，下面的demo程序是通过python的FileChunkIO模块来实现的。所以可能需要首先运行pip install FileChunkIO来安装。

    >>> import math, os
    >>> from ks3.connection import Connection
    >>> from filechunkio import FileChunkIO
     
    # Connect to S3
    >>> bucket_name = "YOUR_BUCKET_NAME"
    >>> c = Connection(ak, sk)
    >>> b = c.get_bucket(bucket_name)
     
    # Get file info
    >>> source_path = 'path/to/your/file.ext'
    >>> source_size = os.stat(source_path).st_size
     
    # Create a multipart upload request
    >>> mp = b.initiate_multipart_upload(os.path.basename(source_path))
     
    # Use a chunk size of 50 MiB (feel free to change this)
    >>> chunk_size = 52428800
    >>> chunk_count = int(math.ceil(source_size / chunk_size))
     
    # Send the file parts, using FileChunkIO to create a file-like object
    # that points to a certain byte range within the original file. We
    # set bytes to never exceed the original file size.
    >>> for i in range(chunk_count + 1):
    >>>     offset = chunk_size * i
    >>>     bytes = min(chunk_size, source_size - offset)
    >>>     with FileChunkIO(source_path, 'r', offset=offset,
                             bytes=bytes) as fp:
    >>>         mp.upload_part_from_file(fp, part_num=i + 1)
     
    # Finish the upload
    >>> mp.complete_upload()
    
*获取已上传分块列表*

	bucket = conn.get_bucket(bucket_name)
	for p in bucket.list_multipart_uploads():
		print 'uploadId:%s,key:%s' % (p.id, p.key_name)
		for i in p:
			print i.part_number, i.size, i.etag, i.last_modified

#### Generate URL
*生成下载外链地址*

对私密属性的文件生成下载外链（该链接具有时效性）

    b = conn.get_bucket(bucket_name)
    k = b.get_key(obj_key)
    if k:
	    url = k.generate_url(60) # 60s 后该链接过期
	    print url

指定时间过期
	
	k.generate_url(1492073594,expires_in_absolute=True) # 1492073594为Unix Time