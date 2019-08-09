using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_Bloom : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom o;
			o=new UnityStandardAssets.ImageEffects.Bloom();
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
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom a1;
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
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnRenderImage(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.RenderTexture a1;
			checkType(l,2,out a1);
			UnityEngine.RenderTexture a2;
			checkType(l,3,out a2);
			self.OnRenderImage(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tweakMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushEnum(l,(int)self.tweakMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tweakMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom.TweakMode v;
			checkEnum(l,2,out v);
			self.tweakMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_screenBlendMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushEnum(l,(int)self.screenBlendMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_screenBlendMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom.BloomScreenBlendMode v;
			checkEnum(l,2,out v);
			self.screenBlendMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hdr(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushEnum(l,(int)self.hdr);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hdr(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom.HDRBloomMode v;
			checkEnum(l,2,out v);
			self.hdr=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sepBlurSpread(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.sepBlurSpread);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sepBlurSpread(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.sepBlurSpread=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_quality(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushEnum(l,(int)self.quality);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_quality(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom.BloomQuality v;
			checkEnum(l,2,out v);
			self.quality=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bloomIntensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.bloomIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bloomIntensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bloomIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bloomThreshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.bloomThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bloomThreshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bloomThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bloomThresholdColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.bloomThresholdColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bloomThresholdColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.bloomThresholdColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bloomBlurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.bloomBlurIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bloomBlurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.bloomBlurIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hollywoodFlareBlurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.hollywoodFlareBlurIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hollywoodFlareBlurIterations(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.hollywoodFlareBlurIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flareRotation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.flareRotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flareRotation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.flareRotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensflareMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushEnum(l,(int)self.lensflareMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensflareMode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityStandardAssets.ImageEffects.Bloom.LensFlareStyle v;
			checkEnum(l,2,out v);
			self.lensflareMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hollyStretchWidth(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.hollyStretchWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hollyStretchWidth(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.hollyStretchWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensflareIntensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.lensflareIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensflareIntensity(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lensflareIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensflareThreshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.lensflareThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensflareThreshold(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lensflareThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensFlareSaturation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.lensFlareSaturation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensFlareSaturation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lensFlareSaturation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flareColorA(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.flareColorA);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flareColorA(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.flareColorA=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flareColorB(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.flareColorB);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flareColorB(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.flareColorB=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flareColorC(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.flareColorC);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flareColorC(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.flareColorC=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flareColorD(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.flareColorD);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flareColorD(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.flareColorD=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensFlareVignetteMask(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.lensFlareVignetteMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensFlareVignetteMask(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.lensFlareVignetteMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensFlareShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.lensFlareShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensFlareShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.lensFlareShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_screenBlendShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.screenBlendShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_screenBlendShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.screenBlendShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurAndFlaresShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.blurAndFlaresShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurAndFlaresShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.blurAndFlaresShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_brightPassFilterShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			pushValue(l,self.brightPassFilterShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_brightPassFilterShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.Bloom self=(UnityStandardAssets.ImageEffects.Bloom)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.brightPassFilterShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.Bloom");
		addMember(l,Copy);
		addMember(l,CheckResources);
		addMember(l,OnRenderImage);
		addMember(l,"tweakMode",get_tweakMode,set_tweakMode,true);
		addMember(l,"screenBlendMode",get_screenBlendMode,set_screenBlendMode,true);
		addMember(l,"hdr",get_hdr,set_hdr,true);
		addMember(l,"sepBlurSpread",get_sepBlurSpread,set_sepBlurSpread,true);
		addMember(l,"quality",get_quality,set_quality,true);
		addMember(l,"bloomIntensity",get_bloomIntensity,set_bloomIntensity,true);
		addMember(l,"bloomThreshold",get_bloomThreshold,set_bloomThreshold,true);
		addMember(l,"bloomThresholdColor",get_bloomThresholdColor,set_bloomThresholdColor,true);
		addMember(l,"bloomBlurIterations",get_bloomBlurIterations,set_bloomBlurIterations,true);
		addMember(l,"hollywoodFlareBlurIterations",get_hollywoodFlareBlurIterations,set_hollywoodFlareBlurIterations,true);
		addMember(l,"flareRotation",get_flareRotation,set_flareRotation,true);
		addMember(l,"lensflareMode",get_lensflareMode,set_lensflareMode,true);
		addMember(l,"hollyStretchWidth",get_hollyStretchWidth,set_hollyStretchWidth,true);
		addMember(l,"lensflareIntensity",get_lensflareIntensity,set_lensflareIntensity,true);
		addMember(l,"lensflareThreshold",get_lensflareThreshold,set_lensflareThreshold,true);
		addMember(l,"lensFlareSaturation",get_lensFlareSaturation,set_lensFlareSaturation,true);
		addMember(l,"flareColorA",get_flareColorA,set_flareColorA,true);
		addMember(l,"flareColorB",get_flareColorB,set_flareColorB,true);
		addMember(l,"flareColorC",get_flareColorC,set_flareColorC,true);
		addMember(l,"flareColorD",get_flareColorD,set_flareColorD,true);
		addMember(l,"lensFlareVignetteMask",get_lensFlareVignetteMask,set_lensFlareVignetteMask,true);
		addMember(l,"lensFlareShader",get_lensFlareShader,set_lensFlareShader,true);
		addMember(l,"screenBlendShader",get_screenBlendShader,set_screenBlendShader,true);
		addMember(l,"blurAndFlaresShader",get_blurAndFlaresShader,set_blurAndFlaresShader,true);
		addMember(l,"brightPassFilterShader",get_brightPassFilterShader,set_brightPassFilterShader,true);
		createTypeMetatable(l,constructor, typeof(UnityStandardAssets.ImageEffects.Bloom),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
