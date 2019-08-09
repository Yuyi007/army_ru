using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_GlobalScheduler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.GlobalScheduler o;
			o=new LBoot.GlobalScheduler();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init_s(IntPtr l) {
		try {
			LBoot.SchedulerBehaviour a1;
			checkType(l,1,out a1);
			LBoot.GlobalScheduler.Init(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Schedule_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.Single a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action<System.Int32> a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				var ret=LBoot.GlobalScheduler.Schedule(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				System.Single a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action<System.Int32> a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				System.Boolean a5;
				checkType(l,5,out a5);
				var ret=LBoot.GlobalScheduler.Schedule(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Unschedule_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			LBoot.GlobalScheduler.Unschedule(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnscheduleAll_s(IntPtr l) {
		try {
			LBoot.GlobalScheduler.UnscheduleAll();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnscheduleAllAndGlobal_s(IntPtr l) {
		try {
			LBoot.GlobalScheduler.UnscheduleAllAndGlobal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.GlobalScheduler");
		addMember(l,Init_s);
		addMember(l,Schedule_s);
		addMember(l,Unschedule_s);
		addMember(l,UnscheduleAll_s);
		addMember(l,UnscheduleAllAndGlobal_s);
		createTypeMetatable(l,constructor, typeof(LBoot.GlobalScheduler));
	}
}
