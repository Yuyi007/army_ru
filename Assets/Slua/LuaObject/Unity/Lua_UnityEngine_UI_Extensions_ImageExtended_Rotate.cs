using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ImageExtended_Rotate : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.ImageExtended.Rotate");
		addMember(l,0,"Rotate0");
		addMember(l,1,"Rotate90");
		addMember(l,2,"Rotate180");
		addMember(l,3,"Rotate270");
		LuaDLL.lua_pop(l, 1);
	}
}
