using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LogUtil_LogLevel : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"LBoot.LogUtil.LogLevel");
		addMember(l,0,"Trace");
		addMember(l,1,"Debug");
		addMember(l,2,"Info");
		addMember(l,3,"Warn");
		addMember(l,4,"Error");
		LuaDLL.lua_pop(l, 1);
	}
}
