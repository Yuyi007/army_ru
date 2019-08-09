using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_BundleHelper : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.BundleHelper o;
			o=new LBoot.BundleHelper();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadAllUnsuedAssetsAsync_s(IntPtr l) {
		try {
			System.Action a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			LBoot.BundleHelper.UnloadAllUnsuedAssetsAsync(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadLevel_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			LBoot.BundleHelper.LoadLevel(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadLevelAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				LBoot.BundleHelper.LoadLevelAsync(a1,a2,a3);
				return 0;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				System.Action<LBoot.AsyncLoadingType,System.Single> a4;
				LuaDelegation.checkDelegate(l,4,out a4);
				LBoot.BundleHelper.LoadLevelAsync(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadLevelAdditive_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			LBoot.BundleHelper.LoadLevelAdditive(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadLevelAdditiveAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				LBoot.BundleHelper.LoadLevelAdditiveAsync(a1,a2,a3);
				return 0;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				System.Action<LBoot.AsyncLoadingType,System.Single> a4;
				LuaDelegation.checkDelegate(l,4,out a4);
				LBoot.BundleHelper.LoadLevelAdditiveAsync(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Load_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=LBoot.BundleHelper.Load(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRealBundlePath_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleHelper.GetRealBundlePath(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAssetInEditor_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Type a3;
			checkType(l,3,out a3);
			var ret=LBoot.BundleHelper.LoadAssetInEditor(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadWithDependencies_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=LBoot.BundleHelper.LoadWithDependencies(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Unload_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			LBoot.BundleHelper.Unload(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action<LBoot.AssetBundleRef> a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				LBoot.BundleHelper.LoadAsync(a1,a2,a3);
				return 0;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				SLua.LuaTable a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				LBoot.BundleHelper.LoadAsync(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadWithDependenciesAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action<LBoot.AssetBundleRef> a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				LBoot.BundleHelper.LoadWithDependenciesAsync(a1,a2,a3);
				return 0;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				SLua.LuaTable a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				LBoot.BundleHelper.LoadWithDependenciesAsync(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset_s(IntPtr l) {
		try {
			LBoot.BundleHelper.Reset();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetBundleVariants_s(IntPtr l) {
		try {
			System.String[] a1;
			checkType(l,1,out a1);
			LBoot.BundleHelper.SetBundleVariants(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadDeadBundles_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				LBoot.BundleHelper.UnloadDeadBundles();
				return 0;
			}
			else if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				LBoot.BundleHelper.UnloadDeadBundles(a1);
				return 0;
			}
			else if(argc==2){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				LBoot.BundleHelper.UnloadDeadBundles(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAllDependencies_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleHelper.GetAllDependencies(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uriPrefix(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleHelper.uriPrefix);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uriPrefix(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			LBoot.BundleHelper.uriPrefix=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.BundleHelper");
		addMember(l,UnloadAllUnsuedAssetsAsync_s);
		addMember(l,LoadLevel_s);
		addMember(l,LoadLevelAsync_s);
		addMember(l,LoadLevelAdditive_s);
		addMember(l,LoadLevelAdditiveAsync_s);
		addMember(l,Load_s);
		addMember(l,GetRealBundlePath_s);
		addMember(l,LoadAssetInEditor_s);
		addMember(l,LoadWithDependencies_s);
		addMember(l,Unload_s);
		addMember(l,LoadAsync_s);
		addMember(l,LoadWithDependenciesAsync_s);
		addMember(l,Reset_s);
		addMember(l,SetBundleVariants_s);
		addMember(l,UnloadDeadBundles_s);
		addMember(l,GetAllDependencies_s);
		addMember(l,"uriPrefix",get_uriPrefix,set_uriPrefix,false);
		createTypeMetatable(l,constructor, typeof(LBoot.BundleHelper));
	}
}
