using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_StaticBatchRoot : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int doCombineStaticBatch(IntPtr l) {
		try {
			LBoot.StaticBatchRoot self=(LBoot.StaticBatchRoot)checkSelf(l);
			self.doCombineStaticBatch();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_staticGameObjects(IntPtr l) {
		try {
			LBoot.StaticBatchRoot self=(LBoot.StaticBatchRoot)checkSelf(l);
			pushValue(l,self.staticGameObjects);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_staticGameObjects(IntPtr l) {
		try {
			LBoot.StaticBatchRoot self=(LBoot.StaticBatchRoot)checkSelf(l);
			UnityEngine.GameObject[] v;
			checkType(l,2,out v);
			self.staticGameObjects=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.StaticBatchRoot");
		addMember(l,doCombineStaticBatch);
		addMember(l,"staticGameObjects",get_staticGameObjects,set_staticGameObjects,true);
		createTypeMetatable(l,null, typeof(LBoot.StaticBatchRoot),typeof(UnityEngine.MonoBehaviour));
	}
}
