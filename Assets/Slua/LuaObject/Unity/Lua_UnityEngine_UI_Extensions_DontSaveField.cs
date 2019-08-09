using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DontSaveField : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DontSaveField o;
			o=new UnityEngine.UI.Extensions.DontSaveField();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DontSaveField");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.DontSaveField),typeof(System.Attribute));
	}
}
