﻿
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SLua
{
    public class LuaUnityEvent_UnityEngine_Vector2 : LuaObject
    {

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int AddListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<UnityEngine.Vector2> self = checkSelf<UnityEngine.Events.UnityEvent<UnityEngine.Vector2>>(l);
                UnityEngine.Events.UnityAction<UnityEngine.Vector2> a1;
                checkType(l, 2, out a1);
                self.AddListener(a1);
				// pushValue(l,true);
                // return 1;
				return 0;
            }
            catch (Exception e)
            {
				return error(l,e);
            }
        }
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int RemoveListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<UnityEngine.Vector2> self = checkSelf<UnityEngine.Events.UnityEvent<UnityEngine.Vector2>>(l);
                UnityEngine.Events.UnityAction<UnityEngine.Vector2> a1;
                checkType(l, 2, out a1);
                self.RemoveListener(a1);
				// pushValue(l,true);
                // return 1;
				return 0;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int Invoke(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<UnityEngine.Vector2> self = checkSelf<UnityEngine.Events.UnityEvent<UnityEngine.Vector2>>(l);
                UnityEngine.Vector2 o;
                checkType(l,2,out o);
                self.Invoke(o);
				// pushValue(l,true);
                // return 1;
				return 0;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        static public void reg(IntPtr l)
        {
            getTypeTable(l, typeof(LuaUnityEvent_UnityEngine_Vector2).FullName);
            addMember(l, AddListener);
            addMember(l, RemoveListener);
            addMember(l, Invoke);
            createTypeMetatable(l, null, typeof(LuaUnityEvent_UnityEngine_Vector2), typeof(UnityEngine.Events.UnityEventBase));
        }

        static bool checkType(IntPtr l,int p,out UnityEngine.Events.UnityAction<UnityEngine.Vector2> ua) {
            LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TFUNCTION);
            LuaDelegate ld;
            checkType(l, p, out ld);
            if (ld.d != null)
            {
                ua = (UnityEngine.Events.UnityAction<UnityEngine.Vector2>)ld.d;
                return true;
            }
			l = LuaState.get(l).L;
            ua = (UnityEngine.Vector2 v) =>
            {
                int error = pushTry(l);
                pushValue(l, v);
                ld.pcall(1, error);
                LuaDLL.lua_settop(l,error - 1);
            };
            ld.d = ua;
            return true;
        }
    }
}
