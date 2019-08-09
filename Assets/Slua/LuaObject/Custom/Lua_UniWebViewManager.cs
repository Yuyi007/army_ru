using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UniWebViewManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UniWebViewManager o;
			o=new UniWebViewManager();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateWebView_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				UniWebViewManager.CreateWebView(a1);
				return 0;
			}
			else if(argc==5){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UniWebViewManager.CreateWebView(a1,a2,a3,a4,a5);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadUrl_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UniWebViewManager.LoadUrl(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Close_s(IntPtr l) {
		try {
			UniWebViewManager.Close();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UniWebViewManager");
		addMember(l,CreateWebView_s);
		addMember(l,LoadUrl_s);
		addMember(l,Close_s);
		createTypeMetatable(l,constructor, typeof(UniWebViewManager));
	}
}
