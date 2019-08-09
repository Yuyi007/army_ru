using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HSVSliderEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVSliderEvent o;
			o=new UnityEngine.UI.Extensions.HSVSliderEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_UnityEngine_Color.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.HSVSliderEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.HSVSliderEvent),typeof(LuaUnityEvent_UnityEngine_Color));
	}
}
