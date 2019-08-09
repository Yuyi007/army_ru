using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_TrackGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Optimize(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
	static public int Pause(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Resume(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRunningTime(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
	static public int GetMilestones(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
	static public int GetTracks(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			var ret=self.GetTracks();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAllowedTrackTypes(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			var ret=self.GetAllowedTrackTypes();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Cutscene(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			pushValue(l,self.Cutscene);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Ordinal(IntPtr l) {
		try {
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
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
			CinemaDirector.TrackGroup self=(CinemaDirector.TrackGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.CanOptimize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.TrackGroup");
		addMember(l,Optimize);
		addMember(l,Initialize);
		addMember(l,UpdateTrackGroup);
		addMember(l,Pause);
		addMember(l,Stop);
		addMember(l,Resume);
		addMember(l,SetRunningTime);
		addMember(l,GetMilestones);
		addMember(l,GetTracks);
		addMember(l,GetAllowedTrackTypes);
		addMember(l,"Cutscene",get_Cutscene,null,true);
		addMember(l,"Ordinal",get_Ordinal,set_Ordinal,true);
		addMember(l,"CanOptimize",get_CanOptimize,set_CanOptimize,true);
		createTypeMetatable(l,null, typeof(CinemaDirector.TrackGroup),typeof(UnityEngine.MonoBehaviour));
	}
}
