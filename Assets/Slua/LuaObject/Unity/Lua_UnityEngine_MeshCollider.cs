using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_MeshCollider : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.MeshCollider o;
			o=new UnityEngine.MeshCollider();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sharedMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,self.sharedMesh);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sharedMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.sharedMesh=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_convex(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,self.convex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_convex(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.convex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cookingOptions(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushEnum(l,(int)self.cookingOptions);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cookingOptions(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			UnityEngine.MeshColliderCookingOptions v;
			checkEnum(l,2,out v);
			self.cookingOptions=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inflateMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,self.inflateMesh);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inflateMesh(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.inflateMesh=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_skinWidth(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			pushValue(l,self.skinWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_skinWidth(IntPtr l) {
		try {
			UnityEngine.MeshCollider self=(UnityEngine.MeshCollider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.skinWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.MeshCollider");
		addMember(l,"sharedMesh",get_sharedMesh,set_sharedMesh,true);
		addMember(l,"convex",get_convex,set_convex,true);
		addMember(l,"cookingOptions",get_cookingOptions,set_cookingOptions,true);
		addMember(l,"inflateMesh",get_inflateMesh,set_inflateMesh,true);
		addMember(l,"skinWidth",get_skinWidth,set_skinWidth,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.MeshCollider),typeof(UnityEngine.Collider));
	}
}
