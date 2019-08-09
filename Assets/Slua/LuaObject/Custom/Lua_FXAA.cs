using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_FXAA : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			FXAA o;
			o=new FXAA();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnRenderImage(IntPtr l) {
		try {
			FXAA self=(FXAA)checkSelf(l);
			UnityEngine.RenderTexture a1;
			checkType(l,2,out a1);
			UnityEngine.RenderTexture a2;
			checkType(l,3,out a2);
			self.OnRenderImage(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shader(IntPtr l) {
		try {
			FXAA self=(FXAA)checkSelf(l);
			pushValue(l,self.shader);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shader(IntPtr l) {
		try {
			FXAA self=(FXAA)checkSelf(l);
			UnityEngine.Shader v;
			checkType(l,2,out v);
			self.shader=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FXAA");
		addMember(l,OnRenderImage);
		addMember(l,"shader",get_shader,set_shader,true);
		createTypeMetatable(l,constructor, typeof(FXAA),typeof(FXAAPostEffectsBase));
	}
}
