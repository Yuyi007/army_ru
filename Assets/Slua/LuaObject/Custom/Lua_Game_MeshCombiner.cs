using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_MeshCombiner : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Combine(IntPtr l) {
		try {
			Game.MeshCombiner self=(Game.MeshCombiner)checkSelf(l);
			self.Combine();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.MeshCombiner");
		addMember(l,Combine);
		createTypeMetatable(l,null, typeof(Game.MeshCombiner),typeof(UnityEngine.MonoBehaviour));
	}
}
