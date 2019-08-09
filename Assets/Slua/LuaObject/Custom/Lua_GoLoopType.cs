using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoLoopType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoLoopType");
		addMember(l,0,"RestartFromBeginning");
		addMember(l,1,"PingPong");
		LuaDLL.lua_pop(l, 1);
	}
}
