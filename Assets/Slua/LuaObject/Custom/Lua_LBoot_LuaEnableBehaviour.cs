using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaEnableBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaEnableBehaviour o;
			o=new LBoot.LuaEnableBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaEnableBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaEnableBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
