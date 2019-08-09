using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoSmoothingType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoSmoothingType");
		addMember(l,0,"Lerp");
		addMember(l,1,"Slerp");
		LuaDLL.lua_pop(l, 1);
	}
}
