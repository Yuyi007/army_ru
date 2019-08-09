using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_TabNavigationHelper : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Update(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TabNavigationHelper self=(UnityEngine.UI.Extensions.TabNavigationHelper)checkSelf(l);
			self.Update();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NavigationPath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TabNavigationHelper self=(UnityEngine.UI.Extensions.TabNavigationHelper)checkSelf(l);
			pushValue(l,self.NavigationPath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_NavigationPath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TabNavigationHelper self=(UnityEngine.UI.Extensions.TabNavigationHelper)checkSelf(l);
			UnityEngine.UI.Selectable[] v;
			checkType(l,2,out v);
			self.NavigationPath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NavigationMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TabNavigationHelper self=(UnityEngine.UI.Extensions.TabNavigationHelper)checkSelf(l);
			pushEnum(l,(int)self.NavigationMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_NavigationMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TabNavigationHelper self=(UnityEngine.UI.Extensions.TabNavigationHelper)checkSelf(l);
			UnityEngine.UI.Extensions.NavigationMode v;
			checkEnum(l,2,out v);
			self.NavigationMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.TabNavigationHelper");
		addMember(l,Update);
		addMember(l,"NavigationPath",get_NavigationPath,set_NavigationPath,true);
		addMember(l,"NavigationMode",get_NavigationMode,set_NavigationMode,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.TabNavigationHelper),typeof(UnityEngine.MonoBehaviour));
	}
}
