// UnityEngine.GameObject
using UnityEngine;
using System;
public static class CompExt_UnityEngine_GameObjectReflectionExt
{
	static public object FastGetter(this UnityEngine.GameObject o, string propertyName)
	{
		switch(propertyName) {
			case "transform":
			  return o.transform;
			case "layer":
			  return o.layer;
			case "activeSelf":
			  return o.activeSelf;
			case "activeInHierarchy":
			  return o.activeInHierarchy;
			case "isStatic":
			  return o.isStatic;
			case "tag":
			  return o.tag;
			case "scene":
			  return o.scene;
			case "gameObject":
			  return o.gameObject;
		}
		LBoot.LogUtil.Error("UnityEngine.GameObject no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.GameObject o, string propertyName, object value)
	{
		switch(propertyName) {
			case "layer":
			  o.layer=(System.Int32)value;return;
			case "isStatic":
			  o.isStatic=(System.Boolean)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.GameObject no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.GameObject o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "layer":
			  o.layer=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.GameObject no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.GameObject o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "isStatic":
			  o.isStatic=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.GameObject no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.GameObject o, string propertyName, System.String value)
	{
		switch(propertyName) {
			case "tag":
			  o.tag=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.GameObject no Setter Found : " + propertyName);
	}
}
