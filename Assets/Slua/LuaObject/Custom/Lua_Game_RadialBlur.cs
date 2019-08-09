using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_RadialBlur : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDisable(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			self.OnDisable();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RadialBlurShader(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			pushValue(l,self.RadialBlurShader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RadialBlurShader(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.RadialBlurShader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SampleDist(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			pushValue(l,self.SampleDist);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SampleDist(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.SampleDist=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SampleStrength(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			pushValue(l,self.SampleStrength);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SampleStrength(IntPtr l) {
		try {
			Game.RadialBlur self=(Game.RadialBlur)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.SampleStrength=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.RadialBlur");
		addMember(l,OnDisable);
		addMember(l,"RadialBlurShader",get_RadialBlurShader,set_RadialBlurShader,true);
		addMember(l,"SampleDist",get_SampleDist,set_SampleDist,true);
		addMember(l,"SampleStrength",get_SampleStrength,set_SampleStrength,true);
		createTypeMetatable(l,null, typeof(Game.RadialBlur),typeof(UnityEngine.MonoBehaviour));
	}
}
