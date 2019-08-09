using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoLookAtType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoLookAtType");
		addMember(l,0,"None");
		addMember(l,1,"NextPathNode");
		addMember(l,2,"TargetTransform");
		LuaDLL.lua_pop(l, 1);
	}
}
