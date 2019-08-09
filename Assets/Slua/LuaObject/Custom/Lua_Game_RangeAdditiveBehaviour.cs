using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_RangeAdditiveBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetFakeLightObject(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
				UnityEngine.GameObject a1;
				checkType(l,2,out a1);
				self.SetFakeLightObject(a1);
				return 0;
			}
			else if(argc==3){
				Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
				UnityEngine.GameObject a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				self.SetFakeLightObject(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetTransform(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			self.ResetTransform();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetMaterial(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			self.ResetMaterial();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightObject(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			pushValue(l,self.lightObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightObject(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.lightObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightTransform(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			pushValue(l,self.lightTransform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightTransform(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.lightTransform=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mat(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			pushValue(l,self.mat);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mat(IntPtr l) {
		try {
			Game.RangeAdditiveBehaviour self=(Game.RangeAdditiveBehaviour)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.mat=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.RangeAdditiveBehaviour");
		addMember(l,SetFakeLightObject);
		addMember(l,ResetTransform);
		addMember(l,ResetMaterial);
		addMember(l,"lightObject",get_lightObject,set_lightObject,true);
		addMember(l,"lightTransform",get_lightTransform,set_lightTransform,true);
		addMember(l,"mat",get_mat,set_mat,true);
		createTypeMetatable(l,null, typeof(Game.RangeAdditiveBehaviour),typeof(UnityEngine.MonoBehaviour));
	}
}
