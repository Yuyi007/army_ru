using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_AuthLogin : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int registAuthResult(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			SLua.LuaFunction a1;
			checkType(l,2,out a1);
			self.registAuthResult(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int registGetUserInfoResult(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			SLua.LuaFunction a1;
			checkType(l,2,out a1);
			self.registGetUserInfoResult(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int authorize(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.authorize(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getUserInfo(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.getUserInfo(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ssdk(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			pushValue(l,self.ssdk);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ssdk(IntPtr l) {
		try {
			Game.AuthLogin self=(Game.AuthLogin)checkSelf(l);
			cn.sharesdk.unity3d.ShareSDK v;
			checkType(l,2,out v);
			self.ssdk=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.AuthLogin");
		addMember(l,registAuthResult);
		addMember(l,registGetUserInfoResult);
		addMember(l,authorize);
		addMember(l,getUserInfo);
		addMember(l,"ssdk",get_ssdk,set_ssdk,true);
		createTypeMetatable(l,null, typeof(Game.AuthLogin),typeof(UnityEngine.MonoBehaviour));
	}
}
