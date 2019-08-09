using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_PostProcessCtrl2 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_watchCam(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.watchCam);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_watchCam(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.watchCam=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateInterval(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.updateInterval);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_updateInterval(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.updateInterval=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_time(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.time);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_time(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.time=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ccColorCorrectionEnable(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.ccColorCorrectionEnable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ccColorCorrectionEnable(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ccColorCorrectionEnable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ccSaturation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.ccSaturation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ccSaturation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.ccSaturation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ccRedChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.ccRedChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ccRedChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.ccRedChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ccGreenChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.ccGreenChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ccGreenChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.ccGreenChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ccBlueChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.ccBlueChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ccBlueChannel(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.ccBlueChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgBloomAndGlareEnable(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgBloomAndGlareEnable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgBloomAndGlareEnable(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.bgBloomAndGlareEnable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgIntensity(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgIntensity(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgRGBThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgRGBThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgRGBThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.bgRGBThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgBlurIterations(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgBlurIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgBlurIterations(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.bgBlurIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgSampleDistance(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgSampleDistance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgSampleDistance(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgSampleDistance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgLensFlareIntensity(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgLensFlareIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgLensFlareIntensity(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgLensFlareIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgLensFlareThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgLensFlareThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgLensFlareThreshold(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgLensFlareThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgLensFlareStretchWidth(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgLensFlareStretchWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgLensFlareStretchWidth(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgLensFlareStretchWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgLensFlareRotation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgLensFlareRotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgLensFlareRotation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgLensFlareRotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgSaturation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgSaturation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgSaturation(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.bgSaturation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bgTintColor(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			pushValue(l,self.bgTintColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bgTintColor(IntPtr l) {
		try {
			PostProcessCtrl2 self=(PostProcessCtrl2)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.bgTintColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"PostProcessCtrl2");
		addMember(l,DoRefresh);
		addMember(l,"watchCam",get_watchCam,set_watchCam,true);
		addMember(l,"updateInterval",get_updateInterval,set_updateInterval,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"ccColorCorrectionEnable",get_ccColorCorrectionEnable,set_ccColorCorrectionEnable,true);
		addMember(l,"ccSaturation",get_ccSaturation,set_ccSaturation,true);
		addMember(l,"ccRedChannel",get_ccRedChannel,set_ccRedChannel,true);
		addMember(l,"ccGreenChannel",get_ccGreenChannel,set_ccGreenChannel,true);
		addMember(l,"ccBlueChannel",get_ccBlueChannel,set_ccBlueChannel,true);
		addMember(l,"bgBloomAndGlareEnable",get_bgBloomAndGlareEnable,set_bgBloomAndGlareEnable,true);
		addMember(l,"bgIntensity",get_bgIntensity,set_bgIntensity,true);
		addMember(l,"bgThreshold",get_bgThreshold,set_bgThreshold,true);
		addMember(l,"bgRGBThreshold",get_bgRGBThreshold,set_bgRGBThreshold,true);
		addMember(l,"bgBlurIterations",get_bgBlurIterations,set_bgBlurIterations,true);
		addMember(l,"bgSampleDistance",get_bgSampleDistance,set_bgSampleDistance,true);
		addMember(l,"bgLensFlareIntensity",get_bgLensFlareIntensity,set_bgLensFlareIntensity,true);
		addMember(l,"bgLensFlareThreshold",get_bgLensFlareThreshold,set_bgLensFlareThreshold,true);
		addMember(l,"bgLensFlareStretchWidth",get_bgLensFlareStretchWidth,set_bgLensFlareStretchWidth,true);
		addMember(l,"bgLensFlareRotation",get_bgLensFlareRotation,set_bgLensFlareRotation,true);
		addMember(l,"bgSaturation",get_bgSaturation,set_bgSaturation,true);
		addMember(l,"bgTintColor",get_bgTintColor,set_bgTintColor,true);
		createTypeMetatable(l,null, typeof(PostProcessCtrl2),typeof(UnityEngine.MonoBehaviour));
	}
}
