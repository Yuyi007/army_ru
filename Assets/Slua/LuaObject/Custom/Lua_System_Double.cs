using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Double : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			System.Double o;
			o=new System.Double();
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
			if(matchType(l,argc,2,typeof(double))){
				System.Double self;
				checkType(l,1,out self);
				System.Double a1;
				checkType(l,2,out a1);
				var ret=self.CompareTo(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Object))){
				System.Double self;
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
			System.Double self;
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
	static public int IsInfinity_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=System.Double.IsInfinity(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsNaN_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=System.Double.IsNaN(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsNegativeInfinity_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=System.Double.IsNegativeInfinity(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPositiveInfinity_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			var ret=System.Double.IsPositiveInfinity(a1);
			pushValue(l,ret);
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
				var ret=System.Double.Parse(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.Globalization.NumberStyles))){
				System.String a1;
				checkType(l,1,out a1);
				System.Globalization.NumberStyles a2;
				checkEnum(l,2,out a2);
				var ret=System.Double.Parse(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.IFormatProvider))){
				System.String a1;
				checkType(l,1,out a1);
				System.IFormatProvider a2;
				checkType(l,2,out a2);
				var ret=System.Double.Parse(a1,a2);
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
				var ret=System.Double.Parse(a1,a2,a3);
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
				System.Double a2;
				var ret=System.Double.TryParse(a1,out a2);
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
				System.Double a4;
				var ret=System.Double.TryParse(a1,a2,a3,out a4);
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
	static public int get_Epsilon(IntPtr l) {
		try {
			pushValue(l,System.Double.Epsilon);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxValue(IntPtr l) {
		try {
			pushValue(l,System.Double.MaxValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinValue(IntPtr l) {
		try {
			pushValue(l,System.Double.MinValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NaN(IntPtr l) {
		try {
			pushValue(l,System.Double.NaN);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NegativeInfinity(IntPtr l) {
		try {
			pushValue(l,System.Double.NegativeInfinity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PositiveInfinity(IntPtr l) {
		try {
			pushValue(l,System.Double.PositiveInfinity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Double");
		addMember(l,CompareTo);
		addMember(l,GetTypeCode);
		addMember(l,IsInfinity_s);
		addMember(l,IsNaN_s);
		addMember(l,IsNegativeInfinity_s);
		addMember(l,IsPositiveInfinity_s);
		addMember(l,Parse_s);
		addMember(l,TryParse_s);
		addMember(l,"Epsilon",get_Epsilon,null,false);
		addMember(l,"MaxValue",get_MaxValue,null,false);
		addMember(l,"MinValue",get_MinValue,null,false);
		addMember(l,"NaN",get_NaN,null,false);
		addMember(l,"NegativeInfinity",get_NegativeInfinity,null,false);
		addMember(l,"PositiveInfinity",get_PositiveInfinity,null,false);
		createTypeMetatable(l,constructor, typeof(System.Double),typeof(System.ValueType));
	}
}
