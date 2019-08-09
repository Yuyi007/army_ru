using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_BoundTooltipTrigger : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerEnter(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerEnter(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSelect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSelect(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerExit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerExit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnDeselect(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			pushValue(l,self.text);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_text(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.text=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useMousePosition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			pushValue(l,self.useMousePosition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useMousePosition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useMousePosition=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			pushValue(l,self.offset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_offset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipTrigger self=(UnityEngine.UI.Extensions.BoundTooltipTrigger)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.offset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.BoundTooltipTrigger");
		addMember(l,OnPointerEnter);
		addMember(l,OnSelect);
		addMember(l,OnPointerExit);
		addMember(l,OnDeselect);
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"useMousePosition",get_useMousePosition,set_useMousePosition,true);
		addMember(l,"offset",get_offset,set_offset,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.BoundTooltipTrigger),typeof(UnityEngine.MonoBehaviour));
	}
}
