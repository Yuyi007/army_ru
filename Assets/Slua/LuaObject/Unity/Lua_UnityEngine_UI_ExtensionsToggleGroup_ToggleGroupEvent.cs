using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ExtensionsToggleGroup_ToggleGroupEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent o;
			o=new UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_bool.reg(l);
		getTypeTable(l,"UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent),typeof(LuaUnityEvent_bool));
	}
}
