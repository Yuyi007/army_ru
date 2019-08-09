using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem_LimitVelocityOverLifetimeModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule o;
			o=new UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule();
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
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
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
	static public int get_limitX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitX);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitX=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitXMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limitXMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitY=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitYMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limitYMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitZ);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitZ=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitZMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limitZMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limit(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limit);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limit(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limit=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limitMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.dampen);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.dampen=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.separateAxes);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.separateAxes=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushEnum(l,(int)self.space);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemSimulationSpace v;
			checkEnum(l,2,out v);
			self.space=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_drag(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.drag);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_drag(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.drag=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.dragMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.dragMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_multiplyDragByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.multiplyDragByParticleSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_multiplyDragByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.multiplyDragByParticleSize=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_multiplyDragByParticleVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.multiplyDragByParticleVelocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_multiplyDragByParticleVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.multiplyDragByParticleVelocity=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"limitX",get_limitX,set_limitX,true);
		addMember(l,"limitXMultiplier",get_limitXMultiplier,set_limitXMultiplier,true);
		addMember(l,"limitY",get_limitY,set_limitY,true);
		addMember(l,"limitYMultiplier",get_limitYMultiplier,set_limitYMultiplier,true);
		addMember(l,"limitZ",get_limitZ,set_limitZ,true);
		addMember(l,"limitZMultiplier",get_limitZMultiplier,set_limitZMultiplier,true);
		addMember(l,"limit",get_limit,set_limit,true);
		addMember(l,"limitMultiplier",get_limitMultiplier,set_limitMultiplier,true);
		addMember(l,"dampen",get_dampen,set_dampen,true);
		addMember(l,"separateAxes",get_separateAxes,set_separateAxes,true);
		addMember(l,"space",get_space,set_space,true);
		addMember(l,"drag",get_drag,set_drag,true);
		addMember(l,"dragMultiplier",get_dragMultiplier,set_dragMultiplier,true);
		addMember(l,"multiplyDragByParticleSize",get_multiplyDragByParticleSize,set_multiplyDragByParticleSize,true);
		addMember(l,"multiplyDragByParticleVelocity",get_multiplyDragByParticleVelocity,set_multiplyDragByParticleVelocity,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule),typeof(System.ValueType));
	}
}
