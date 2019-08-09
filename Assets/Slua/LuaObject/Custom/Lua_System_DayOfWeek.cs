using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_DayOfWeek : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"System.DayOfWeek");
		addMember(l,0,"Sunday");
		addMember(l,1,"Monday");
		addMember(l,2,"Tuesday");
		addMember(l,3,"Wednesday");
		addMember(l,4,"Thursday");
		addMember(l,5,"Friday");
		addMember(l,6,"Saturday");
		LuaDLL.lua_pop(l, 1);
	}
}
