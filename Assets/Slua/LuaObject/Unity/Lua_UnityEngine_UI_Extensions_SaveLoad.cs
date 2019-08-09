using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SaveLoad : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Save_s(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveGame a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.SaveLoad.Save(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Load_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.Extensions.SaveLoad.Load(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_saveGamePath(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Extensions.SaveLoad.saveGamePath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_saveGamePath(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			UnityEngine.UI.Extensions.SaveLoad.saveGamePath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SaveLoad");
		addMember(l,Save_s);
		addMember(l,Load_s);
		addMember(l,"saveGamePath",get_saveGamePath,set_saveGamePath,false);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.SaveLoad));
	}
}
