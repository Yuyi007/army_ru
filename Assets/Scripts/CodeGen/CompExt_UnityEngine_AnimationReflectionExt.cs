// UnityEngine.Animation
using UnityEngine;
using System;
public static class CompExt_UnityEngine_AnimationReflectionExt
{
	static public object FastGetter(this UnityEngine.Animation o, string propertyName)
	{
		switch(propertyName) {
			case "clip":
			  return o.clip;
			case "playAutomatically":
			  return o.playAutomatically;
			case "wrapMode":
			  return o.wrapMode;
			case "isPlaying":
			  return o.isPlaying;
			case "animatePhysics":
			  return o.animatePhysics;
			case "cullingType":
			  return o.cullingType;
			case "localBounds":
			  return o.localBounds;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
			case "enabled":
			  return o.enabled;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, object value)
	{
		switch(propertyName) {
			case "clip":
			  o.clip=(UnityEngine.AnimationClip)value;return;
			case "playAutomatically":
			  o.playAutomatically=(System.Boolean)value;return;
			case "wrapMode":
			  o.wrapMode=(UnityEngine.WrapMode)value;return;
			case "animatePhysics":
			  o.animatePhysics=(System.Boolean)value;return;
			case "cullingType":
			  o.cullingType=(UnityEngine.AnimationCullingType)value;return;
			case "localBounds":
			  o.localBounds=(UnityEngine.Bounds)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
			case "enabled":
			  o.enabled=(bool)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, UnityEngine.AnimationClip value)
	{
		switch(propertyName) {
			case "clip":
			  o.clip=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "playAutomatically":
			  o.playAutomatically=value;return;
			case "animatePhysics":
			  o.animatePhysics=value;return;
			case "enabled":
			  o.enabled=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, UnityEngine.WrapMode value)
	{
		switch(propertyName) {
			case "wrapMode":
			  o.wrapMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, UnityEngine.AnimationCullingType value)
	{
		switch(propertyName) {
			case "cullingType":
			  o.cullingType=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animation o, string propertyName, UnityEngine.Bounds value)
	{
		switch(propertyName) {
			case "localBounds":
			  o.localBounds=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animation no Setter Found : " + propertyName);
	}
}
