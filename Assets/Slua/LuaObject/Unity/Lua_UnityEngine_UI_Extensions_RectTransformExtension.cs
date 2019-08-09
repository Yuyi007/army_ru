using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_RectTransformExtension : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int switchToRectTransform_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.RectTransform a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.Extensions.RectTransformExtension.switchToRectTransform(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.RectTransformExtension");
		addMember(l,switchToRectTransform_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.RectTransformExtension));
	}
}
