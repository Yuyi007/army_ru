using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_RescaleDragPanel : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescaleDragPanel self=(UnityEngine.UI.Extensions.RescaleDragPanel)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.RescaleDragPanel self=(UnityEngine.UI.Extensions.RescaleDragPanel)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.RescaleDragPanel");
		addMember(l,OnPointerDown);
		addMember(l,OnDrag);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.RescaleDragPanel),typeof(UnityEngine.MonoBehaviour));
	}
}
