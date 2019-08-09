using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_Grayscale_FillDirection : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"LBoot.Grayscale.FillDirection");
		addMember(l,0,"BottomTop");
		addMember(l,1,"TopBottom");
		addMember(l,2,"LeftRight");
		addMember(l,3,"RightLeft");
		LuaDLL.lua_pop(l, 1);
	}
}
