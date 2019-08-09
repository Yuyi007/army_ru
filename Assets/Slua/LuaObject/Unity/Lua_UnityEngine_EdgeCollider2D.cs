using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EdgeCollider2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D o;
			o=new UnityEngine.EdgeCollider2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			self.Reset();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_points(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			pushValue(l,self.points);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_points(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkType(l,2,out v);
			self.points=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_edgeRadius(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			pushValue(l,self.edgeRadius);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_edgeRadius(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.edgeRadius=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_edgeCount(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			pushValue(l,self.edgeCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pointCount(IntPtr l) {
		try {
			UnityEngine.EdgeCollider2D self=(UnityEngine.EdgeCollider2D)checkSelf(l);
			pushValue(l,self.pointCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EdgeCollider2D");
		addMember(l,Reset);
		addMember(l,"points",get_points,set_points,true);
		addMember(l,"edgeRadius",get_edgeRadius,set_edgeRadius,true);
		addMember(l,"edgeCount",get_edgeCount,null,true);
		addMember(l,"pointCount",get_pointCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EdgeCollider2D),typeof(UnityEngine.Collider2D));
	}
}
