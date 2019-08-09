using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIScrollToSelection : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIScrollToSelection");
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIScrollToSelection),typeof(UnityEngine.MonoBehaviour));
	}
}
