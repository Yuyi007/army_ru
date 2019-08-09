using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ToolTip : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Awake(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ToolTip self=(UnityEngine.UI.Extensions.ToolTip)checkSelf(l);
			self.Awake();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTooltip(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ToolTip self=(UnityEngine.UI.Extensions.ToolTip)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.SetTooltip(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideTooltip(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ToolTip self=(UnityEngine.UI.Extensions.ToolTip)checkSelf(l);
			self.HideTooltip();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnScreenSpaceCamera(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ToolTip self=(UnityEngine.UI.Extensions.ToolTip)checkSelf(l);
			self.OnScreenSpaceCamera();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ToolTip");
		addMember(l,Awake);
		addMember(l,SetTooltip);
		addMember(l,HideTooltip);
		addMember(l,OnScreenSpaceCamera);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ToolTip),typeof(UnityEngine.MonoBehaviour));
	}
}
