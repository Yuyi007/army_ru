-- debug.lua

local app = 'ddz'
local user = os.getenv("USER") or "none" -- now not available in IOS 8 simulator
local home = os.getenv("HOME") -- not available on Android
local scriptSearchFolders = { -- search lua script from these workspace folders
  'E:\\workspace\\race\\rs',
  'E:\\UnityProject\\rs',
  'F:\\rs',
  '/Users/cv/Documents/yiyou/race/src/rs',
  '/Users/jenkins/rs',
  '/Users/guoqiong/Documents/WorkSpace/Race/rs/',
  '/Users/dujie/Projects/race/rs',
  '/Users/jenkins/.jenkins/workspace/config/',
  'F:\\Race\\rs',
  'D:\\race\\rs',
  'F:\\ShareFolder\\rs',
  'F:\\src\\rs',
  'E:\\rs',
  '/Users/linjianfu/army/ars',
}
local unity = nil
local lfs = lfs
local log = function (msg) LBoot.LogUtil.Debug(msg) end
local loge = function (msg) LBoot.LogUtil.Error(msg) end
local runEvery = function (msecs, func) return scheduler.scheduleWithUpdate(func, msecs / 1000.0, false, true) end
local runAfter = function (msecs, func) return scheduler.performWithDelay(msecs / 1000.0, func) end
local beginSample = function (label) unity = unity or rawget(_G, 'unity'); if unity then unity.beginSample(label) end end
local endSample = function () if unity then unity.endSample() end end
local stopRun = function (handle) return scheduler.unschedule(handle) end
local scriptFolder = nil -- the lua script folder
local scansPerCall = 50 -- scan lua script files per coroutine resume
local changedFiles = {} -- a queue of changed lua source files
local scriptMonitoringHandle = nil
local classDefFuncNames = {'class', 'ViewBase', 'ViewScene'}
local originalClassDefs = {}
local classDefCallbacks = {}
local classDefLevel = 0
local classInfo = {} -- class info include objects, subclasses and code version

if PLATFORM ~= 'editor' then
  scansPerCall = 8
end

-- determine script folder
if PLATFORM == 'android' then
  scriptFolder = '/sdcard/' .. app .. '/scripts'
  RESOURCE_FOLDER = '/sdcard/' .. app .. '/resources'
else
  local base = nil
  if home then base = string.match(home, '^/[^/]+/[^/]+') end
  -- if not base then base = '/Users/' .. user end
  for i, v in ipairs(scriptSearchFolders) do
    scriptFolder = v .. '/client/scripts'
    if lfs.attributes(scriptFolder, 'mode') == 'directory' then break end
  end
end

-- print some stuff so people are aware that we're in debug mode
MODE = 'development'
SCRIPT = 'debug folder'

log('======== DEBUG MODE =======')
log('== USER: ' .. tostring(user))
log('== HOME: ' .. tostring(home))
log('== MODE: ' .. tostring(MODE))
log('== SCRIPT: ' .. tostring(SCRIPT))
log('== RESOURCE_FOLDER: ' .. tostring(RESOURCE_FOLDER))
log('== dev folder: ' .. tostring(scriptFolder))
log('===========================')

-- decorate class definitions so that we can apply new class code on existing objects
local decorateClassDef = function (classDefFuncName)
  log("debug.lua: decorateClassDef funcName=" .. classDefFuncName)

  local originalClassDef = originalClassDefs[classDefFuncName]
  rawset(_G, classDefFuncName, function (...)
    classDefLevel = classDefLevel + 1

    local classDefArgs = {...}
    local classname = classDefArgs[1]
    local oldCls = rawget(_G, classname)
    local newCls = originalClassDef(...)
    local originalClassNew = newCls.new

    -- we must reuse the old class table, because
    -- many places may have kept local references of the old table
    local cls = oldCls and oldCls or newCls
    rawset(_G, classname, cls)

    if oldCls then
      -- set all new class members to the old class table
      for k, v in pairs(newCls) do
        if k ~= '__index' then
          rawset(cls, k, v)
        end
      end
    end

    local info = classInfo[classname]
    if not info then
      -- init objTable and subclasses for the first time
      info = {
        objTable = setmetatable({}, {__mode = 'v'}),
        objId = 1,
        subclasses = {},
        codeVersion = 1,
      }
      -- logd("[ci] classname:%s", tostring(classname))
      classInfo[classname] = info
    end

    info.codeVersion = info.codeVersion + 1

    -- cls.new will record class objects
    cls.new = function (...)
      local obj = originalClassNew(...)
      obj.class = cls
      obj = setmetatable(obj, cls)
      info.objTable[info.objId] = obj
      info.objId = info.objId + 1
      return obj
    end

    -- setting class subclasses
    if cls.super then
      -- class may be defined in base lib
      local ci = classInfo[cls.super.classname]
      if ci then
        local superSubclasses = classInfo[cls.super.classname].subclasses
        for i = #superSubclasses, 1, -1 do
          local c = superSubclasses[i]
          if c.classname == classname then
            table.remove(superSubclasses, i)
          end
        end
        table.insert(superSubclasses, cls)
      end
    end

    classDefLevel = classDefLevel - 1

    if classDefLevel == 0 then
      -- find the source file who defined this class
      local classSource = nil
      for i = 2, 100, 1 do
        local info = debug.getinfo(i, 'S')
        if not info then break end
        if info.source == '=[C]' then
          classSource = debug.getinfo(i - 1, 'S').source
          break
        end
      end

      -- cls.redefine can redo definition of the class
      cls.redefine = function ()
        if classSource then
          table.insert(changedFiles, classSource)
        end
      end

      -- calling class define callbacks
      for _, callback in ipairs(classDefCallbacks) do
        local status, err = pcall(function () callback(cls, newCls) end)
        if not status then loge('debug.lua: Class define callback failed: ' .. err) end
      end

      -- wait for the class body to be executed
      runAfter(0, function ()
        -- the new class.new() will do things using the new class as metatable
        -- ensure they have latest code too (e.g. View.bind(), View.init())
        --
        -- NOTE
        -- this can cause memory leak, since newCls inherits all references
        -- hold in oldCls
        for k, v in pairs(cls) do
          rawset(newCls, k, v)
        end

        -- run class reload callback
        if type(cls.onClassReloaded) == 'function' then
          log('debug.lua: Calling back onClassReloaded() of class ' .. cls.classname)
          cls.onClassReloaded(cls)
        end
      end)
    end

    return cls
  end)
end

-- poll lua script changes periodically
function startScriptMonitoring()

  -- callback when Lua class changed
  local function onClassChanged(cls, newCls)
    local classname = cls.classname

    if classname:match('Decorator$') then
      unity.resetDecorate(classname)
    end

    local count = 0

    local info = classInfo[cls.classname]
    for _, obj in pairs(info.objTable) do
      obj = setmetatable(obj, cls)
      obj.class = cls
      count = count + 1
    end
    log('debug.lua: Patched ' .. count .. ' objects of class ' ..
      cls.classname .. '[' .. info.codeVersion .. ']')

    -- cls.subclasses may change during redefine()
    local subclasses = clone(info.subclasses)
    for _, subclass in ipairs(subclasses) do
      subclass.redefine()
    end
  end

  -- reload a Lua file
  local function reloadFile(file)
    local classDefs = {}
    for _, name in ipairs(classDefFuncNames) do
      table.insert(classDefs, {name, _G[name]})
    end

    local idx = file:find('scripts/')
    if idx ~= nil then
      local relative = file:sub(idx + 8)
      if relative:sub(-4, -1) == '.lua' then
        local rel = relative:sub(1, -5)
        local pkg = rel:gsub('/', '.')
        log('debug.lua: Reloading: ' .. relative .. ' [' .. pkg .. ']')
        table.insert(classDefCallbacks, onClassChanged)
        local status, err = pcall(function ()
          package.loaded[rel] = nil
          dofile(scriptFolder .. '/' .. relative)
        end)
        table.remove(classDefCallbacks)
        if not status then loge('debug.lua: Reloading failed: ' .. err) end
      end
    end

    -- if class definition funcs have been changed after dofile(),
    -- they need to be re-decorated.
    for _, val in ipairs(classDefs) do
      local name, def = unpack(val)
      if def ~= _G[name] then decorateClassDef(name) end
    end
  end

  -- callback when a Lua source file changed
  local function onFileChanged(file)
    table.insert(changedFiles, file)
  end

  local scanned = 0
  local function pollChangedFile(root, mtable)
    for n in lfs.dir(root) do
      if string.sub(n, 1, 1) ~= '.' then
        local name = root .. '/' .. n
        local mode = lfs.attributes(name, 'mode')
        if mode == 'directory' then
          local changed = pollChangedFile(name, mtable)
          if changed then
            onFileChanged(changed)
          end
        elseif mode == 'file' then
          local modtime = lfs.attributes(name, 'modification')
          local modtime0 = mtable[name]
          mtable[name] = modtime
          if modtime0 and modtime0 < modtime then
            onFileChanged(name)
          end
        end

        scanned = scanned + 1
        if scanned % scansPerCall == 0 then
          coroutine.yield()
        end
      end
    end
  end

  local mtable = {}
  local co = coroutine.create(function ()
    while true do
      pollChangedFile(scriptFolder, mtable)
      -- log('debug.lua: poll done ' .. tostring(os.date()))
    end
  end)

  if scriptMonitoringHandle then
    log('script monitoring already started!')
    return
  end

  scriptMonitoringHandle = runEvery(60, function ()
    -- beginSample('scriptMonitoring')

    if co and coroutine.status(co) ~= 'dead' then
      local success, msg = coroutine.resume(co)
      if not success and msg then
        loge('debug.lua: failed msg=' .. tostring(msg)..' '..tostring(success))
      end
    end

    local changed = table.remove(changedFiles)
    local count, max = 1, 99
    while changed do
      reloadFile(changed)
      changed = table.remove(changedFiles)
      count = count + 1
      if count > max then
        -- add a guard to avoid busy looping the Unity Editor
        error('debug.lua: too many changed files! ' .. #changedFiles .. ' left')
      end
    end

    -- endSample()
  end)

  log('script monitoring started.')
end

function stopScriptMonitoring()
  if scriptMonitoringHandle then
    stopRun(scriptMonitoringHandle)
    scriptMonitoringHandle = nil
    log('script monitoring stopped.')
  else
    log('script monitoring already stopped!')
  end
end

function scheduleReloadScript(file)
  table.insert(changedFiles, string.format('%s/%s.lua', scriptFolder, file))
end

function getClassInfo(classname)
  return classInfo[classname]
end

-- set package path
package.path = scriptFolder .. '/?.lua'

--require("mobdebug").start()
--require("mobdebug").on()
--require("mobdebug").coro()

-- require game scripts
require 'init'
require 'lboot/lboot'
require 'lboot/lboot_unity'
require 'lboot/globals'

-- start polling scripts
if type(scriptFolder) == 'string' and scriptFolder ~= 'none' then
  startScriptMonitoring()
end

-- rewrite class def functions
for _, classDefFuncName in ipairs(classDefFuncNames) do
  originalClassDefs[classDefFuncName] = rawget(_G, classDefFuncName)
  decorateClassDef(classDefFuncName)
end

-- clear requires and require lboot scripts again, so that
-- lboot classes can also be defined with decorated define functions.
clearRequires()
require 'lboot/lboot'
require 'lboot/lboot_unity'
require 'lboot/globals'

-- rewrite class def functions, again
for _, classDefFuncName in ipairs(classDefFuncNames) do
  decorateClassDef(classDefFuncName)
end

-- require 'lboot/test/FractorTest'
-- require 'lboot/test/FractorTableTest'

-- boom!
xpcall(__main, __G__TRACKBACK__)
