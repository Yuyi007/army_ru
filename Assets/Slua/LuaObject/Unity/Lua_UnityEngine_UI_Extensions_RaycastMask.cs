using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_RaycastMask : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RaycastMask self=(UnityEngine.UI.Extensions.RaycastMask)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.IsRaycastLocationValid(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.RaycastMask");
		addMember(l,IsRaycastLocationValid);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.RaycastMask),typeof(UnityEngine.MonoBehaviour));
	}
}
