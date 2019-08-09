using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_NavigationMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.NavigationMode");
		addMember(l,0,"Auto");
		addMember(l,1,"Manual");
		LuaDLL.lua_pop(l, 1);
	}
}
