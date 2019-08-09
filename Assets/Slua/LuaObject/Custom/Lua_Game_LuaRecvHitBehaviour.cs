using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_LuaRecvHitBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.LuaRecvHitBehaviour o;
			o=new Game.LuaRecvHitBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.LuaRecvHitBehaviour");
		createTypeMetatable(l,constructor, typeof(Game.LuaRecvHitBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
