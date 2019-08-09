using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_FileUtils : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.FileUtils o;
			o=new LBoot.FileUtils();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ExtractZipFile(IntPtr l) {
		try {
			LBoot.FileUtils self=(LBoot.FileUtils)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			System.String a4;
			checkType(l,5,out a4);
			self.ExtractZipFile(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddSearchPath_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				LBoot.FileUtils.AddSearchPath(a1);
				return 0;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				LBoot.FileUtils.AddSearchPath(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HasSearchPath_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.HasSearchPath(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSearchPaths_s(IntPtr l) {
		try {
			var ret=LBoot.FileUtils.GetSearchPaths();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetSearchPaths_s(IntPtr l) {
		try {
			System.String[] a1;
			checkType(l,1,out a1);
			LBoot.FileUtils.SetSearchPaths(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveSearchPath_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			LBoot.FileUtils.RemoveSearchPath(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveAllSearchPaths_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			LBoot.FileUtils.RemoveAllSearchPaths(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetWritablePath_s(IntPtr l) {
		try {
			var ret=LBoot.FileUtils.GetWritablePath();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromFile_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=LBoot.FileUtils.GetDataFromFile(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				var ret=LBoot.FileUtils.GetDataFromFile(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Int64 a4;
				var ret=LBoot.FileUtils.GetDataFromFile(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromFileNoSearching_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				var ret=LBoot.FileUtils.GetDataFromFileNoSearching(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Int64 a4;
				var ret=LBoot.FileUtils.GetDataFromFileNoSearching(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromFileNoSearching_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromFileNoSearching(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExists_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.IsFileExists(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExistsNoSearching_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=LBoot.FileUtils.IsFileExistsNoSearching(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				var ret=LBoot.FileUtils.IsFileExistsNoSearching(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetFullPathOfFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetFullPathOfFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExistsInPersistentData_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=LBoot.FileUtils.IsFileExistsInPersistentData(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				var ret=LBoot.FileUtils.IsFileExistsInPersistentData(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromPersistentData_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				var ret=LBoot.FileUtils.GetDataFromPersistentData(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Int64 a4;
				var ret=LBoot.FileUtils.GetDataFromPersistentData(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromPersistentData_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromPersistentData(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExistsInStreamingAssets_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=LBoot.FileUtils.IsFileExistsInStreamingAssets(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				var ret=LBoot.FileUtils.IsFileExistsInStreamingAssets(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromStreamingAssets_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				var ret=LBoot.FileUtils.GetDataFromStreamingAssets(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Int64 a4;
				var ret=LBoot.FileUtils.GetDataFromStreamingAssets(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromStreamingAssets_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromStreamingAssets(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExistsInRawPath_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=LBoot.FileUtils.IsFileExistsInRawPath(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				var ret=LBoot.FileUtils.IsFileExistsInRawPath(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromRawPath_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				var ret=LBoot.FileUtils.GetDataFromRawPath(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Int64 a2;
				checkType(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Int64 a4;
				var ret=LBoot.FileUtils.GetDataFromRawPath(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromRawPath_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromRawPath(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetStringFromRawPathZip_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetStringFromRawPathZip(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromFileAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetDataFromFileAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromFileNoSearchingAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetDataFromFileNoSearchingAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromPersistentDataAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetDataFromPersistentDataAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromStreamingAssetsAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetDataFromStreamingAssetsAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDataFromRawPathAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.GetDataFromRawPathAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrepareBundleFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.PrepareBundleFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CopyFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			var ret=LBoot.FileUtils.CopyFile(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DeleteFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.FileUtils.DeleteFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UpdatePath(IntPtr l) {
		try {
			pushValue(l,LBoot.FileUtils.UpdatePath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UpdatePath(IntPtr l) {
		try {
			string v;
			checkType(l,2,out v);
			LBoot.FileUtils.UpdatePath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.FileUtils");
		addMember(l,ExtractZipFile);
		addMember(l,AddSearchPath_s);
		addMember(l,HasSearchPath_s);
		addMember(l,GetSearchPaths_s);
		addMember(l,SetSearchPaths_s);
		addMember(l,RemoveSearchPath_s);
		addMember(l,RemoveAllSearchPaths_s);
		addMember(l,GetWritablePath_s);
		addMember(l,GetDataFromFile_s);
		addMember(l,GetStringFromFile_s);
		addMember(l,GetDataFromFileNoSearching_s);
		addMember(l,GetStringFromFileNoSearching_s);
		addMember(l,IsFileExists_s);
		addMember(l,IsFileExistsNoSearching_s);
		addMember(l,GetFullPathOfFile_s);
		addMember(l,IsFileExistsInPersistentData_s);
		addMember(l,GetDataFromPersistentData_s);
		addMember(l,GetStringFromPersistentData_s);
		addMember(l,IsFileExistsInStreamingAssets_s);
		addMember(l,GetDataFromStreamingAssets_s);
		addMember(l,GetStringFromStreamingAssets_s);
		addMember(l,IsFileExistsInRawPath_s);
		addMember(l,GetDataFromRawPath_s);
		addMember(l,GetStringFromRawPath_s);
		addMember(l,GetStringFromRawPathZip_s);
		addMember(l,GetDataFromFileAsync_s);
		addMember(l,GetDataFromFileNoSearchingAsync_s);
		addMember(l,GetDataFromPersistentDataAsync_s);
		addMember(l,GetDataFromStreamingAssetsAsync_s);
		addMember(l,GetDataFromRawPathAsync_s);
		addMember(l,PrepareBundleFile_s);
		addMember(l,CopyFile_s);
		addMember(l,DeleteFile_s);
		addMember(l,"UpdatePath",get_UpdatePath,set_UpdatePath,false);
		createTypeMetatable(l,constructor, typeof(LBoot.FileUtils));
	}
}
