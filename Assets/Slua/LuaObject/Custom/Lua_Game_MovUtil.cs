using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_MovUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.MovUtil o;
			o=new Game.MovUtil();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playMovName_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.MovUtil.playMovName(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playMovNameWithControl_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.MovUtil.playMovNameWithControl(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playMovNameNonInteractive_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.MovUtil.playMovNameNonInteractive(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playMovNameNormal_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.MovUtil.playMovNameNormal(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.MovUtil");
		addMember(l,playMovName_s);
		addMember(l,playMovNameWithControl_s);
		addMember(l,playMovNameNonInteractive_s);
		addMember(l,playMovNameNormal_s);
		createTypeMetatable(l,constructor, typeof(Game.MovUtil));
	}
}
