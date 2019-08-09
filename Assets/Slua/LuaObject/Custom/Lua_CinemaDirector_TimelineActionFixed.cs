using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_TimelineActionFixed : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_InTime(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			pushValue(l,self.InTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_InTime(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.InTime=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OutTime(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			pushValue(l,self.OutTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OutTime(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.OutTime=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemLength(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			pushValue(l,self.ItemLength);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemLength(IntPtr l) {
		try {
			CinemaDirector.TimelineActionFixed self=(CinemaDirector.TimelineActionFixed)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.ItemLength=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.TimelineActionFixed");
		addMember(l,"InTime",get_InTime,set_InTime,true);
		addMember(l,"OutTime",get_OutTime,set_OutTime,true);
		addMember(l,"ItemLength",get_ItemLength,set_ItemLength,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.TimelineActionFixed),typeof(CinemaDirector.TimelineAction));
	}
}
