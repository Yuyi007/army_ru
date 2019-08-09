using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_BezierPath : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath o;
			o=new UnityEngine.UI.Extensions.BezierPath();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetControlPoints(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2[]))){
				UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
				UnityEngine.Vector2[] a1;
				checkType(l,2,out a1);
				self.SetControlPoints(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector2>))){
				UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector2> a1;
				checkType(l,2,out a1);
				self.SetControlPoints(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetControlPoints(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			var ret=self.GetControlPoints();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Interpolate(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector2> a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.Interpolate(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SamplePoints(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector2> a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			self.SamplePoints(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateBezierPoint(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.CalculateBezierPoint(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDrawingPoints0(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			var ret=self.GetDrawingPoints0();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDrawingPoints1(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			var ret=self.GetDrawingPoints1();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDrawingPoints2(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			var ret=self.GetDrawingPoints2();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SegmentsPerCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			pushValue(l,self.SegmentsPerCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SegmentsPerCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.SegmentsPerCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MINIMUM_SQR_DISTANCE(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			pushValue(l,self.MINIMUM_SQR_DISTANCE);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MINIMUM_SQR_DISTANCE(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MINIMUM_SQR_DISTANCE=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DIVISION_THRESHOLD(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			pushValue(l,self.DIVISION_THRESHOLD);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DIVISION_THRESHOLD(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BezierPath self=(UnityEngine.UI.Extensions.BezierPath)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.DIVISION_THRESHOLD=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.BezierPath");
		addMember(l,SetControlPoints);
		addMember(l,GetControlPoints);
		addMember(l,Interpolate);
		addMember(l,SamplePoints);
		addMember(l,CalculateBezierPoint);
		addMember(l,GetDrawingPoints0);
		addMember(l,GetDrawingPoints1);
		addMember(l,GetDrawingPoints2);
		addMember(l,"SegmentsPerCurve",get_SegmentsPerCurve,set_SegmentsPerCurve,true);
		addMember(l,"MINIMUM_SQR_DISTANCE",get_MINIMUM_SQR_DISTANCE,set_MINIMUM_SQR_DISTANCE,true);
		addMember(l,"DIVISION_THRESHOLD",get_DIVISION_THRESHOLD,set_DIVISION_THRESHOLD,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.BezierPath));
	}
}
