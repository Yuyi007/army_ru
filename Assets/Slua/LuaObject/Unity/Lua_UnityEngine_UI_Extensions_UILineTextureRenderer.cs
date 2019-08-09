using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UILineTextureRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineTextureRenderer o;
			o=new UnityEngine.UI.Extensions.UILineTextureRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RotatePointAroundPivot(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,4,out a3);
			var ret=self.RotatePointAroundPivot(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LineThickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
	static public int get_uvRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
			UnityEngine.UI.Extensions.UILineTextureRenderer self=(UnityEngine.UI.Extensions.UILineTextureRenderer)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.Extensions.UILineTextureRenderer");
		addMember(l,RotatePointAroundPivot);
		addMember(l,"LineThickness",get_LineThickness,set_LineThickness,true);
		addMember(l,"UseMargins",get_UseMargins,set_UseMargins,true);
		addMember(l,"Margin",get_Margin,set_Margin,true);
		addMember(l,"relativeSize",get_relativeSize,set_relativeSize,true);
		addMember(l,"uvRect",get_uvRect,set_uvRect,true);
		addMember(l,"Points",get_Points,set_Points,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UILineTextureRenderer),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
