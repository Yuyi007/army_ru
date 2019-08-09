using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Accordion_Transition : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.Accordion.Transition");
		addMember(l,0,"Instant");
		addMember(l,1,"Tween");
		LuaDLL.lua_pop(l, 1);
	}
}
