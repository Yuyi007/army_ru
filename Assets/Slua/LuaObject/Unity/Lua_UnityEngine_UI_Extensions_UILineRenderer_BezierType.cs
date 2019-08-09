using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UILineRenderer_BezierType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.UILineRenderer.BezierType");
		addMember(l,0,"None");
		addMember(l,1,"Quick");
		addMember(l,2,"Basic");
		addMember(l,3,"Improved");
		LuaDLL.lua_pop(l, 1);
	}
}
