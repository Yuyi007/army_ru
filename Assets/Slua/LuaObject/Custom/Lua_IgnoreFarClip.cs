using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_IgnoreFarClip : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isSkyBox(IntPtr l) {
		try {
			IgnoreFarClip self=(IgnoreFarClip)checkSelf(l);
			pushValue(l,self.isSkyBox);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isSkyBox(IntPtr l) {
		try {
			IgnoreFarClip self=(IgnoreFarClip)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isSkyBox=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_farClipPlane(IntPtr l) {
		try {
			IgnoreFarClip self=(IgnoreFarClip)checkSelf(l);
			pushValue(l,self.farClipPlane);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_farClipPlane(IntPtr l) {
		try {
			IgnoreFarClip self=(IgnoreFarClip)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.farClipPlane=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"IgnoreFarClip");
		addMember(l,"isSkyBox",get_isSkyBox,set_isSkyBox,true);
		addMember(l,"farClipPlane",get_farClipPlane,set_farClipPlane,true);
		createTypeMetatable(l,null, typeof(IgnoreFarClip),typeof(UnityEngine.MonoBehaviour));
	}
}
