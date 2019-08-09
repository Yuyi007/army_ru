using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_WheelSkid : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetSkidParams(IntPtr l) {
		try {
			WheelSkid self=(WheelSkid)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			System.Single a5;
			checkType(l,6,out a5);
			System.Single a6;
			checkType(l,7,out a6);
			System.Single a7;
			checkType(l,8,out a7);
			self.SetSkidParams(a1,a2,a3,a4,a5,a6,a7);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Awake(IntPtr l) {
		try {
			WheelSkid self=(WheelSkid)checkSelf(l);
			self.Awake();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LateUpdate(IntPtr l) {
		try {
			WheelSkid self=(WheelSkid)checkSelf(l);
			self.LateUpdate();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShowSkid_s(IntPtr l) {
		try {
			WheelSkid.ShowSkid();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideSkid_s(IntPtr l) {
		try {
			WheelSkid.HideSkid();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"WheelSkid");
		addMember(l,SetSkidParams);
		addMember(l,Awake);
		addMember(l,LateUpdate);
		addMember(l,ShowSkid_s);
		addMember(l,HideSkid_s);
		createTypeMetatable(l,null, typeof(WheelSkid),typeof(UnityEngine.MonoBehaviour));
	}
}
