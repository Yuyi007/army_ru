using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_RadialLayout : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout o;
			o=new UnityEngine.UI.Extensions.RadialLayout();
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
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
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
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
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
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
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
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fDistance(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			pushValue(l,self.fDistance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fDistance(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fDistance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			pushValue(l,self.MinAngle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MinAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MinAngle=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			pushValue(l,self.MaxAngle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MaxAngle=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_StartAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			pushValue(l,self.StartAngle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_StartAngle(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RadialLayout self=(UnityEngine.UI.Extensions.RadialLayout)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.StartAngle=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.RadialLayout");
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,"fDistance",get_fDistance,set_fDistance,true);
		addMember(l,"MinAngle",get_MinAngle,set_MinAngle,true);
		addMember(l,"MaxAngle",get_MaxAngle,set_MaxAngle,true);
		addMember(l,"StartAngle",get_StartAngle,set_StartAngle,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.RadialLayout),typeof(UnityEngine.UI.LayoutGroup));
	}
}
