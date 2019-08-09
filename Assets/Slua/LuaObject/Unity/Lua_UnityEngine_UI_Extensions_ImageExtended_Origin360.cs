using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ImageExtended_Origin360 : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.ImageExtended.Origin360");
		addMember(l,0,"Bottom");
		addMember(l,1,"Right");
		addMember(l,2,"Top");
		addMember(l,3,"Left");
		LuaDLL.lua_pop(l, 1);
	}
}
