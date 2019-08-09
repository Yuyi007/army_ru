using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HSVUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ConvertRgbToHsv_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Color a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.UI.Extensions.HSVUtil.ConvertRgbToHsv(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Double a1;
				checkType(l,1,out a1);
				System.Double a2;
				checkType(l,2,out a2);
				System.Double a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.UI.Extensions.HSVUtil.ConvertRgbToHsv(a1,a2,a3);
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
	static public int ConvertHsvToRgb_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.UI.Extensions.HsvColor a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.UI.Extensions.HSVUtil.ConvertHsvToRgb(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Double a1;
				checkType(l,1,out a1);
				System.Double a2;
				checkType(l,2,out a2);
				System.Double a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.UI.Extensions.HSVUtil.ConvertHsvToRgb(a1,a2,a3);
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
	static public int GenerateHsvSpectrum_s(IntPtr l) {
		try {
			var ret=UnityEngine.UI.Extensions.HSVUtil.GenerateHsvSpectrum();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GenerateHSVTexture_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.Extensions.HSVUtil.GenerateHSVTexture(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GenerateColorTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Color a1;
				checkType(l,1,out a1);
				UnityEngine.Texture2D a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.UI.Extensions.HSVUtil.GenerateColorTexture(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Color a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.UI.Extensions.HSVUtil.GenerateColorTexture(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HSVUtil");
		addMember(l,ConvertRgbToHsv_s);
		addMember(l,ConvertHsvToRgb_s);
		addMember(l,GenerateHsvSpectrum_s);
		addMember(l,GenerateHSVTexture_s);
		addMember(l,GenerateColorTexture_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.HSVUtil));
	}
}
