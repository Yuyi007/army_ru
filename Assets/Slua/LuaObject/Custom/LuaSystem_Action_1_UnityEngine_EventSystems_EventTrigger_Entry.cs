﻿
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal int checkDelegate(IntPtr l,int p,out System.Action<UnityEngine.EventSystems.EventTrigger.Entry> ua) {
            int op = extractFunction(l,p);
			if(LuaDLL.lua_isnil(l,p)) {
				ua=null;
				return op;
			}
            else if (LuaDLL.lua_isuserdata(l, p)==1)
            {
                ua = (System.Action<UnityEngine.EventSystems.EventTrigger.Entry>)checkObj(l, p);
                return op;
            }
            LuaDelegate ld;
            checkType(l, -1, out ld);
            if(ld.d!=null)
            {
                ua = (System.Action<UnityEngine.EventSystems.EventTrigger.Entry>)ld.d;
                return op;
            }
			LuaDLL.lua_pop(l,1);

			l = LuaState.get(l).L;
            ua = (UnityEngine.EventSystems.EventTrigger.Entry a1) =>
            {
                int error = pushTry(l);

				pushValue(l,a1);
				ld.pcall(1, error);
				LuaDLL.lua_settop(l, error-1);
			};
			ld.d=ua;
			return op;
		}
	}
}
