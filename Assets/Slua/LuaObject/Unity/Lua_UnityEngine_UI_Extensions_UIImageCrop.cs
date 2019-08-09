using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIImageCrop : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetMaterial(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			self.SetMaterial();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnValidate(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			self.OnValidate();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetXCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetXCrop(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetYCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetYCrop(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_XCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			pushValue(l,self.XCrop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_XCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.XCrop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_YCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			pushValue(l,self.YCrop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_YCrop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIImageCrop self=(UnityEngine.UI.Extensions.UIImageCrop)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.YCrop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIImageCrop");
		addMember(l,SetMaterial);
		addMember(l,OnValidate);
		addMember(l,SetXCrop);
		addMember(l,SetYCrop);
		addMember(l,"XCrop",get_XCrop,set_XCrop,true);
		addMember(l,"YCrop",get_YCrop,set_YCrop,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIImageCrop),typeof(UnityEngine.MonoBehaviour));
	}
}
