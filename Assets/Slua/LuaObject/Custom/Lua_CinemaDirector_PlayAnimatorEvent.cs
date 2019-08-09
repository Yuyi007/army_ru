using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_PlayAnimatorEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.PlayAnimatorEvent o;
			o=new CinemaDirector.PlayAnimatorEvent();
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
			CinemaDirector.PlayAnimatorEvent self=(CinemaDirector.PlayAnimatorEvent)checkSelf(l);
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
	static public int get_StateName(IntPtr l) {
		try {
			CinemaDirector.PlayAnimatorEvent self=(CinemaDirector.PlayAnimatorEvent)checkSelf(l);
			pushValue(l,self.StateName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_StateName(IntPtr l) {
		try {
			CinemaDirector.PlayAnimatorEvent self=(CinemaDirector.PlayAnimatorEvent)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.StateName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Layer(IntPtr l) {
		try {
			CinemaDirector.PlayAnimatorEvent self=(CinemaDirector.PlayAnimatorEvent)checkSelf(l);
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
			CinemaDirector.PlayAnimatorEvent self=(CinemaDirector.PlayAnimatorEvent)checkSelf(l);
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
		getTypeTable(l,"CinemaDirector.PlayAnimatorEvent");
		addMember(l,Trigger);
		addMember(l,"StateName",get_StateName,set_StateName,true);
		addMember(l,"Layer",get_Layer,set_Layer,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.PlayAnimatorEvent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
