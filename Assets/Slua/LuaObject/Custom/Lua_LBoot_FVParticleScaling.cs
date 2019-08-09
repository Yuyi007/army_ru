using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_FVParticleScaling : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEnable(IntPtr l) {
		try {
			LBoot.FVParticleScaling self=(LBoot.FVParticleScaling)checkSelf(l);
			self.OnEnable();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear_s(IntPtr l) {
		try {
			LBoot.FVParticleScaling.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_psRoot(IntPtr l) {
		try {
			LBoot.FVParticleScaling self=(LBoot.FVParticleScaling)checkSelf(l);
			pushValue(l,self.psRoot);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_psRoot(IntPtr l) {
		try {
			LBoot.FVParticleScaling self=(LBoot.FVParticleScaling)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.psRoot=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.FVParticleScaling");
		addMember(l,OnEnable);
		addMember(l,Clear_s);
		addMember(l,"psRoot",get_psRoot,set_psRoot,true);
		createTypeMetatable(l,null, typeof(LBoot.FVParticleScaling),typeof(UnityEngine.MonoBehaviour));
	}
}
