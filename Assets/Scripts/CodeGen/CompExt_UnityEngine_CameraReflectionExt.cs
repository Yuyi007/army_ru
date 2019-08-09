// UnityEngine.Camera
using UnityEngine;
using System;
public static class CompExt_UnityEngine_CameraReflectionExt
{
	static public object FastGetter(this UnityEngine.Camera o, string propertyName)
	{
		switch(propertyName) {
			case "fieldOfView":
			  return o.fieldOfView;
			case "nearClipPlane":
			  return o.nearClipPlane;
			case "farClipPlane":
			  return o.farClipPlane;
			case "renderingPath":
			  return o.renderingPath;
			case "actualRenderingPath":
			  return o.actualRenderingPath;
			case "hdr":
			  return o.hdr;
			case "orthographicSize":
			  return o.orthographicSize;
			case "orthographic":
			  return o.orthographic;
			case "opaqueSortMode":
			  return o.opaqueSortMode;
			case "transparencySortMode":
			  return o.transparencySortMode;
			case "depth":
			  return o.depth;
			case "aspect":
			  return o.aspect;
			case "cullingMask":
			  return o.cullingMask;
			case "eventMask":
			  return o.eventMask;
			case "backgroundColor":
			  return o.backgroundColor;
			case "rect":
			  return o.rect;
			case "pixelRect":
			  return o.pixelRect;
			case "targetTexture":
			  return o.targetTexture;
			case "pixelWidth":
			  return o.pixelWidth;
			case "pixelHeight":
			  return o.pixelHeight;
			case "cameraToWorldMatrix":
			  return o.cameraToWorldMatrix;
			case "worldToCameraMatrix":
			  return o.worldToCameraMatrix;
			case "projectionMatrix":
			  return o.projectionMatrix;
			case "nonJitteredProjectionMatrix":
			  return o.nonJitteredProjectionMatrix;
			case "velocity":
			  return o.velocity;
			case "clearFlags":
			  return o.clearFlags;
			case "stereoEnabled":
			  return o.stereoEnabled;
			case "stereoSeparation":
			  return o.stereoSeparation;
			case "stereoConvergence":
			  return o.stereoConvergence;
			case "cameraType":
			  return o.cameraType;
			case "stereoTargetEye":
			  return o.stereoTargetEye;
			case "targetDisplay":
			  return o.targetDisplay;
			case "useOcclusionCulling":
			  return o.useOcclusionCulling;
			case "cullingMatrix":
			  return o.cullingMatrix;
			case "layerCullDistances":
			  return o.layerCullDistances;
			case "layerCullSpherical":
			  return o.layerCullSpherical;
			case "depthTextureMode":
			  return o.depthTextureMode;
			case "clearStencilAfterLightingPass":
			  return o.clearStencilAfterLightingPass;
			case "commandBufferCount":
			  return o.commandBufferCount;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
			case "enabled":
			  return o.enabled;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, object value)
	{
		switch(propertyName) {
			case "fieldOfView":
			  o.fieldOfView=(System.Single)value;return;
			case "nearClipPlane":
			  o.nearClipPlane=(System.Single)value;return;
			case "farClipPlane":
			  o.farClipPlane=(System.Single)value;return;
			case "renderingPath":
			  o.renderingPath=(UnityEngine.RenderingPath)value;return;
			case "hdr":
			  o.hdr=(System.Boolean)value;return;
			case "orthographicSize":
			  o.orthographicSize=(System.Single)value;return;
			case "orthographic":
			  o.orthographic=(System.Boolean)value;return;
			case "opaqueSortMode":
			  o.opaqueSortMode=(UnityEngine.Rendering.OpaqueSortMode)value;return;
			case "transparencySortMode":
			  o.transparencySortMode=(UnityEngine.TransparencySortMode)value;return;
			case "depth":
			  o.depth=(System.Single)value;return;
			case "aspect":
			  o.aspect=(System.Single)value;return;
			case "cullingMask":
			  o.cullingMask=(System.Int32)value;return;
			case "eventMask":
			  o.eventMask=(System.Int32)value;return;
			case "backgroundColor":
			  o.backgroundColor=(UnityEngine.Color)value;return;
			case "rect":
			  o.rect=(UnityEngine.Rect)value;return;
			case "pixelRect":
			  o.pixelRect=(UnityEngine.Rect)value;return;
			case "targetTexture":
			  o.targetTexture=(UnityEngine.RenderTexture)value;return;
			case "worldToCameraMatrix":
			  o.worldToCameraMatrix=(UnityEngine.Matrix4x4)value;return;
			case "projectionMatrix":
			  o.projectionMatrix=(UnityEngine.Matrix4x4)value;return;
			case "nonJitteredProjectionMatrix":
			  o.nonJitteredProjectionMatrix=(UnityEngine.Matrix4x4)value;return;
			case "clearFlags":
			  o.clearFlags=(UnityEngine.CameraClearFlags)value;return;
			case "stereoSeparation":
			  o.stereoSeparation=(System.Single)value;return;
			case "stereoConvergence":
			  o.stereoConvergence=(System.Single)value;return;
			case "cameraType":
			  o.cameraType=(UnityEngine.CameraType)value;return;
			case "stereoTargetEye":
			  o.stereoTargetEye=(UnityEngine.StereoTargetEyeMask)value;return;
			case "targetDisplay":
			  o.targetDisplay=(System.Int32)value;return;
			case "useOcclusionCulling":
			  o.useOcclusionCulling=(System.Boolean)value;return;
			case "cullingMatrix":
			  o.cullingMatrix=(UnityEngine.Matrix4x4)value;return;
			case "layerCullDistances":
			  o.layerCullDistances=(System.Single[])value;return;
			case "layerCullSpherical":
			  o.layerCullSpherical=(System.Boolean)value;return;
			case "depthTextureMode":
			  o.depthTextureMode=(UnityEngine.DepthTextureMode)value;return;
			case "clearStencilAfterLightingPass":
			  o.clearStencilAfterLightingPass=(System.Boolean)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
			case "enabled":
			  o.enabled=(bool)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "fieldOfView":
			  o.fieldOfView=value;return;
			case "nearClipPlane":
			  o.nearClipPlane=value;return;
			case "farClipPlane":
			  o.farClipPlane=value;return;
			case "orthographicSize":
			  o.orthographicSize=value;return;
			case "depth":
			  o.depth=value;return;
			case "aspect":
			  o.aspect=value;return;
			case "stereoSeparation":
			  o.stereoSeparation=value;return;
			case "stereoConvergence":
			  o.stereoConvergence=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.RenderingPath value)
	{
		switch(propertyName) {
			case "renderingPath":
			  o.renderingPath=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "hdr":
			  o.hdr=value;return;
			case "orthographic":
			  o.orthographic=value;return;
			case "useOcclusionCulling":
			  o.useOcclusionCulling=value;return;
			case "layerCullSpherical":
			  o.layerCullSpherical=value;return;
			case "clearStencilAfterLightingPass":
			  o.clearStencilAfterLightingPass=value;return;
			case "enabled":
			  o.enabled=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.Rendering.OpaqueSortMode value)
	{
		switch(propertyName) {
			case "opaqueSortMode":
			  o.opaqueSortMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.TransparencySortMode value)
	{
		switch(propertyName) {
			case "transparencySortMode":
			  o.transparencySortMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "cullingMask":
			  o.cullingMask=value;return;
			case "eventMask":
			  o.eventMask=value;return;
			case "targetDisplay":
			  o.targetDisplay=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.Color value)
	{
		switch(propertyName) {
			case "backgroundColor":
			  o.backgroundColor=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.Rect value)
	{
		switch(propertyName) {
			case "rect":
			  o.rect=value;return;
			case "pixelRect":
			  o.pixelRect=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.RenderTexture value)
	{
		switch(propertyName) {
			case "targetTexture":
			  o.targetTexture=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.Matrix4x4 value)
	{
		switch(propertyName) {
			case "worldToCameraMatrix":
			  o.worldToCameraMatrix=value;return;
			case "projectionMatrix":
			  o.projectionMatrix=value;return;
			case "nonJitteredProjectionMatrix":
			  o.nonJitteredProjectionMatrix=value;return;
			case "cullingMatrix":
			  o.cullingMatrix=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.CameraClearFlags value)
	{
		switch(propertyName) {
			case "clearFlags":
			  o.clearFlags=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.CameraType value)
	{
		switch(propertyName) {
			case "cameraType":
			  o.cameraType=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.StereoTargetEyeMask value)
	{
		switch(propertyName) {
			case "stereoTargetEye":
			  o.stereoTargetEye=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, System.Single[] value)
	{
		switch(propertyName) {
			case "layerCullDistances":
			  o.layerCullDistances=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Camera o, string propertyName, UnityEngine.DepthTextureMode value)
	{
		switch(propertyName) {
			case "depthTextureMode":
			  o.depthTextureMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Camera no Setter Found : " + propertyName);
	}
}
