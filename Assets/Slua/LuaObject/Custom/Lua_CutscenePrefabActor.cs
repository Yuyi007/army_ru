using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CutscenePrefabActor : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_prefabPath(IntPtr l) {
		try {
			CutscenePrefabActor self=(CutscenePrefabActor)checkSelf(l);
			pushValue(l,self.prefabPath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_prefabPath(IntPtr l) {
		try {
			CutscenePrefabActor self=(CutscenePrefabActor)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.prefabPath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CutscenePrefabActor");
		addMember(l,"prefabPath",get_prefabPath,set_prefabPath,true);
		createTypeMetatable(l,null, typeof(CutscenePrefabActor),typeof(UnityEngine.MonoBehaviour));
	}
}
