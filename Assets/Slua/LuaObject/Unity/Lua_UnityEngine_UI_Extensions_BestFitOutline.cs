using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_BestFitOutline : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ModifyMesh(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BestFitOutline self=(UnityEngine.UI.Extensions.BestFitOutline)checkSelf(l);
			UnityEngine.Mesh a1;
			checkType(l,2,out a1);
			self.ModifyMesh(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.BestFitOutline");
		addMember(l,ModifyMesh);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.BestFitOutline),typeof(UnityEngine.UI.Shadow));
	}
}
