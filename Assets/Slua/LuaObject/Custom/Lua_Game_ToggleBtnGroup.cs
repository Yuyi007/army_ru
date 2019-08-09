using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_ToggleBtnGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegistToggleBtn(IntPtr l) {
		try {
			Game.ToggleBtnGroup self=(Game.ToggleBtnGroup)checkSelf(l);
			Game.ToggleButton a1;
			checkType(l,2,out a1);
			self.RegistToggleBtn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnregistToggleBtn(IntPtr l) {
		try {
			Game.ToggleBtnGroup self=(Game.ToggleBtnGroup)checkSelf(l);
			Game.ToggleButton a1;
			checkType(l,2,out a1);
			self.UnregistToggleBtn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SelectToggleBtn(IntPtr l) {
		try {
			Game.ToggleBtnGroup self=(Game.ToggleBtnGroup)checkSelf(l);
			Game.ToggleButton a1;
			checkType(l,2,out a1);
			self.SelectToggleBtn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curbtn(IntPtr l) {
		try {
			Game.ToggleBtnGroup self=(Game.ToggleBtnGroup)checkSelf(l);
			pushValue(l,self.curbtn);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curbtn(IntPtr l) {
		try {
			Game.ToggleBtnGroup self=(Game.ToggleBtnGroup)checkSelf(l);
			Game.ToggleButton v;
			checkType(l,2,out v);
			self.curbtn=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.ToggleBtnGroup");
		addMember(l,RegistToggleBtn);
		addMember(l,UnregistToggleBtn);
		addMember(l,SelectToggleBtn);
		addMember(l,"curbtn",get_curbtn,set_curbtn,true);
		createTypeMetatable(l,null, typeof(Game.ToggleBtnGroup),typeof(UnityEngine.MonoBehaviour));
	}
}
