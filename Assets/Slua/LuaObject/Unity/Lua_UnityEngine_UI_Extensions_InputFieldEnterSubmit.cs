using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_InputFieldEnterSubmit : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndEdit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFieldEnterSubmit self=(UnityEngine.UI.Extensions.InputFieldEnterSubmit)checkSelf(l);
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
	static public int get_EnterSubmit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFieldEnterSubmit self=(UnityEngine.UI.Extensions.InputFieldEnterSubmit)checkSelf(l);
			pushValue(l,self.EnterSubmit);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_EnterSubmit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.InputFieldEnterSubmit self=(UnityEngine.UI.Extensions.InputFieldEnterSubmit)checkSelf(l);
			UnityEngine.UI.Extensions.InputFieldEnterSubmit.EnterSubmitEvent v;
			checkType(l,2,out v);
			self.EnterSubmit=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.InputFieldEnterSubmit");
		addMember(l,OnEndEdit);
		addMember(l,"EnterSubmit",get_EnterSubmit,set_EnterSubmit,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.InputFieldEnterSubmit),typeof(UnityEngine.MonoBehaviour));
	}
}
