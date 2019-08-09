using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenUtils : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int easeFunctionForType_s(IntPtr l) {
		try {
			GoEaseType a1;
			checkEnum(l,1,out a1);
			GoTween a2;
			checkType(l,2,out a2);
			var ret=GoTweenUtils.easeFunctionForType(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int unclampedColorLerp_s(IntPtr l) {
		try {
			UnityEngine.Color a1;
			checkType(l,1,out a1);
			UnityEngine.Color a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=GoTweenUtils.unclampedColorLerp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int unclampedVector2Lerp_s(IntPtr l) {
		try {
			UnityEngine.Vector2 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=GoTweenUtils.unclampedVector2Lerp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int unclampedVector3Lerp_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=GoTweenUtils.unclampedVector3Lerp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int unclampedVector4Lerp_s(IntPtr l) {
		try {
			UnityEngine.Vector4 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=GoTweenUtils.unclampedVector4Lerp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTweenUtils");
		addMember(l,easeFunctionForType_s);
		addMember(l,unclampedColorLerp_s);
		addMember(l,unclampedVector2Lerp_s);
		addMember(l,unclampedVector3Lerp_s);
		addMember(l,unclampedVector4Lerp_s);
		createTypeMetatable(l,null, typeof(GoTweenUtils));
	}
}
