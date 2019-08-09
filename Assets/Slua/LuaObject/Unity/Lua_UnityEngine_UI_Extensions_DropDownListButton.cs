using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DropDownListButton : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton o;
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			o=new UnityEngine.UI.Extensions.DropDownListButton(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.rectTransform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.rectTransform=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_btn(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.btn);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_btn(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.UI.Button v;
			checkType(l,2,out v);
			self.btn=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_txt(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.txt);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_txt(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.txt=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_btnImg(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.btnImg);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_btnImg(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.btnImg=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_img(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.img);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_img(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.img=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gameobject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			pushValue(l,self.gameobject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gameobject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListButton self=(UnityEngine.UI.Extensions.DropDownListButton)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.gameobject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DropDownListButton");
		addMember(l,"rectTransform",get_rectTransform,set_rectTransform,true);
		addMember(l,"btn",get_btn,set_btn,true);
		addMember(l,"txt",get_txt,set_txt,true);
		addMember(l,"btnImg",get_btnImg,set_btnImg,true);
		addMember(l,"img",get_img,set_img,true);
		addMember(l,"gameobject",get_gameobject,set_gameobject,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.DropDownListButton));
	}
}
