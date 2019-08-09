using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ColorPickerTester : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pickerRenderer(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorPickerTester self=(UnityEngine.UI.Extensions.ColorPickerTester)checkSelf(l);
			pushValue(l,self.pickerRenderer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pickerRenderer(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorPickerTester self=(UnityEngine.UI.Extensions.ColorPickerTester)checkSelf(l);
			UnityEngine.Renderer v;
			checkType(l,2,out v);
			self.pickerRenderer=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_picker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorPickerTester self=(UnityEngine.UI.Extensions.ColorPickerTester)checkSelf(l);
			pushValue(l,self.picker);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_picker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorPickerTester self=(UnityEngine.UI.Extensions.ColorPickerTester)checkSelf(l);
			UnityEngine.UI.Extensions.HSVPicker v;
			checkType(l,2,out v);
			self.picker=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ColorPickerTester");
		addMember(l,"pickerRenderer",get_pickerRenderer,set_pickerRenderer,true);
		addMember(l,"picker",get_picker,set_picker,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ColorPickerTester),typeof(UnityEngine.MonoBehaviour));
	}
}
