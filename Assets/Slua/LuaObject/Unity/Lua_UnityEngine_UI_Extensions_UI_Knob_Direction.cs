using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UI_Knob_Direction : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.UI_Knob.Direction");
		addMember(l,0,"CW");
		addMember(l,1,"CCW");
		LuaDLL.lua_pop(l, 1);
	}
}
