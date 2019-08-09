using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_TextPic_HrefClickEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.HrefClickEvent o;
			o=new UnityEngine.UI.Extensions.TextPic.HrefClickEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_string.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.TextPic.HrefClickEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.TextPic.HrefClickEvent),typeof(LuaUnityEvent_string));
	}
}
