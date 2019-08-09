using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DiamondGraph : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph o;
			o=new UnityEngine.UI.Extensions.DiamondGraph();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_a(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			pushValue(l,self.a);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_a(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.a=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_b(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			pushValue(l,self.b);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_b(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.b=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_c(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			pushValue(l,self.c);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_c(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.c=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_d(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			pushValue(l,self.d);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_d(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DiamondGraph self=(UnityEngine.UI.Extensions.DiamondGraph)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.d=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DiamondGraph");
		addMember(l,"a",get_a,set_a,true);
		addMember(l,"b",get_b,set_b,true);
		addMember(l,"c",get_c,set_c,true);
		addMember(l,"d",get_d,set_d,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.DiamondGraph),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
