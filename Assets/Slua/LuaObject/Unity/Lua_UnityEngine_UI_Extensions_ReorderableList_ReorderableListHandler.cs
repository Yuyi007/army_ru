using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableList_ReorderableListHandler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler o;
			o=new UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_UnityEngine_UI_Extensions_ReorderableList_ReorderableListEventStruct.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler),typeof(LuaUnityEvent_UnityEngine_UI_Extensions_ReorderableList_ReorderableListEventStruct));
	}
}
