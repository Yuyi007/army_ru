using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_OSUtils : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.OSUtils o;
			o=new LBoot.OSUtils();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetBatteryLevel_s(IntPtr l) {
		try {
			var ret=LBoot.OSUtils.GetBatteryLevel();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.OSUtils");
		addMember(l,GetBatteryLevel_s);
		createTypeMetatable(l,constructor, typeof(LBoot.OSUtils));
	}
}
