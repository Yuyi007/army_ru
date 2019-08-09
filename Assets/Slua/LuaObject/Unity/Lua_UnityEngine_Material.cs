using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Material : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Material o;
			if(matchType(l,argc,2,typeof(UnityEngine.Shader))){
				UnityEngine.Shader a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Material(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Material(a1);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HasProperty(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.HasProperty(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.HasProperty(a1);
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
	static public int GetTag(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetTag(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.String a3;
				checkType(l,4,out a3);
				var ret=self.GetTag(a1,a2,a3);
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
	static public int SetOverrideTag(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			self.SetOverrideTag(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetShaderPassEnabled(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetShaderPassEnabled(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetShaderPassEnabled(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetShaderPassEnabled(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Lerp(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			UnityEngine.Material a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.Lerp(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetPass(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.SetPass(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPassName(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPassName(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindPass(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.FindPass(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CopyPropertiesFromMaterial(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			self.CopyPropertiesFromMaterial(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EnableKeyword(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.EnableKeyword(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DisableKeyword(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.DisableKeyword(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsKeywordEnabled(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.IsKeywordEnabled(a1);
			pushValue(l,ret);
			return 1;
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetFloat(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetInt(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetInt(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetInt(a1,a2);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Color a2;
				checkType(l,3,out a2);
				self.SetColor(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Color))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4 a2;
				checkType(l,3,out a2);
				self.SetVector(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Vector4))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetMatrix(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Matrix4x4))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,3,out a2);
				self.SetMatrix(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Matrix4x4))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetTexture(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Texture))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Texture a2;
				checkType(l,3,out a2);
				self.SetTexture(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Texture))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetBuffer(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.ComputeBuffer))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,3,out a2);
				self.SetBuffer(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.ComputeBuffer))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetTextureOffset(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector2))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				self.SetTextureOffset(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Vector2))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				self.SetTextureOffset(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTextureScale(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector2))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				self.SetTextureScale(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Vector2))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				self.SetTextureScale(a1,a2);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(System.Single[]))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<System.Single>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.SetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<System.Single>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int SetColorArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.Color[]))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Color[] a2;
				checkType(l,3,out a2);
				self.SetColorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Color[]))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Color[] a2;
				checkType(l,3,out a2);
				self.SetColorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Color>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Color> a2;
				checkType(l,3,out a2);
				self.SetColorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Color>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Color> a2;
				checkType(l,3,out a2);
				self.SetColorArray(a1,a2);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4[]))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.SetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Matrix4x4[]))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.SetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetFloat(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int GetInt(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetInt(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetInt(a1);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetColor(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int GetVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetVector(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int GetMatrix(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrix(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetFloatArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetFloatArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<System.Single>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,3,out a2);
				self.GetFloatArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<System.Single>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetVectorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetVectorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.GetVectorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int GetColorArray(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetColorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetColorArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Color>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Color> a2;
				checkType(l,3,out a2);
				self.GetColorArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Color>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Color> a2;
				checkType(l,3,out a2);
				self.GetColorArray(a1,a2);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrixArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetMatrixArray(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,3,out a2);
				self.GetMatrixArray(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetTexture(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
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
	static public int GetTextureOffset(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetTextureOffset(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetTextureOffset(a1);
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
	static public int GetTextureScale(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetTextureScale(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetTextureScale(a1);
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
	static public int get_shader(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.shader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shader(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.shader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.color);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainTexture(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.mainTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mainTexture(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.mainTexture=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainTextureOffset(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.mainTextureOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mainTextureOffset(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.mainTextureOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainTextureScale(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.mainTextureScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mainTextureScale(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.mainTextureScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_passCount(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.passCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderQueue(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.renderQueue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderQueue(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.renderQueue=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shaderKeywords(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.shaderKeywords);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shaderKeywords(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			System.String[] v;
			checkType(l,2,out v);
			self.shaderKeywords=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_globalIlluminationFlags(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushEnum(l,(int)self.globalIlluminationFlags);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_globalIlluminationFlags(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			UnityEngine.MaterialGlobalIlluminationFlags v;
			checkEnum(l,2,out v);
			self.globalIlluminationFlags=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enableInstancing(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.enableInstancing);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enableInstancing(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enableInstancing=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_doubleSidedGI(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			pushValue(l,self.doubleSidedGI);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_doubleSidedGI(IntPtr l) {
		try {
			UnityEngine.Material self=(UnityEngine.Material)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.doubleSidedGI=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Material");
		addMember(l,HasProperty);
		addMember(l,GetTag);
		addMember(l,SetOverrideTag);
		addMember(l,SetShaderPassEnabled);
		addMember(l,GetShaderPassEnabled);
		addMember(l,Lerp);
		addMember(l,SetPass);
		addMember(l,GetPassName);
		addMember(l,FindPass);
		addMember(l,CopyPropertiesFromMaterial);
		addMember(l,EnableKeyword);
		addMember(l,DisableKeyword);
		addMember(l,IsKeywordEnabled);
		addMember(l,SetFloat);
		addMember(l,SetInt);
		addMember(l,SetColor);
		addMember(l,SetVector);
		addMember(l,SetMatrix);
		addMember(l,SetTexture);
		addMember(l,SetBuffer);
		addMember(l,SetTextureOffset);
		addMember(l,SetTextureScale);
		addMember(l,SetFloatArray);
		addMember(l,SetColorArray);
		addMember(l,SetVectorArray);
		addMember(l,SetMatrixArray);
		addMember(l,GetFloat);
		addMember(l,GetInt);
		addMember(l,GetColor);
		addMember(l,GetVector);
		addMember(l,GetMatrix);
		addMember(l,GetFloatArray);
		addMember(l,GetVectorArray);
		addMember(l,GetColorArray);
		addMember(l,GetMatrixArray);
		addMember(l,GetTexture);
		addMember(l,GetTextureOffset);
		addMember(l,GetTextureScale);
		addMember(l,"shader",get_shader,set_shader,true);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"mainTexture",get_mainTexture,set_mainTexture,true);
		addMember(l,"mainTextureOffset",get_mainTextureOffset,set_mainTextureOffset,true);
		addMember(l,"mainTextureScale",get_mainTextureScale,set_mainTextureScale,true);
		addMember(l,"passCount",get_passCount,null,true);
		addMember(l,"renderQueue",get_renderQueue,set_renderQueue,true);
		addMember(l,"shaderKeywords",get_shaderKeywords,set_shaderKeywords,true);
		addMember(l,"globalIlluminationFlags",get_globalIlluminationFlags,set_globalIlluminationFlags,true);
		addMember(l,"enableInstancing",get_enableInstancing,set_enableInstancing,true);
		addMember(l,"doubleSidedGI",get_doubleSidedGI,set_doubleSidedGI,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Material),typeof(UnityEngine.Object));
	}
}
