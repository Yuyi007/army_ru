﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Int32 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			System.Int32 o;
			o=new System.Int32();
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
			if(matchType(l,argc,2,typeof(int))){
				System.Int32 self;
				checkType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.CompareTo(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Object))){
				System.Int32 self;
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
			System.Int32 self;
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
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.Int32.Parse(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.Globalization.NumberStyles))){
				System.String a1;
				checkType(l,1,out a1);
				System.Globalization.NumberStyles a2;
				checkEnum(l,2,out a2);
				var ret=System.Int32.Parse(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.IFormatProvider))){
				System.String a1;
				checkType(l,1,out a1);
				System.IFormatProvider a2;
				checkType(l,2,out a2);
				var ret=System.Int32.Parse(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Globalization.NumberStyles a2;
				checkEnum(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				var ret=System.Int32.Parse(a1,a2,a3);
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
	static public int TryParse_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				var ret=System.Int32.TryParse(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Globalization.NumberStyles a2;
				checkEnum(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				var ret=System.Int32.TryParse(a1,a2,a3,out a4);
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
	static public int get_MaxValue(IntPtr l) {
		try {
			pushValue(l,System.Int32.MaxValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinValue(IntPtr l) {
		try {
			pushValue(l,System.Int32.MinValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Int");
		addMember(l,CompareTo);
		addMember(l,GetTypeCode);
		addMember(l,Parse_s);
		addMember(l,TryParse_s);
		addMember(l,"MaxValue",get_MaxValue,null,false);
		addMember(l,"MinValue",get_MinValue,null,false);
		createTypeMetatable(l,constructor, typeof(System.Int32),typeof(System.ValueType));
	}
}
