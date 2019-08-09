using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ImageExtended_OriginHorizontal : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.ImageExtended.OriginHorizontal");
		addMember(l,0,"Left");
		addMember(l,1,"Right");
		LuaDLL.lua_pop(l, 1);
	}
}
