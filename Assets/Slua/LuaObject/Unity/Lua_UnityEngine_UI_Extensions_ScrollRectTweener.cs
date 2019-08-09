using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollRectTweener : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollHorizontal(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.ScrollHorizontal(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.ScrollHorizontal(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollVertical(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.ScrollVertical(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.ScrollVertical(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Scroll(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				self.Scroll(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.Scroll(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EaseVector(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,3,out a2);
			UnityEngine.Vector2 a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			var ret=self.EaseVector(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_moveSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			pushValue(l,self.moveSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_moveSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.moveSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_disableDragWhileTweening(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			pushValue(l,self.disableDragWhileTweening);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_disableDragWhileTweening(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectTweener self=(UnityEngine.UI.Extensions.ScrollRectTweener)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.disableDragWhileTweening=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ScrollRectTweener");
		addMember(l,ScrollHorizontal);
		addMember(l,ScrollVertical);
		addMember(l,Scroll);
		addMember(l,EaseVector);
		addMember(l,OnDrag);
		addMember(l,"moveSpeed",get_moveSpeed,set_moveSpeed,true);
		addMember(l,"disableDragWhileTweening",get_disableDragWhileTweening,set_disableDragWhileTweening,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ScrollRectTweener),typeof(UnityEngine.MonoBehaviour));
	}
}
