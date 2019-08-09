using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollConflictManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollConflictManager self=(UnityEngine.UI.Extensions.ScrollConflictManager)checkSelf(l);
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
			UnityEngine.UI.Extensions.ScrollConflictManager self=(UnityEngine.UI.Extensions.ScrollConflictManager)checkSelf(l);
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
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollConflictManager self=(UnityEngine.UI.Extensions.ScrollConflictManager)checkSelf(l);
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
	static public int get_ParentScrollRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollConflictManager self=(UnityEngine.UI.Extensions.ScrollConflictManager)checkSelf(l);
			pushValue(l,self.ParentScrollRect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ParentScrollRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollConflictManager self=(UnityEngine.UI.Extensions.ScrollConflictManager)checkSelf(l);
			UnityEngine.UI.ScrollRect v;
			checkType(l,2,out v);
			self.ParentScrollRect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ScrollConflictManager");
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,OnDrag);
		addMember(l,"ParentScrollRect",get_ParentScrollRect,set_ParentScrollRect,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ScrollConflictManager),typeof(UnityEngine.MonoBehaviour));
	}
}
