using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_FogCtrl : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogEnabled(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushValue(l,self.fogEnabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogEnabled(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.fogEnabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogMode(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushEnum(l,(int)self.fogMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogMode(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			UnityEngine.FogMode v;
			checkEnum(l,2,out v);
			self.fogMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogColor(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushValue(l,self.fogColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogColor(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.fogColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogDensity(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushValue(l,self.fogDensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogDensity(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fogDensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogStartDistance(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushValue(l,self.fogStartDistance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogStartDistance(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fogStartDistance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogEndDistance(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			pushValue(l,self.fogEndDistance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogEndDistance(IntPtr l) {
		try {
			FogCtrl self=(FogCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fogEndDistance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FogCtrl");
		addMember(l,DoRefresh);
		addMember(l,"fogEnabled",get_fogEnabled,set_fogEnabled,true);
		addMember(l,"fogMode",get_fogMode,set_fogMode,true);
		addMember(l,"fogColor",get_fogColor,set_fogColor,true);
		addMember(l,"fogDensity",get_fogDensity,set_fogDensity,true);
		addMember(l,"fogStartDistance",get_fogStartDistance,set_fogStartDistance,true);
		addMember(l,"fogEndDistance",get_fogEndDistance,set_fogEndDistance,true);
		createTypeMetatable(l,null, typeof(FogCtrl),typeof(UnityEngine.MonoBehaviour));
	}
}
