using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UISelectableExtension_UIButtonEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent o;
			o=new UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_UnityEngine_EventSystems_PointerEventData_InputButton.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent),typeof(LuaUnityEvent_UnityEngine_EventSystems_PointerEventData_InputButton));
	}
}
