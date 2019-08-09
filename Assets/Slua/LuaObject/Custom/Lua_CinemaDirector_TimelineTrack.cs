using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_TimelineTrack : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Optimize(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			self.Optimize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Initialize(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			self.Initialize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTrack(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.UpdateTrack(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
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
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTime(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
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
	static public int GetMilestones(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.GetMilestones(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAllowedCutsceneItems(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			var ret=self.GetAllowedCutsceneItems();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTimelineItems(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			var ret=self.GetTimelineItems();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PlaybackMode(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushEnum(l,(int)self.PlaybackMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_PlaybackMode(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			CinemaDirector.PlaybackMode v;
			checkEnum(l,2,out v);
			self.PlaybackMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Cutscene(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushValue(l,self.Cutscene);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TrackGroup(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushValue(l,self.TrackGroup);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Ordinal(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushValue(l,self.Ordinal);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Ordinal(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.Ordinal=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CanOptimize(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushValue(l,self.CanOptimize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CanOptimize(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.CanOptimize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TimelineItems(IntPtr l) {
		try {
			CinemaDirector.TimelineTrack self=(CinemaDirector.TimelineTrack)checkSelf(l);
			pushValue(l,self.TimelineItems);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.TimelineTrack");
		addMember(l,Optimize);
		addMember(l,Initialize);
		addMember(l,UpdateTrack);
		addMember(l,Pause);
		addMember(l,Resume);
		addMember(l,SetTime);
		addMember(l,GetMilestones);
		addMember(l,Stop);
		addMember(l,GetAllowedCutsceneItems);
		addMember(l,GetTimelineItems);
		addMember(l,"PlaybackMode",get_PlaybackMode,set_PlaybackMode,true);
		addMember(l,"Cutscene",get_Cutscene,null,true);
		addMember(l,"TrackGroup",get_TrackGroup,null,true);
		addMember(l,"Ordinal",get_Ordinal,set_Ordinal,true);
		addMember(l,"CanOptimize",get_CanOptimize,set_CanOptimize,true);
		addMember(l,"TimelineItems",get_TimelineItems,null,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.TimelineTrack),typeof(UnityEngine.MonoBehaviour));
	}
}
