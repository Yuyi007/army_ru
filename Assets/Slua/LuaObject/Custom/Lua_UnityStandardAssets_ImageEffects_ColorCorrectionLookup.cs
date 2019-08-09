using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_ColorCorrectionLookup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup o;
			o=new UnityStandardAssets.ImageEffects.ColorCorrectionLookup();
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
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetIdentityLut(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			self.SetIdentityLut();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ValidDimensions(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
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
	static public int Convert(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			UnityEngine.Texture2D a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			self.Convert(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
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
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
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
	static public int get_converted3DLut(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			pushValue(l,self.converted3DLut);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_converted3DLut(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			UnityEngine.Texture3D v;
			checkType(l,2,out v);
			self.converted3DLut=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_basedOnTempTex(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			pushValue(l,self.basedOnTempTex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_basedOnTempTex(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionLookup self=(UnityStandardAssets.ImageEffects.ColorCorrectionLookup)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.basedOnTempTex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.ColorCorrectionLookup");
		addMember(l,CheckResources);
		addMember(l,SetIdentityLut);
		addMember(l,ValidDimensions);
		addMember(l,Convert);
		addMember(l,"shader",get_shader,set_shader,true);
		addMember(l,"converted3DLut",get_converted3DLut,set_converted3DLut,true);
		addMember(l,"basedOnTempTex",get_basedOnTempTex,set_basedOnTempTex,true);
		createTypeMetatable(l,constructor, typeof(UnityStandardAssets.ImageEffects.ColorCorrectionLookup),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
