using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_DateTimeKind : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"System.DateTimeKind");
		addMember(l,0,"Unspecified");
		addMember(l,1,"Utc");
		addMember(l,2,"Local");
		LuaDLL.lua_pop(l, 1);
	}
}
