using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_StateClipPair : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.StateClipPair o;
			o=new Game.StateClipPair();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_stateName(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			pushValue(l,self.stateName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_stateName(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.stateName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clipName(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			pushValue(l,self.clipName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clipName(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.clipName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clipLength(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			pushValue(l,self.clipLength);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clipLength(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.clipLength=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clipFrameRate(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			pushValue(l,self.clipFrameRate);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clipFrameRate(IntPtr l) {
		try {
			Game.StateClipPair self=(Game.StateClipPair)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.clipFrameRate=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.StateClipPair");
		addMember(l,"stateName",get_stateName,set_stateName,true);
		addMember(l,"clipName",get_clipName,set_clipName,true);
		addMember(l,"clipLength",get_clipLength,set_clipLength,true);
		addMember(l,"clipFrameRate",get_clipFrameRate,set_clipFrameRate,true);
		createTypeMetatable(l,constructor, typeof(Game.StateClipPair));
	}
}
