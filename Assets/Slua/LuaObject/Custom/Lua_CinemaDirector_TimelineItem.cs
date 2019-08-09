using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_TimelineItem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Initialize(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			self.Initialize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetDefaults(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
				self.SetDefaults();
				return 0;
			}
			else if(argc==2){
				CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
				UnityEngine.Object a1;
				checkType(l,2,out a1);
				self.SetDefaults(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Firetime(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			pushValue(l,self.Firetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Firetime(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Firetime=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Cutscene(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			pushValue(l,self.Cutscene);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TimelineTrack(IntPtr l) {
		try {
			CinemaDirector.TimelineItem self=(CinemaDirector.TimelineItem)checkSelf(l);
			pushValue(l,self.TimelineTrack);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.TimelineItem");
		addMember(l,Initialize);
		addMember(l,Stop);
		addMember(l,SetDefaults);
		addMember(l,"Firetime",get_Firetime,set_Firetime,true);
		addMember(l,"Cutscene",get_Cutscene,null,true);
		addMember(l,"TimelineTrack",get_TimelineTrack,null,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.TimelineItem),typeof(UnityEngine.MonoBehaviour));
	}
}
