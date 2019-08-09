using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityStandardAssets_ImageEffects_PostEffectsBase : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckResources(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.PostEffectsBase self=(UnityStandardAssets.ImageEffects.PostEffectsBase)checkSelf(l);
			var ret=self.CheckResources();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Dx11Support(IntPtr l) {
		try {
			UnityStandardAssets.ImageEffects.PostEffectsBase self=(UnityStandardAssets.ImageEffects.PostEffectsBase)checkSelf(l);
			var ret=self.Dx11Support();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityStandardAssets.ImageEffects.PostEffectsBase");
		addMember(l,CheckResources);
		addMember(l,Dx11Support);
		createTypeMetatable(l,null, typeof(UnityStandardAssets.ImageEffects.PostEffectsBase),typeof(UnityEngine.MonoBehaviour));
	}
}
