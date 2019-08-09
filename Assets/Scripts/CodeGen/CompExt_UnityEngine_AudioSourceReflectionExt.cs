// UnityEngine.AudioSource
using UnityEngine;
using System;
public static class CompExt_UnityEngine_AudioSourceReflectionExt
{
	static public object FastGetter(this UnityEngine.AudioSource o, string propertyName)
	{
		switch(propertyName) {
			case "volume":
			  return o.volume;
			case "pitch":
			  return o.pitch;
			case "time":
			  return o.time;
			case "timeSamples":
			  return o.timeSamples;
			case "clip":
			  return o.clip;
			case "outputAudioMixerGroup":
			  return o.outputAudioMixerGroup;
			case "isPlaying":
			  return o.isPlaying;
			case "isVirtual":
			  return o.isVirtual;
			case "loop":
			  return o.loop;
			case "ignoreListenerVolume":
			  return o.ignoreListenerVolume;
			case "playOnAwake":
			  return o.playOnAwake;
			case "ignoreListenerPause":
			  return o.ignoreListenerPause;
			case "velocityUpdateMode":
			  return o.velocityUpdateMode;
			case "panStereo":
			  return o.panStereo;
			case "spatialBlend":
			  return o.spatialBlend;
			case "spatialize":
			  return o.spatialize;
			case "reverbZoneMix":
			  return o.reverbZoneMix;
			case "bypassEffects":
			  return o.bypassEffects;
			case "bypassListenerEffects":
			  return o.bypassListenerEffects;
			case "bypassReverbZones":
			  return o.bypassReverbZones;
			case "dopplerLevel":
			  return o.dopplerLevel;
			case "spread":
			  return o.spread;
			case "priority":
			  return o.priority;
			case "mute":
			  return o.mute;
			case "minDistance":
			  return o.minDistance;
			case "maxDistance":
			  return o.maxDistance;
			case "rolloffMode":
			  return o.rolloffMode;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
			case "enabled":
			  return o.enabled;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, object value)
	{
		switch(propertyName) {
			case "volume":
			  o.volume=(System.Single)value;return;
			case "pitch":
			  o.pitch=(System.Single)value;return;
			case "time":
			  o.time=(System.Single)value;return;
			case "timeSamples":
			  o.timeSamples=(System.Int32)value;return;
			case "clip":
			  o.clip=(UnityEngine.AudioClip)value;return;
			case "outputAudioMixerGroup":
			  o.outputAudioMixerGroup=(UnityEngine.Audio.AudioMixerGroup)value;return;
			case "loop":
			  o.loop=(System.Boolean)value;return;
			case "ignoreListenerVolume":
			  o.ignoreListenerVolume=(System.Boolean)value;return;
			case "playOnAwake":
			  o.playOnAwake=(System.Boolean)value;return;
			case "ignoreListenerPause":
			  o.ignoreListenerPause=(System.Boolean)value;return;
			case "velocityUpdateMode":
			  o.velocityUpdateMode=(UnityEngine.AudioVelocityUpdateMode)value;return;
			case "panStereo":
			  o.panStereo=(System.Single)value;return;
			case "spatialBlend":
			  o.spatialBlend=(System.Single)value;return;
			case "spatialize":
			  o.spatialize=(System.Boolean)value;return;
			case "reverbZoneMix":
			  o.reverbZoneMix=(System.Single)value;return;
			case "bypassEffects":
			  o.bypassEffects=(System.Boolean)value;return;
			case "bypassListenerEffects":
			  o.bypassListenerEffects=(System.Boolean)value;return;
			case "bypassReverbZones":
			  o.bypassReverbZones=(System.Boolean)value;return;
			case "dopplerLevel":
			  o.dopplerLevel=(System.Single)value;return;
			case "spread":
			  o.spread=(System.Single)value;return;
			case "priority":
			  o.priority=(System.Int32)value;return;
			case "mute":
			  o.mute=(System.Boolean)value;return;
			case "minDistance":
			  o.minDistance=(System.Single)value;return;
			case "maxDistance":
			  o.maxDistance=(System.Single)value;return;
			case "rolloffMode":
			  o.rolloffMode=(UnityEngine.AudioRolloffMode)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
			case "enabled":
			  o.enabled=(bool)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "volume":
			  o.volume=value;return;
			case "pitch":
			  o.pitch=value;return;
			case "time":
			  o.time=value;return;
			case "panStereo":
			  o.panStereo=value;return;
			case "spatialBlend":
			  o.spatialBlend=value;return;
			case "reverbZoneMix":
			  o.reverbZoneMix=value;return;
			case "dopplerLevel":
			  o.dopplerLevel=value;return;
			case "spread":
			  o.spread=value;return;
			case "minDistance":
			  o.minDistance=value;return;
			case "maxDistance":
			  o.maxDistance=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "timeSamples":
			  o.timeSamples=value;return;
			case "priority":
			  o.priority=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, UnityEngine.AudioClip value)
	{
		switch(propertyName) {
			case "clip":
			  o.clip=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, UnityEngine.Audio.AudioMixerGroup value)
	{
		switch(propertyName) {
			case "outputAudioMixerGroup":
			  o.outputAudioMixerGroup=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "loop":
			  o.loop=value;return;
			case "ignoreListenerVolume":
			  o.ignoreListenerVolume=value;return;
			case "playOnAwake":
			  o.playOnAwake=value;return;
			case "ignoreListenerPause":
			  o.ignoreListenerPause=value;return;
			case "spatialize":
			  o.spatialize=value;return;
			case "bypassEffects":
			  o.bypassEffects=value;return;
			case "bypassListenerEffects":
			  o.bypassListenerEffects=value;return;
			case "bypassReverbZones":
			  o.bypassReverbZones=value;return;
			case "mute":
			  o.mute=value;return;
			case "enabled":
			  o.enabled=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, UnityEngine.AudioVelocityUpdateMode value)
	{
		switch(propertyName) {
			case "velocityUpdateMode":
			  o.velocityUpdateMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.AudioSource o, string propertyName, UnityEngine.AudioRolloffMode value)
	{
		switch(propertyName) {
			case "rolloffMode":
			  o.rolloffMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.AudioSource no Setter Found : " + propertyName);
	}
}
