using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_SetParent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.SetParent o;
			o=new CinemaDirector.SetParent();
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
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
	static public int CacheState(IntPtr l) {
		try {
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
			var ret=self.CacheState();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_parent(IntPtr l) {
		try {
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
			pushValue(l,self.parent);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_parent(IntPtr l) {
		try {
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.parent=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EditorRevertMode(IntPtr l) {
		try {
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
			CinemaDirector.SetParent self=(CinemaDirector.SetParent)checkSelf(l);
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
		getTypeTable(l,"CinemaDirector.SetParent");
		addMember(l,Trigger);
		addMember(l,Reverse);
		addMember(l,CacheState);
		addMember(l,"parent",get_parent,set_parent,true);
		addMember(l,"EditorRevertMode",get_EditorRevertMode,set_EditorRevertMode,true);
		addMember(l,"RuntimeRevertMode",get_RuntimeRevertMode,set_RuntimeRevertMode,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.SetParent),typeof(CinemaDirector.CinemaActorEvent));
	}
}
