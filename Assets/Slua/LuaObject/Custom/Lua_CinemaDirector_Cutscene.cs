using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_Cutscene : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Optimize(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Optimize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Play();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Pause();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Skip(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Skip();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateCutscene(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.UpdateCutscene(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PreviewPlay(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.PreviewPlay();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrubToTime(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.ScrubToTime(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRunningTime(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
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
	static public int EnterPreviewMode(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.EnterPreviewMode();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ExitPreviewMode(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.ExitPreviewMode();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Refresh(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.Refresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTrackGroups(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			var ret=self.GetTrackGroups();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PreparePlay(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			self.PreparePlay();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UseFastEval(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.UseFastEval);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UseFastEval(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.UseFastEval=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Duration(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.Duration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Duration(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Duration=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_State(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushEnum(l,(int)self.State);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RunningTime(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.RunningTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RunningTime(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.RunningTime=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TrackGroups(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.TrackGroups);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DirectorGroup(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.DirectorGroup);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CanOptimize(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
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
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
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
	static public int get_IsSkippable(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.IsSkippable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsSkippable(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.IsSkippable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsLooping(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			pushValue(l,self.IsLooping);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsLooping(IntPtr l) {
		try {
			CinemaDirector.Cutscene self=(CinemaDirector.Cutscene)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.IsLooping=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.Cutscene");
		addMember(l,Optimize);
		addMember(l,Play);
		addMember(l,Pause);
		addMember(l,Skip);
		addMember(l,Stop);
		addMember(l,UpdateCutscene);
		addMember(l,PreviewPlay);
		addMember(l,ScrubToTime);
		addMember(l,SetRunningTime);
		addMember(l,EnterPreviewMode);
		addMember(l,ExitPreviewMode);
		addMember(l,Refresh);
		addMember(l,GetTrackGroups);
		addMember(l,PreparePlay);
		addMember(l,"UseFastEval",get_UseFastEval,set_UseFastEval,true);
		addMember(l,"Duration",get_Duration,set_Duration,true);
		addMember(l,"State",get_State,null,true);
		addMember(l,"RunningTime",get_RunningTime,set_RunningTime,true);
		addMember(l,"TrackGroups",get_TrackGroups,null,true);
		addMember(l,"DirectorGroup",get_DirectorGroup,null,true);
		addMember(l,"CanOptimize",get_CanOptimize,set_CanOptimize,true);
		addMember(l,"IsSkippable",get_IsSkippable,set_IsSkippable,true);
		addMember(l,"IsLooping",get_IsLooping,set_IsLooping,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.Cutscene),typeof(UnityEngine.MonoBehaviour));
	}
}
