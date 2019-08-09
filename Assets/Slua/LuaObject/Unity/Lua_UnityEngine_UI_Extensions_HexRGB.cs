using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HexRGB : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ManipulateViaRGB2Hex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			self.ManipulateViaRGB2Hex();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ManipulateViaHex2RGB(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			self.ManipulateViaHex2RGB();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ColorToHex_s(IntPtr l) {
		try {
			UnityEngine.Color a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.Extensions.HexRGB.ColorToHex(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hexInput(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			pushValue(l,self.hexInput);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hexInput(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			UnityEngine.UI.InputField v;
			checkType(l,2,out v);
			self.hexInput=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hsvpicker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			pushValue(l,self.hsvpicker);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hsvpicker(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HexRGB self=(UnityEngine.UI.Extensions.HexRGB)checkSelf(l);
			UnityEngine.UI.Extensions.HSVPicker v;
			checkType(l,2,out v);
			self.hsvpicker=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HexRGB");
		addMember(l,ManipulateViaRGB2Hex);
		addMember(l,ManipulateViaHex2RGB);
		addMember(l,ColorToHex_s);
		addMember(l,"hexInput",get_hexInput,set_hexInput,true);
		addMember(l,"hsvpicker",get_hsvpicker,set_hsvpicker,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.HexRGB),typeof(UnityEngine.MonoBehaviour));
	}
}
