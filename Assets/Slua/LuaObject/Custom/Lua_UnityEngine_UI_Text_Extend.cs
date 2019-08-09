using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Text_Extend : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend o;
			o=new UnityEngine.UI.Text_Extend();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearLinkCallback(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.ClearLinkCallback(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLinkCallback(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Action<System.String> a2;
			LuaDelegation.checkDelegate(l,3,out a2);
			self.SetLinkCallback(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearLinkCallbacks(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			self.ClearLinkCallbacks();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_linkObject(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			pushValue(l,self.linkObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_linkObject(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.linkObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OriginText(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			pushValue(l,self.OriginText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OriginText(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.OriginText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_processedText(IntPtr l) {
		try {
			UnityEngine.UI.Text_Extend self=(UnityEngine.UI.Text_Extend)checkSelf(l);
			pushValue(l,self.processedText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Text_Extend");
		addMember(l,ClearLinkCallback);
		addMember(l,SetLinkCallback);
		addMember(l,ClearLinkCallbacks);
		addMember(l,"linkObject",get_linkObject,set_linkObject,true);
		addMember(l,"OriginText",get_OriginText,set_OriginText,true);
		addMember(l,"processedText",get_processedText,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Text_Extend),typeof(UnityEngine.UI.Text));
	}
}
