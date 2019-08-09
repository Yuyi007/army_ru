// UnityEngine.Component
using UnityEngine;
using System;
public static class CompExt_UnityEngine_ComponentReflectionExt
{
	static public object FastGetter(this UnityEngine.Component o, string propertyName)
	{
		switch(propertyName) {
			case "transform":
			  return o.transform;
			case "gameObject":
			  return o.gameObject;
			case "tag":
			  return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.Component no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Component o, string propertyName, object value)
	{
		switch(propertyName) {
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Component no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Component o, string propertyName, System.String value)
	{
		switch(propertyName) {
			case "tag":
			  o.tag=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Component no Setter Found : " + propertyName);
	}
}
