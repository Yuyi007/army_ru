using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaAnimatorBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaAnimatorBehaviour o;
			o=new LBoot.LuaAnimatorBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaAnimatorBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaAnimatorBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
