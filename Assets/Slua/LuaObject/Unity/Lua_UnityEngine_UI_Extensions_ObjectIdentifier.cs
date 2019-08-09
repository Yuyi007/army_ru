using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ObjectIdentifier : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetID(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			self.SetID();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_prefabName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			pushValue(l,self.prefabName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_prefabName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.prefabName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			pushValue(l,self.id);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.id=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_idParent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			pushValue(l,self.idParent);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_idParent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.idParent=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dontSave(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			pushValue(l,self.dontSave);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dontSave(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ObjectIdentifier self=(UnityEngine.UI.Extensions.ObjectIdentifier)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.dontSave=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ObjectIdentifier");
		addMember(l,SetID);
		addMember(l,"prefabName",get_prefabName,set_prefabName,true);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"idParent",get_idParent,set_idParent,true);
		addMember(l,"dontSave",get_dontSave,set_dontSave,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ObjectIdentifier),typeof(UnityEngine.MonoBehaviour));
	}
}
