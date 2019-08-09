using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_GradientDir : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Extensions.GradientDir");
		addMember(l,0,"Vertical");
		addMember(l,1,"Horizontal");
		addMember(l,2,"DiagonalLeftToRight");
		addMember(l,3,"DiagonalRightToLeft");
		LuaDLL.lua_pop(l, 1);
	}
}
