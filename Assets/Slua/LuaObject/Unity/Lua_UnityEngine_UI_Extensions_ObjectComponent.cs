using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ObjectComponent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectComponent o;
			o=new UnityEngine.UI.Extensions.ObjectComponent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_componentName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectComponent self=(UnityEngine.UI.Extensions.ObjectComponent)checkSelf(l);
			pushValue(l,self.componentName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_componentName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectComponent self=(UnityEngine.UI.Extensions.ObjectComponent)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.componentName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fields(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectComponent self=(UnityEngine.UI.Extensions.ObjectComponent)checkSelf(l);
			pushValue(l,self.fields);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fields(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectComponent self=(UnityEngine.UI.Extensions.ObjectComponent)checkSelf(l);
			System.Collections.Generic.Dictionary<System.String,System.Object> v;
			checkType(l,2,out v);
			self.fields=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ObjectComponent");
		addMember(l,"componentName",get_componentName,set_componentName,true);
		addMember(l,"fields",get_fields,set_fields,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.ObjectComponent));
	}
}
