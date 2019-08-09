using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_InputFieldEnterSubmit_EnterSubmitEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFieldEnterSubmit.EnterSubmitEvent o;
			o=new UnityEngine.UI.Extensions.InputFieldEnterSubmit.EnterSubmitEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_string.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.InputFieldEnterSubmit.EnterSubmitEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.InputFieldEnterSubmit.EnterSubmitEvent),typeof(LuaUnityEvent_string));
	}
}
