using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_AssetBundleRef : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.AssetBundleRef o;
			System.String a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			o=new LBoot.AssetBundleRef(a1,a2);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddParentBundle(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.AddParentBundle(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateEndTime(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			self.UpdateEndTime();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAssetAsync(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.LoadAssetAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Type a2;
				checkType(l,3,out a2);
				var ret=self.LoadAssetAsync(a1,a2);
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
	static public int CanUnload(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			var ret=self.CanUnload();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadAsset(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.UnloadAsset(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAsset(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.LoadAsset(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Type a2;
				checkType(l,3,out a2);
				var ret=self.LoadAsset(a1,a2);
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
	static public int LoadAssetWithSubAssets(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.LoadAssetWithSubAssets(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Contains(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.Contains(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uri(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
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
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
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
	static public int get_AssetBundle(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			pushValue(l,self.AssetBundle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_AssetBundle(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			UnityEngine.AssetBundle v;
			checkType(l,2,out v);
			self.AssetBundle=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SecondsToLive(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			pushValue(l,self.SecondsToLive);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SecondsToLive(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.SecondsToLive=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EndTime(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			pushValue(l,self.EndTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Dead(IntPtr l) {
		try {
			LBoot.AssetBundleRef self=(LBoot.AssetBundleRef)checkSelf(l);
			pushValue(l,self.Dead);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.AssetBundleRef");
		addMember(l,AddParentBundle);
		addMember(l,UpdateEndTime);
		addMember(l,LoadAssetAsync);
		addMember(l,CanUnload);
		addMember(l,UnloadAsset);
		addMember(l,LoadAsset);
		addMember(l,LoadAssetWithSubAssets);
		addMember(l,Contains);
		addMember(l,"uri",get_uri,set_uri,true);
		addMember(l,"AssetBundle",get_AssetBundle,set_AssetBundle,true);
		addMember(l,"SecondsToLive",get_SecondsToLive,set_SecondsToLive,true);
		addMember(l,"EndTime",get_EndTime,null,true);
		addMember(l,"Dead",get_Dead,null,true);
		createTypeMetatable(l,constructor, typeof(LBoot.AssetBundleRef));
	}
}
