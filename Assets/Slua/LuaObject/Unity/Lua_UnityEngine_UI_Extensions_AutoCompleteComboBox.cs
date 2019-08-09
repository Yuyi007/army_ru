using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_AutoCompleteComboBox : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Awake(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			self.Awake();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.OnValueChanged(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToggleDropdownPanel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
	static public int get_AvailableOptions(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			pushValue(l,self.AvailableOptions);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_AvailableOptions(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			System.Collections.Generic.List<System.String> v;
			checkType(l,2,out v);
			self.AvailableOptions=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnSelectionChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
	static public int get_SelectedItem(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			pushValue(l,self.SelectedItem);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Text(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
			pushValue(l,self.Text);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScrollBarWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
			UnityEngine.UI.Extensions.AutoCompleteComboBox self=(UnityEngine.UI.Extensions.AutoCompleteComboBox)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.Extensions.AutoCompleteComboBox");
		addMember(l,Awake);
		addMember(l,OnValueChanged);
		addMember(l,ToggleDropdownPanel);
		addMember(l,"disabledTextColor",get_disabledTextColor,set_disabledTextColor,true);
		addMember(l,"AvailableOptions",get_AvailableOptions,set_AvailableOptions,true);
		addMember(l,"OnSelectionChanged",null,set_OnSelectionChanged,true);
		addMember(l,"SelectedItem",get_SelectedItem,null,true);
		addMember(l,"Text",get_Text,null,true);
		addMember(l,"ScrollBarWidth",get_ScrollBarWidth,set_ScrollBarWidth,true);
		addMember(l,"ItemsToDisplay",get_ItemsToDisplay,set_ItemsToDisplay,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.AutoCompleteComboBox),typeof(UnityEngine.MonoBehaviour));
	}
}
