using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_AssetBundleLoadHistory : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory o;
			System.String a1;
			checkType(l,2,out a1);
			o=new LBoot.AssetBundleLoadHistory(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RecordLoad(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			self.RecordLoad();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RecordUnload(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			self.RecordUnload();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			self.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uri(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			pushValue(l,self.uri);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uri(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.uri=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loadTimes(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			pushValue(l,self.loadTimes);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loadTimes(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			System.Double[] v;
			checkType(l,2,out v);
			self.loadTimes=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_unloadTimes(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			pushValue(l,self.unloadTimes);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_unloadTimes(IntPtr l) {
		try {
			LBoot.AssetBundleLoadHistory self=(LBoot.AssetBundleLoadHistory)checkSelf(l);
			System.Double[] v;
			checkType(l,2,out v);
			self.unloadTimes=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.AssetBundleLoadHistory");
		addMember(l,RecordLoad);
		addMember(l,RecordUnload);
		addMember(l,Clear);
		addMember(l,"uri",get_uri,set_uri,true);
		addMember(l,"loadTimes",get_loadTimes,set_loadTimes,true);
		addMember(l,"unloadTimes",get_unloadTimes,set_unloadTimes,true);
		createTypeMetatable(l,constructor, typeof(LBoot.AssetBundleLoadHistory));
	}
}
