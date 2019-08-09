using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LBootApp : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LBootApp o;
			o=new LBoot.LBootApp();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_GAME_OBJECT_NAME(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.GAME_OBJECT_NAME);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GAME_OBJECT_NAME(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			LBoot.LBootApp.GAME_OBJECT_NAME=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ALWAYS_AWAKE(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.ALWAYS_AWAKE);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ALWAYS_AWAKE(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			LBoot.LBootApp.ALWAYS_AWAKE=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TARGET_FRAME_RATE(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.TARGET_FRAME_RATE);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_TARGET_FRAME_RATE(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			LBoot.LBootApp.TARGET_FRAME_RATE=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LUA_KEY(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.LUA_KEY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LUA_KEY(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.LUA_KEY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LUA_IV(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.LUA_IV);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LUA_IV(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.LUA_IV=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BUNDLE_KEY(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.BUNDLE_KEY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BUNDLE_KEY(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.BUNDLE_KEY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BUNDLE_IV(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.BUNDLE_IV);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BUNDLE_IV(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.BUNDLE_IV=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BUNDLE_NONCE(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.BUNDLE_NONCE);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BUNDLE_NONCE(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.BUNDLE_NONCE=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_COMM_KEY(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.COMM_KEY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_COMM_KEY(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.COMM_KEY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_COMM_NONCE(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.COMM_NONCE);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_COMM_NONCE(IntPtr l) {
		try {
			System.Byte[] v;
			checkType(l,2,out v);
			LBoot.LBootApp.COMM_NONCE=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DEFAULT_BUNDLE_EXTENSION(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.DEFAULT_BUNDLE_EXTENSION);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DEFAULT_BUNDLE_EXTENSION(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			LBoot.LBootApp.DEFAULT_BUNDLE_EXTENSION=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_luaBridge(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.luaBridge);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_luaBridge(IntPtr l) {
		try {
			LBoot.LuaBridge v;
			checkType(l,2,out v);
			LBoot.LBootApp.luaBridge=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_initGameObject(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.initGameObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_initGameObject(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			LBoot.LBootApp.initGameObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Instance(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.Instance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Instance(IntPtr l) {
		try {
			LBoot.LBootApp v;
			checkType(l,2,out v);
			LBoot.LBootApp.Instance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Running(IntPtr l) {
		try {
			pushValue(l,LBoot.LBootApp.Running);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LBootApp");
		addMember(l,"GAME_OBJECT_NAME",get_GAME_OBJECT_NAME,set_GAME_OBJECT_NAME,false);
		addMember(l,"ALWAYS_AWAKE",get_ALWAYS_AWAKE,set_ALWAYS_AWAKE,false);
		addMember(l,"TARGET_FRAME_RATE",get_TARGET_FRAME_RATE,set_TARGET_FRAME_RATE,false);
		addMember(l,"LUA_KEY",get_LUA_KEY,set_LUA_KEY,false);
		addMember(l,"LUA_IV",get_LUA_IV,set_LUA_IV,false);
		addMember(l,"BUNDLE_KEY",get_BUNDLE_KEY,set_BUNDLE_KEY,false);
		addMember(l,"BUNDLE_IV",get_BUNDLE_IV,set_BUNDLE_IV,false);
		addMember(l,"BUNDLE_NONCE",get_BUNDLE_NONCE,set_BUNDLE_NONCE,false);
		addMember(l,"COMM_KEY",get_COMM_KEY,set_COMM_KEY,false);
		addMember(l,"COMM_NONCE",get_COMM_NONCE,set_COMM_NONCE,false);
		addMember(l,"DEFAULT_BUNDLE_EXTENSION",get_DEFAULT_BUNDLE_EXTENSION,set_DEFAULT_BUNDLE_EXTENSION,false);
		addMember(l,"luaBridge",get_luaBridge,set_luaBridge,false);
		addMember(l,"initGameObject",get_initGameObject,set_initGameObject,false);
		addMember(l,"Instance",get_Instance,set_Instance,false);
		addMember(l,"Running",get_Running,null,false);
		createTypeMetatable(l,constructor, typeof(LBoot.LBootApp),typeof(LBoot.LBootAppBehaviour));
	}
}
