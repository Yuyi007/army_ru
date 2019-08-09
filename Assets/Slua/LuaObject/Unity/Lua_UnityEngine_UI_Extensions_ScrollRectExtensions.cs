using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollRectExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollToTop_s(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.ScrollRectExtensions.ScrollToTop(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollToBottom_s(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.ScrollRectExtensions.ScrollToBottom(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ScrollRectExtensions");
		addMember(l,ScrollToTop_s);
		addMember(l,ScrollToBottom_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ScrollRectExtensions));
	}
}
