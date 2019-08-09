using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_TimeUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Now_s(IntPtr l) {
		try {
			var ret=LBoot.TimeUtil.Now();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.TimeUtil");
		addMember(l,Now_s);
		createTypeMetatable(l,null, typeof(LBoot.TimeUtil));
	}
}
