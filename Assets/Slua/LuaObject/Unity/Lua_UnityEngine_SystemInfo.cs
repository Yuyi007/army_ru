﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SystemInfo : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SystemInfo o;
			o=new UnityEngine.SystemInfo();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SupportsRenderTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureFormat a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.SystemInfo.SupportsRenderTextureFormat(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SupportsBlendingOnRenderTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureFormat a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.SystemInfo.SupportsBlendingOnRenderTextureFormat(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SupportsTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.TextureFormat a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.SystemInfo.SupportsTextureFormat(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_unsupportedIdentifier(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.unsupportedIdentifier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_batteryLevel(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.batteryLevel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_batteryStatus(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.batteryStatus);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_operatingSystem(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.operatingSystem);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_operatingSystemFamily(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.operatingSystemFamily);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_processorType(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.processorType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_processorFrequency(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.processorFrequency);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_processorCount(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.processorCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_systemMemorySize(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.systemMemorySize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsMemorySize(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsMemorySize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceName(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceVendor(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVendor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceID(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceID);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceVendorID(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVendorID);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceType(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.graphicsDeviceType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsUVStartsAtTop(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsUVStartsAtTop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsDeviceVersion(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVersion);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsShaderLevel(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsShaderLevel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_graphicsMultiThreaded(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.graphicsMultiThreaded);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsShadows(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsShadows);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsRawShadowDepthSampling(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsRawShadowDepthSampling);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsMotionVectors(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsMotionVectors);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsRenderToCubemap(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsRenderToCubemap);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsImageEffects(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsImageEffects);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supports3DTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supports3DTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supports2DArrayTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supports2DArrayTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supports3DRenderTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supports3DRenderTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsCubemapArrayTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsCubemapArrayTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_copyTextureSupport(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.copyTextureSupport);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsComputeShaders(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsComputeShaders);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsInstancing(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsInstancing);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsSparseTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsSparseTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportedRenderTargetCount(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportedRenderTargetCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsMultisampledTextures(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsMultisampledTextures);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsTextureWrapMirrorOnce(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsTextureWrapMirrorOnce);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_usesReversedZBuffer(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.usesReversedZBuffer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_npotSupport(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.npotSupport);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deviceUniqueIdentifier(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.deviceUniqueIdentifier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deviceName(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.deviceName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deviceModel(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.deviceModel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsAccelerometer(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsAccelerometer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsGyroscope(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsGyroscope);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsLocationService(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsLocationService);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsVibration(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsVibration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsAudio(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsAudio);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deviceType(IntPtr l) {
		try {
			pushEnum(l,(int)UnityEngine.SystemInfo.deviceType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxTextureSize(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.maxTextureSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxCubemapSize(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.maxCubemapSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsAsyncCompute(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsAsyncCompute);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportsGPUFence(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SystemInfo.supportsGPUFence);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SystemInfo");
		addMember(l,SupportsRenderTextureFormat_s);
		addMember(l,SupportsBlendingOnRenderTextureFormat_s);
		addMember(l,SupportsTextureFormat_s);
		addMember(l,"unsupportedIdentifier",get_unsupportedIdentifier,null,false);
		addMember(l,"batteryLevel",get_batteryLevel,null,false);
		addMember(l,"batteryStatus",get_batteryStatus,null,false);
		addMember(l,"operatingSystem",get_operatingSystem,null,false);
		addMember(l,"operatingSystemFamily",get_operatingSystemFamily,null,false);
		addMember(l,"processorType",get_processorType,null,false);
		addMember(l,"processorFrequency",get_processorFrequency,null,false);
		addMember(l,"processorCount",get_processorCount,null,false);
		addMember(l,"systemMemorySize",get_systemMemorySize,null,false);
		addMember(l,"graphicsMemorySize",get_graphicsMemorySize,null,false);
		addMember(l,"graphicsDeviceName",get_graphicsDeviceName,null,false);
		addMember(l,"graphicsDeviceVendor",get_graphicsDeviceVendor,null,false);
		addMember(l,"graphicsDeviceID",get_graphicsDeviceID,null,false);
		addMember(l,"graphicsDeviceVendorID",get_graphicsDeviceVendorID,null,false);
		addMember(l,"graphicsDeviceType",get_graphicsDeviceType,null,false);
		addMember(l,"graphicsUVStartsAtTop",get_graphicsUVStartsAtTop,null,false);
		addMember(l,"graphicsDeviceVersion",get_graphicsDeviceVersion,null,false);
		addMember(l,"graphicsShaderLevel",get_graphicsShaderLevel,null,false);
		addMember(l,"graphicsMultiThreaded",get_graphicsMultiThreaded,null,false);
		addMember(l,"supportsShadows",get_supportsShadows,null,false);
		addMember(l,"supportsRawShadowDepthSampling",get_supportsRawShadowDepthSampling,null,false);
		addMember(l,"supportsMotionVectors",get_supportsMotionVectors,null,false);
		addMember(l,"supportsRenderToCubemap",get_supportsRenderToCubemap,null,false);
		addMember(l,"supportsImageEffects",get_supportsImageEffects,null,false);
		addMember(l,"supports3DTextures",get_supports3DTextures,null,false);
		addMember(l,"supports2DArrayTextures",get_supports2DArrayTextures,null,false);
		addMember(l,"supports3DRenderTextures",get_supports3DRenderTextures,null,false);
		addMember(l,"supportsCubemapArrayTextures",get_supportsCubemapArrayTextures,null,false);
		addMember(l,"copyTextureSupport",get_copyTextureSupport,null,false);
		addMember(l,"supportsComputeShaders",get_supportsComputeShaders,null,false);
		addMember(l,"supportsInstancing",get_supportsInstancing,null,false);
		addMember(l,"supportsSparseTextures",get_supportsSparseTextures,null,false);
		addMember(l,"supportedRenderTargetCount",get_supportedRenderTargetCount,null,false);
		addMember(l,"supportsMultisampledTextures",get_supportsMultisampledTextures,null,false);
		addMember(l,"supportsTextureWrapMirrorOnce",get_supportsTextureWrapMirrorOnce,null,false);
		addMember(l,"usesReversedZBuffer",get_usesReversedZBuffer,null,false);
		addMember(l,"npotSupport",get_npotSupport,null,false);
		addMember(l,"deviceUniqueIdentifier",get_deviceUniqueIdentifier,null,false);
		addMember(l,"deviceName",get_deviceName,null,false);
		addMember(l,"deviceModel",get_deviceModel,null,false);
		addMember(l,"supportsAccelerometer",get_supportsAccelerometer,null,false);
		addMember(l,"supportsGyroscope",get_supportsGyroscope,null,false);
		addMember(l,"supportsLocationService",get_supportsLocationService,null,false);
		addMember(l,"supportsVibration",get_supportsVibration,null,false);
		addMember(l,"supportsAudio",get_supportsAudio,null,false);
		addMember(l,"deviceType",get_deviceType,null,false);
		addMember(l,"maxTextureSize",get_maxTextureSize,null,false);
		addMember(l,"maxCubemapSize",get_maxCubemapSize,null,false);
		addMember(l,"supportsAsyncCompute",get_supportsAsyncCompute,null,false);
		addMember(l,"supportsGPUFence",get_supportsGPUFence,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SystemInfo));
	}
}
