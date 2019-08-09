using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_ToggleButton : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEnable(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			self.OnEnable();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDisable(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			self.OnDisable();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DisplayCheck(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.DisplayCheck(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetOn(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetOn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetParent(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			self.SetParent(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_group(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			pushValue(l,self.group);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_group(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			Game.ToggleBtnGroup v;
			checkType(l,2,out v);
			self.group=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_normal(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			pushValue(l,self.normal);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_normal(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.normal=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_check(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			pushValue(l,self.check);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_check(IntPtr l) {
		try {
			Game.ToggleButton self=(Game.ToggleButton)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.check=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.ToggleButton");
		addMember(l,OnEnable);
		addMember(l,OnDisable);
		addMember(l,DisplayCheck);
		addMember(l,SetOn);
		addMember(l,SetParent);
		addMember(l,"group",get_group,set_group,true);
		addMember(l,"normal",get_normal,set_normal,true);
		addMember(l,"check",get_check,set_check,true);
		createTypeMetatable(l,null, typeof(Game.ToggleButton),typeof(UnityEngine.MonoBehaviour));
	}
}
