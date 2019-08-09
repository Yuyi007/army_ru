using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaVisibleBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaVisibleBehaviour o;
			o=new LBoot.LuaVisibleBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaVisibleBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaVisibleBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
