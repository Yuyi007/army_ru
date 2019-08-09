using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaBaseBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceExit(IntPtr l) {
		try {
			LBoot.LuaBaseBehaviour self=(LBoot.LuaBaseBehaviour)checkSelf(l);
			self.ForceExit();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Lua(IntPtr l) {
		try {
			LBoot.LuaBaseBehaviour self=(LBoot.LuaBaseBehaviour)checkSelf(l);
			pushValue(l,self.Lua);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Lua(IntPtr l) {
		try {
			LBoot.LuaBaseBehaviour self=(LBoot.LuaBaseBehaviour)checkSelf(l);
			SLua.LuaTable v;
			checkType(l,2,out v);
			self.Lua=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaBaseBehaviour");
		addMember(l,ForceExit);
		addMember(l,"Lua",get_Lua,set_Lua,true);
		createTypeMetatable(l,null, typeof(LBoot.LuaBaseBehaviour),typeof(UnityEngine.MonoBehaviour));
	}
}
