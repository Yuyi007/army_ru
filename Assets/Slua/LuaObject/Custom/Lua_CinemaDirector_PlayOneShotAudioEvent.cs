using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_PlayOneShotAudioEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.PlayOneShotAudioEvent o;
			o=new CinemaDirector.PlayOneShotAudioEvent();
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
			CinemaDirector.PlayOneShotAudioEvent self=(CinemaDirector.PlayOneShotAudioEvent)checkSelf(l);
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
	static public int get_Clip(IntPtr l) {
		try {
			CinemaDirector.PlayOneShotAudioEvent self=(CinemaDirector.PlayOneShotAudioEvent)checkSelf(l);
			pushValue(l,self.Clip);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Clip(IntPtr l) {
		try {
			CinemaDirector.PlayOneShotAudioEvent self=(CinemaDirector.PlayOneShotAudioEvent)checkSelf(l);
			UnityEngine.AudioClip v;
			checkType(l,2,out v);
			self.Clip=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_VolumeScale(IntPtr l) {
		try {
			CinemaDirector.PlayOneShotAudioEvent self=(CinemaDirector.PlayOneShotAudioEvent)checkSelf(l);
			pushValue(l,self.VolumeScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_VolumeScale(IntPtr l) {
		try {
			CinemaDirector.PlayOneShotAudioEvent self=(CinemaDirector.PlayOneShotAudioEvent)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.VolumeScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.PlayOneShotAudioEvent");
		addMember(l,Trigger);
		addMember(l,"Clip",get_Clip,set_Clip,true);
		addMember(l,"VolumeScale",get_VolumeScale,set_VolumeScale,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.PlayOneShotAudioEvent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
