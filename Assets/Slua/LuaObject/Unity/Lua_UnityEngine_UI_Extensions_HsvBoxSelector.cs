using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HsvBoxSelector : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvBoxSelector self=(UnityEngine.UI.Extensions.HsvBoxSelector)checkSelf(l);
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
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvBoxSelector self=(UnityEngine.UI.Extensions.HsvBoxSelector)checkSelf(l);
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
	static public int get_picker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvBoxSelector self=(UnityEngine.UI.Extensions.HsvBoxSelector)checkSelf(l);
			pushValue(l,self.picker);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_picker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HsvBoxSelector self=(UnityEngine.UI.Extensions.HsvBoxSelector)checkSelf(l);
			UnityEngine.UI.Extensions.HSVPicker v;
			checkType(l,2,out v);
			self.picker=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HsvBoxSelector");
		addMember(l,OnDrag);
		addMember(l,OnPointerDown);
		addMember(l,"picker",get_picker,set_picker,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.HsvBoxSelector),typeof(UnityEngine.MonoBehaviour));
	}
}
