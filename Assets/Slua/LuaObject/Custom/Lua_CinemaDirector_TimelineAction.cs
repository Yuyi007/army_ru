using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_TimelineAction : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetDefaults(IntPtr l) {
		try {
			CinemaDirector.TimelineAction self=(CinemaDirector.TimelineAction)checkSelf(l);
			self.SetDefaults();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Duration(IntPtr l) {
		try {
			CinemaDirector.TimelineAction self=(CinemaDirector.TimelineAction)checkSelf(l);
			pushValue(l,self.Duration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Duration(IntPtr l) {
		try {
			CinemaDirector.TimelineAction self=(CinemaDirector.TimelineAction)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Duration=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EndTime(IntPtr l) {
		try {
			CinemaDirector.TimelineAction self=(CinemaDirector.TimelineAction)checkSelf(l);
			pushValue(l,self.EndTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.TimelineAction");
		addMember(l,SetDefaults);
		addMember(l,"Duration",get_Duration,set_Duration,true);
		addMember(l,"EndTime",get_EndTime,null,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.TimelineAction),typeof(CinemaDirector.TimelineItem));
	}
}
