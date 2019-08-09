using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HsvColor : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor o;
			System.Double a1;
			checkType(l,2,out a1);
			System.Double a2;
			checkType(l,3,out a2);
			System.Double a3;
			checkType(l,4,out a3);
			o=new UnityEngine.UI.Extensions.HsvColor(a1,a2,a3);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_H(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			pushValue(l,self.H);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_H(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			System.Double v;
			checkType(l,2,out v);
			self.H=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_S(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			pushValue(l,self.S);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_S(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			System.Double v;
			checkType(l,2,out v);
			self.S=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_V(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			pushValue(l,self.V);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_V(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvColor self;
			checkValueType(l,1,out self);
			System.Double v;
			checkType(l,2,out v);
			self.V=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HsvColor");
		addMember(l,"H",get_H,set_H,true);
		addMember(l,"S",get_S,set_S,true);
		addMember(l,"V",get_V,set_V,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.HsvColor),typeof(System.ValueType));
	}
}
