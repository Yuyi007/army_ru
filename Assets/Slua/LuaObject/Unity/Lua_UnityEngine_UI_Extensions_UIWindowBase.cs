using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIWindowBase : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIWindowBase self=(UnityEngine.UI.Extensions.UIWindowBase)checkSelf(l);
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
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIWindowBase self=(UnityEngine.UI.Extensions.UIWindowBase)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIWindowBase self=(UnityEngine.UI.Extensions.UIWindowBase)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ResetCoords(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Extensions.UIWindowBase.ResetCoords);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ResetCoords(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			UnityEngine.UI.Extensions.UIWindowBase.ResetCoords=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_KeepWindowInCanvas(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIWindowBase self=(UnityEngine.UI.Extensions.UIWindowBase)checkSelf(l);
			pushValue(l,self.KeepWindowInCanvas);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_KeepWindowInCanvas(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIWindowBase self=(UnityEngine.UI.Extensions.UIWindowBase)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.KeepWindowInCanvas=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIWindowBase");
		addMember(l,OnDrag);
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,"ResetCoords",get_ResetCoords,set_ResetCoords,false);
		addMember(l,"KeepWindowInCanvas",get_KeepWindowInCanvas,set_KeepWindowInCanvas,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIWindowBase),typeof(UnityEngine.MonoBehaviour));
	}
}
