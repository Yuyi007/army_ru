using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIScrollToSelection_ScrollType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.UIScrollToSelection.ScrollType");
		addMember(l,0,"VERTICAL");
		addMember(l,1,"HORIZONTAL");
		addMember(l,2,"BOTH");
		LuaDLL.lua_pop(l, 1);
	}
}
