using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_CurvedLayout : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout o;
			o=new UnityEngine.UI.Extensions.CurvedLayout();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			self.SetLayoutHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			self.SetLayoutVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateLayoutInputVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			self.CalculateLayoutInputVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CurveOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			pushValue(l,self.CurveOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CurveOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.CurveOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemAxis(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			pushValue(l,self.itemAxis);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemAxis(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.itemAxis=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			pushValue(l,self.itemSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.itemSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_centerpoint(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			pushValue(l,self.centerpoint);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_centerpoint(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedLayout self=(UnityEngine.UI.Extensions.CurvedLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.centerpoint=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.CurvedLayout");
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,"CurveOffset",get_CurveOffset,set_CurveOffset,true);
		addMember(l,"itemAxis",get_itemAxis,set_itemAxis,true);
		addMember(l,"itemSize",get_itemSize,set_itemSize,true);
		addMember(l,"centerpoint",get_centerpoint,set_centerpoint,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.CurvedLayout),typeof(UnityEngine.UI.LayoutGroup));
	}
}
