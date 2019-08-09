using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CinemaGlobalAction : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTime(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.UpdateTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int End(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			self.End();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTime(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
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
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReverseTrigger(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			self.ReverseTrigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReverseEnd(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			self.ReverseEnd();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompareTo(IntPtr l) {
		try {
			CinemaDirector.CinemaGlobalAction self=(CinemaDirector.CinemaGlobalAction)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.CompareTo(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CinemaGlobalAction");
		addMember(l,Trigger);
		addMember(l,UpdateTime);
		addMember(l,End);
		addMember(l,SetTime);
		addMember(l,Pause);
		addMember(l,Resume);
		addMember(l,ReverseTrigger);
		addMember(l,ReverseEnd);
		addMember(l,CompareTo);
		createTypeMetatable(l,null, typeof(CinemaDirector.CinemaGlobalAction),typeof(CinemaDirector.TimelineAction));
	}
}
