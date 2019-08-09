using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_BindDropdownData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetItems(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.SetItems(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearDropdownData(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			self.ClearDropdownData();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RefreshDropdownData(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			self.RefreshDropdownData();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dropdown(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			pushValue(l,self.dropdown);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dropdown(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			UnityEngine.UI.Dropdown v;
			checkType(l,2,out v);
			self.dropdown=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_list(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			pushValue(l,self.list);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_list(IntPtr l) {
		try {
			BindDropdownData self=(BindDropdownData)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> v;
			checkType(l,2,out v);
			self.list=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"BindDropdownData");
		addMember(l,SetItems);
		addMember(l,ClearDropdownData);
		addMember(l,RefreshDropdownData);
		addMember(l,"dropdown",get_dropdown,set_dropdown,true);
		addMember(l,"list",get_list,set_list,true);
		createTypeMetatable(l,null, typeof(BindDropdownData),typeof(UnityEngine.MonoBehaviour));
	}
}
