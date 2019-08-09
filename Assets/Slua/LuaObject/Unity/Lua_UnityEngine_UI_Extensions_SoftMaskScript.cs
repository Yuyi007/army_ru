using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SoftMaskScript : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaskArea(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.MaskArea);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaskArea(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.MaskArea=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskScalingRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.maskScalingRect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskScalingRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.maskScalingRect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AlphaMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.AlphaMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_AlphaMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.AlphaMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CutOff(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.CutOff);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CutOff(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.CutOff=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_HardBlend(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.HardBlend);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_HardBlend(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.HardBlend=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FlipAlphaMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.FlipAlphaMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FlipAlphaMask(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.FlipAlphaMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DontClipMaskScalingRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.DontClipMaskScalingRect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DontClipMaskScalingRect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.DontClipMaskScalingRect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CascadeToALLChildren(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			pushValue(l,self.CascadeToALLChildren);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CascadeToALLChildren(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SoftMaskScript self=(UnityEngine.UI.Extensions.SoftMaskScript)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.CascadeToALLChildren=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SoftMaskScript");
		addMember(l,"MaskArea",get_MaskArea,set_MaskArea,true);
		addMember(l,"maskScalingRect",get_maskScalingRect,set_maskScalingRect,true);
		addMember(l,"AlphaMask",get_AlphaMask,set_AlphaMask,true);
		addMember(l,"CutOff",get_CutOff,set_CutOff,true);
		addMember(l,"HardBlend",get_HardBlend,set_HardBlend,true);
		addMember(l,"FlipAlphaMask",get_FlipAlphaMask,set_FlipAlphaMask,true);
		addMember(l,"DontClipMaskScalingRect",get_DontClipMaskScalingRect,set_DontClipMaskScalingRect,true);
		addMember(l,"CascadeToALLChildren",get_CascadeToALLChildren,set_CascadeToALLChildren,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.SoftMaskScript),typeof(UnityEngine.MonoBehaviour));
	}
}
