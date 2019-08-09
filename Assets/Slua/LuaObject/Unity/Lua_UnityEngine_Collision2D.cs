using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Collision2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Collision2D o;
			o=new UnityEngine.Collision2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetContacts(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			UnityEngine.ContactPoint2D[] a1;
			checkType(l,2,out a1);
			var ret=self.GetContacts(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_collider(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
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
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
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
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
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
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.otherRigidbody);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.transform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gameObject(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.gameObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_contacts(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.contacts);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_relativeVelocity(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.relativeVelocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.Collision2D self=(UnityEngine.Collision2D)checkSelf(l);
			pushValue(l,self.enabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Collision2D");
		addMember(l,GetContacts);
		addMember(l,"collider",get_collider,null,true);
		addMember(l,"otherCollider",get_otherCollider,null,true);
		addMember(l,"rigidbody",get_rigidbody,null,true);
		addMember(l,"otherRigidbody",get_otherRigidbody,null,true);
		addMember(l,"transform",get_transform,null,true);
		addMember(l,"gameObject",get_gameObject,null,true);
		addMember(l,"contacts",get_contacts,null,true);
		addMember(l,"relativeVelocity",get_relativeVelocity,null,true);
		addMember(l,"enabled",get_enabled,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Collision2D));
	}
}
