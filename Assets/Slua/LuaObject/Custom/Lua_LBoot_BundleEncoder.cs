using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_BundleEncoder : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.BundleEncoder o;
			o=new LBoot.BundleEncoder();
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
			System.Byte[] a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			LBoot.BundleEncoder.Init(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetEncodingOfFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.GetEncodingOfFile(a1);
			pushEnum(l,(int)ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetEncodingOfData_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.GetEncodingOfData(a1);
			pushEnum(l,(int)ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EncodeOverwriteBundleFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			LBoot.BundleEncoder.EncodeOverwriteBundleFile(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EncodeStream_s(IntPtr l) {
		try {
			System.IO.Stream a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			LBoot.BundleEncoder.Encoding a3;
			checkEnum(l,3,out a3);
			LBoot.BundleEncoder.EncodeStream(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DecodeBundleFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.DecodeBundleFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DecodeBundle_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.DecodeBundle(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DecodeData_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Int64 a3;
			checkType(l,3,out a3);
			var ret=LBoot.BundleEncoder.DecodeData(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromMemory_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.CreateBundleFromMemory(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromMemoryAsync_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.CreateBundleFromMemoryAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.CreateBundleFromFile(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromFileAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=LBoot.BundleEncoder.CreateBundleFromFileAsync(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromWWW_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.UInt32 a3;
			checkType(l,3,out a3);
			var ret=LBoot.BundleEncoder.CreateBundleFromWWW(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateBundleFromWWWAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.UInt32 a3;
			checkType(l,3,out a3);
			var ret=LBoot.BundleEncoder.CreateBundleFromWWWAsync(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.BundleEncoder");
		addMember(l,Init_s);
		addMember(l,GetEncodingOfFile_s);
		addMember(l,GetEncodingOfData_s);
		addMember(l,EncodeOverwriteBundleFile_s);
		addMember(l,EncodeStream_s);
		addMember(l,DecodeBundleFile_s);
		addMember(l,DecodeBundle_s);
		addMember(l,DecodeData_s);
		addMember(l,CreateBundleFromMemory_s);
		addMember(l,CreateBundleFromMemoryAsync_s);
		addMember(l,CreateBundleFromFile_s);
		addMember(l,CreateBundleFromFileAsync_s);
		addMember(l,CreateBundleFromWWW_s);
		addMember(l,CreateBundleFromWWWAsync_s);
		createTypeMetatable(l,constructor, typeof(LBoot.BundleEncoder));
	}
}
