using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UGUISpriteAnimation : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			self.Play();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayReverse(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			self.PlayReverse();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
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
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			self.Resume();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Rewind(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			self.Rewind();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FPS(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.FPS);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FPS(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.FPS=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SpriteFrames(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.SpriteFrames);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SpriteFrames(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Sprite> v;
			checkType(l,2,out v);
			self.SpriteFrames=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsPlaying(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.IsPlaying);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsPlaying(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.IsPlaying=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Foward(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.Foward);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Foward(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.Foward=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AutoPlay(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.AutoPlay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_AutoPlay(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.AutoPlay=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Loop(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.Loop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Loop(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.Loop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FrameCount(IntPtr l) {
		try {
			UGUISpriteAnimation self=(UGUISpriteAnimation)checkSelf(l);
			pushValue(l,self.FrameCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UGUISpriteAnimation");
		addMember(l,Play);
		addMember(l,PlayReverse);
		addMember(l,Pause);
		addMember(l,Resume);
		addMember(l,Stop);
		addMember(l,Rewind);
		addMember(l,"FPS",get_FPS,set_FPS,true);
		addMember(l,"SpriteFrames",get_SpriteFrames,set_SpriteFrames,true);
		addMember(l,"IsPlaying",get_IsPlaying,set_IsPlaying,true);
		addMember(l,"Foward",get_Foward,set_Foward,true);
		addMember(l,"AutoPlay",get_AutoPlay,set_AutoPlay,true);
		addMember(l,"Loop",get_Loop,set_Loop,true);
		addMember(l,"FrameCount",get_FrameCount,null,true);
		createTypeMetatable(l,null, typeof(UGUISpriteAnimation),typeof(UnityEngine.MonoBehaviour));
	}
}
