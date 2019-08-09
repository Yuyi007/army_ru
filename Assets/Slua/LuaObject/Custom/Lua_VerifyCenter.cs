using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_VerifyCenter : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			VerifyCenter o;
			o=new VerifyCenter();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Start_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			VerifyCenter.Start(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Teminate_s(IntPtr l) {
		try {
			VerifyCenter.Teminate();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int pushMessage_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			VerifyCenter.pushMessage(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int popMessage_s(IntPtr l) {
		try {
			var ret=VerifyCenter.popMessage();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"VerifyCenter");
		addMember(l,Start_s);
		addMember(l,Teminate_s);
		addMember(l,pushMessage_s);
		addMember(l,popMessage_s);
		createTypeMetatable(l,constructor, typeof(VerifyCenter));
	}
}
