﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Collider2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Collider2D o;
			o=new UnityEngine.Collider2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCollider(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			UnityEngine.ContactFilter2D a1;
			checkValueType(l,2,out a1);
			UnityEngine.Collider2D[] a2;
			checkType(l,3,out a2);
			var ret=self.OverlapCollider(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Raycast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				var ret=self.Raycast(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.Raycast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,4,out a3);
				var ret=self.Raycast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.RaycastHit2D[]),typeof(float),typeof(int))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.Raycast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				var ret=self.Raycast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				var ret=self.Raycast(a1,a2,a3,a4,a5,a6);
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
	static public int Cast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				var ret=self.Cast(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.Cast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,4,out a3);
				var ret=self.Cast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				var ret=self.Cast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.RaycastHit2D[]),typeof(float),typeof(bool))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				var ret=self.Cast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				var ret=self.Cast(a1,a2,a3,a4,a5);
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
	static public int GetContacts(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Collider2D[] a1;
				checkType(l,2,out a1);
				var ret=self.GetContacts(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.ContactPoint2D[] a1;
				checkType(l,2,out a1);
				var ret=self.GetContacts(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.ContactFilter2D a1;
				checkValueType(l,2,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,3,out a2);
				var ret=self.GetContacts(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.ContactFilter2D a1;
				checkValueType(l,2,out a1);
				UnityEngine.ContactPoint2D[] a2;
				checkType(l,3,out a2);
				var ret=self.GetContacts(a1,a2);
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
	static public int IsTouching(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.ContactFilter2D a1;
				checkValueType(l,2,out a1);
				var ret=self.IsTouching(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Collider2D))){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Collider2D a1;
				checkType(l,2,out a1);
				var ret=self.IsTouching(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				UnityEngine.Collider2D a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				var ret=self.IsTouching(a1,a2);
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
	static public int IsTouchingLayers(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				var ret=self.IsTouchingLayers();
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.IsTouchingLayers(a1);
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
	static public int OverlapPoint(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			var ret=self.OverlapPoint(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Distance(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			UnityEngine.Collider2D a1;
			checkType(l,2,out a1);
			var ret=self.Distance(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_density(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.density);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_density(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.density=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isTrigger(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.isTrigger);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isTrigger(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isTrigger=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_usedByEffector(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.usedByEffector);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_usedByEffector(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.usedByEffector=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_usedByComposite(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.usedByComposite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_usedByComposite(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.usedByComposite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_composite(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.composite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offset(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.offset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_offset(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.offset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_attachedRigidbody(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.attachedRigidbody);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shapeCount(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.shapeCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bounds(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.bounds);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.sharedMaterial);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			UnityEngine.PhysicsMaterial2D v;
			checkType(l,2,out v);
			self.sharedMaterial=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_friction(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.friction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bounciness(IntPtr l) {
		try {
			UnityEngine.Collider2D self=(UnityEngine.Collider2D)checkSelf(l);
			pushValue(l,self.bounciness);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Collider2D");
		addMember(l,OverlapCollider);
		addMember(l,Raycast);
		addMember(l,Cast);
		addMember(l,GetContacts);
		addMember(l,IsTouching);
		addMember(l,IsTouchingLayers);
		addMember(l,OverlapPoint);
		addMember(l,Distance);
		addMember(l,"density",get_density,set_density,true);
		addMember(l,"isTrigger",get_isTrigger,set_isTrigger,true);
		addMember(l,"usedByEffector",get_usedByEffector,set_usedByEffector,true);
		addMember(l,"usedByComposite",get_usedByComposite,set_usedByComposite,true);
		addMember(l,"composite",get_composite,null,true);
		addMember(l,"offset",get_offset,set_offset,true);
		addMember(l,"attachedRigidbody",get_attachedRigidbody,null,true);
		addMember(l,"shapeCount",get_shapeCount,null,true);
		addMember(l,"bounds",get_bounds,null,true);
		addMember(l,"sharedMaterial",get_sharedMaterial,set_sharedMaterial,true);
		addMember(l,"friction",get_friction,null,true);
		addMember(l,"bounciness",get_bounciness,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Collider2D),typeof(UnityEngine.Behaviour));
	}
}
