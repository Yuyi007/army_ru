using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaUpdateBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaUpdateBehaviour o;
			o=new LBoot.LuaUpdateBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaUpdateBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaUpdateBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
