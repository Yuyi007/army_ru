using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UICircle : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle o;
			o=new UnityEngine.UI.Extensions.UICircle();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fillPercent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			pushValue(l,self.fillPercent);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fillPercent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.fillPercent=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FixedToSegments(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			pushValue(l,self.FixedToSegments);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FixedToSegments(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.FixedToSegments=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fill(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			pushValue(l,self.fill);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fill(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.fill=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_thickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			pushValue(l,self.thickness);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_thickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.thickness=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_segments(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			pushValue(l,self.segments);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_segments(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICircle self=(UnityEngine.UI.Extensions.UICircle)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.segments=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UICircle");
		addMember(l,"fillPercent",get_fillPercent,set_fillPercent,true);
		addMember(l,"FixedToSegments",get_FixedToSegments,set_FixedToSegments,true);
		addMember(l,"fill",get_fill,set_fill,true);
		addMember(l,"thickness",get_thickness,set_thickness,true);
		addMember(l,"segments",get_segments,set_segments,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UICircle),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
