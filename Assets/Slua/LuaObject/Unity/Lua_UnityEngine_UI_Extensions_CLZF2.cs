using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_CLZF2 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Compress_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.Extensions.CLZF2.Compress(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Decompress_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.Extensions.CLZF2.Decompress(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int lzf_compress_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.Extensions.CLZF2.lzf_compress(a1,ref a2);
			pushValue(l,ret);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int lzf_decompress_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.Extensions.CLZF2.lzf_decompress(a1,ref a2);
			pushValue(l,ret);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.CLZF2");
		addMember(l,Compress_s);
		addMember(l,Decompress_s);
		addMember(l,lzf_compress_s);
		addMember(l,lzf_decompress_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.CLZF2));
	}
}
