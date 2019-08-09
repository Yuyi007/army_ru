using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ImageExtended_FillMethod : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.ImageExtended.FillMethod");
		addMember(l,0,"Horizontal");
		addMember(l,1,"Vertical");
		addMember(l,2,"Radial90");
		addMember(l,3,"Radial180");
		addMember(l,4,"Radial360");
		LuaDLL.lua_pop(l, 1);
	}
}
