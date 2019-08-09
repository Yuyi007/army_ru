using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenConfig : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			GoTweenConfig o;
			o=new GoTweenConfig();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setAutoClear(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.setAutoClear(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int position(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.position(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int localPosition(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.localPosition(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int positionPath(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoSpline a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			GoLookAtType a3;
			checkEnum(l,4,out a3);
			UnityEngine.Transform a4;
			checkType(l,5,out a4);
			var ret=self.positionPath(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int scale(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.scale(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.scale(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int scalePath(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoSpline a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.scalePath(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int eulerAngles(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.eulerAngles(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int localEulerAngles(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.localEulerAngles(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int rotation(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Quaternion),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				UnityEngine.Quaternion a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.rotation(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.rotation(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int localRotation(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Quaternion),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				UnityEngine.Quaternion a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.localRotation(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(bool))){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.localRotation(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int anchoredPosition(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.anchoredPosition(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int anchoredPosition3D(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.anchoredPosition3D(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int anchorMax(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.anchorMax(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int anchorMin(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.anchorMin(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int offsetMax(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.offsetMax(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int offsetMin(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.offsetMin(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int pivot(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.pivot(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int sizeDelta(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.sizeDelta(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int materialColor(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Color a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.materialColor(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int materialVector(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector4 a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.materialVector(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int materialFloat(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.materialFloat(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int shake(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			GoShakeType a2;
			checkEnum(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			System.Boolean a4;
			checkType(l,5,out a4);
			var ret=self.shake(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector2Prop(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector2Prop(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector3Prop(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector3Prop(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector4Prop(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector4Prop(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector3PathProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			GoSpline a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector3PathProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector3XProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector3XProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector3YProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector3YProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int vector3ZProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.vector3ZProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int colorProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Color a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.colorProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int intProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.intProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int floatProp(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.floatProp(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int addTweenProperty(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			AbstractTweenProperty a1;
			checkType(l,2,out a1);
			var ret=self.addTweenProperty(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clearProperties(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.clearProperties();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clearEvents(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.clearEvents();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setDelay(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.setDelay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setIterations(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.setIterations(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				GoTweenConfig self=(GoTweenConfig)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				GoLoopType a2;
				checkEnum(l,3,out a2);
				var ret=self.setIterations(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setTimeScale(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.setTimeScale(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setEaseType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoEaseType a1;
			checkEnum(l,2,out a1);
			var ret=self.setEaseType(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setEaseCurve(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.AnimationCurve a1;
			checkType(l,2,out a1);
			var ret=self.setEaseCurve(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int startPaused(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.startPaused();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setUpdateType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoUpdateType a1;
			checkEnum(l,2,out a1);
			var ret=self.setUpdateType(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setIsFrom(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.setIsFrom();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setIsTo(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.setIsTo();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onInit(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onInit(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onBegin(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onBegin(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onIterationStart(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onIterationStart(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onUpdate(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onUpdate(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onIterationEnd(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onIterationEnd(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onComplete(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onComplete(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setId(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.setId(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clone(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			var ret=self.clone();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clear(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			self.clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.id);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.id=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_delay(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.delay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_delay(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.delay=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_iterations(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.iterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_iterations(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.iterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.timeScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.timeScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loopType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushEnum(l,(int)self.loopType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loopType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoLoopType v;
			checkEnum(l,2,out v);
			self.loopType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easeType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushEnum(l,(int)self.easeType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoEaseType v;
			checkEnum(l,2,out v);
			self.easeType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easeCurve(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.easeCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeCurve(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.easeCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPaused(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.isPaused);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isPaused(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isPaused=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_propertyUpdateType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushEnum(l,(int)self.propertyUpdateType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_propertyUpdateType(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			GoUpdateType v;
			checkEnum(l,2,out v);
			self.propertyUpdateType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isFrom(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.isFrom);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isFrom(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isFrom=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onInitHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onInitHandler=v;
			else if(op==1) self.onInitHandler+=v;
			else if(op==2) self.onInitHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onBeginHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onBeginHandler=v;
			else if(op==1) self.onBeginHandler+=v;
			else if(op==2) self.onBeginHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onIterationStartHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onIterationStartHandler=v;
			else if(op==1) self.onIterationStartHandler+=v;
			else if(op==2) self.onIterationStartHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onUpdateHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onUpdateHandler=v;
			else if(op==1) self.onUpdateHandler+=v;
			else if(op==2) self.onUpdateHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onIterationEndHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onIterationEndHandler=v;
			else if(op==1) self.onIterationEndHandler+=v;
			else if(op==2) self.onIterationEndHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onCompleteHandler(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onCompleteHandler=v;
			else if(op==1) self.onCompleteHandler+=v;
			else if(op==2) self.onCompleteHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoClear(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.autoClear);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoClear(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.autoClear=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tweenProperties(IntPtr l) {
		try {
			GoTweenConfig self=(GoTweenConfig)checkSelf(l);
			pushValue(l,self.tweenProperties);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTweenConfig");
		addMember(l,setAutoClear);
		addMember(l,position);
		addMember(l,localPosition);
		addMember(l,positionPath);
		addMember(l,scale);
		addMember(l,scalePath);
		addMember(l,eulerAngles);
		addMember(l,localEulerAngles);
		addMember(l,rotation);
		addMember(l,localRotation);
		addMember(l,anchoredPosition);
		addMember(l,anchoredPosition3D);
		addMember(l,anchorMax);
		addMember(l,anchorMin);
		addMember(l,offsetMax);
		addMember(l,offsetMin);
		addMember(l,pivot);
		addMember(l,sizeDelta);
		addMember(l,materialColor);
		addMember(l,materialVector);
		addMember(l,materialFloat);
		addMember(l,shake);
		addMember(l,vector2Prop);
		addMember(l,vector3Prop);
		addMember(l,vector4Prop);
		addMember(l,vector3PathProp);
		addMember(l,vector3XProp);
		addMember(l,vector3YProp);
		addMember(l,vector3ZProp);
		addMember(l,colorProp);
		addMember(l,intProp);
		addMember(l,floatProp);
		addMember(l,addTweenProperty);
		addMember(l,clearProperties);
		addMember(l,clearEvents);
		addMember(l,setDelay);
		addMember(l,setIterations);
		addMember(l,setTimeScale);
		addMember(l,setEaseType);
		addMember(l,setEaseCurve);
		addMember(l,startPaused);
		addMember(l,setUpdateType);
		addMember(l,setIsFrom);
		addMember(l,setIsTo);
		addMember(l,onInit);
		addMember(l,onBegin);
		addMember(l,onIterationStart);
		addMember(l,onUpdate);
		addMember(l,onIterationEnd);
		addMember(l,onComplete);
		addMember(l,setId);
		addMember(l,clone);
		addMember(l,clear);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"delay",get_delay,set_delay,true);
		addMember(l,"iterations",get_iterations,set_iterations,true);
		addMember(l,"timeScale",get_timeScale,set_timeScale,true);
		addMember(l,"loopType",get_loopType,set_loopType,true);
		addMember(l,"easeType",get_easeType,set_easeType,true);
		addMember(l,"easeCurve",get_easeCurve,set_easeCurve,true);
		addMember(l,"isPaused",get_isPaused,set_isPaused,true);
		addMember(l,"propertyUpdateType",get_propertyUpdateType,set_propertyUpdateType,true);
		addMember(l,"isFrom",get_isFrom,set_isFrom,true);
		addMember(l,"onInitHandler",null,set_onInitHandler,true);
		addMember(l,"onBeginHandler",null,set_onBeginHandler,true);
		addMember(l,"onIterationStartHandler",null,set_onIterationStartHandler,true);
		addMember(l,"onUpdateHandler",null,set_onUpdateHandler,true);
		addMember(l,"onIterationEndHandler",null,set_onIterationEndHandler,true);
		addMember(l,"onCompleteHandler",null,set_onCompleteHandler,true);
		addMember(l,"autoClear",get_autoClear,set_autoClear,true);
		addMember(l,"tweenProperties",get_tweenProperties,null,true);
		createTypeMetatable(l,constructor, typeof(GoTweenConfig));
	}
}
