using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenState : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoTweenState");
		addMember(l,0,"Running");
		addMember(l,1,"Paused");
		addMember(l,2,"Complete");
		addMember(l,3,"Destroyed");
		LuaDLL.lua_pop(l, 1);
	}
}
