// #define PROFILE_FILE

using System;
using LuaInterface;
using UnityEngine;

namespace SLua
{
    public static class SLuaExtensions
    {
        // NOTE
        // Beaware of these Call() functions
        // They use [] to access values, causes GC alloc when splitting fields
        // Use OneLevelCall() whenever possible
        
        // fast lookup one level field, do not try to support path like 'a.b.c.d'
        public static object getOneLevelField(this LuaState luaState, string field)
        {
            IntPtr L = luaState.L;
            
            LuaDLL.lua_pushglobaltable(L);

            object returnValue = null;
            LuaDLL.lua_pushstring(L, field);
            LuaDLL.lua_gettable(L, -2);
            int p = LuaDLL.lua_absindex(L, -1);
            returnValue = LuaObject.checkVar(L, p);
            LuaDLL.lua_remove(L, -2);
            
            LuaDLL.lua_pop(L, 1);
            
            return returnValue;
        }
        
        // fast lookup one level field, do not try to support path like 'a.b.c.d'
        public static object getOneLevelField(this LuaState luaState, int reference, string field)
        {
            IntPtr L = luaState.L;
            
            // int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_getref(L, reference);
            
            object returnValue = null;
            LuaDLL.lua_pushstring(L, field);
            LuaDLL.lua_gettable(L, -2);
            int p = LuaDLL.lua_absindex(L, -1);
            returnValue = LuaObject.checkVar(L, p);
            LuaDLL.lua_remove(L, -2);
            
            LuaDLL.lua_pop(L, 1);

            // LuaDLL.lua_settop(L, oldTop);
            return returnValue;
        }

        // fast lookup one level field, do not try to support path like 'a.b.c.d'
        public static object getOneLevelField(this LuaTable lua, string field)
        {
            return lua.State.getOneLevelField(lua.Ref, field);    
        }
        
        // fast set one level field
        public static void setOneLevelField(this LuaState luaState, int reference, string field, object o)
        {
            IntPtr L = luaState.L;
            
            // int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_getref(L, reference);

            LuaDLL.lua_pushstring(L, field);
            LuaObject.pushVar(L, o);
            LuaDLL.lua_settable(L, -3);
            
            LuaDLL.lua_pop(L, 1);

            // LuaDLL.lua_settop(L, oldTop);
        }  

        // fast set one level field
        public static void setOneLevelField(this LuaTable lua, string field, object o)
        {
            lua.State.setOneLevelField(lua.Ref, field, o);
        }

        // Call lua stable function with one level field
        public static object OneLevelCall(this LuaTable lua, string func)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall");
            Profiler.BeginSample("SLuaExt.OneLevelCall." + func);
#endif
            LuaFunction f = (LuaFunction)lua.getOneLevelField(func);
            object res = null;
            if (f != null)
            {
                res = f.call();
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        public static object OneLevelCall(this LuaTable lua, string func, object a1)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall");
            Profiler.BeginSample("SLuaExt.OneLevelCall." + func);
#endif
            LuaFunction f = (LuaFunction)lua.getOneLevelField(func);
            object res = null;
            if (f != null)
            {
                res = f.call(a1);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        public static object OneLevelCall(this LuaTable lua, string func, params object[] args)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall");
            Profiler.BeginSample("SLuaExt.OneLevelCall." + func);
#endif
            LuaFunction f = (LuaFunction)lua.getOneLevelField(func);
            object res = null;
            if (f != null)
            {
                res = f.call(args);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua table function with paths
        public static object Call(this LuaTable lua, string func)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.Call");
            Profiler.BeginSample("SLuaExt.Call." + func);
#endif
            LuaFunction f = (LuaFunction)lua[func];
            object res = null;
            if (f != null)
            {
                res = f.call();
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        public static object Call(this LuaTable lua, string func, object a1)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.Call");
            Profiler.BeginSample("SLuaExt.Call." + func);
#endif
            LuaFunction f = (LuaFunction)lua[func];
            object res = null;
            if (f != null)
            {
                res = f.call(a1);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        public static object Call(this LuaTable lua, string func, params object[] args)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.Call");
            Profiler.BeginSample("SLuaExt.Call." + func);
#endif
            LuaFunction f = (LuaFunction)lua[func];
            object res = null;
            if (f != null)
            {
                res = f.call(args);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        // Call lua state function with one level field
        public static object OneLevelCall(this LuaState luaState, string key)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall_state");
            Profiler.BeginSample("SLuaExt.OneLevelCall_state." + key);
#endif
            LuaFunction func = (LuaFunction)luaState.getOneLevelField(key);
            object res = null;
            if (func != null)
            {
                res = func.call();
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua state function with one level field
        public static object OneLevelCall(this LuaState luaState, string key, object a1)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall_state");
            Profiler.BeginSample("SLuaExt.OneLevelCall_state." + key);
#endif
            LuaFunction func = (LuaFunction)luaState.getOneLevelField(key);
            object res = null;
            if (func != null)
            {
                res = func.call(a1);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua state function with one level field
        public static object OneLevelCall(this LuaState luaState, string key, object a1, object a2)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall_state");
            Profiler.BeginSample("SLuaExt.OneLevelCall_state." + key);
#endif
            LuaFunction func = (LuaFunction)luaState.getOneLevelField(key);
            object res = null;
            if (func != null)
            {
                res = func.call(a1, a2);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua state function with one level field
        public static object OneLevelCall(this LuaState luaState, string key, object a1, object a2, object a3)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall_state");
            Profiler.BeginSample("SLuaExt.OneLevelCall_state." + key);
#endif
            LuaFunction func = (LuaFunction)luaState.getOneLevelField(key);
            object res = null;
            if (func != null)
            {
                res = func.call(a1, a2, a3);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua state function with one level field
        public static object OneLevelCall(this LuaState luaState, string key, params object[] args)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.OneLevelCall_state");
            Profiler.BeginSample("SLuaExt.OneLevelCall_state." + key);
#endif
            LuaFunction func = (LuaFunction)luaState.getOneLevelField(key);
            object res = null;
            if (func != null)
            {
                res = func.call(args);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }
        
        // Call lua state function with paths
        public static object Call(this LuaState luaState, string key, params object[] args)
        {
#if PROFILE_FILE
            Profiler.BeginSample("SLuaExt.Call_state");
            Profiler.BeginSample("SLuaExt.Call_state." + key);
#endif
            var func = luaState.getFunction(key);
            object res = null;
            if (func != null)
            {
                res = func.call(args);
            }
#if PROFILE_FILE
            Profiler.EndSample();
            Profiler.EndSample();
#endif
            return res;
        }

        public static object do_file(this LuaState luaState, string path)
        {
            return LuaDLL.luaL_dofile(luaState.L, path);
        }
    }

}