using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_ColorCorrectionCurves : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves o;
			o=new UnityStandardAssets.ImageEffects.ColorCorrectionCurves();
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
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateParameters(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			self.UpdateParameters();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_redChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.redChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_redChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.redChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_greenChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.greenChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_greenChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.greenChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blueChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.blueChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blueChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.blueChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useDepthCorrection(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.useDepthCorrection);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useDepthCorrection(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useDepthCorrection=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_zCurve(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.zCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_zCurve(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.zCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_depthRedChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.depthRedChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_depthRedChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.depthRedChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_depthGreenChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.depthGreenChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_depthGreenChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.depthGreenChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_depthBlueChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.depthBlueChannel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_depthBlueChannel(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.depthBlueChannel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_saturation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.saturation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_saturation(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.saturation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectiveCc(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.selectiveCc);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectiveCc(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.selectiveCc=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectiveFromColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.selectiveFromColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectiveFromColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.selectiveFromColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectiveToColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.selectiveToColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectiveToColor(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.selectiveToColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushEnum(l,(int)self.mode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mode(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves.ColorCorrectionMode v;
			checkEnum(l,2,out v);
			self.mode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateTextures(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.updateTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_updateTextures(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.updateTextures=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorCorrectionCurvesShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.colorCorrectionCurvesShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorCorrectionCurvesShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.colorCorrectionCurvesShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_simpleColorCorrectionCurvesShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.simpleColorCorrectionCurvesShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_simpleColorCorrectionCurvesShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.simpleColorCorrectionCurvesShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorCorrectionSelectiveShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			pushValue(l,self.colorCorrectionSelectiveShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorCorrectionSelectiveShader(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.ColorCorrectionCurves self=(UnityStandardAssets.ImageEffects.ColorCorrectionCurves)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.colorCorrectionSelectiveShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.ColorCorrectionCurves");
		addMember(l,CheckResources);
		addMember(l,UpdateParameters);
		addMember(l,"redChannel",get_redChannel,set_redChannel,true);
		addMember(l,"greenChannel",get_greenChannel,set_greenChannel,true);
		addMember(l,"blueChannel",get_blueChannel,set_blueChannel,true);
		addMember(l,"useDepthCorrection",get_useDepthCorrection,set_useDepthCorrection,true);
		addMember(l,"zCurve",get_zCurve,set_zCurve,true);
		addMember(l,"depthRedChannel",get_depthRedChannel,set_depthRedChannel,true);
		addMember(l,"depthGreenChannel",get_depthGreenChannel,set_depthGreenChannel,true);
		addMember(l,"depthBlueChannel",get_depthBlueChannel,set_depthBlueChannel,true);
		addMember(l,"saturation",get_saturation,set_saturation,true);
		addMember(l,"selectiveCc",get_selectiveCc,set_selectiveCc,true);
		addMember(l,"selectiveFromColor",get_selectiveFromColor,set_selectiveFromColor,true);
		addMember(l,"selectiveToColor",get_selectiveToColor,set_selectiveToColor,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"updateTextures",get_updateTextures,set_updateTextures,true);
		addMember(l,"colorCorrectionCurvesShader",get_colorCorrectionCurvesShader,set_colorCorrectionCurvesShader,true);
		addMember(l,"simpleColorCorrectionCurvesShader",get_simpleColorCorrectionCurvesShader,set_simpleColorCorrectionCurvesShader,true);
		addMember(l,"colorCorrectionSelectiveShader",get_colorCorrectionSelectiveShader,set_colorCorrectionSelectiveShader,true);
		createTypeMetatable(l,constructor, typeof(UnityStandardAssets.ImageEffects.ColorCorrectionCurves),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
