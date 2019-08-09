using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_TextPic_IconName : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.IconName o;
			o=new UnityEngine.UI.Extensions.TextPic.IconName();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.IconName self;
			checkValueType(l,1,out self);
			pushValue(l,self.name);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_name(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.IconName self;
			checkValueType(l,1,out self);
			System.String v;
			checkType(l,2,out v);
			self.name=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.IconName self;
			checkValueType(l,1,out self);
			pushValue(l,self.sprite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic.IconName self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.sprite=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.TextPic.IconName");
		addMember(l,"name",get_name,set_name,true);
		addMember(l,"sprite",get_sprite,set_sprite,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.TextPic.IconName),typeof(System.ValueType));
	}
}
