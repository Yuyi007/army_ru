using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CinemaActorEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
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
	static public int Reverse(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Reverse(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTimeTo(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetTimeTo(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			self.Pause();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Resume(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Initialize(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Initialize(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Stop(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetActors(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			var ret=self.GetActors();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ActorTrackGroup(IntPtr l) {
		try {
			CinemaDirector.CinemaActorEvent self=(CinemaDirector.CinemaActorEvent)checkSelf(l);
			pushValue(l,self.ActorTrackGroup);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CinemaActorEvent");
		addMember(l,Trigger);
		addMember(l,Reverse);
		addMember(l,SetTimeTo);
		addMember(l,Pause);
		addMember(l,Resume);
		addMember(l,Initialize);
		addMember(l,Stop);
		addMember(l,GetActors);
		addMember(l,"ActorTrackGroup",get_ActorTrackGroup,null,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.CinemaActorEvent),typeof(CinemaDirector.TimelineItem));
	}
}
