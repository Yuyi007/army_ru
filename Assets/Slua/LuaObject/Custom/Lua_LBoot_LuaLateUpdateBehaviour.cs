using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaLateUpdateBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaLateUpdateBehaviour o;
			o=new LBoot.LuaLateUpdateBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaLateUpdateBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaLateUpdateBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
