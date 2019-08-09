using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UI_ScrollRectOcclusion : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_ScrollRectOcclusion self=(UnityEngine.UI.Extensions.UI_ScrollRectOcclusion)checkSelf(l);
			self.Init();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnScroll(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_ScrollRectOcclusion self=(UnityEngine.UI.Extensions.UI_ScrollRectOcclusion)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			self.OnScroll(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_InitByUser(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_ScrollRectOcclusion self=(UnityEngine.UI.Extensions.UI_ScrollRectOcclusion)checkSelf(l);
			pushValue(l,self.InitByUser);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_InitByUser(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_ScrollRectOcclusion self=(UnityEngine.UI.Extensions.UI_ScrollRectOcclusion)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.InitByUser=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UI_ScrollRectOcclusion");
		addMember(l,Init);
		addMember(l,OnScroll);
		addMember(l,"InitByUser",get_InitByUser,set_InitByUser,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UI_ScrollRectOcclusion),typeof(UnityEngine.MonoBehaviour));
	}
}
