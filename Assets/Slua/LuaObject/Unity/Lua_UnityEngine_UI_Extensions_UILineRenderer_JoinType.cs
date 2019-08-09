using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UILineRenderer_JoinType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.UILineRenderer.JoinType");
		addMember(l,0,"Bevel");
		addMember(l,1,"Miter");
		LuaDLL.lua_pop(l, 1);
	}
}
