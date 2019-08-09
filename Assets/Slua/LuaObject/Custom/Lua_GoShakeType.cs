using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoShakeType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoShakeType");
		addMember(l,1,"Position");
		addMember(l,2,"Scale");
		addMember(l,4,"Eulers");
		LuaDLL.lua_pop(l, 1);
	}
}
