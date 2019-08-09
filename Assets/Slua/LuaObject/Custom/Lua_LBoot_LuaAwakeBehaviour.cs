using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaAwakeBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaAwakeBehaviour o;
			o=new LBoot.LuaAwakeBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaAwakeBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaAwakeBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
