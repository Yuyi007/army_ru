using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SetLightMapWithDynamicLightColor : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_watchGameObject(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.watchGameObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_watchGameObject(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.watchGameObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gameObjectEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.gameObjectEnabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gameObjectEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.gameObjectEnabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_multColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.multColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_multColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.multColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorIntensity(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.colorIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorIntensity(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.colorIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.maskEnabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.maskEnabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskIntensityCtrl(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.maskIntensityCtrl);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskIntensityCtrl(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.maskIntensityCtrl=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskIntensity(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.maskIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskIntensity(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.maskIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tiltFogEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.tiltFogEnabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tiltFogEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.tiltFogEnabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogStart(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.fogStart);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogStart(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fogStart=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogEnd(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.fogEnd);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogEnd(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fogEnd=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogStartColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.fogStartColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogStartColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.fogStartColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fogEndColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.fogEndColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fogEndColor(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.fogEndColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_multLightColorEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.multLightColorEnabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_multLightColorEnabled(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.multLightColorEnabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateInterval(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			pushValue(l,self.updateInterval);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_updateInterval(IntPtr l) {
		try {
			SetLightMapWithDynamicLightColor self=(SetLightMapWithDynamicLightColor)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.updateInterval=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SetLightMapWithDynamicLightColor");
		addMember(l,DoRefresh);
		addMember(l,"watchGameObject",get_watchGameObject,set_watchGameObject,true);
		addMember(l,"gameObjectEnabled",get_gameObjectEnabled,set_gameObjectEnabled,true);
		addMember(l,"multColor",get_multColor,set_multColor,true);
		addMember(l,"colorIntensity",get_colorIntensity,set_colorIntensity,true);
		addMember(l,"maskEnabled",get_maskEnabled,set_maskEnabled,true);
		addMember(l,"maskIntensityCtrl",get_maskIntensityCtrl,set_maskIntensityCtrl,true);
		addMember(l,"maskIntensity",get_maskIntensity,set_maskIntensity,true);
		addMember(l,"tiltFogEnabled",get_tiltFogEnabled,set_tiltFogEnabled,true);
		addMember(l,"fogStart",get_fogStart,set_fogStart,true);
		addMember(l,"fogEnd",get_fogEnd,set_fogEnd,true);
		addMember(l,"fogStartColor",get_fogStartColor,set_fogStartColor,true);
		addMember(l,"fogEndColor",get_fogEndColor,set_fogEndColor,true);
		addMember(l,"multLightColorEnabled",get_multLightColorEnabled,set_multLightColorEnabled,true);
		addMember(l,"updateInterval",get_updateInterval,set_updateInterval,true);
		createTypeMetatable(l,null, typeof(SetLightMapWithDynamicLightColor),typeof(UnityEngine.MonoBehaviour));
	}
}
