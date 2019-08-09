using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Boolean : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			System.Boolean o;
			o=new System.Boolean();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompareTo(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(bool))){
				System.Boolean self;
				checkType(l,1,out self);
				System.Boolean a1;
				checkType(l,2,out a1);
				var ret=self.CompareTo(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Object))){
				System.Boolean self;
				checkType(l,1,out self);
				System.Object a1;
				checkType(l,2,out a1);
				var ret=self.CompareTo(a1);
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
	static public int GetTypeCode(IntPtr l) {
		try {
			System.Boolean self;
			checkType(l,1,out self);
			var ret=self.GetTypeCode();
			pushEnum(l,(int)ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Parse_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.Boolean.Parse(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TryParse_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			var ret=System.Boolean.TryParse(a1,out a2);
			pushValue(l,ret);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FalseString(IntPtr l) {
		try {
			pushValue(l,System.Boolean.FalseString);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TrueString(IntPtr l) {
		try {
			pushValue(l,System.Boolean.TrueString);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Bool");
		addMember(l,CompareTo);
		addMember(l,GetTypeCode);
		addMember(l,Parse_s);
		addMember(l,TryParse_s);
		addMember(l,"FalseString",get_FalseString,null,false);
		addMember(l,"TrueString",get_TrueString,null,false);
		createTypeMetatable(l,constructor, typeof(System.Boolean),typeof(System.ValueType));
	}
}
