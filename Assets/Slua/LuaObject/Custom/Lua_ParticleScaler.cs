using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_ParticleScaler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear_s(IntPtr l) {
		try {
			ParticleScaler.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScaleByTransform_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystem a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				ParticleScaler.ScaleByTransform(a1,a2);
				return 0;
			}
			else if(argc==3){
				UnityEngine.GameObject a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				ParticleScaler.ScaleByTransform(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScaleSystem_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			ParticleScalerOptions a4;
			checkType(l,4,out a4);
			ParticleScaler.ScaleSystem(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"ParticleScaler");
		addMember(l,Clear_s);
		addMember(l,ScaleByTransform_s);
		addMember(l,ScaleSystem_s);
		createTypeMetatable(l,null, typeof(ParticleScaler));
	}
}
