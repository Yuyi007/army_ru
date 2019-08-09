using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_DisableGameObjectGlobal : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal o;
			o=new CinemaDirector.DisableGameObjectGlobal();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CacheState(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
			var ret=self.CacheState();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trigger(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reverse(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
			self.Reverse();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
			pushValue(l,self.target);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.target=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EditorRevertMode(IntPtr l) {
		try {
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
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
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
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
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
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
			CinemaDirector.DisableGameObjectGlobal self=(CinemaDirector.DisableGameObjectGlobal)checkSelf(l);
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
		getTypeTable(l,"CinemaDirector.DisableGameObjectGlobal");
		addMember(l,CacheState);
		addMember(l,Trigger);
		addMember(l,Reverse);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"EditorRevertMode",get_EditorRevertMode,set_EditorRevertMode,true);
		addMember(l,"RuntimeRevertMode",get_RuntimeRevertMode,set_RuntimeRevertMode,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.DisableGameObjectGlobal),typeof(CinemaDirector.CinemaGlobalEvent));
	}
}
