// UnityEngine.ParticleSystem
using UnityEngine;
using System;
public static class CompExt_UnityEngine_ParticleSystemReflectionExt
{
	static public object FastGetter(this UnityEngine.ParticleSystem o, string propertyName)
	{
		switch(propertyName) {
			case "startDelay":
			  return o.startDelay;
			case "isPlaying":
			  return o.isPlaying;
			case "isStopped":
			  return o.isStopped;
			case "isPaused":
			  return o.isPaused;
			case "loop":
			  return o.loop;
			case "playOnAwake":
			  return o.playOnAwake;
			case "time":
			  return o.time;
			case "duration":
			  return o.duration;
			case "playbackSpeed":
			  return o.playbackSpeed;
			case "particleCount":
			  return o.particleCount;
			case "startSpeed":
			  return o.startSpeed;
			case "startSize":
			  return o.startSize;
			case "startColor":
			  return o.startColor;
			case "startRotation":
			  return o.startRotation;
			case "startRotation3D":
			  return o.startRotation3D;
			case "startLifetime":
			  return o.startLifetime;
			case "gravityModifier":
			  return o.gravityModifier;
			case "maxParticles":
			  return o.maxParticles;
			case "simulationSpace":
			  return o.simulationSpace;
			case "scalingMode":
			  return o.scalingMode;
			case "randomSeed":
			  return o.randomSeed;
			case "emission":
			  return o.emission;
			case "shape":
			  return o.shape;
			case "velocityOverLifetime":
			  return o.velocityOverLifetime;
			case "limitVelocityOverLifetime":
			  return o.limitVelocityOverLifetime;
			case "inheritVelocity":
			  return o.inheritVelocity;
			case "forceOverLifetime":
			  return o.forceOverLifetime;
			case "colorOverLifetime":
			  return o.colorOverLifetime;
			case "colorBySpeed":
			  return o.colorBySpeed;
			case "sizeOverLifetime":
			  return o.sizeOverLifetime;
			case "sizeBySpeed":
			  return o.sizeBySpeed;
			case "rotationOverLifetime":
			  return o.rotationOverLifetime;
			case "rotationBySpeed":
			  return o.rotationBySpeed;
			case "externalForces":
			  return o.externalForces;
			case "collision":
			  return o.collision;
			case "trigger":
			  return o.trigger;
			case "subEmitters":
			  return o.subEmitters;
			case "textureSheetAnimation":
			  return o.textureSheetAnimation;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, object value)
	{
		switch(propertyName) {
			case "startDelay":
			  o.startDelay=(System.Single)value;return;
			case "loop":
			  o.loop=(System.Boolean)value;return;
			case "playOnAwake":
			  o.playOnAwake=(System.Boolean)value;return;
			case "time":
			  o.time=(System.Single)value;return;
			case "playbackSpeed":
			  o.playbackSpeed=(System.Single)value;return;
			case "startSpeed":
			  o.startSpeed=(System.Single)value;return;
			case "startSize":
			  o.startSize=(System.Single)value;return;
			case "startColor":
			  o.startColor=(UnityEngine.Color)value;return;
			case "startRotation":
			  o.startRotation=(System.Single)value;return;
			case "startRotation3D":
			  o.startRotation3D=(UnityEngine.Vector3)value;return;
			case "startLifetime":
			  o.startLifetime=(System.Single)value;return;
			case "gravityModifier":
			  o.gravityModifier=(System.Single)value;return;
			case "maxParticles":
			  o.maxParticles=(System.Int32)value;return;
			case "simulationSpace":
			  o.simulationSpace=(UnityEngine.ParticleSystemSimulationSpace)value;return;
			case "scalingMode":
			  o.scalingMode=(UnityEngine.ParticleSystemScalingMode)value;return;
			case "randomSeed":
			  o.randomSeed=(System.UInt32)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "startDelay":
			  o.startDelay=value;return;
			case "time":
			  o.time=value;return;
			case "playbackSpeed":
			  o.playbackSpeed=value;return;
			case "startSpeed":
			  o.startSpeed=value;return;
			case "startSize":
			  o.startSize=value;return;
			case "startRotation":
			  o.startRotation=value;return;
			case "startLifetime":
			  o.startLifetime=value;return;
			case "gravityModifier":
			  o.gravityModifier=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "loop":
			  o.loop=value;return;
			case "playOnAwake":
			  o.playOnAwake=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, UnityEngine.Color value)
	{
		switch(propertyName) {
			case "startColor":
			  o.startColor=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "startRotation3D":
			  o.startRotation3D=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "maxParticles":
			  o.maxParticles=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, UnityEngine.ParticleSystemSimulationSpace value)
	{
		switch(propertyName) {
			case "simulationSpace":
			  o.simulationSpace=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, UnityEngine.ParticleSystemScalingMode value)
	{
		switch(propertyName) {
			case "scalingMode":
			  o.scalingMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.ParticleSystem o, string propertyName, System.UInt32 value)
	{
		switch(propertyName) {
			case "randomSeed":
			  o.randomSeed=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.ParticleSystem no Setter Found : " + propertyName);
	}
}
