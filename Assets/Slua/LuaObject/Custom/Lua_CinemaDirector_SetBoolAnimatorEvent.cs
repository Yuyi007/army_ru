using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_SetBoolAnimatorEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.SetBoolAnimatorEvent o;
			o=new CinemaDirector.SetBoolAnimatorEvent();
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
			CinemaDirector.SetBoolAnimatorEvent self=(CinemaDirector.SetBoolAnimatorEvent)checkSelf(l);
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
	static public int get_BoolName(IntPtr l) {
		try {
			CinemaDirector.SetBoolAnimatorEvent self=(CinemaDirector.SetBoolAnimatorEvent)checkSelf(l);
			pushValue(l,self.BoolName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BoolName(IntPtr l) {
		try {
			CinemaDirector.SetBoolAnimatorEvent self=(CinemaDirector.SetBoolAnimatorEvent)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.BoolName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Value(IntPtr l) {
		try {
			CinemaDirector.SetBoolAnimatorEvent self=(CinemaDirector.SetBoolAnimatorEvent)checkSelf(l);
			pushValue(l,self.Value);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Value(IntPtr l) {
		try {
			CinemaDirector.SetBoolAnimatorEvent self=(CinemaDirector.SetBoolAnimatorEvent)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.Value=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.SetBoolAnimatorEvent");
		addMember(l,Trigger);
		addMember(l,"BoolName",get_BoolName,set_BoolName,true);
		addMember(l,"Value",get_Value,set_Value,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.SetBoolAnimatorEvent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
