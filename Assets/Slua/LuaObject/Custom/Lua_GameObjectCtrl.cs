using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GameObjectCtrl : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			GameObjectCtrl self=(GameObjectCtrl)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ctrlObjects(IntPtr l) {
		try {
			GameObjectCtrl self=(GameObjectCtrl)checkSelf(l);
			pushValue(l,self.ctrlObjects);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ctrlObjects(IntPtr l) {
		try {
			GameObjectCtrl self=(GameObjectCtrl)checkSelf(l);
			UnityEngine.GameObject[] v;
			checkType(l,2,out v);
			self.ctrlObjects=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			GameObjectCtrl self=(GameObjectCtrl)checkSelf(l);
			pushValue(l,self.enabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			GameObjectCtrl self=(GameObjectCtrl)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.enabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GameObjectCtrl");
		addMember(l,DoRefresh);
		addMember(l,"ctrlObjects",get_ctrlObjects,set_ctrlObjects,true);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		createTypeMetatable(l,null, typeof(GameObjectCtrl),typeof(UnityEngine.MonoBehaviour));
	}
}
