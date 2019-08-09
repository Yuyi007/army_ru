using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CinemaGlobalEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalEvent self=(CinemaDirector.CinemaGlobalEvent)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reverse(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalEvent self=(CinemaDirector.CinemaGlobalEvent)checkSelf(l);
			self.Reverse();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CinemaGlobalEvent");
		addMember(l,Trigger);
		addMember(l,Reverse);
		createTypeMetatable(l,null, typeof(CinemaDirector.CinemaGlobalEvent),typeof(CinemaDirector.TimelineItem));
	}
}
