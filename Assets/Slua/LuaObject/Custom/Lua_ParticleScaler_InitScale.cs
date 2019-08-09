using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_ParticleScaler_InitScale : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			ParticleScaler.InitScale o;
			o=new ParticleScaler.InitScale();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scale(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.scale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scale(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.scale=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gravity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.gravity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gravity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.gravity=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveScalar(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.curveScalar);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveScalar(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.curveScalar=v;
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
			ParticleScaler.InitScale self;
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
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
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
	static public int get_constantMax(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
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
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
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
	static public int get_startSize(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.startSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startSize(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.startSize=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startSpeed(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.startSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startSpeed(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.startSpeed=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_radius(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.radius);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_radius(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.radius=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_localPosition(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.localPosition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_localPosition(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.localPosition=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_box(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.box);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_box(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.box=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.velocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_velocity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve[] v;
			checkType(l,2,out v);
			self.velocity=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitVelocity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.limitVelocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitVelocity(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve[] v;
			checkType(l,2,out v);
			self.limitVelocity=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_force(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			pushValue(l,self.force);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_force(IntPtr l) {
		try {
			ParticleScaler.InitScale self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve[] v;
			checkType(l,2,out v);
			self.force=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"ParticleScaler.InitScale");
		addMember(l,"scale",get_scale,set_scale,true);
		addMember(l,"gravity",get_gravity,set_gravity,true);
		addMember(l,"curveScalar",get_curveScalar,set_curveScalar,true);
		addMember(l,"constantMin",get_constantMin,set_constantMin,true);
		addMember(l,"constantMax",get_constantMax,set_constantMax,true);
		addMember(l,"startSize",get_startSize,set_startSize,true);
		addMember(l,"startSpeed",get_startSpeed,set_startSpeed,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"localPosition",get_localPosition,set_localPosition,true);
		addMember(l,"box",get_box,set_box,true);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"limitVelocity",get_limitVelocity,set_limitVelocity,true);
		addMember(l,"force",get_force,set_force,true);
		createTypeMetatable(l,constructor, typeof(ParticleScaler.InitScale),typeof(System.ValueType));
	}
}
