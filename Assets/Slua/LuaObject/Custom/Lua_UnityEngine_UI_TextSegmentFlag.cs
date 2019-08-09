using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_TextSegmentFlag : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.TextSegmentFlag o;
			o=new UnityEngine.UI.TextSegmentFlag();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_start(IntPtr l) {
		try {
			UnityEngine.UI.TextSegmentFlag self;
			checkValueType(l,1,out self);
			pushValue(l,self.start);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_start(IntPtr l) {
		try {
			UnityEngine.UI.TextSegmentFlag self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.start=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_end(IntPtr l) {
		try {
			UnityEngine.UI.TextSegmentFlag self;
			checkValueType(l,1,out self);
			pushValue(l,self.end);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_end(IntPtr l) {
		try {
			UnityEngine.UI.TextSegmentFlag self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.end=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.TextSegmentFlag");
		addMember(l,"start",get_start,set_start,true);
		addMember(l,"end",get_end,set_end,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.TextSegmentFlag),typeof(System.ValueType));
	}
}
