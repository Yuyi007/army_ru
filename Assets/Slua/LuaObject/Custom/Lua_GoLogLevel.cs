using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoLogLevel : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoLogLevel");
		addMember(l,0,"None");
		addMember(l,1,"Info");
		addMember(l,2,"Warn");
		addMember(l,3,"Error");
		LuaDLL.lua_pop(l, 1);
	}
}
