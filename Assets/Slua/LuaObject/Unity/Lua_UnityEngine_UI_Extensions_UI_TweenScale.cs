using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UI_TweenScale : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			self.Play();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetTween(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			self.ResetTween();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_animCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.animCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_animCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.animCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_speed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.speed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_speed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.speed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isLoop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.isLoop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isLoop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isLoop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_playAtAwake(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.playAtAwake);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_playAtAwake(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.playAtAwake=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isUniform(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.isUniform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isUniform(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isUniform=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_animCurveY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			pushValue(l,self.animCurveY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_animCurveY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_TweenScale self=(UnityEngine.UI.Extensions.UI_TweenScale)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.animCurveY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UI_TweenScale");
		addMember(l,Play);
		addMember(l,ResetTween);
		addMember(l,"animCurve",get_animCurve,set_animCurve,true);
		addMember(l,"speed",get_speed,set_speed,true);
		addMember(l,"isLoop",get_isLoop,set_isLoop,true);
		addMember(l,"playAtAwake",get_playAtAwake,set_playAtAwake,true);
		addMember(l,"isUniform",get_isUniform,set_isUniform,true);
		addMember(l,"animCurveY",get_animCurveY,set_animCurveY,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UI_TweenScale),typeof(UnityEngine.MonoBehaviour));
	}
}
