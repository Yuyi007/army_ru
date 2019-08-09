using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_TextPic : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic o;
			o=new UnityEngine.UI.Extensions.TextPic();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetVerticesDirty(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			self.SetVerticesDirty();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerClick(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerClick(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerEnter(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerEnter(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerExit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerExit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSelect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSelect(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inspectorIconList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			pushValue(l,self.inspectorIconList);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inspectorIconList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.UI.Extensions.TextPic.IconName[] v;
			checkType(l,2,out v);
			self.inspectorIconList=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ImageScalingFactor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			pushValue(l,self.ImageScalingFactor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ImageScalingFactor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.ImageScalingFactor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hyperlinkColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			pushValue(l,self.hyperlinkColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hyperlinkColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.hyperlinkColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_imageOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			pushValue(l,self.imageOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_imageOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.imageOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onHrefClick(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			pushValue(l,self.onHrefClick);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onHrefClick(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TextPic self=(UnityEngine.UI.Extensions.TextPic)checkSelf(l);
			UnityEngine.UI.Extensions.TextPic.HrefClickEvent v;
			checkType(l,2,out v);
			self.onHrefClick=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.TextPic");
		addMember(l,SetVerticesDirty);
		addMember(l,OnPointerClick);
		addMember(l,OnPointerEnter);
		addMember(l,OnPointerExit);
		addMember(l,OnSelect);
		addMember(l,"inspectorIconList",get_inspectorIconList,set_inspectorIconList,true);
		addMember(l,"ImageScalingFactor",get_ImageScalingFactor,set_ImageScalingFactor,true);
		addMember(l,"hyperlinkColor",get_hyperlinkColor,set_hyperlinkColor,true);
		addMember(l,"imageOffset",get_imageOffset,set_imageOffset,true);
		addMember(l,"onHrefClick",get_onHrefClick,set_onHrefClick,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.TextPic),typeof(UnityEngine.UI.Text));
	}
}
