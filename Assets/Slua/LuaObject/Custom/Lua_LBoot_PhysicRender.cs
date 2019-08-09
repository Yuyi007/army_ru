using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_PhysicRender : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int addAABB(IntPtr l) {
		try {
			LBoot.PhysicRender self=(LBoot.PhysicRender)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			System.Single a5;
			checkType(l,6,out a5);
			System.Single a6;
			checkType(l,7,out a6);
			self.addAABB(a1,a2,a3,a4,a5,a6);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clear(IntPtr l) {
		try {
			LBoot.PhysicRender self=(LBoot.PhysicRender)checkSelf(l);
			self.clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int renderAABBs(IntPtr l) {
		try {
			LBoot.PhysicRender self=(LBoot.PhysicRender)checkSelf(l);
			self.renderAABBs();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_aabbs(IntPtr l) {
		try {
			LBoot.PhysicRender self=(LBoot.PhysicRender)checkSelf(l);
			pushValue(l,self.aabbs);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_aabbs(IntPtr l) {
		try {
			LBoot.PhysicRender self=(LBoot.PhysicRender)checkSelf(l);
			System.Collections.Generic.List<LBoot.AABB> v;
			checkType(l,2,out v);
			self.aabbs=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.PhysicRender");
		addMember(l,addAABB);
		addMember(l,clear);
		addMember(l,renderAABBs);
		addMember(l,"aabbs",get_aabbs,set_aabbs,true);
		createTypeMetatable(l,null, typeof(LBoot.PhysicRender),typeof(UnityEngine.MonoBehaviour));
	}
}
