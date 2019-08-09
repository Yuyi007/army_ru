using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UI_Sources_TextWithIcon : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UI.Sources.TextWithIcon o;
			o=new UI.Sources.TextWithIcon();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sizeDelta(IntPtr l) {
		try {
			UI.Sources.TextWithIcon self=(UI.Sources.TextWithIcon)checkSelf(l);
			pushValue(l,self.sizeDelta);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sizeDelta(IntPtr l) {
		try {
			UI.Sources.TextWithIcon self=(UI.Sources.TextWithIcon)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.sizeDelta=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OriginText(IntPtr l) {
		try {
			UI.Sources.TextWithIcon self=(UI.Sources.TextWithIcon)checkSelf(l);
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
			UI.Sources.TextWithIcon self=(UI.Sources.TextWithIcon)checkSelf(l);
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
			UI.Sources.TextWithIcon self=(UI.Sources.TextWithIcon)checkSelf(l);
			pushValue(l,self.processedText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UI.Sources.TextWithIcon");
		addMember(l,"sizeDelta",get_sizeDelta,set_sizeDelta,true);
		addMember(l,"OriginText",get_OriginText,set_OriginText,true);
		addMember(l,"processedText",get_processedText,null,true);
		createTypeMetatable(l,constructor, typeof(UI.Sources.TextWithIcon),typeof(UnityEngine.UI.Text));
	}
}
