using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_AppLifecycle : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.AppLifecycle o;
			o=new LBoot.AppLifecycle();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BootstrapApp_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			LBoot.AppLifecycle.BootstrapApp(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RestartApp_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			LBoot.AppLifecycle.RestartApp(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PauseApp_s(IntPtr l) {
		try {
			LBoot.AppLifecycle.PauseApp();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResumeApp_s(IntPtr l) {
		try {
			LBoot.AppLifecycle.ResumeApp();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShutdownApp_s(IntPtr l) {
		try {
			LBoot.AppLifecycle.ShutdownApp();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReceivedMemoryWarning_s(IntPtr l) {
		try {
			LBoot.AppLifecycle.ReceivedMemoryWarning();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.AppLifecycle");
		addMember(l,BootstrapApp_s);
		addMember(l,RestartApp_s);
		addMember(l,PauseApp_s);
		addMember(l,ResumeApp_s);
		addMember(l,ShutdownApp_s);
		addMember(l,ReceivedMemoryWarning_s);
		createTypeMetatable(l,constructor, typeof(LBoot.AppLifecycle));
	}
}
