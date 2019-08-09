using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoDuplicatePropertyRuleType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoDuplicatePropertyRuleType");
		addMember(l,0,"None");
		addMember(l,1,"RemoveRunningProperty");
		addMember(l,2,"DontAddCurrentProperty");
		LuaDLL.lua_pop(l, 1);
	}
}
