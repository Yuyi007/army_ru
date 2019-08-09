// UnityEngine.SkinnedMeshRenderer
using UnityEngine;
using System;
public static class CompExt_UnityEngine_SkinnedMeshRendererReflectionExt
{
	static public object FastGetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName)
	{
		switch(propertyName) {
			case "bones":
			  return o.bones;
			case "rootBone":
			  return o.rootBone;
			case "quality":
			  return o.quality;
			case "sharedMesh":
			  return o.sharedMesh;
			case "updateWhenOffscreen":
			  return o.updateWhenOffscreen;
			case "skinnedMotionVectors":
			  return o.skinnedMotionVectors;
			case "localBounds":
			  return o.localBounds;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, object value)
	{
		switch(propertyName) {
			case "bones":
			  o.bones=(UnityEngine.Transform[])value;return;
			case "rootBone":
			  o.rootBone=(UnityEngine.Transform)value;return;
			case "quality":
			  o.quality=(UnityEngine.SkinQuality)value;return;
			case "sharedMesh":
			  o.sharedMesh=(UnityEngine.Mesh)value;return;
			case "updateWhenOffscreen":
			  o.updateWhenOffscreen=(System.Boolean)value;return;
			case "skinnedMotionVectors":
			  o.skinnedMotionVectors=(System.Boolean)value;return;
			case "localBounds":
			  o.localBounds=(UnityEngine.Bounds)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, UnityEngine.Transform[] value)
	{
		switch(propertyName) {
			case "bones":
			  o.bones=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, UnityEngine.Transform value)
	{
		switch(propertyName) {
			case "rootBone":
			  o.rootBone=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, UnityEngine.SkinQuality value)
	{
		switch(propertyName) {
			case "quality":
			  o.quality=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, UnityEngine.Mesh value)
	{
		switch(propertyName) {
			case "sharedMesh":
			  o.sharedMesh=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "updateWhenOffscreen":
			  o.updateWhenOffscreen=value;return;
			case "skinnedMotionVectors":
			  o.skinnedMotionVectors=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.SkinnedMeshRenderer o, string propertyName, UnityEngine.Bounds value)
	{
		switch(propertyName) {
			case "localBounds":
			  o.localBounds=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.SkinnedMeshRenderer no Setter Found : " + propertyName);
	}
}
