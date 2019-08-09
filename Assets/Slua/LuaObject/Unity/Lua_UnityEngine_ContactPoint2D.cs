﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ContactPoint2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D o;
			o=new UnityEngine.ContactPoint2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_point(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.point);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_normal(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.normal);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_separation(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.separation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_normalImpulse(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.normalImpulse);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tangentImpulse(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.tangentImpulse);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_relativeVelocity(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.relativeVelocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_collider(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.collider);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_otherCollider(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.otherCollider);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rigidbody(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.rigidbody);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_otherRigidbody(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.otherRigidbody);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ContactPoint2D self;
			checkValueType(l,1,out self);
			pushValue(l,self.enabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ContactPoint2D");
		addMember(l,"point",get_point,null,true);
		addMember(l,"normal",get_normal,null,true);
		addMember(l,"separation",get_separation,null,true);
		addMember(l,"normalImpulse",get_normalImpulse,null,true);
		addMember(l,"tangentImpulse",get_tangentImpulse,null,true);
		addMember(l,"relativeVelocity",get_relativeVelocity,null,true);
		addMember(l,"collider",get_collider,null,true);
		addMember(l,"otherCollider",get_otherCollider,null,true);
		addMember(l,"rigidbody",get_rigidbody,null,true);
		addMember(l,"otherRigidbody",get_otherRigidbody,null,true);
		addMember(l,"enabled",get_enabled,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ContactPoint2D),typeof(System.ValueType));
	}
}
