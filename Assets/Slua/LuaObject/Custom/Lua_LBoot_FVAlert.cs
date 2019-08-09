using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_FVAlert : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init_s(IntPtr l) {
		try {
			LBoot.FVAlert.Init();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScheduleAlert_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Int64 a3;
			checkType(l,3,out a3);
			LBoot.FVAlert.ScheduleAlert(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearAlerts_s(IntPtr l) {
		try {
			LBoot.FVAlert.ClearAlerts();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SendRepeatingNotification_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Int64 a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			LBoot.FVAlert.SendRepeatingNotification(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CancelNotification_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			LBoot.FVAlert.CancelNotification(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.FVAlert");
		addMember(l,Init_s);
		addMember(l,ScheduleAlert_s);
		addMember(l,ClearAlerts_s);
		addMember(l,SendRepeatingNotification_s);
		addMember(l,CancelNotification_s);
		createTypeMetatable(l,null, typeof(LBoot.FVAlert));
	}
}
