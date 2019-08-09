using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_FVColorCorrectionLookup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup o;
			o=new UnityStandardAssets.ImageEffects.FVColorCorrectionLookup();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tryCheckResources(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.tryCheckResources(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckResources(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ValidDimensions(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			UnityEngine.Texture2D a1;
			checkType(l,2,out a1);
			var ret=self.ValidDimensions(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLutFromCache(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetLutFromCache(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Convert(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			UnityEngine.Texture2D a1;
			checkType(l,2,out a1);
			self.Convert(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_refTexture(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			pushValue(l,self.refTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_refTexture(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.refTexture=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
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
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
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
	static public int get_ForceUseLut2D(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			pushValue(l,self.ForceUseLut2D);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ForceUseLut2D(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.FVColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ForceUseLut2D=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.FVColorCorrectionLookup");
		addMember(l,tryCheckResources);
		addMember(l,CheckResources);
		addMember(l,ValidDimensions);
		addMember(l,GetLutFromCache);
		addMember(l,Convert);
		addMember(l,"refTexture",get_refTexture,set_refTexture,true);
		addMember(l,"shader",get_shader,set_shader,true);
		addMember(l,"ForceUseLut2D",get_ForceUseLut2D,set_ForceUseLut2D,true);
		createTypeMetatable(l,constructor, typeof(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
