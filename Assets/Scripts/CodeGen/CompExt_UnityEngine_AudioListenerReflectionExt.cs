// UnityEngine.AudioListener
using UnityEngine;
using System;
public static class CompExt_UnityEngine_AudioListenerReflectionExt
{
	static public object FastGetter(this UnityEngine.AudioListener o, string propertyName)
	{
		switch(propertyName) {
			case "velocityUpdateMode":
			  return o.velocityUpdateMode;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
			case "enabled":
			  return o.enabled;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioListener no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.AudioListener o, string propertyName, object value)
	{
		switch(propertyName) {
			case "velocityUpdateMode":
			  o.velocityUpdateMode=(UnityEngine.AudioVelocityUpdateMode)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
			case "enabled":
			  o.enabled=(bool)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioListener no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioListener o, string propertyName, UnityEngine.AudioVelocityUpdateMode value)
	{
		switch(propertyName) {
			case "velocityUpdateMode":
			  o.velocityUpdateMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioListener no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioListener o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "enabled":
			  o.enabled=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioListener no Setter Found : " + propertyName);
	}
}
