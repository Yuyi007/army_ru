using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HoverTooltip : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTooltip(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(System.String[]))){
				UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
				System.String[] a1;
				checkType(l,2,out a1);
				self.SetTooltip(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.SetTooltip(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.SetTooltip(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnScreenSpaceCamera(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			self.OnScreenSpaceCamera();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideTooltip(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			self.HideTooltip();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ActivateTooltipVisibility(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			self.ActivateTooltipVisibility();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideTooltipVisibility(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			self.HideTooltipVisibility();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalPadding(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			pushValue(l,self.horizontalPadding);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalPadding(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.horizontalPadding=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalPadding(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			pushValue(l,self.verticalPadding);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalPadding(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.verticalPadding=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_thisText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			pushValue(l,self.thisText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_thisText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.thisText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hlG(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			pushValue(l,self.hlG);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hlG(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			UnityEngine.UI.HorizontalLayoutGroup v;
			checkType(l,2,out v);
			self.hlG=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			pushValue(l,self.bgImage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HoverTooltip self=(UnityEngine.UI.Extensions.HoverTooltip)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.bgImage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HoverTooltip");
		addMember(l,SetTooltip);
		addMember(l,OnScreenSpaceCamera);
		addMember(l,HideTooltip);
		addMember(l,ActivateTooltipVisibility);
		addMember(l,HideTooltipVisibility);
		addMember(l,"horizontalPadding",get_horizontalPadding,set_horizontalPadding,true);
		addMember(l,"verticalPadding",get_verticalPadding,set_verticalPadding,true);
		addMember(l,"thisText",get_thisText,set_thisText,true);
		addMember(l,"hlG",get_hlG,set_hlG,true);
		addMember(l,"bgImage",get_bgImage,set_bgImage,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.HoverTooltip),typeof(UnityEngine.MonoBehaviour));
	}
}
