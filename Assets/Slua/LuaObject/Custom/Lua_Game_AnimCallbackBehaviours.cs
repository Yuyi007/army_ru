using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_AnimCallbackBehaviours : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.AnimCallbackBehaviours o;
			o=new Game.AnimCallbackBehaviours();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.AnimCallbackBehaviours");
		createTypeMetatable(l,constructor, typeof(Game.AnimCallbackBehaviours),typeof(LBoot.LuaBaseBehaviour));
	}
}
