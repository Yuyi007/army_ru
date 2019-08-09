using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SelectionBox : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAllSelected(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			var ret=self.GetAllSelected();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			pushValue(l,self.color);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_art(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			pushValue(l,self.art);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_art(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.art=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectionMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			pushValue(l,self.selectionMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectionMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.selectionMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onSelectionChange(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			pushValue(l,self.onSelectionChange);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onSelectionChange(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SelectionBox self=(UnityEngine.UI.Extensions.SelectionBox)checkSelf(l);
			UnityEngine.UI.Extensions.SelectionBox.SelectionEvent v;
			checkType(l,2,out v);
			self.onSelectionChange=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SelectionBox");
		addMember(l,GetAllSelected);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"art",get_art,set_art,true);
		addMember(l,"selectionMask",get_selectionMask,set_selectionMask,true);
		addMember(l,"onSelectionChange",get_onSelectionChange,set_onSelectionChange,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.SelectionBox),typeof(UnityEngine.MonoBehaviour));
	}
}
