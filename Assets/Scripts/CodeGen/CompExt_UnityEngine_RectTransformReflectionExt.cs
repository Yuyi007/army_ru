// UnityEngine.RectTransform
using UnityEngine;
using System;
public static class CompExt_UnityEngine_RectTransformReflectionExt
{
	static public object FastGetter(this UnityEngine.RectTransform o, string propertyName)
	{
		switch(propertyName) {
			case "rect":
			  return o.rect;
			case "anchorMin":
			  return o.anchorMin;
			case "anchorMax":
			  return o.anchorMax;
			case "anchoredPosition3D":
			  return o.anchoredPosition3D;
			case "anchoredPosition":
			  return o.anchoredPosition;
			case "sizeDelta":
			  return o.sizeDelta;
			case "pivot":
			  return o.pivot;
			case "offsetMin":
			  return o.offsetMin;
			case "offsetMax":
			  return o.offsetMax;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.RectTransform no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.RectTransform o, string propertyName, object value)
	{
		switch(propertyName) {
			case "anchorMin":
			  o.anchorMin=(UnityEngine.Vector2)value;return;
			case "anchorMax":
			  o.anchorMax=(UnityEngine.Vector2)value;return;
			case "anchoredPosition3D":
			  o.anchoredPosition3D=(UnityEngine.Vector3)value;return;
			case "anchoredPosition":
			  o.anchoredPosition=(UnityEngine.Vector2)value;return;
			case "sizeDelta":
			  o.sizeDelta=(UnityEngine.Vector2)value;return;
			case "pivot":
			  o.pivot=(UnityEngine.Vector2)value;return;
			case "offsetMin":
			  o.offsetMin=(UnityEngine.Vector2)value;return;
			case "offsetMax":
			  o.offsetMax=(UnityEngine.Vector2)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.RectTransform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.RectTransform o, string propertyName, UnityEngine.Vector2 value)
	{
		switch(propertyName) {
			case "anchorMin":
			  o.anchorMin=value;return;
			case "anchorMax":
			  o.anchorMax=value;return;
			case "anchoredPosition":
			  o.anchoredPosition=value;return;
			case "sizeDelta":
			  o.sizeDelta=value;return;
			case "pivot":
			  o.pivot=value;return;
			case "offsetMin":
			  o.offsetMin=value;return;
			case "offsetMax":
			  o.offsetMax=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.RectTransform no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.RectTransform o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "anchoredPosition3D":
			  o.anchoredPosition3D=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.RectTransform no Setter Found : " + propertyName);
	}
}
