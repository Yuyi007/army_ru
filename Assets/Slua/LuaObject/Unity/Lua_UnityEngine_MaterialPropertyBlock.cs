﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_MaterialPropertyBlock : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.MaterialPropertyBlock o;
			o=new UnityEngine.MaterialPropertyBlock();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
			self.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetFloat(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(float))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetFloat(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetFloat(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4 a2;
				checkType(l,3,out a2);
				self.SetVector(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Vector4))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4 a2;
				checkType(l,3,out a2);
				self.SetVector(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetColor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Color))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Color a2;
				checkType(l,3,out a2);
				self.SetColor(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Color))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Color a2;
				checkType(l,3,out a2);
				self.SetColor(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetMatrix(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Matrix4x4))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,3,out a2);
				self.SetMatrix(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Matrix4x4))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,3,out a2);
				self.SetMatrix(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetBuffer(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.ComputeBuffer))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,3,out a2);
				self.SetBuffer(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.ComputeBuffer))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,3,out a2);
				self.SetBuffer(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTexture(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Texture))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Texture a2;
				checkType(l,3,out a2);
				self.SetTexture(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Texture))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Texture a2;
				checkType(l,3,out a2);
				self.SetTexture(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetFloatArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(System.Single[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(System.Single[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<System.Single>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<System.Single>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetVectorArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Vector4[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetMatrixArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Matrix4x4[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Matrix4x4[]))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetFloat(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetFloat(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetFloat(a1);
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
	static public int GetVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetVector(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetVector(a1);
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
	static public int GetColor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetColor(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetColor(a1);
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
	static public int GetMatrix(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrix(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrix(a1);
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
	static public int GetFloatArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetFloatArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetFloatArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<System.Single>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.GetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<System.Single>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.GetFloatArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetVectorArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetVectorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetVectorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.GetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.GetVectorArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetMatrixArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrixArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrixArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.GetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.GetMatrixArray(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTexture(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetTexture(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetTexture(a1);
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
	static public int get_isEmpty(IntPtr l) {
		try {
			UnityEngine.MaterialPropertyBlock self=(UnityEngine.MaterialPropertyBlock)checkSelf(l);
			pushValue(l,self.isEmpty);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.MaterialPropertyBlock");
		addMember(l,Clear);
		addMember(l,SetFloat);
		addMember(l,SetVector);
		addMember(l,SetColor);
		addMember(l,SetMatrix);
		addMember(l,SetBuffer);
		addMember(l,SetTexture);
		addMember(l,SetFloatArray);
		addMember(l,SetVectorArray);
		addMember(l,SetMatrixArray);
		addMember(l,GetFloat);
		addMember(l,GetVector);
		addMember(l,GetColor);
		addMember(l,GetMatrix);
		addMember(l,GetFloatArray);
		addMember(l,GetVectorArray);
		addMember(l,GetMatrixArray);
		addMember(l,GetTexture);
		addMember(l,"isEmpty",get_isEmpty,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.MaterialPropertyBlock));
	}
}
