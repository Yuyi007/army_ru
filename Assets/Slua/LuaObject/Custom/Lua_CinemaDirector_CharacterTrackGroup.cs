using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_CharacterTrackGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup o;
			o=new CinemaDirector.CharacterTrackGroup();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Bake(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			self.Bake();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CacheState(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			var ret=self.CacheState();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Initialize(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			self.Initialize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTrackGroup(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.UpdateTrackGroup(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRunningTime(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetRunningTime(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EditorRevertMode(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			pushEnum(l,(int)self.EditorRevertMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_EditorRevertMode(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			CinemaDirector.RevertMode v;
			checkEnum(l,2,out v);
			self.EditorRevertMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RuntimeRevertMode(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			pushEnum(l,(int)self.RuntimeRevertMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RuntimeRevertMode(IntPtr l) {
		try {
			CinemaDirector.CharacterTrackGroup self=(CinemaDirector.CharacterTrackGroup)checkSelf(l);
			CinemaDirector.RevertMode v;
			checkEnum(l,2,out v);
			self.RuntimeRevertMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.CharacterTrackGroup");
		addMember(l,Bake);
		addMember(l,CacheState);
		addMember(l,Initialize);
		addMember(l,UpdateTrackGroup);
		addMember(l,SetRunningTime);
		addMember(l,Stop);
		addMember(l,"EditorRevertMode",get_EditorRevertMode,set_EditorRevertMode,true);
		addMember(l,"RuntimeRevertMode",get_RuntimeRevertMode,set_RuntimeRevertMode,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.CharacterTrackGroup),typeof(CinemaDirector.ActorTrackGroup));
	}
}
