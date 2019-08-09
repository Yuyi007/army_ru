using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_MaskableGraphic : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetModifiedMaterial(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			var ret=self.GetModifiedMaterial(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Cull(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			UnityEngine.Rect a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.Cull(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetClipRect(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			UnityEngine.Rect a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetClipRect(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RecalculateClipping(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			self.RecalculateClipping();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RecalculateMasking(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			self.RecalculateMasking();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onCullStateChanged(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			pushValue(l,self.onCullStateChanged);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onCullStateChanged(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			UnityEngine.UI.MaskableGraphic.CullStateChangedEvent v;
			checkType(l,2,out v);
			self.onCullStateChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskable(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			pushValue(l,self.maskable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskable(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.maskable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.MaskableGraphic");
		addMember(l,GetModifiedMaterial);
		addMember(l,Cull);
		addMember(l,SetClipRect);
		addMember(l,RecalculateClipping);
		addMember(l,RecalculateMasking);
		addMember(l,"onCullStateChanged",get_onCullStateChanged,set_onCullStateChanged,true);
		addMember(l,"maskable",get_maskable,set_maskable,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.MaskableGraphic),typeof(UnityEngine.UI.Graphic));
	}
}
