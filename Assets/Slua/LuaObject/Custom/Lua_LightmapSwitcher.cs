using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LightmapSwitcher : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int initData(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			self.initData();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_allParams(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.allParams);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_allParams(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			LightmapParams[] v;
			checkType(l,2,out v);
			self.allParams=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dayLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.dayLightmaps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dayLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			UnityEngine.Texture2D[] v;
			checkType(l,2,out v);
			self.dayLightmaps=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_nightLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.nightLightmaps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_nightLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			UnityEngine.Texture2D[] v;
			checkType(l,2,out v);
			self.nightLightmaps=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useNightLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.useNightLightmaps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useNightLightmaps(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useNightLightmaps=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DayLightMapDatas(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.DayLightMapDatas);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NightLightMapDatas(IntPtr l) {
		try {
			LightmapSwitcher self=(LightmapSwitcher)checkSelf(l);
			pushValue(l,self.NightLightMapDatas);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LightmapSwitcher");
		addMember(l,initData);
		addMember(l,DoRefresh);
		addMember(l,"allParams",get_allParams,set_allParams,true);
		addMember(l,"dayLightmaps",get_dayLightmaps,set_dayLightmaps,true);
		addMember(l,"nightLightmaps",get_nightLightmaps,set_nightLightmaps,true);
		addMember(l,"useNightLightmaps",get_useNightLightmaps,set_useNightLightmaps,true);
		addMember(l,"DayLightMapDatas",get_DayLightMapDatas,null,true);
		addMember(l,"NightLightMapDatas",get_NightLightMapDatas,null,true);
		createTypeMetatable(l,null, typeof(LightmapSwitcher),typeof(UnityEngine.MonoBehaviour));
	}
}
