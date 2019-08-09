using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_KnobFloatValueEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.KnobFloatValueEvent o;
			o=new UnityEngine.UI.Extensions.KnobFloatValueEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_float.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.KnobFloatValueEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.KnobFloatValueEvent),typeof(LuaUnityEvent_float));
	}
}
