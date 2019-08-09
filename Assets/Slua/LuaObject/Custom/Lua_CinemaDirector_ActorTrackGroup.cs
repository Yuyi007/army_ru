using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_ActorTrackGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.ActorTrackGroup o;
			o=new CinemaDirector.ActorTrackGroup();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cc(IntPtr l) {
		try {
			CinemaDirector.ActorTrackGroup self=(CinemaDirector.ActorTrackGroup)checkSelf(l);
			pushValue(l,self.cc);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Actor(IntPtr l) {
		try {
			CinemaDirector.ActorTrackGroup self=(CinemaDirector.ActorTrackGroup)checkSelf(l);
			pushValue(l,self.Actor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Actor(IntPtr l) {
		try {
			CinemaDirector.ActorTrackGroup self=(CinemaDirector.ActorTrackGroup)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.Actor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.ActorTrackGroup");
		addMember(l,"cc",get_cc,null,true);
		addMember(l,"Actor",get_Actor,set_Actor,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.ActorTrackGroup),typeof(CinemaDirector.TrackGroup));
	}
}
