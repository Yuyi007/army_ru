using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaCollisionBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaCollisionBehaviour o;
			o=new LBoot.LuaCollisionBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaCollisionBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaCollisionBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
