using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DragCorrector : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_baseTH(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			pushValue(l,self.baseTH);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_baseTH(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.baseTH=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_basePPI(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			pushValue(l,self.basePPI);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_basePPI(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.basePPI=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragTH(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			pushValue(l,self.dragTH);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragTH(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DragCorrector self=(UnityEngine.UI.Extensions.DragCorrector)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.dragTH=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DragCorrector");
		addMember(l,"baseTH",get_baseTH,set_baseTH,true);
		addMember(l,"basePPI",get_basePPI,set_basePPI,true);
		addMember(l,"dragTH",get_dragTH,set_dragTH,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.DragCorrector),typeof(UnityEngine.MonoBehaviour));
	}
}
