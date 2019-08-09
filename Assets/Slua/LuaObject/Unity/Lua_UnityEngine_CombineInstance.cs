using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_CombineInstance : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.CombineInstance o;
			o=new UnityEngine.CombineInstance();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,self.mesh);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_subMeshIndex(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,self.subMeshIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_subMeshIndex(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.subMeshIndex=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,self.transform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_transform(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Matrix4x4 v;
			checkValueType(l,2,out v);
			self.transform=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,self.lightmapScaleOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.lightmapScaleOffset=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_realtimeLightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			pushValue(l,self.realtimeLightmapScaleOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_realtimeLightmapScaleOffset(IntPtr l) {
		try {
			UnityEngine.CombineInstance self;
			checkValueType(l,1,out self);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.realtimeLightmapScaleOffset=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CombineInstance");
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"subMeshIndex",get_subMeshIndex,set_subMeshIndex,true);
		addMember(l,"transform",get_transform,set_transform,true);
		addMember(l,"lightmapScaleOffset",get_lightmapScaleOffset,set_lightmapScaleOffset,true);
		addMember(l,"realtimeLightmapScaleOffset",get_realtimeLightmapScaleOffset,set_realtimeLightmapScaleOffset,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CombineInstance),typeof(System.ValueType));
	}
}
