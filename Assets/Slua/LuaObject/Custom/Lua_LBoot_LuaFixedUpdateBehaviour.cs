using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaFixedUpdateBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LuaFixedUpdateBehaviour o;
			o=new LBoot.LuaFixedUpdateBehaviour();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LuaFixedUpdateInterval(IntPtr l) {
		try {
			LBoot.LuaFixedUpdateBehaviour self=(LBoot.LuaFixedUpdateBehaviour)checkSelf(l);
			pushValue(l,self.LuaFixedUpdateInterval);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LuaFixedUpdateInterval(IntPtr l) {
		try {
			LBoot.LuaFixedUpdateBehaviour self=(LBoot.LuaFixedUpdateBehaviour)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.LuaFixedUpdateInterval=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaFixedUpdateBehaviour");
		addMember(l,"LuaFixedUpdateInterval",get_LuaFixedUpdateInterval,set_LuaFixedUpdateInterval,true);
		createTypeMetatable(l,constructor, typeof(LBoot.LuaFixedUpdateBehaviour),typeof(LBoot.LuaBaseBehaviour));
	}
}
