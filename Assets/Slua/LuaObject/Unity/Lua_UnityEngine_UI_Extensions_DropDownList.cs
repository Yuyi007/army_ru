using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DropDownList : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Start(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			self.Start();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToggleDropdownPanel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.ToggleDropdownPanel(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_disabledTextColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.disabledTextColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_disabledTextColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.disabledTextColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Items(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.Items);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Items(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UI.Extensions.DropDownListItem> v;
			checkType(l,2,out v);
			self.Items=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnSelectionChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.OnSelectionChanged=v;
			else if(op==1) self.OnSelectionChanged+=v;
			else if(op==2) self.OnSelectionChanged-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OverrideHighlighted(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.OverrideHighlighted);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OverrideHighlighted(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.OverrideHighlighted=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SelectedItem(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.SelectedItem);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScrollBarWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.ScrollBarWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ScrollBarWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.ScrollBarWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemsToDisplay(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			pushValue(l,self.ItemsToDisplay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemsToDisplay(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownList self=(UnityEngine.UI.Extensions.DropDownList)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.ItemsToDisplay=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DropDownList");
		addMember(l,Start);
		addMember(l,ToggleDropdownPanel);
		addMember(l,"disabledTextColor",get_disabledTextColor,set_disabledTextColor,true);
		addMember(l,"Items",get_Items,set_Items,true);
		addMember(l,"OnSelectionChanged",null,set_OnSelectionChanged,true);
		addMember(l,"OverrideHighlighted",get_OverrideHighlighted,set_OverrideHighlighted,true);
		addMember(l,"SelectedItem",get_SelectedItem,null,true);
		addMember(l,"ScrollBarWidth",get_ScrollBarWidth,set_ScrollBarWidth,true);
		addMember(l,"ItemsToDisplay",get_ItemsToDisplay,set_ItemsToDisplay,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.DropDownList),typeof(UnityEngine.MonoBehaviour));
	}
}
