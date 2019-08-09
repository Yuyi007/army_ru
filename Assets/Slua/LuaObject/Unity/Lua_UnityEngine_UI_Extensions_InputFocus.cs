using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_InputFocus : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int buttonPressed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFocus self=(UnityEngine.UI.Extensions.InputFocus)checkSelf(l);
			self.buttonPressed();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndEdit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFocus self=(UnityEngine.UI.Extensions.InputFocus)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.OnEndEdit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__ignoreNextActivation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFocus self=(UnityEngine.UI.Extensions.InputFocus)checkSelf(l);
			pushValue(l,self._ignoreNextActivation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__ignoreNextActivation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFocus self=(UnityEngine.UI.Extensions.InputFocus)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self._ignoreNextActivation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.InputFocus");
		addMember(l,buttonPressed);
		addMember(l,OnEndEdit);
		addMember(l,"_ignoreNextActivation",get__ignoreNextActivation,set__ignoreNextActivation,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.InputFocus),typeof(UnityEngine.MonoBehaviour));
	}
}
