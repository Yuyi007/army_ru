﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem_MinMaxCurve : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.ParticleSystem.MinMaxCurve o;
			if(argc==2){
				System.Single a1;
				checkType(l,2,out a1);
				o=new UnityEngine.ParticleSystem.MinMaxCurve(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(UnityEngine.AnimationCurve))){
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.AnimationCurve a2;
				checkType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.MinMaxCurve(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(argc==4){
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.AnimationCurve a2;
				checkType(l,3,out a2);
				UnityEngine.AnimationCurve a3;
				checkType(l,4,out a3);
				o=new UnityEngine.ParticleSystem.MinMaxCurve(a1,a2,a3);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(float))){
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.MinMaxCurve(a1,a2);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Evaluate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystem.MinMaxCurve self;
				checkValueType(l,1,out self);
				System.Single a1;
				checkType(l,2,out a1);
				var ret=self.Evaluate(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ParticleSystem.MinMaxCurve self;
				checkValueType(l,1,out self);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.Evaluate(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
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
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCurveMode v;
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
	static public int get_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
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
			UnityEngine.ParticleSystem.MinMaxCurve self;
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
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			pushValue(l,self.curveMax);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.curveMax=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			pushValue(l,self.curveMin);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.curveMin=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_constantMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			pushValue(l,self.constantMax);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_constantMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.constantMax=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_constantMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			pushValue(l,self.constantMin);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_constantMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.constantMin=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_constant(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			pushValue(l,self.constant);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_constant(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.constant=v;
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
			UnityEngine.ParticleSystem.MinMaxCurve self;
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
			UnityEngine.ParticleSystem.MinMaxCurve self;
			checkValueType(l,1,out self);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.curve=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.MinMaxCurve");
		addMember(l,Evaluate);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"curveMultiplier",get_curveMultiplier,set_curveMultiplier,true);
		addMember(l,"curveMax",get_curveMax,set_curveMax,true);
		addMember(l,"curveMin",get_curveMin,set_curveMin,true);
		addMember(l,"constantMax",get_constantMax,set_constantMax,true);
		addMember(l,"constantMin",get_constantMin,set_constantMin,true);
		addMember(l,"constant",get_constant,set_constant,true);
		addMember(l,"curve",get_curve,set_curve,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.MinMaxCurve),typeof(System.ValueType));
	}
}
