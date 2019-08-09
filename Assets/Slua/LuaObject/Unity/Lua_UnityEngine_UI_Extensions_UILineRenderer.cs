using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UILineRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer o;
			o=new UnityEngine.UI.Extensions.UILineRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LineThickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.LineThickness);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LineThickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.LineThickness=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UseMargins(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.UseMargins);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UseMargins(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.UseMargins=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Margin(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.Margin);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Margin(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.Margin=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_relativeSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.relativeSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_relativeSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.relativeSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LineList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.LineList);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LineList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.LineList=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LineCaps(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.LineCaps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LineCaps(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.LineCaps=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LineJoins(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushEnum(l,(int)self.LineJoins);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LineJoins(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			UnityEngine.UI.Extensions.UILineRenderer.JoinType v;
			checkEnum(l,2,out v);
			self.LineJoins=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BezierMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushEnum(l,(int)self.BezierMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BezierMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			UnityEngine.UI.Extensions.UILineRenderer.BezierType v;
			checkEnum(l,2,out v);
			self.BezierMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BezierSegmentsPerCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.BezierSegmentsPerCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BezierSegmentsPerCurve(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.BezierSegmentsPerCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uvRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.uvRect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uvRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			UnityEngine.Rect v;
			checkValueType(l,2,out v);
			self.uvRect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Points(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			pushValue(l,self.Points);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Points(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineRenderer self=(UnityEngine.UI.Extensions.UILineRenderer)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkType(l,2,out v);
			self.Points=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UILineRenderer");
		addMember(l,"LineThickness",get_LineThickness,set_LineThickness,true);
		addMember(l,"UseMargins",get_UseMargins,set_UseMargins,true);
		addMember(l,"Margin",get_Margin,set_Margin,true);
		addMember(l,"relativeSize",get_relativeSize,set_relativeSize,true);
		addMember(l,"LineList",get_LineList,set_LineList,true);
		addMember(l,"LineCaps",get_LineCaps,set_LineCaps,true);
		addMember(l,"LineJoins",get_LineJoins,set_LineJoins,true);
		addMember(l,"BezierMode",get_BezierMode,set_BezierMode,true);
		addMember(l,"BezierSegmentsPerCurve",get_BezierSegmentsPerCurve,set_BezierSegmentsPerCurve,true);
		addMember(l,"uvRect",get_uvRect,set_uvRect,true);
		addMember(l,"Points",get_Points,set_Points,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UILineRenderer),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
