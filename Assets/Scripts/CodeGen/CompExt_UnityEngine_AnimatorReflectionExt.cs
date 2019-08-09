// UnityEngine.Animator
using UnityEngine;
using System;
public static class CompExt_UnityEngine_AnimatorReflectionExt
{
	static public object FastGetter(this UnityEngine.Animator o, string propertyName)
	{
		switch(propertyName) {
			case "isOptimizable":
			  return o.isOptimizable;
			case "isHuman":
			  return o.isHuman;
			case "hasRootMotion":
			  return o.hasRootMotion;
			case "humanScale":
			  return o.humanScale;
			case "isInitialized":
			  return o.isInitialized;
			case "deltaPosition":
			  return o.deltaPosition;
			case "deltaRotation":
			  return o.deltaRotation;
			case "velocity":
			  return o.velocity;
			case "angularVelocity":
			  return o.angularVelocity;
			case "rootPosition":
			  return o.rootPosition;
			case "rootRotation":
			  return o.rootRotation;
			case "applyRootMotion":
			  return o.applyRootMotion;
			case "linearVelocityBlending":
			  return o.linearVelocityBlending;
			case "updateMode":
			  return o.updateMode;
			case "hasTransformHierarchy":
			  return o.hasTransformHierarchy;
			case "gravityWeight":
			  return o.gravityWeight;
			case "bodyPosition":
			  return o.bodyPosition;
			case "bodyRotation":
			  return o.bodyRotation;
			case "stabilizeFeet":
			  return o.stabilizeFeet;
			case "layerCount":
			  return o.layerCount;
			case "parameters":
			  return o.parameters;
			case "parameterCount":
			  return o.parameterCount;
			case "feetPivotActive":
			  return o.feetPivotActive;
			case "pivotWeight":
			  return o.pivotWeight;
			case "pivotPosition":
			  return o.pivotPosition;
			case "isMatchingTarget":
			  return o.isMatchingTarget;
			case "speed":
			  return o.speed;
			case "targetPosition":
			  return o.targetPosition;
			case "targetRotation":
			  return o.targetRotation;
			case "cullingMode":
			  return o.cullingMode;
			case "playbackTime":
			  return o.playbackTime;
			case "recorderStartTime":
			  return o.recorderStartTime;
			case "recorderStopTime":
			  return o.recorderStopTime;
			case "recorderMode":
			  return o.recorderMode;
			case "runtimeAnimatorController":
			  return o.runtimeAnimatorController;
			case "avatar":
			  return o.avatar;
			case "layersAffectMassCenter":
			  return o.layersAffectMassCenter;
			case "leftFeetBottomHeight":
			  return o.leftFeetBottomHeight;
			case "rightFeetBottomHeight":
			  return o.rightFeetBottomHeight;
			case "logWarnings":
			  return o.logWarnings;
			case "fireEvents":
			  return o.fireEvents;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
			case "enabled":
			  return o.enabled;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, object value)
	{
		switch(propertyName) {
			case "rootPosition":
			  o.rootPosition=(UnityEngine.Vector3)value;return;
			case "rootRotation":
			  o.rootRotation=(UnityEngine.Quaternion)value;return;
			case "applyRootMotion":
			  o.applyRootMotion=(System.Boolean)value;return;
			case "linearVelocityBlending":
			  o.linearVelocityBlending=(System.Boolean)value;return;
			case "updateMode":
			  o.updateMode=(UnityEngine.AnimatorUpdateMode)value;return;
			case "bodyPosition":
			  o.bodyPosition=(UnityEngine.Vector3)value;return;
			case "bodyRotation":
			  o.bodyRotation=(UnityEngine.Quaternion)value;return;
			case "stabilizeFeet":
			  o.stabilizeFeet=(System.Boolean)value;return;
			case "feetPivotActive":
			  o.feetPivotActive=(System.Single)value;return;
			case "speed":
			  o.speed=(System.Single)value;return;
			case "cullingMode":
			  o.cullingMode=(UnityEngine.AnimatorCullingMode)value;return;
			case "playbackTime":
			  o.playbackTime=(System.Single)value;return;
			case "recorderStartTime":
			  o.recorderStartTime=(System.Single)value;return;
			case "recorderStopTime":
			  o.recorderStopTime=(System.Single)value;return;
			case "runtimeAnimatorController":
			  o.runtimeAnimatorController=(UnityEngine.RuntimeAnimatorController)value;return;
			case "avatar":
			  o.avatar=(UnityEngine.Avatar)value;return;
			case "layersAffectMassCenter":
			  o.layersAffectMassCenter=(System.Boolean)value;return;
			case "logWarnings":
			  o.logWarnings=(System.Boolean)value;return;
			case "fireEvents":
			  o.fireEvents=(System.Boolean)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
			case "enabled":
			  o.enabled=(bool)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "rootPosition":
			  o.rootPosition=value;return;
			case "bodyPosition":
			  o.bodyPosition=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.Quaternion value)
	{
		switch(propertyName) {
			case "rootRotation":
			  o.rootRotation=value;return;
			case "bodyRotation":
			  o.bodyRotation=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "applyRootMotion":
			  o.applyRootMotion=value;return;
			case "linearVelocityBlending":
			  o.linearVelocityBlending=value;return;
			case "stabilizeFeet":
			  o.stabilizeFeet=value;return;
			case "layersAffectMassCenter":
			  o.layersAffectMassCenter=value;return;
			case "logWarnings":
			  o.logWarnings=value;return;
			case "fireEvents":
			  o.fireEvents=value;return;
			case "enabled":
			  o.enabled=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.AnimatorUpdateMode value)
	{
		switch(propertyName) {
			case "updateMode":
			  o.updateMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "feetPivotActive":
			  o.feetPivotActive=value;return;
			case "speed":
			  o.speed=value;return;
			case "playbackTime":
			  o.playbackTime=value;return;
			case "recorderStartTime":
			  o.recorderStartTime=value;return;
			case "recorderStopTime":
			  o.recorderStopTime=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.AnimatorCullingMode value)
	{
		switch(propertyName) {
			case "cullingMode":
			  o.cullingMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.RuntimeAnimatorController value)
	{
		switch(propertyName) {
			case "runtimeAnimatorController":
			  o.runtimeAnimatorController=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Animator o, string propertyName, UnityEngine.Avatar value)
	{
		switch(propertyName) {
			case "avatar":
			  o.avatar=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Animator no Setter Found : " + propertyName);
	}
}
