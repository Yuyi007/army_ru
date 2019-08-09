using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_IO_SearchOption : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"System.IO.SearchOption");
		addMember(l,0,"TopDirectoryOnly");
		addMember(l,1,"AllDirectories");
		LuaDLL.lua_pop(l, 1);
	}
}
