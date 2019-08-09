using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_DayNightConfig : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefreshDayNight(IntPtr l) {
		try {
			LBoot.DayNightConfig self=(LBoot.DayNightConfig)checkSelf(l);
			self.DoRefreshDayNight();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_names(IntPtr l) {
		try {
			LBoot.DayNightConfig self=(LBoot.DayNightConfig)checkSelf(l);
			pushValue(l,self.names);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_names(IntPtr l) {
		try {
			LBoot.DayNightConfig self=(LBoot.DayNightConfig)checkSelf(l);
			System.String[] v;
			checkType(l,2,out v);
			self.names=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.DayNightConfig");
		addMember(l,DoRefreshDayNight);
		addMember(l,"names",get_names,set_names,true);
		createTypeMetatable(l,null, typeof(LBoot.DayNightConfig),typeof(UnityEngine.MonoBehaviour));
	}
}
