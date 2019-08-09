using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_FVParticleRoot : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_noFlip(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.noFlip);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_noFlip(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.noFlip=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PropertyBlock(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.PropertyBlock);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TransformMatrix(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.TransformMatrix);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Rotation(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.Rotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Rotation(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.Rotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Quat(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.Quat);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Quat(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.Quat=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Scale(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.Scale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Scale(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.Scale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScaleRatio(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.ScaleRatio);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ScaleRatio(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.ScaleRatio=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Others(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.Others);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScalingComps(IntPtr l) {
		try {
			LBoot.FVParticleRoot self=(LBoot.FVParticleRoot)checkSelf(l);
			pushValue(l,self.ScalingComps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.FVParticleRoot");
		addMember(l,"noFlip",get_noFlip,set_noFlip,true);
		addMember(l,"PropertyBlock",get_PropertyBlock,null,true);
		addMember(l,"TransformMatrix",get_TransformMatrix,null,true);
		addMember(l,"Rotation",get_Rotation,set_Rotation,true);
		addMember(l,"Quat",get_Quat,set_Quat,true);
		addMember(l,"Scale",get_Scale,set_Scale,true);
		addMember(l,"ScaleRatio",get_ScaleRatio,set_ScaleRatio,true);
		addMember(l,"Others",get_Others,null,true);
		addMember(l,"ScalingComps",get_ScalingComps,null,true);
		createTypeMetatable(l,null, typeof(LBoot.FVParticleRoot),typeof(UnityEngine.MonoBehaviour));
	}
}
