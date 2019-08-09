// UnityEngine.ParticleSystemRenderer
using UnityEngine;
using System;
public static class CompExt_UnityEngine_ParticleSystemRendererReflectionExt
{
	static public object FastGetter(this UnityEngine.ParticleSystemRenderer o, string propertyName)
	{
		switch(propertyName) {
			case "renderMode":
			  return o.renderMode;
			case "lengthScale":
			  return o.lengthScale;
			case "velocityScale":
			  return o.velocityScale;
			case "cameraVelocityScale":
			  return o.cameraVelocityScale;
			case "normalDirection":
			  return o.normalDirection;
			case "alignment":
			  return o.alignment;
			case "pivot":
			  return o.pivot;
			case "sortMode":
			  return o.sortMode;
			case "sortingFudge":
			  return o.sortingFudge;
			case "minParticleSize":
			  return o.minParticleSize;
			case "maxParticleSize":
			  return o.maxParticleSize;
			case "mesh":
			  return o.mesh;
			case "meshCount":
			  return o.meshCount;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, object value)
	{
		switch(propertyName) {
			case "renderMode":
			  o.renderMode=(UnityEngine.ParticleSystemRenderMode)value;return;
			case "lengthScale":
			  o.lengthScale=(System.Single)value;return;
			case "velocityScale":
			  o.velocityScale=(System.Single)value;return;
			case "cameraVelocityScale":
			  o.cameraVelocityScale=(System.Single)value;return;
			case "normalDirection":
			  o.normalDirection=(System.Single)value;return;
			case "alignment":
			  o.alignment=(UnityEngine.ParticleSystemRenderSpace)value;return;
			case "pivot":
			  o.pivot=(UnityEngine.Vector3)value;return;
			case "sortMode":
			  o.sortMode=(UnityEngine.ParticleSystemSortMode)value;return;
			case "sortingFudge":
			  o.sortingFudge=(System.Single)value;return;
			case "minParticleSize":
			  o.minParticleSize=(System.Single)value;return;
			case "maxParticleSize":
			  o.maxParticleSize=(System.Single)value;return;
			case "mesh":
			  o.mesh=(UnityEngine.Mesh)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, UnityEngine.ParticleSystemRenderMode value)
	{
		switch(propertyName) {
			case "renderMode":
			  o.renderMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "lengthScale":
			  o.lengthScale=value;return;
			case "velocityScale":
			  o.velocityScale=value;return;
			case "cameraVelocityScale":
			  o.cameraVelocityScale=value;return;
			case "normalDirection":
			  o.normalDirection=value;return;
			case "sortingFudge":
			  o.sortingFudge=value;return;
			case "minParticleSize":
			  o.minParticleSize=value;return;
			case "maxParticleSize":
			  o.maxParticleSize=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, UnityEngine.ParticleSystemRenderSpace value)
	{
		switch(propertyName) {
			case "alignment":
			  o.alignment=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "pivot":
			  o.pivot=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, UnityEngine.ParticleSystemSortMode value)
	{
		switch(propertyName) {
			case "sortMode":
			  o.sortMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystemRenderer o, string propertyName, UnityEngine.Mesh value)
	{
		switch(propertyName) {
			case "mesh":
			  o.mesh=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystemRenderer no Setter Found : " + propertyName);
	}
}
