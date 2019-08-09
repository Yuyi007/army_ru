﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_LightmapData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LightmapData o;
			o=new UnityEngine.LightmapData();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightmapColor(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			pushValue(l,self.lightmapColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightmapColor(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.lightmapColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightmapDir(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			pushValue(l,self.lightmapDir);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightmapDir(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.lightmapDir=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowMask(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			pushValue(l,self.shadowMask);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowMask(IntPtr l) {
		try {
			UnityEngine.LightmapData self=(UnityEngine.LightmapData)checkSelf(l);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.shadowMask=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LightmapData");
		addMember(l,"lightmapColor",get_lightmapColor,set_lightmapColor,true);
		addMember(l,"lightmapDir",get_lightmapDir,set_lightmapDir,true);
		addMember(l,"shadowMask",get_shadowMask,set_shadowMask,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LightmapData));
	}
}
