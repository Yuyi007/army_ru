using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableListDebug : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DebugLabel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListDebug self=(UnityEngine.UI.Extensions.ReorderableListDebug)checkSelf(l);
			pushValue(l,self.DebugLabel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DebugLabel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListDebug self=(UnityEngine.UI.Extensions.ReorderableListDebug)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.DebugLabel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableListDebug");
		addMember(l,"DebugLabel",get_DebugLabel,set_DebugLabel,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ReorderableListDebug),typeof(UnityEngine.MonoBehaviour));
	}
}
