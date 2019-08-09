using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_AnimatorStorable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int findState(IntPtr l) {
		try {
			Game.AnimatorStorable self=(Game.AnimatorStorable)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.findState(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int findStatesByClip(IntPtr l) {
		try {
			Game.AnimatorStorable self=(Game.AnimatorStorable)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.findStatesByClip(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int findClip(IntPtr l) {
		try {
			Game.AnimatorStorable self=(Game.AnimatorStorable)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.findClip(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_stateClipPairs(IntPtr l) {
		try {
			Game.AnimatorStorable self=(Game.AnimatorStorable)checkSelf(l);
			pushValue(l,self.stateClipPairs);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_stateClipPairs(IntPtr l) {
		try {
			Game.AnimatorStorable self=(Game.AnimatorStorable)checkSelf(l);
			Game.StateClipPair[] v;
			checkType(l,2,out v);
			self.stateClipPairs=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.AnimatorStorable");
		addMember(l,findState);
		addMember(l,findStatesByClip);
		addMember(l,findClip);
		addMember(l,"stateClipPairs",get_stateClipPairs,set_stateClipPairs,true);
		createTypeMetatable(l,null, typeof(Game.AnimatorStorable),typeof(UnityEngine.MonoBehaviour));
	}
}
