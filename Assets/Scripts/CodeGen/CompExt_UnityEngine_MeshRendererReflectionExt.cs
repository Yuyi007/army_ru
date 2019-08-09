// UnityEngine.MeshRenderer
using UnityEngine;
using System;
public static class CompExt_UnityEngine_MeshRendererReflectionExt
{
	static public object FastGetter(this UnityEngine.MeshRenderer o, string propertyName)
	{
		switch(propertyName) {
			case "additionalVertexStreams":
			  return o.additionalVertexStreams;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.MeshRenderer no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.MeshRenderer o, string propertyName, object value)
	{
		switch(propertyName) {
			case "additionalVertexStreams":
			  o.additionalVertexStreams=(UnityEngine.Mesh)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.MeshRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.MeshRenderer o, string propertyName, UnityEngine.Mesh value)
	{
		switch(propertyName) {
			case "additionalVertexStreams":
			  o.additionalVertexStreams=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.MeshRenderer no Setter Found : " + propertyName);
	}
}
