using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_BundleManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.BundleManager o;
			o=new LBoot.BundleManager();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetBundleDependencies(IntPtr l) {
		try {
			LBoot.BundleManager self=(LBoot.BundleManager)checkSelf(l);
			var ret=self.GetBundleDependencies();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTTLSettings_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			LBoot.BundleManager.SetTTLSettings(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetPatternTTLSettings_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			LBoot.BundleManager.SetPatternTTLSettings(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetBundleVariantes_s(IntPtr l) {
		try {
			System.String[] a1;
			checkType(l,1,out a1);
			LBoot.BundleManager.SetBundleVariantes(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemapVariantBundleName_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.RemapVariantBundleName(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Get_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.Get(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetBundleRef_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.GetBundleRef(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TryGetRefreshedBundleRef_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			LBoot.AssetBundleRef a3;
			var ret=LBoot.BundleManager.TryGetRefreshedBundleRef(a1,a2,out a3);
			pushValue(l,ret);
			pushValue(l,a3);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRecentLoadHistories_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.GetRecentLoadHistories(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearRecentLoadHistories_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			LBoot.BundleManager.ClearRecentLoadHistories(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLoadAfterUnloadHistories_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.GetLoadAfterUnloadHistories(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLoadHistory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleManager.GetLoadHistory(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearLoadHistory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			LBoot.BundleManager.ClearLoadHistory(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddLoadHistory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=LBoot.BundleManager.AddLoadHistory(a1,a2);
			pushValue(l,ret);
			return 1;
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
			var ret=LBoot.BundleManager.Load(a1,a2);
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
			var ret=LBoot.BundleManager.LoadWithDependencies(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadWithDependenciesAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=LBoot.BundleManager.LoadWithDependenciesAsync(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Action<LBoot.AssetBundleRef> a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				var ret=LBoot.BundleManager.LoadWithDependenciesAsync(a1,a2,a3);
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
	static public int LoadAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Action<LBoot.AssetBundleRef> a3;
			LuaDelegation.checkDelegate(l,3,out a3);
			var ret=LBoot.BundleManager.LoadAsync(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				LBoot.BundleManager.Reset();
				return 0;
			}
			else if(argc==1){
				System.String[] a1;
				checkType(l,1,out a1);
				LBoot.BundleManager.Reset(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
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
			LBoot.BundleManager.Unload(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				LBoot.BundleManager.UnloadAll(a1);
				return 0;
			}
			else if(argc==2){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.String[] a2;
				checkType(l,2,out a2);
				LBoot.BundleManager.UnloadAll(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
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
				LBoot.BundleManager.UnloadDeadBundles();
				return 0;
			}
			else if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				LBoot.BundleManager.UnloadDeadBundles(a1);
				return 0;
			}
			else if(argc==2){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				LBoot.BundleManager.UnloadDeadBundles(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadDyingBundles_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			LBoot.BundleManager.UnloadDyingBundles(a1,a2);
			return 0;
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
			var ret=LBoot.BundleManager.GetAllDependencies(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DumpAll_s(IntPtr l) {
		try {
			LBoot.BundleManager.DumpAll();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DumpBundleRefs_s(IntPtr l) {
		try {
			LBoot.BundleManager.DumpBundleRefs();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DumpBundleLoadHistories_s(IntPtr l) {
		try {
			LBoot.BundleManager.DumpBundleLoadHistories();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DumpBundleLists_s(IntPtr l) {
		try {
			LBoot.BundleManager.DumpBundleLists();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loadWithWWW(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.loadWithWWW);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loadWithWWW(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			LBoot.BundleManager.loadWithWWW=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_wwwVersion(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.wwwVersion);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_wwwVersion(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			LBoot.BundleManager.wwwVersion=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_wwwCrc(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.wwwCrc);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_wwwCrc(IntPtr l) {
		try {
			System.UInt32 v;
			checkType(l,2,out v);
			LBoot.BundleManager.wwwCrc=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DictAssetBundleRefs(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.DictAssetBundleRefs);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ListAssetBundleUris(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.ListAssetBundleUris);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DictAssetBundleLoadHistories(IntPtr l) {
		try {
			pushValue(l,LBoot.BundleManager.DictAssetBundleLoadHistories);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.BundleManager");
		addMember(l,GetBundleDependencies);
		addMember(l,SetTTLSettings_s);
		addMember(l,SetPatternTTLSettings_s);
		addMember(l,SetBundleVariantes_s);
		addMember(l,RemapVariantBundleName_s);
		addMember(l,Get_s);
		addMember(l,GetBundleRef_s);
		addMember(l,TryGetRefreshedBundleRef_s);
		addMember(l,GetRecentLoadHistories_s);
		addMember(l,ClearRecentLoadHistories_s);
		addMember(l,GetLoadAfterUnloadHistories_s);
		addMember(l,GetLoadHistory_s);
		addMember(l,ClearLoadHistory_s);
		addMember(l,AddLoadHistory_s);
		addMember(l,Load_s);
		addMember(l,LoadWithDependencies_s);
		addMember(l,LoadWithDependenciesAsync_s);
		addMember(l,LoadAsync_s);
		addMember(l,Reset_s);
		addMember(l,Unload_s);
		addMember(l,UnloadAll_s);
		addMember(l,UnloadDeadBundles_s);
		addMember(l,UnloadDyingBundles_s);
		addMember(l,GetAllDependencies_s);
		addMember(l,DumpAll_s);
		addMember(l,DumpBundleRefs_s);
		addMember(l,DumpBundleLoadHistories_s);
		addMember(l,DumpBundleLists_s);
		addMember(l,"loadWithWWW",get_loadWithWWW,set_loadWithWWW,false);
		addMember(l,"wwwVersion",get_wwwVersion,set_wwwVersion,false);
		addMember(l,"wwwCrc",get_wwwCrc,set_wwwCrc,false);
		addMember(l,"DictAssetBundleRefs",get_DictAssetBundleRefs,null,false);
		addMember(l,"ListAssetBundleUris",get_ListAssetBundleUris,null,false);
		addMember(l,"DictAssetBundleLoadHistories",get_DictAssetBundleLoadHistories,null,false);
		createTypeMetatable(l,constructor, typeof(LBoot.BundleManager));
	}
}
