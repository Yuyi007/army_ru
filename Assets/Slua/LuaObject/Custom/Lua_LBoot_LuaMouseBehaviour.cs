using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaMouseBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaMouseBehaviour o;
			o=new LBoot.LuaMouseBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaMouseBehaviour");
		createTypeMetatable(l,constructor, typeof(LBoot.LuaMouseBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
