using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoUpdateType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoUpdateType");
		addMember(l,0,"Update");
		addMember(l,1,"LateUpdate");
		addMember(l,2,"FixedUpdate");
		addMember(l,3,"TimeScaleIndependentUpdate");
		LuaDLL.lua_pop(l, 1);
	}
}
