// UnityEngine.Rigidbody
using UnityEngine;
using System;
public static class CompExt_UnityEngine_RigidbodyReflectionExt
{
	static public object FastGetter(this UnityEngine.Rigidbody o, string propertyName)
	{
		switch(propertyName) {
			case "velocity":
			  return o.velocity;
			case "angularVelocity":
			  return o.angularVelocity;
			case "drag":
			  return o.drag;
			case "angularDrag":
			  return o.angularDrag;
			case "mass":
			  return o.mass;
			case "useGravity":
			  return o.useGravity;
			case "maxDepenetrationVelocity":
			  return o.maxDepenetrationVelocity;
			case "isKinematic":
			  return o.isKinematic;
			case "freezeRotation":
			  return o.freezeRotation;
			case "constraints":
			  return o.constraints;
			case "collisionDetectionMode":
			  return o.collisionDetectionMode;
			case "centerOfMass":
			  return o.centerOfMass;
			case "worldCenterOfMass":
			  return o.worldCenterOfMass;
			case "inertiaTensorRotation":
			  return o.inertiaTensorRotation;
			case "inertiaTensor":
			  return o.inertiaTensor;
			case "detectCollisions":
			  return o.detectCollisions;
			case "useConeFriction":
			  return o.useConeFriction;
			case "position":
			  return o.position;
			case "rotation":
			  return o.rotation;
			case "interpolation":
			  return o.interpolation;
			case "solverIterations":
			  return o.solverIterations;
			case "solverVelocityIterations":
			  return o.solverVelocityIterations;
			case "sleepThreshold":
			  return o.sleepThreshold;
			case "maxAngularVelocity":
			  return o.maxAngularVelocity;
			case "transform":
			   return o.transform;
			case "gameObject":
			   return o.gameObject;
			case "tag":
			   return o.tag;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Getter Found : " + propertyName);
		return null;
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, object value)
	{
		switch(propertyName) {
			case "velocity":
			  o.velocity=(UnityEngine.Vector3)value;return;
			case "angularVelocity":
			  o.angularVelocity=(UnityEngine.Vector3)value;return;
			case "drag":
			  o.drag=(System.Single)value;return;
			case "angularDrag":
			  o.angularDrag=(System.Single)value;return;
			case "mass":
			  o.mass=(System.Single)value;return;
			case "useGravity":
			  o.useGravity=(System.Boolean)value;return;
			case "maxDepenetrationVelocity":
			  o.maxDepenetrationVelocity=(System.Single)value;return;
			case "isKinematic":
			  o.isKinematic=(System.Boolean)value;return;
			case "freezeRotation":
			  o.freezeRotation=(System.Boolean)value;return;
			case "constraints":
			  o.constraints=(UnityEngine.RigidbodyConstraints)value;return;
			case "collisionDetectionMode":
			  o.collisionDetectionMode=(UnityEngine.CollisionDetectionMode)value;return;
			case "centerOfMass":
			  o.centerOfMass=(UnityEngine.Vector3)value;return;
			case "inertiaTensorRotation":
			  o.inertiaTensorRotation=(UnityEngine.Quaternion)value;return;
			case "inertiaTensor":
			  o.inertiaTensor=(UnityEngine.Vector3)value;return;
			case "detectCollisions":
			  o.detectCollisions=(System.Boolean)value;return;
			case "useConeFriction":
			  o.useConeFriction=(System.Boolean)value;return;
			case "position":
			  o.position=(UnityEngine.Vector3)value;return;
			case "rotation":
			  o.rotation=(UnityEngine.Quaternion)value;return;
			case "interpolation":
			  o.interpolation=(UnityEngine.RigidbodyInterpolation)value;return;
			case "solverIterations":
			  o.solverIterations=(System.Int32)value;return;
			case "solverVelocityIterations":
			  o.solverVelocityIterations=(System.Int32)value;return;
			case "sleepThreshold":
			  o.sleepThreshold=(System.Single)value;return;
			case "maxAngularVelocity":
			  o.maxAngularVelocity=(System.Single)value;return;
			case "tag":
			  o.tag=(System.String)value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, UnityEngine.Vector3 value)
	{
		switch(propertyName) {
			case "velocity":
			  o.velocity=value;return;
			case "angularVelocity":
			  o.angularVelocity=value;return;
			case "centerOfMass":
			  o.centerOfMass=value;return;
			case "inertiaTensor":
			  o.inertiaTensor=value;return;
			case "position":
			  o.position=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, System.Single value)
	{
		switch(propertyName) {
			case "drag":
			  o.drag=value;return;
			case "angularDrag":
			  o.angularDrag=value;return;
			case "mass":
			  o.mass=value;return;
			case "maxDepenetrationVelocity":
			  o.maxDepenetrationVelocity=value;return;
			case "sleepThreshold":
			  o.sleepThreshold=value;return;
			case "maxAngularVelocity":
			  o.maxAngularVelocity=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, System.Boolean value)
	{
		switch(propertyName) {
			case "useGravity":
			  o.useGravity=value;return;
			case "isKinematic":
			  o.isKinematic=value;return;
			case "freezeRotation":
			  o.freezeRotation=value;return;
			case "detectCollisions":
			  o.detectCollisions=value;return;
			case "useConeFriction":
			  o.useConeFriction=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, UnityEngine.RigidbodyConstraints value)
	{
		switch(propertyName) {
			case "constraints":
			  o.constraints=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, UnityEngine.CollisionDetectionMode value)
	{
		switch(propertyName) {
			case "collisionDetectionMode":
			  o.collisionDetectionMode=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, UnityEngine.Quaternion value)
	{
		switch(propertyName) {
			case "inertiaTensorRotation":
			  o.inertiaTensorRotation=value;return;
			case "rotation":
			  o.rotation=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, UnityEngine.RigidbodyInterpolation value)
	{
		switch(propertyName) {
			case "interpolation":
			  o.interpolation=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
	static public void FastSetter(this UnityEngine.Rigidbody o, string propertyName, System.Int32 value)
	{
		switch(propertyName) {
			case "solverIterations":
			  o.solverIterations=value;return;
			case "solverVelocityIterations":
			  o.solverVelocityIterations=value;return;
		}
		LBoot.LogUtil.Error("UnityEngine.Rigidbody no Setter Found : " + propertyName);
	}
}
