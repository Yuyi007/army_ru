using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableListContent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnTransformChildrenChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListContent self=(UnityEngine.UI.Extensions.ReorderableListContent)checkSelf(l);
			self.OnTransformChildrenChanged();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListContent self=(UnityEngine.UI.Extensions.ReorderableListContent)checkSelf(l);
			UnityEngine.UI.Extensions.ReorderableList a1;
			checkType(l,2,out a1);
			self.Init(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableListContent");
		addMember(l,OnTransformChildrenChanged);
		addMember(l,Init);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ReorderableListContent),typeof(UnityEngine.MonoBehaviour));
	}
}
