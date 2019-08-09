using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ExtensionsToggleGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int NotifyToggleOn(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			UnityEngine.UI.ExtensionsToggle a1;
			checkType(l,2,out a1);
			self.NotifyToggleOn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnregisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			UnityEngine.UI.ExtensionsToggle a1;
			checkType(l,2,out a1);
			self.UnregisterToggle(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			UnityEngine.UI.ExtensionsToggle a1;
			checkType(l,2,out a1);
			self.RegisterToggle(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AnyTogglesOn(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			var ret=self.AnyTogglesOn();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ActiveToggles(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			var ret=self.ActiveToggles();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetAllTogglesOff(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			self.SetAllTogglesOff();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HasTheGroupToggle(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.HasTheGroupToggle(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HasAToggleFlipped(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.HasAToggleFlipped(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onToggleGroupChanged(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			pushValue(l,self.onToggleGroupChanged);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onToggleGroupChanged(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent v;
			checkType(l,2,out v);
			self.onToggleGroupChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onToggleGroupToggleChanged(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			pushValue(l,self.onToggleGroupToggleChanged);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onToggleGroupToggleChanged(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			UnityEngine.UI.ExtensionsToggleGroup.ToggleGroupEvent v;
			checkType(l,2,out v);
			self.onToggleGroupToggleChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_allowSwitchOff(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			pushValue(l,self.allowSwitchOff);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_allowSwitchOff(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.allowSwitchOff=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SelectedToggle(IntPtr l) {
		try {
			UnityEngine.UI.ExtensionsToggleGroup self=(UnityEngine.UI.ExtensionsToggleGroup)checkSelf(l);
			pushValue(l,self.SelectedToggle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ExtensionsToggleGroup");
		addMember(l,NotifyToggleOn);
		addMember(l,UnregisterToggle);
		addMember(l,RegisterToggle);
		addMember(l,AnyTogglesOn);
		addMember(l,ActiveToggles);
		addMember(l,SetAllTogglesOff);
		addMember(l,HasTheGroupToggle);
		addMember(l,HasAToggleFlipped);
		addMember(l,"onToggleGroupChanged",get_onToggleGroupChanged,set_onToggleGroupChanged,true);
		addMember(l,"onToggleGroupToggleChanged",get_onToggleGroupToggleChanged,set_onToggleGroupToggleChanged,true);
		addMember(l,"allowSwitchOff",get_allowSwitchOff,set_allowSwitchOff,true);
		addMember(l,"SelectedToggle",get_SelectedToggle,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ExtensionsToggleGroup),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
