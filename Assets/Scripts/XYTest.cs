using UnityEngine;
using System.Collections;
using SLua;
using LuaInterface;
using LBoot;

public class XYTest : MonoBehaviour
{
    
    private LuaState lua;
    
    // Use this for initialization
    void Start()
    {
        LogUtil.Debug("[XYTest] start");
        var luaRef = new LuaBridge();
        lua = LuaState.main;
        
        LogUtil.Debug("[XYTest] init lua dll");
        
        LuaCodeInit();
    }
    
    // Update is called once per frame
    void Update()
    {
//        LogUtil.Debug("[XYTest] update");
        Test1();
    }

    void Test1()
    {
        lua.doString(@"
local input, output

for i = 1, 1, 1 do
    input = '{ ""id"": ""' .. 1 .. '"", ""firstName"": ""Andrea"", ""lastName"": ""Pirlo"" }'
    output = cjson.decode(input)

    input = '{ ""id"": ""' .. 2 .. '"", ""firstName"": ""Bayern"", ""lastName"": ""Munich"" }'
    output = cjson.decode(input)

    input = '{ ""id"": ""' .. 3 .. '"", ""firstName"": ""Real"", ""lastName"": ""Madrid"" }'
    output = cjson.decode(input)
    
    input = '{ ""id"": ""' .. 4 .. '"", ""firstName"": ""Series A"", ""lastName"": ""Juventus"" }'
    output = cjson.decode(input)

    input = '{ ""id"": ""' .. 5 .. '"", ""firstName"": ""FC"", ""lastName"": ""Barcelona"" }'
    output = cjson.decode(input)

    for j = 1, 5, 1 do 
        local go = unity.GameObject.Find ('Canvas/Text 1')
        local text = go:GetComponent('Text')
        text.text = (output.lastName .. j)
    end
end

  ");
        LogUtil.Debug("decode finished");
    }

    
    void LuaCodeInit()
    {
        ////////////////////////////////////////////////////
        // init common
        lua.doString(
            @"

File = System.IO.File
Directory = System.IO.Directory
import 'UnityEngine'
rawset(_G, 'unity', UnityEngine)

rawset(_G, 'u3log', function(text, ...)
  local str = string.format(text, ...)
  unity.LogUtil.Debug('[LUA] ' ..tostring(str))
end)

rawset(_G, 'ccwarn', u3log)
");
        
        ////////////////////////////////////////////////////
        // init luaj
        lua.doString(
            @"

luaj = {}

local function checkArguments(args, sig)
    if type(args) ~= 'table' then args = {} end
    if sig then return args, sig end

    sig = {'('}
    for i, v in ipairs(args) do
        local t = type(v)
        if t == 'number' then
            sig[#sig + 1] = 'F'
        elseif t == 'boolean' then
            sig[#sig + 1] = 'Z'
        elseif t == 'function' then
            sig[#sig + 1] = 'I'
        else
            sig[#sig + 1] = 'Ljava/lang/String;'
        end
    end
    sig[#sig + 1] = ')V'

    return args, table.concat(sig)
end

function luaj.callStaticMethod(className, methodName, args, sig)
    local args, sig = checkArguments(args, sig)
    ccwarn('luaj.callStaticMethod(\'%s\',\n\t\'%s\',\n\targs,\n\t\'%s', className, methodName, sig)
    return CCLuaJavaBridge.callStaticMethod(className, methodName, args, sig)
end

u3log('init luaj done')
            ");
        
        ////////////////////////////////////////////////////
        // init luaoc
        lua.doString(
            @"

luaoc = {}

function luaoc.callStaticMethod(className, methodName, args)
    local ok, ret = CCLuaObjcBridge.callStaticMethod(className, methodName, args)
    if not ok then
        local msg = string.format('luaoc.callStaticMethod(\'%s\', \'%s\', \'%s\') - error: [%s] ',
                className, methodName, tostring(args), tostring(ret))
        if ret == -1 then
            ccerror(msg .. 'INVALID PARAMETERS')
        elseif ret == -2 then
            ccerror(msg .. 'CLASS NOT FOUND')
        elseif ret == -3 then
            ccerror(msg .. 'METHOD NOT FOUND')
        elseif ret == -4 then
            ccerror(msg .. 'EXCEPTION OCCURRED')
        elseif ret == -5 then
            ccerror(msg .. 'INVALID METHOD SIGNATURE')
        else
            ccerror(msg .. 'UNKNOWN')
        end
    end
    return ok, ret
end

u3log('init luaoc done')
");

    }
}
