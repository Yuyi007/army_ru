using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CinemaAudio : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio o;
			o=new CinemaDirector.CinemaAudio();
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
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int End(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			self.End();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTime(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
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
	static public int Resume(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			self.Pause();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTime(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetTime(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetDefaults(IntPtr l) {
		try {
			CinemaDirector.CinemaAudio self=(CinemaDirector.CinemaAudio)checkSelf(l);
			UnityEngine.Object a1;
			checkType(l,2,out a1);
			self.SetDefaults(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CinemaAudio");
		addMember(l,Trigger);
		addMember(l,End);
		addMember(l,UpdateTime);
		addMember(l,Resume);
		addMember(l,Pause);
		addMember(l,Stop);
		addMember(l,SetTime);
		addMember(l,SetDefaults);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.CinemaAudio),typeof(CinemaDirector.TimelineActionFixed));
	}
}
