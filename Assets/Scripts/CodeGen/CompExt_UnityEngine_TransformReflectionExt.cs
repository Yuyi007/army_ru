// UnityEngine.Transform
using UnityEngine;
using System;
public static class CompExt_UnityEngine_TransformReflectionExt
{
	static public object FastGetter(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "position":
			  return o.position;
			case "localPosition":
			  return o.localPosition;
			case "eulerAngles":
			  return o.eulerAngles;
			case "localEulerAngles":
			  return o.localEulerAngles;
			case "right":
			  return o.right;
			case "up":
			  return o.up;
			case "forward":
			  return o.forward;
			case "rotation":
			  return o.rotation;
			case "localRotation":
			  return o.localRotation;
			case "localScale":
			  return o.localScale;
			case "parent":
			  return o.parent;
			case "worldToLocalMatrix":
			  return o.worldToLocalMatrix;
			case "localToWorldMatrix":
			  return o.localToWorldMatrix;
			case "root":
			  return o.root;
			case "childCount":
			  return o.childCount;
			case "lossyScale":
			  return o.lossyScale;
			case "hasChanged":
			  return o.hasChanged;
			case "hierarchyCapacity":
			  return o.hierarchyCapacity;
			case "hierarchyCount":
			  return o.hierarchyCount;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, object value)
	{
		switch(propertyName) {
			case "position":
			  o.position=(UnityEngine.Vector3)value;return;
			case "localPosition":
			  o.localPosition=(UnityEngine.Vector3)value;return;
			case "eulerAngles":
			  o.eulerAngles=(UnityEngine.Vector3)value;return;
			case "localEulerAngles":
			  o.localEulerAngles=(UnityEngine.Vector3)value;return;
			case "right":
			  o.right=(UnityEngine.Vector3)value;return;
			case "up":
			  o.up=(UnityEngine.Vector3)value;return;
			case "forward":
			  o.forward=(UnityEngine.Vector3)value;return;
			case "rotation":
			  o.rotation=(UnityEngine.Quaternion)value;return;
			case "localRotation":
			  o.localRotation=(UnityEngine.Quaternion)value;return;
			case "localScale":
			  o.localScale=(UnityEngine.Vector3)value;return;
			case "parent":
			  o.parent=(UnityEngine.Transform)value;return;
			case "hasChanged":
			  o.hasChanged=(System.Boolean)value;return;
			case "hierarchyCapacity":
			  o.hierarchyCapacity=(System.Int32)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "position":
			  o.position=value;return;
			case "localPosition":
			  o.localPosition=value;return;
			case "eulerAngles":
			  o.eulerAngles=value;return;
			case "localEulerAngles":
			  o.localEulerAngles=value;return;
			case "right":
			  o.right=value;return;
			case "up":
			  o.up=value;return;
			case "forward":
			  o.forward=value;return;
			case "localScale":
			  o.localScale=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, UnityEngine.Quaternion value)
	{
		switch(propertyName) {
			case "rotation":
			  o.rotation=value;return;
			case "localRotation":
			  o.localRotation=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, UnityEngine.Transform value)
	{
		switch(propertyName) {
			case "parent":
			  o.parent=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "hasChanged":
			  o.hasChanged=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Transform o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "hierarchyCapacity":
			  o.hierarchyCapacity=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Setter Found : " + propertyName);
	}
	static public UnityEngine.Vector3 FastGetterVector3(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "position":
			  return o.position;
			case "localPosition":
			  return o.localPosition;
			case "eulerAngles":
			  return o.eulerAngles;
			case "localEulerAngles":
			  return o.localEulerAngles;
			case "right":
			  return o.right;
			case "up":
			  return o.up;
			case "forward":
			  return o.forward;
			case "localScale":
			  return o.localScale;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return default(UnityEngine.Vector3);
	}
	static public UnityEngine.Quaternion FastGetterQuaternion(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "rotation":
			  return o.rotation;
			case "localRotation":
			  return o.localRotation;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return default(UnityEngine.Quaternion);
	}
	static public UnityEngine.Transform FastGetterTransform(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "parent":
			  return o.parent;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return null;
	}
	static public System.Boolean FastGetterBoolean(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "hasChanged":
			  return o.hasChanged;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return default(System.Boolean);
	}
	static public System.Int32 FastGetterInt32(this UnityEngine.Transform o, string propertyName)
	{
		switch(propertyName) {
			case "hierarchyCapacity":
			  return o.hierarchyCapacity;
		}
		LBoot.LogUtil.Error("UnityEngine.Transform no Getter Found : " + propertyName);
		return default(System.Int32);
	}
}
