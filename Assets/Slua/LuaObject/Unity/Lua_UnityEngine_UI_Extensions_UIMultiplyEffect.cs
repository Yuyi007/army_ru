using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIMultiplyEffect : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetMaterial(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIMultiplyEffect self=(UnityEngine.UI.Extensions.UIMultiplyEffect)checkSelf(l);
			self.SetMaterial();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnValidate(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIMultiplyEffect self=(UnityEngine.UI.Extensions.UIMultiplyEffect)checkSelf(l);
			self.OnValidate();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIMultiplyEffect");
		addMember(l,SetMaterial);
		addMember(l,OnValidate);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIMultiplyEffect),typeof(UnityEngine.MonoBehaviour));
	}
}
