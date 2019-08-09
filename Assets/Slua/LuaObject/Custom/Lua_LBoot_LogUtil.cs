using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_LogUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.LogUtil o;
			o=new LBoot.LogUtil();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShouldLog_s(IntPtr l) {
		try {
			LBoot.LogUtil.LogLevel a1;
			checkEnum(l,1,out a1);
			var ret=LBoot.LogUtil.ShouldLog(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trace_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Trace(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TraceFormat_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			LBoot.LogUtil.TraceFormat(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Debug_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Debug(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DebugFormat_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			LBoot.LogUtil.DebugFormat(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Info_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Info(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InfoFormat_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			LBoot.LogUtil.InfoFormat(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Warn_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Warn(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WarnFormat_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			LBoot.LogUtil.WarnFormat(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Error_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Error(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ErrorFormat_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			LBoot.LogUtil.ErrorFormat(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Exception_s(IntPtr l) {
		try {
			System.Exception a1;
			checkType(l,1,out a1);
			LBoot.LogUtil.Exception(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int dumpObjectCache_s(IntPtr l) {
		try {
			LBoot.LogUtil.dumpObjectCache();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_level(IntPtr l) {
		try {
			pushEnum(l,(int)LBoot.LogUtil.level);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_level(IntPtr l) {
		try {
			LBoot.LogUtil.LogLevel v;
			checkEnum(l,2,out v);
			LBoot.LogUtil.level=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.LogUtil");
		addMember(l,ShouldLog_s);
		addMember(l,Trace_s);
		addMember(l,TraceFormat_s);
		addMember(l,Debug_s);
		addMember(l,DebugFormat_s);
		addMember(l,Info_s);
		addMember(l,InfoFormat_s);
		addMember(l,Warn_s);
		addMember(l,WarnFormat_s);
		addMember(l,Error_s);
		addMember(l,ErrorFormat_s);
		addMember(l,Exception_s);
		addMember(l,dumpObjectCache_s);
		addMember(l,"level",get_level,set_level,false);
		createTypeMetatable(l,constructor, typeof(LBoot.LogUtil));
	}
}
