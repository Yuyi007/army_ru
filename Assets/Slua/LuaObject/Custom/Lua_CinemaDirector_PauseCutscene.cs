using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_PauseCutscene : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.PauseCutscene o;
			o=new CinemaDirector.PauseCutscene();
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
			CinemaDirector.PauseCutscene self=(CinemaDirector.PauseCutscene)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutscene(IntPtr l) {
		try {
			CinemaDirector.PauseCutscene self=(CinemaDirector.PauseCutscene)checkSelf(l);
			pushValue(l,self.cutscene);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutscene(IntPtr l) {
		try {
			CinemaDirector.PauseCutscene self=(CinemaDirector.PauseCutscene)checkSelf(l);
			CinemaDirector.Cutscene v;
			checkType(l,2,out v);
			self.cutscene=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.PauseCutscene");
		addMember(l,Trigger);
		addMember(l,"cutscene",get_cutscene,set_cutscene,true);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.PauseCutscene),typeof(CinemaDirector.CinemaGlobalEvent));
	}
}
