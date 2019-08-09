using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Tweens_FloatTween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween o;
			o=new UnityEngine.UI.Extensions.Tweens.FloatTween();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TweenValue(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.TweenValue(a1);
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddOnChangedCallback(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			UnityEngine.Events.UnityAction<System.Single> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.AddOnChangedCallback(a1);
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddOnFinishCallback(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			UnityEngine.Events.UnityAction a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.AddOnFinishCallback(a1);
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetIgnoreTimescale(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			var ret=self.GetIgnoreTimescale();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDuration(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			var ret=self.GetDuration();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ValidTarget(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			var ret=self.ValidTarget();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Finished(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			self.Finished();
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startFloat(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			pushValue(l,self.startFloat);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startFloat(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startFloat=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_targetFloat(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			pushValue(l,self.targetFloat);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_targetFloat(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.targetFloat=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duration(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			pushValue(l,self.duration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duration(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.duration=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreTimeScale(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			pushValue(l,self.ignoreTimeScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreTimeScale(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.ignoreTimeScale=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.Tweens.FloatTween");
		addMember(l,TweenValue);
		addMember(l,AddOnChangedCallback);
		addMember(l,AddOnFinishCallback);
		addMember(l,GetIgnoreTimescale);
		addMember(l,GetDuration);
		addMember(l,ValidTarget);
		addMember(l,Finished);
		addMember(l,"startFloat",get_startFloat,set_startFloat,true);
		addMember(l,"targetFloat",get_targetFloat,set_targetFloat,true);
		addMember(l,"duration",get_duration,set_duration,true);
		addMember(l,"ignoreTimeScale",get_ignoreTimeScale,set_ignoreTimeScale,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.Tweens.FloatTween),typeof(System.ValueType));
	}
}
