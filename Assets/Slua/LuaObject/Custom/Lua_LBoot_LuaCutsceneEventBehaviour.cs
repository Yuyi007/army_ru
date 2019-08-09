using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaCutsceneEventBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaCutsceneEventBehaviour o;
			o=new LBoot.LuaCutsceneEventBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RefreshCutsceneHandlers(IntPtr l) {
		try {
			LBoot.LuaCutsceneEventBehaviour self=(LBoot.LuaCutsceneEventBehaviour)checkSelf(l);
			self.RefreshCutsceneHandlers();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaCutsceneEventBehaviour");
		addMember(l,RefreshCutsceneHandlers);
		createTypeMetatable(l,constructor, typeof(LBoot.LuaCutsceneEventBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
