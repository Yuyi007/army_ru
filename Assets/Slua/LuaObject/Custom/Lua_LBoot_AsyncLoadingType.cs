using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_AsyncLoadingType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"LBoot.AsyncLoadingType");
		addMember(l,0,"None");
		addMember(l,1,"AllAssetsInBundle");
		addMember(l,2,"AssetBundle");
		addMember(l,3,"Scene");
		addMember(l,4,"UnloadingUnused");
		LuaDLL.lua_pop(l, 1);
	}
}
