using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaCameraBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaCameraBehaviour o;
			o=new LBoot.LuaCameraBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaCameraBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaCameraBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
