using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ExtensionsToggle_ToggleEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggle.ToggleEvent o;
			o=new UnityEngine.UI.ExtensionsToggle.ToggleEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_bool.reg(l);
		getTypeTable(l,"UnityEngine.UI.ExtensionsToggle.ToggleEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.ExtensionsToggle.ToggleEvent),typeof(LuaUnityEvent_bool));
	}
}
