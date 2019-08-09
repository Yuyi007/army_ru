# -*- encoding:utf-8 -*-
from kscore.offline import getOfflineClient
import json

#没有配置kscore.cfg调用方式
#ks_access_key_id='xxxxxxxxxxxxxxxxxxxx'
#ks_secret_access_key='xxxxxxxxxxxxxxxxxxxxxxx'
# 参数：服务service_name,大区region_name 
#client = getOfflineClient("offline", "cn-beijing-6",use_ssl=False,ks_access_key_id=ks_access_key_id,ks_secret_access_key=ks_secret_access_key)

#配置kscore.cfg调用方式

client = getOfflineClient("offline", "cn-beijing-6",use_ssl=False)

#创建模板接口调用示例 : preset  
presetname = 'testpreset'
description = 'just a demo'
presetType = 'avop'

#具体的格式请参考官网说明
param = {
    "preset": presetname,
    "description": description,
    "presettype": presetType,
    "param": {
        "f": "mp4",
        "AUDIO": {
            "acodec": "aac",
            "ar":"44100",
            "ab":"64k"
        },
        "VIDEO": {
            "vr": 25,
            "vb": "500k",
            "vcodec": "h264",
            "width": 640,
            "height": 360
        }
    }
}

#该接口需要输入json格式数据
res = client.Preset(param)
print json.dumps(res)

#更新模板接口调用示例 : UpdatePreset
#该接口需要输入json格式数据
res = client.UpdatePreset(param)
print json.dumps(res)

#获取模板列表接口调用示例 : GetPresetList
#参数
# withDetail:是否查询模板详情，1-是 0-否
# presettype:模板类型，多种模板类型以逗号隔开
# presets:模板名称，多个模板名称以逗号隔开
res = client.GetPresetList(withDetail=0,presettype="avop")
print json.dumps(res)

#获取模板信息接口调用示例 : GetPresetDetail
res = client.GetPresetDetail(presetname)
print json.dumps(res)

#删除模板接口调用示例 : DelPreset
res = client.DelPreset(presetname)
print json.dumps(res)


#创建任务接口调用示例 : CreateTask
#具体参数请参考官方文档
task = {
    "dstDir": "",
    "dstObjectKey": "4.mp4",
    "dstBucket": "autotestoffline",
    "dstAcl": "public-read",
    "preset": presetname,
    "srcInfo": [
        {
            "path": "/autotestoffline/11.mp4",
            "type": "video",
            "index": 0
        }
    ],
    "cbMethod": "POST",
    "cbUrl": "http://10.4.2.38:19090/"
}

#该接口需要输入json格式数据
res = client.CreateTask(task)
print json.dumps(res)

#查看任务状态接口调用示例 : GetTaskByTaskID
taskid = "40d309d3b2bf373cd3f08e5b5e1bddf720160816"
res = client.GetTaskByTaskID(taskid)
print json.dumps(res)

#获取任务列表接口调用示例 : GetTaskList
#参数
# startdate:开始时间，默认为当前月的第一天；格式：20160919
# enddate:截止时间，默认为开始时间加30天；若大于当前时间，则默认为当前时间；格式：20160930
# marker:请求起始游标，默认为0    
# limit:单次请求的记录数，默认为100，最大值为100
res = client.GetTaskList(startdate=20161101,enddate=20161118,marker=0,limit=50)
print json.dumps(res)

#删除任务接口调用示例 : DelTaskByTaskID
res = client.DelTaskByTaskID(taskid)
print json.dumps(res)

#任务置顶接口调用示例 : TopTaskByTaskID
res = client.TopTaskByTaskID(taskid)
print json.dumps(res)

#查询任务META列表接口调用示例 : GetTaskMetaInfo
#参数
# taskid:任务ID
# startdate:开始时间，默认为当前月的第一天；格式：20160919
# enddate:截止时间，默认为开始时间加30天；若大于当前时间，则默认为当前时间；格式：20160930
# marker:请求起始游标，默认为0    
# limit:单次请求的记录数，默认为100，最大值为100

#res = client.GetTaskMetaInfo(startdate=20161101,enddate=20161118,marker=0,limit=50)
#print json.dumps(res)