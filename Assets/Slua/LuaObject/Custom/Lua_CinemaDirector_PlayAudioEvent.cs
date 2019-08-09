using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_PlayAudioEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent o;
			o=new CinemaDirector.PlayAudioEvent();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Update(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			self.Update();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
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
	static public int UpdateTime(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.UpdateTime(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Resume(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Resume(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.Pause(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int End(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.End(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_audioClip(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			pushValue(l,self.audioClip);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_audioClip(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			UnityEngine.AudioClip v;
			checkType(l,2,out v);
			self.audioClip=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loop(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			pushValue(l,self.loop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loop(IntPtr l) {
		try {
			CinemaDirector.PlayAudioEvent self=(CinemaDirector.PlayAudioEvent)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.loop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.PlayAudioEvent");
		addMember(l,Update);
		addMember(l,Trigger);
		addMember(l,UpdateTime);
		addMember(l,Resume);
		addMember(l,Pause);
		addMember(l,End);
		addMember(l,"audioClip",get_audioClip,set_audioClip,true);
		addMember(l,"loop",get_loop,set_loop,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.PlayAudioEvent),typeof(CinemaDirector.CinemaActorAction));
	}
}
