﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_PPIViewer : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.PPIViewer");
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.PPIViewer),typeof(UnityEngine.MonoBehaviour));
	}
}
