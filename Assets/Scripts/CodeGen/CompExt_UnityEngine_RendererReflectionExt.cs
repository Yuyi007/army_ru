// UnityEngine.Renderer
using UnityEngine;
using System;
public static class CompExt_UnityEngine_RendererReflectionExt
{
	static public object FastGetter(this UnityEngine.Renderer o, string propertyName)
	{
		switch(propertyName) {
			case "isPartOfStaticBatch":
			  return o.isPartOfStaticBatch;
			case "worldToLocalMatrix":
			  return o.worldToLocalMatrix;
			case "localToWorldMatrix":
			  return o.localToWorldMatrix;
			case "enabled":
			  return o.enabled;
			case "shadowCastingMode":
			  return o.shadowCastingMode;
			case "receiveShadows":
			  return o.receiveShadows;
			case "material":
			  return o.material;
			case "sharedMaterial":
			  return o.sharedMaterial;
			case "materials":
			  return o.materials;
			case "sharedMaterials":
			  return o.sharedMaterials;
			case "bounds":
			  return o.bounds;
			case "lightmapIndex":
			  return o.lightmapIndex;
			case "realtimeLightmapIndex":
			  return o.realtimeLightmapIndex;
			case "lightmapScaleOffset":
			  return o.lightmapScaleOffset;
			case "motionVectors":
			  return o.motionVectors;
			case "realtimeLightmapScaleOffset":
			  return o.realtimeLightmapScaleOffset;
			case "isVisible":
			  return o.isVisible;
			case "lightProbeUsage":
			  return o.lightProbeUsage;
			case "lightProbeProxyVolumeOverride":
			  return o.lightProbeProxyVolumeOverride;
			case "probeAnchor":
			  return o.probeAnchor;
			case "reflectionProbeUsage":
			  return o.reflectionProbeUsage;
			case "sortingLayerName":
			  return o.sortingLayerName;
			case "sortingLayerID":
			  return o.sortingLayerID;
			case "sortingOrder":
			  return o.sortingOrder;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, object value)
	{
		switch(propertyName) {
			case "enabled":
			  o.enabled=(System.Boolean)value;return;
			case "shadowCastingMode":
			  o.shadowCastingMode=(UnityEngine.Rendering.ShadowCastingMode)value;return;
			case "receiveShadows":
			  o.receiveShadows=(System.Boolean)value;return;
			case "material":
			  o.material=(UnityEngine.Material)value;return;
			case "sharedMaterial":
			  o.sharedMaterial=(UnityEngine.Material)value;return;
			case "materials":
			  o.materials=(UnityEngine.Material[])value;return;
			case "sharedMaterials":
			  o.sharedMaterials=(UnityEngine.Material[])value;return;
			case "lightmapIndex":
			  o.lightmapIndex=(System.Int32)value;return;
			case "realtimeLightmapIndex":
			  o.realtimeLightmapIndex=(System.Int32)value;return;
			case "lightmapScaleOffset":
			  o.lightmapScaleOffset=(UnityEngine.Vector4)value;return;
			case "motionVectors":
			  o.motionVectors=(System.Boolean)value;return;
			case "realtimeLightmapScaleOffset":
			  o.realtimeLightmapScaleOffset=(UnityEngine.Vector4)value;return;
			case "lightProbeUsage":
			  o.lightProbeUsage=(UnityEngine.Rendering.LightProbeUsage)value;return;
			case "lightProbeProxyVolumeOverride":
			  o.lightProbeProxyVolumeOverride=(UnityEngine.GameObject)value;return;
			case "probeAnchor":
			  o.probeAnchor=(UnityEngine.Transform)value;return;
			case "reflectionProbeUsage":
			  o.reflectionProbeUsage=(UnityEngine.Rendering.ReflectionProbeUsage)value;return;
			case "sortingLayerName":
			  o.sortingLayerName=(System.String)value;return;
			case "sortingLayerID":
			  o.sortingLayerID=(System.Int32)value;return;
			case "sortingOrder":
			  o.sortingOrder=(System.Int32)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "enabled":
			  o.enabled=value;return;
			case "receiveShadows":
			  o.receiveShadows=value;return;
			case "motionVectors":
			  o.motionVectors=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Rendering.ShadowCastingMode value)
	{
		switch(propertyName) {
			case "shadowCastingMode":
			  o.shadowCastingMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Material value)
	{
		switch(propertyName) {
			case "material":
			  o.material=value;return;
			case "sharedMaterial":
			  o.sharedMaterial=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Material[] value)
	{
		switch(propertyName) {
			case "materials":
			  o.materials=value;return;
			case "sharedMaterials":
			  o.sharedMaterials=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "lightmapIndex":
			  o.lightmapIndex=value;return;
			case "realtimeLightmapIndex":
			  o.realtimeLightmapIndex=value;return;
			case "sortingLayerID":
			  o.sortingLayerID=value;return;
			case "sortingOrder":
			  o.sortingOrder=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Vector4 value)
	{
		switch(propertyName) {
			case "lightmapScaleOffset":
			  o.lightmapScaleOffset=value;return;
			case "realtimeLightmapScaleOffset":
			  o.realtimeLightmapScaleOffset=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Rendering.LightProbeUsage value)
	{
		switch(propertyName) {
			case "lightProbeUsage":
			  o.lightProbeUsage=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.GameObject value)
	{
		switch(propertyName) {
			case "lightProbeProxyVolumeOverride":
			  o.lightProbeProxyVolumeOverride=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Transform value)
	{
		switch(propertyName) {
			case "probeAnchor":
			  o.probeAnchor=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, UnityEngine.Rendering.ReflectionProbeUsage value)
	{
		switch(propertyName) {
			case "reflectionProbeUsage":
			  o.reflectionProbeUsage=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Renderer o, string propertyName, System.String value)
	{
		switch(propertyName) {
			case "sortingLayerName":
			  o.sortingLayerName=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Renderer no Setter Found : " + propertyName);
	}
}
