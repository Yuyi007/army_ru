using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CrossFadeAnimatorEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent o;
			o=new CinemaDirector.CrossFadeAnimatorEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Trigger(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AnimationStateName(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			pushValue(l,self.AnimationStateName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_AnimationStateName(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.AnimationStateName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TransitionDuration(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			pushValue(l,self.TransitionDuration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_TransitionDuration(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.TransitionDuration=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Layer(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			pushValue(l,self.Layer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Layer(IntPtr l) {
		try {
			CinemaDirector.CrossFadeAnimatorEvent self=(CinemaDirector.CrossFadeAnimatorEvent)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.Layer=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CrossFadeAnimatorEvent");
		addMember(l,Trigger);
		addMember(l,"AnimationStateName",get_AnimationStateName,set_AnimationStateName,true);
		addMember(l,"TransitionDuration",get_TransitionDuration,set_TransitionDuration,true);
		addMember(l,"Layer",get_Layer,set_Layer,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.CrossFadeAnimatorEvent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
