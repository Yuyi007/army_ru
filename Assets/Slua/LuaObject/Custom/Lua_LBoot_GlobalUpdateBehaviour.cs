using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_GlobalUpdateBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UpdateAction(IntPtr l) {
		try {
			LBoot.GlobalUpdateBehaviour self=(LBoot.GlobalUpdateBehaviour)checkSelf(l);
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.UpdateAction=v;
			else if(op==1) self.UpdateAction+=v;
			else if(op==2) self.UpdateAction-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FixedUpdateAction(IntPtr l) {
		try {
			LBoot.GlobalUpdateBehaviour self=(LBoot.GlobalUpdateBehaviour)checkSelf(l);
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.FixedUpdateAction=v;
			else if(op==1) self.FixedUpdateAction+=v;
			else if(op==2) self.FixedUpdateAction-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LateUpdateAction(IntPtr l) {
		try {
			LBoot.GlobalUpdateBehaviour self=(LBoot.GlobalUpdateBehaviour)checkSelf(l);
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.LateUpdateAction=v;
			else if(op==1) self.LateUpdateAction+=v;
			else if(op==2) self.LateUpdateAction-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FinalUpdateAction(IntPtr l) {
		try {
			LBoot.GlobalUpdateBehaviour self=(LBoot.GlobalUpdateBehaviour)checkSelf(l);
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.FinalUpdateAction=v;
			else if(op==1) self.FinalUpdateAction+=v;
			else if(op==2) self.FinalUpdateAction-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.GlobalUpdateBehaviour");
		addMember(l,"UpdateAction",null,set_UpdateAction,true);
		addMember(l,"FixedUpdateAction",null,set_FixedUpdateAction,true);
		addMember(l,"LateUpdateAction",null,set_LateUpdateAction,true);
		addMember(l,"FinalUpdateAction",null,set_FinalUpdateAction,true);
		createTypeMetatable(l,null, typeof(LBoot.GlobalUpdateBehaviour),typeof(UnityEngine.MonoBehaviour));
	}
}
