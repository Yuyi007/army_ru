﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CinemaDirector_FadeToWhite : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite o;
			o=new CinemaDirector.FadeToWhite();
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
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			self.Trigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReverseTrigger(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			self.ReverseTrigger();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTime(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.UpdateTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTime(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int End(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			self.End();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReverseEnd(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			self.ReverseEnd();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			CinemaDirector.FadeToWhite self=(CinemaDirector.FadeToWhite)checkSelf(l);
			self.Stop();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CinemaDirector.FadeToWhite");
		addMember(l,Trigger);
		addMember(l,ReverseTrigger);
		addMember(l,UpdateTime);
		addMember(l,SetTime);
		addMember(l,End);
		addMember(l,ReverseEnd);
		addMember(l,Stop);
		createTypeMetatable(l,constructor, typeof(CinemaDirector.FadeToWhite),typeof(CinemaDirector.CinemaGlobalAction));
	}
}
