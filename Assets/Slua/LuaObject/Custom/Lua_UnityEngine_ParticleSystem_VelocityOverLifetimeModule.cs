using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem_VelocityOverLifetimeModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule o;
			o=new UnityEngine.ParticleSystem.VelocityOverLifetimeModule();
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
	static public int get_x(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.x);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_x(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.x=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_y(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.y);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_y(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.y=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_z(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.z);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_z(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.z=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_speedModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.speedModifier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_speedModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.speedModifier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_xMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.xMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_xMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.xMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_yMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.yMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_yMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.yMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_zMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.zMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_zMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.zMultiplier=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_speedModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,self.speedModifierMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_speedModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.speedModifierMultiplier=v;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.VelocityOverLifetimeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"x",get_x,set_x,true);
		addMember(l,"y",get_y,set_y,true);
		addMember(l,"z",get_z,set_z,true);
		addMember(l,"speedModifier",get_speedModifier,set_speedModifier,true);
		addMember(l,"xMultiplier",get_xMultiplier,set_xMultiplier,true);
		addMember(l,"yMultiplier",get_yMultiplier,set_yMultiplier,true);
		addMember(l,"zMultiplier",get_zMultiplier,set_zMultiplier,true);
		addMember(l,"speedModifierMultiplier",get_speedModifierMultiplier,set_speedModifierMultiplier,true);
		addMember(l,"space",get_space,set_space,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.VelocityOverLifetimeModule),typeof(System.ValueType));
	}
}
