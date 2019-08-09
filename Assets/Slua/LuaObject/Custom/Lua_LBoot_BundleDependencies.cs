using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_BundleDependencies : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.BundleDependencies o;
			System.String a1;
			checkType(l,2,out a1);
			o=new LBoot.BundleDependencies(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReloadManifest(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			self.ReloadManifest();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAllDependenciesAsync(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.LoadAllDependenciesAsync(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAllDependencies(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.LoadAllDependencies(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAllDependencies(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetAllDependencies(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemapVariantName(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.RemapVariantName(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_manifestBundle(IntPtr l) {
		try {
			LBoot.BundleDependencies self=(LBoot.BundleDependencies)checkSelf(l);
			pushValue(l,self.manifestBundle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.BundleDependencies");
		addMember(l,ReloadManifest);
		addMember(l,LoadAllDependenciesAsync);
		addMember(l,LoadAllDependencies);
		addMember(l,GetAllDependencies);
		addMember(l,RemapVariantName);
		addMember(l,"manifestBundle",get_manifestBundle,null,true);
		createTypeMetatable(l,constructor, typeof(LBoot.BundleDependencies));
	}
}
