using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LuaBinderBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Bind(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			SLua.LuaTable a1;
			checkType(l,2,out a1);
			self.Bind(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceExit(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			self.ForceExit();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DetachBinding(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			self.DetachBinding();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Lua(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			pushValue(l,self.Lua);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Pooled(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			pushValue(l,self.Pooled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Pooled(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.Pooled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ExecuteDestroyCallbacks(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			pushValue(l,self.ExecuteDestroyCallbacks);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ExecuteDestroyCallbacks(IntPtr l) {
		try {
			LBoot.LuaBinderBehaviour self=(LBoot.LuaBinderBehaviour)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ExecuteDestroyCallbacks=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LuaBinderBehaviour");
		addMember(l,Bind);
		addMember(l,ForceExit);
		addMember(l,DetachBinding);
		addMember(l,"Lua",get_Lua,null,true);
		addMember(l,"Pooled",get_Pooled,set_Pooled,true);
		addMember(l,"ExecuteDestroyCallbacks",get_ExecuteDestroyCallbacks,set_ExecuteDestroyCallbacks,true);
		createTypeMetatable(l,null, typeof(LBoot.LuaBinderBehaviour),typeof(UnityEngine.MonoBehaviour));
	}
}
