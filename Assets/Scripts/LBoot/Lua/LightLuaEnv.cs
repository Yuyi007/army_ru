//
// LightLuaEnv.cs
//
// This class provides a light weight lua environment for executing lua codes
// "embedded" in C# -- as a contrary to LuaBridge which is the main lua environment
// where most lua codes runs
//
// An example of this is ClientSocketController using a LightLuaEnv to encode/decode
// network packets
//
// Author:
//       duwenjie
//

//
using System;
using SLua;
using LuaInterface;
using UnityEngine;

namespace LBoot
{

    public class LightLuaEnv
    {
        protected LuaState luaState;
        protected LuaStateExt luaStateExt;

        public LightLuaEnv(string luaFilename, bool updatedScript)
        {
            InitLua(luaFilename, updatedScript);
        }

        public LuaState State()
        {
            return luaState;
        }

        private void InitLua(string luaFilename, bool updatedScript)
        {
            luaState = new LuaState();
            luaStateExt = new LuaStateExt(luaState);

            LuaDLL.open_luaext(luaState.L);
            LuaDLL.lua_settop(luaState.L, 0);

            byte [] scriptSource = null;
            if (updatedScript) 
            {
                scriptSource = FileUtils.GetDataFromFile(luaFilename);
            }
            else
            {
                scriptSource = FileUtils.GetDataFromStreamingAssets(luaFilename);
            }

            object ret;
            var ok = luaStateExt.doArc4Buffer(scriptSource, luaFilename, LBootApp.LUA_KEY, out ret);
            if (!ok)
            {
                LogUtil.Error("doArc4Buffer failed! " + luaFilename);
            }
        }

        public object Call(string func, params object[] args)
        {
            return luaState.Call(func, args);
        }

    }
}

