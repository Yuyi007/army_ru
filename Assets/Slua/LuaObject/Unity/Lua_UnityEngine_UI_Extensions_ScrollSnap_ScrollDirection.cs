using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollSnap_ScrollDirection : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.ScrollSnap.ScrollDirection");
		addMember(l,0,"Horizontal");
		addMember(l,1,"Vertical");
		LuaDLL.lua_pop(l, 1);
	}
}
