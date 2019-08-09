using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_FXAAPostEffectsBase : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckShaderAndCreateMaterial(IntPtr l) {
		try {
			FXAAPostEffectsBase self=(FXAAPostEffectsBase)checkSelf(l);
			UnityEngine.Shader a1;
			checkType(l,2,out a1);
			UnityEngine.Material a2;
			checkType(l,3,out a2);
			var ret=self.CheckShaderAndCreateMaterial(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CheckSupport(IntPtr l) {
		try {
			FXAAPostEffectsBase self=(FXAAPostEffectsBase)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.CheckSupport(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FXAAPostEffectsBase");
		addMember(l,CheckShaderAndCreateMaterial);
		addMember(l,CheckSupport);
		createTypeMetatable(l,null, typeof(FXAAPostEffectsBase),typeof(UnityEngine.MonoBehaviour));
	}
}
