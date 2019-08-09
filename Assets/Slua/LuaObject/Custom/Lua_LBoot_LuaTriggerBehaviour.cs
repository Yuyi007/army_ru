using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaTriggerBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaTriggerBehaviour o;
			o=new LBoot.LuaTriggerBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaTriggerBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaTriggerBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
