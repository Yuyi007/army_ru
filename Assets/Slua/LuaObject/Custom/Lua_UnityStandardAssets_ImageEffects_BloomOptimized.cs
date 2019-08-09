using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_BloomOptimized : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized o;
			o=new UnityStandardAssets.ImageEffects.BloomOptimized();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Copy(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			UnityStandardAssets.ImageEffects.BloomOptimized a1;
			checkType(l,2,out a1);
			self.Copy(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckResources(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_threshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushValue(l,self.threshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_threshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.threshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_intensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushValue(l,self.intensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_intensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.intensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurSize(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushValue(l,self.blurSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurSize(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.blurSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushValue(l,self.blurIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.blurIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurType(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushEnum(l,(int)self.blurType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurType(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			UnityStandardAssets.ImageEffects.BloomOptimized.BlurType v;
			checkEnum(l,2,out v);
			self.blurType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fastBloomShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			pushValue(l,self.fastBloomShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fastBloomShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.BloomOptimized self=(UnityStandardAssets.ImageEffects.BloomOptimized)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.fastBloomShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.BloomOptimized");
		addMember(l,Copy);
		addMember(l,CheckResources);
		addMember(l,"threshold",get_threshold,set_threshold,true);
		addMember(l,"intensity",get_intensity,set_intensity,true);
		addMember(l,"blurSize",get_blurSize,set_blurSize,true);
		addMember(l,"blurIterations",get_blurIterations,set_blurIterations,true);
		addMember(l,"blurType",get_blurType,set_blurType,true);
		addMember(l,"fastBloomShader",get_fastBloomShader,set_fastBloomShader,true);
		createTypeMetatable(l,constructor, typeof(UnityStandardAssets.ImageEffects.BloomOptimized),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
