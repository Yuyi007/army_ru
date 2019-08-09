using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_FVBloomSelectiveStencil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			FVBloomSelectiveStencil o;
			o=new FVBloomSelectiveStencil();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsEnabled(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			var ret=self.IsEnabled();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetEnabled(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetEnabled(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsForceDisabled(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			var ret=self.IsForceDisabled();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetForceDisable(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetForceDisable(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckResources(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RefreshMaterialReferences(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			self.RefreshMaterialReferences();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_threshold(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			pushValue(l,self.threshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_threshold(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.threshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_intensity(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			pushValue(l,self.intensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_intensity(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.intensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurSize(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			pushValue(l,self.blurSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurSize(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.blurSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurIterations(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			pushValue(l,self.blurIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurIterations(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.blurIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blurType(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			pushEnum(l,(int)self.blurType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blurType(IntPtr l) {
		try {
			FVBloomSelectiveStencil self=(FVBloomSelectiveStencil)checkSelf(l);
			FVBloomSelectiveStencil.BlurType v;
			checkEnum(l,2,out v);
			self.blurType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FVBloomSelectiveStencil");
		addMember(l,IsEnabled);
		addMember(l,SetEnabled);
		addMember(l,IsForceDisabled);
		addMember(l,SetForceDisable);
		addMember(l,CheckResources);
		addMember(l,RefreshMaterialReferences);
		addMember(l,"threshold",get_threshold,set_threshold,true);
		addMember(l,"intensity",get_intensity,set_intensity,true);
		addMember(l,"blurSize",get_blurSize,set_blurSize,true);
		addMember(l,"blurIterations",get_blurIterations,set_blurIterations,true);
		addMember(l,"blurType",get_blurType,set_blurType,true);
		createTypeMetatable(l,constructor, typeof(FVBloomSelectiveStencil),typeof(UnityStandardAssets.ImageEffects.PostEffectsBase));
	}
}
