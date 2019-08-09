﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Light : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Light o;
			o=new UnityEngine.Light();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddCommandBuffer(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
				UnityEngine.Rendering.LightEvent a1;
				checkEnum(l,2,out a1);
				UnityEngine.Rendering.CommandBuffer a2;
				checkType(l,3,out a2);
				self.AddCommandBuffer(a1,a2);
				return 0;
			}
			else if(argc==4){
				UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
				UnityEngine.Rendering.LightEvent a1;
				checkEnum(l,2,out a1);
				UnityEngine.Rendering.CommandBuffer a2;
				checkType(l,3,out a2);
				UnityEngine.Rendering.ShadowMapPass a3;
				checkEnum(l,4,out a3);
				self.AddCommandBuffer(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveCommandBuffer(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Rendering.LightEvent a1;
			checkEnum(l,2,out a1);
			UnityEngine.Rendering.CommandBuffer a2;
			checkType(l,3,out a2);
			self.RemoveCommandBuffer(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveCommandBuffers(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Rendering.LightEvent a1;
			checkEnum(l,2,out a1);
			self.RemoveCommandBuffers(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveAllCommandBuffers(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			self.RemoveAllCommandBuffers();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCommandBuffers(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Rendering.LightEvent a1;
			checkEnum(l,2,out a1);
			var ret=self.GetCommandBuffers(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLights_s(IntPtr l) {
		try {
			UnityEngine.LightType a1;
			checkEnum(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.Light.GetLights(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadows(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushEnum(l,(int)self.shadows);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadows(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.LightShadows v;
			checkEnum(l,2,out v);
			self.shadows=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowStrength(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.shadowStrength);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowStrength(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowStrength=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowResolution(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushEnum(l,(int)self.shadowResolution);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowResolution(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Rendering.LightShadowResolution v;
			checkEnum(l,2,out v);
			self.shadowResolution=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cookieSize(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.cookieSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cookieSize(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.cookieSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cookie(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.cookie);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cookie(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.cookie=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderMode(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushEnum(l,(int)self.renderMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderMode(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.LightRenderMode v;
			checkEnum(l,2,out v);
			self.renderMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	// [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	// static public int get_lightmapBakeType(IntPtr l) {
	// 	try {
	// 		UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
	// 		pushEnum(l,(int)self.lightmapBakeType);
	// 		return 1;
	// 	}
	// 	catch(Exception e) {
	// 		return error(l,e);
	// 	}
	// }
	// [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	// static public int set_lightmapBakeType(IntPtr l) {
	// 	try {
	// 		UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
	// 		UnityEngine.LightmapBakeType v;
	// 		checkEnum(l,2,out v);
	// 		self.lightmapBakeType=v;
	// 		return 0;
	// 	}
	// 	catch(Exception e) {
	// 		return error(l,e);
	// 	}
	// }
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_commandBufferCount(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.commandBufferCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushEnum(l,(int)self.type);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.LightType v;
			checkEnum(l,2,out v);
			self.type=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spotAngle(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.spotAngle);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spotAngle(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spotAngle=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
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
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
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
	static public int get_colorTemperature(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.colorTemperature);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorTemperature(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.colorTemperature=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_intensity(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
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
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.intensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bounceIntensity(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.bounceIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bounceIntensity(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.bounceIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowCustomResolution(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.shadowCustomResolution);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowCustomResolution(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.shadowCustomResolution=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowBias(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.shadowBias);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowBias(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowBias=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowNormalBias(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.shadowNormalBias);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowNormalBias(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowNormalBias=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowNearPlane(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.shadowNearPlane);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowNearPlane(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowNearPlane=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_range(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.range);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_range(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.range=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flare(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.flare);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flare(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.Flare v;
			checkType(l,2,out v);
			self.flare=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bakingOutput(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.bakingOutput);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bakingOutput(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			UnityEngine.LightBakingOutput v;
			checkValueType(l,2,out v);
			self.bakingOutput=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingMask(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			pushValue(l,self.cullingMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingMask(IntPtr l) {
		try {
			UnityEngine.Light self=(UnityEngine.Light)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.cullingMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Light");
		addMember(l,AddCommandBuffer);
		addMember(l,RemoveCommandBuffer);
		addMember(l,RemoveCommandBuffers);
		addMember(l,RemoveAllCommandBuffers);
		addMember(l,GetCommandBuffers);
		addMember(l,GetLights_s);
		addMember(l,"shadows",get_shadows,set_shadows,true);
		addMember(l,"shadowStrength",get_shadowStrength,set_shadowStrength,true);
		addMember(l,"shadowResolution",get_shadowResolution,set_shadowResolution,true);
		addMember(l,"cookieSize",get_cookieSize,set_cookieSize,true);
		addMember(l,"cookie",get_cookie,set_cookie,true);
		addMember(l,"renderMode",get_renderMode,set_renderMode,true);
		// addMember(l,"lightmapBakeType",get_lightmapBakeType,set_lightmapBakeType,true);
		addMember(l,"commandBufferCount",get_commandBufferCount,null,true);
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"spotAngle",get_spotAngle,set_spotAngle,true);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"colorTemperature",get_colorTemperature,set_colorTemperature,true);
		addMember(l,"intensity",get_intensity,set_intensity,true);
		addMember(l,"bounceIntensity",get_bounceIntensity,set_bounceIntensity,true);
		addMember(l,"shadowCustomResolution",get_shadowCustomResolution,set_shadowCustomResolution,true);
		addMember(l,"shadowBias",get_shadowBias,set_shadowBias,true);
		addMember(l,"shadowNormalBias",get_shadowNormalBias,set_shadowNormalBias,true);
		addMember(l,"shadowNearPlane",get_shadowNearPlane,set_shadowNearPlane,true);
		addMember(l,"range",get_range,set_range,true);
		addMember(l,"flare",get_flare,set_flare,true);
		addMember(l,"bakingOutput",get_bakingOutput,set_bakingOutput,true);
		addMember(l,"cullingMask",get_cullingMask,set_cullingMask,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Light),typeof(UnityEngine.Behaviour));
	}
}
