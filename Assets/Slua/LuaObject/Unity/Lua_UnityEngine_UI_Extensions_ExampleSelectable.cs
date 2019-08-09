using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ExampleSelectable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selected(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ExampleSelectable self=(UnityEngine.UI.Extensions.ExampleSelectable)checkSelf(l);
			pushValue(l,self.selected);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selected(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ExampleSelectable self=(UnityEngine.UI.Extensions.ExampleSelectable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.selected=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_preSelected(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ExampleSelectable self=(UnityEngine.UI.Extensions.ExampleSelectable)checkSelf(l);
			pushValue(l,self.preSelected);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_preSelected(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ExampleSelectable self=(UnityEngine.UI.Extensions.ExampleSelectable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.preSelected=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ExampleSelectable");
		addMember(l,"selected",get_selected,set_selected,true);
		addMember(l,"preSelected",get_preSelected,set_preSelected,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ExampleSelectable),typeof(UnityEngine.MonoBehaviour));
	}
}
