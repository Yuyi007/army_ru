﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem_InheritVelocityModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule o;
			o=new UnityEngine.ParticleSystem.InheritVelocityModule();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.enabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			pushEnum(l,(int)self.mode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemInheritVelocityMode v;
			checkEnum(l,2,out v);
			self.mode=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.curve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.curve=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.curveMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.InheritVelocityModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.curveMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.InheritVelocityModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"curve",get_curve,set_curve,true);
		addMember(l,"curveMultiplier",get_curveMultiplier,set_curveMultiplier,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.InheritVelocityModule),typeof(System.ValueType));
	}
}
