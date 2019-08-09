using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaGizmoBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaGizmoBehaviour o;
			o=new LBoot.LuaGizmoBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaGizmoBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaGizmoBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
