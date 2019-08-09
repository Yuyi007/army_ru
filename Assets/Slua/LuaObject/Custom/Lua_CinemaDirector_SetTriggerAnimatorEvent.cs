using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_SetTriggerAnimatorEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.SetTriggerAnimatorEvent o;
			o=new CinemaDirector.SetTriggerAnimatorEvent();
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
			CinemaDirector.SetTriggerAnimatorEvent self=(CinemaDirector.SetTriggerAnimatorEvent)checkSelf(l);
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
	static public int get_Name(IntPtr l) {
		try {
			CinemaDirector.SetTriggerAnimatorEvent self=(CinemaDirector.SetTriggerAnimatorEvent)checkSelf(l);
			pushValue(l,self.Name);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Name(IntPtr l) {
		try {
			CinemaDirector.SetTriggerAnimatorEvent self=(CinemaDirector.SetTriggerAnimatorEvent)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.Name=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.SetTriggerAnimatorEvent");
		addMember(l,Trigger);
		addMember(l,"Name",get_Name,set_Name,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.SetTriggerAnimatorEvent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
