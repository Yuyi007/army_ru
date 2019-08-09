using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SelectionBox_SelectionEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox.SelectionEvent o;
			o=new UnityEngine.UI.Extensions.SelectionBox.SelectionEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_UnityEngine_UI_Extensions_IBoxSelectable__.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.SelectionBox.SelectionEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.SelectionBox.SelectionEvent),typeof(LuaUnityEvent_UnityEngine_UI_Extensions_IBoxSelectable__));
	}
}
