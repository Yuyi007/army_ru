using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_RescalePanel : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			pushValue(l,self.minSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_minSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.minSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			pushValue(l,self.maxSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescalePanel self=(UnityEngine.UI.Extensions.RescalePanel)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.maxSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.RescalePanel");
		addMember(l,OnPointerDown);
		addMember(l,OnDrag);
		addMember(l,"minSize",get_minSize,set_minSize,true);
		addMember(l,"maxSize",get_maxSize,set_maxSize,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.RescalePanel),typeof(UnityEngine.MonoBehaviour));
	}
}
