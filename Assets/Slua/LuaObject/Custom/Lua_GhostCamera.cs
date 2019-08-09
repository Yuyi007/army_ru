using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GhostCamera : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			GhostCamera o;
			o=new GhostCamera();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckResources(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDestroy(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			self.OnDestroy();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DestroyTexture(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			UnityEngine.RenderTexture a1;
			checkType(l,2,out a1);
			self.DestroyTexture(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getRenderTexture(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			var ret=self.getRenderTexture();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scanlineTex(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			pushValue(l,self.scanlineTex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scanlineTex(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.scanlineTex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lomoMaskTex(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			pushValue(l,self.lomoMaskTex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lomoMaskTex(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.lomoMaskTex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_compShader(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			pushValue(l,self.compShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_compShader(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.compShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_compMaterial(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			pushValue(l,self.compMaterial);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_compMaterial(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.compMaterial=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lineNum(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			pushValue(l,self.lineNum);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lineNum(IntPtr l) {
		try {
			GhostCamera self=(GhostCamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lineNum=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GhostCamera");
		addMember(l,CheckResources);
		addMember(l,OnDestroy);
		addMember(l,DestroyTexture);
		addMember(l,getRenderTexture);
		addMember(l,"scanlineTex",get_scanlineTex,set_scanlineTex,true);
		addMember(l,"lomoMaskTex",get_lomoMaskTex,set_lomoMaskTex,true);
		addMember(l,"compShader",get_compShader,set_compShader,true);
		addMember(l,"compMaterial",get_compMaterial,set_compMaterial,true);
		addMember(l,"lineNum",get_lineNum,set_lineNum,true);
		createTypeMetatable(l,constructor, typeof(GhostCamera),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
