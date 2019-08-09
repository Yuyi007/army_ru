using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ExtensionsToggle_ToggleTransition : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.ExtensionsToggle.ToggleTransition");
		addMember(l,0,"None");
		addMember(l,1,"Fade");
		LuaDLL.lua_pop(l, 1);
	}
}
