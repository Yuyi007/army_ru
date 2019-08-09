using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ShineEffector : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_effector(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			pushValue(l,self.effector);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_effector(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			UnityEngine.UI.Extensions.ShineEffect v;
			checkType(l,2,out v);
			self.effector=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_yOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			pushValue(l,self.yOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_yOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.yOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_width(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			pushValue(l,self.width);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_width(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.width=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_YOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			pushValue(l,self.YOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_YOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffector self=(UnityEngine.UI.Extensions.ShineEffector)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.YOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ShineEffector");
		addMember(l,"effector",get_effector,set_effector,true);
		addMember(l,"yOffset",get_yOffset,set_yOffset,true);
		addMember(l,"width",get_width,set_width,true);
		addMember(l,"YOffset",get_YOffset,set_YOffset,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ShineEffector),typeof(UnityEngine.MonoBehaviour));
	}
}
