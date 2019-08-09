using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableListElement : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListElement self=(UnityEngine.UI.Extensions.ReorderableListElement)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListElement self=(UnityEngine.UI.Extensions.ReorderableListElement)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListElement self=(UnityEngine.UI.Extensions.ReorderableListElement)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableListElement self=(UnityEngine.UI.Extensions.ReorderableListElement)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableListElement");
		addMember(l,OnBeginDrag);
		addMember(l,OnDrag);
		addMember(l,OnEndDrag);
		addMember(l,Init);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ReorderableListElement),typeof(UnityEngine.MonoBehaviour));
	}
}
