using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaApplicationBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaApplicationBehaviour o;
			o=new LBoot.LuaApplicationBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaApplicationBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaApplicationBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
