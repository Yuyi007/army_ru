using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoSplineType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoSplineType");
		addMember(l,0,"StraightLine");
		addMember(l,1,"QuadraticBezier");
		addMember(l,2,"CubicBezier");
		addMember(l,3,"CatmullRom");
		LuaDLL.lua_pop(l, 1);
	}
}
