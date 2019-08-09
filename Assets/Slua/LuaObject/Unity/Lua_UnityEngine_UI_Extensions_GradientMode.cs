using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_GradientMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.GradientMode");
		addMember(l,0,"Global");
		addMember(l,1,"Local");
		LuaDLL.lua_pop(l, 1);
	}
}
