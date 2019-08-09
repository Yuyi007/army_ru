using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Profiling_Profiler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddFramesFromFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Profiling.Profiler.AddFramesFromFile(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BeginThreadProfiling_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			UnityEngine.Profiling.Profiler.BeginThreadProfiling(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EndThreadProfiling_s(IntPtr l) {
		try {
			UnityEngine.Profiling.Profiler.EndThreadProfiling();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BeginSample_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Profiling.Profiler.BeginSample(a1);
				return 0;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Object a2;
				checkType(l,2,out a2);
				UnityEngine.Profiling.Profiler.BeginSample(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EndSample_s(IntPtr l) {
		try {
			UnityEngine.Profiling.Profiler.EndSample();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRuntimeMemorySizeLong_s(IntPtr l) {
		try {
			UnityEngine.Object a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetMonoHeapSizeLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetMonoHeapSizeLong();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetMonoUsedSizeLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTempAllocatorRequestedSize_s(IntPtr l) {
		try {
			System.UInt32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.SetTempAllocatorRequestedSize(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTempAllocatorSize_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTempAllocatorSize();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTotalAllocatedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTotalUnusedReservedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTotalReservedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supported(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Profiling.Profiler.supported);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logFile(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Profiling.Profiler.logFile);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logFile(IntPtr l) {
		try {
			string v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.logFile=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enableBinaryLog(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Profiling.Profiler.enableBinaryLog);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enableBinaryLog(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.enableBinaryLog=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Profiling.Profiler.enabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.enabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_usedHeapSizeLong(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Profiling.Profiler.usedHeapSizeLong);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Profiling.Profiler");
		addMember(l,AddFramesFromFile_s);
		addMember(l,BeginThreadProfiling_s);
		addMember(l,EndThreadProfiling_s);
		addMember(l,BeginSample_s);
		addMember(l,EndSample_s);
		addMember(l,GetRuntimeMemorySizeLong_s);
		addMember(l,GetMonoHeapSizeLong_s);
		addMember(l,GetMonoUsedSizeLong_s);
		addMember(l,SetTempAllocatorRequestedSize_s);
		addMember(l,GetTempAllocatorSize_s);
		addMember(l,GetTotalAllocatedMemoryLong_s);
		addMember(l,GetTotalUnusedReservedMemoryLong_s);
		addMember(l,GetTotalReservedMemoryLong_s);
		addMember(l,"supported",get_supported,null,false);
		addMember(l,"logFile",get_logFile,set_logFile,false);
		addMember(l,"enableBinaryLog",get_enableBinaryLog,set_enableBinaryLog,false);
		addMember(l,"enabled",get_enabled,set_enabled,false);
		addMember(l,"usedHeapSizeLong",get_usedHeapSizeLong,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Profiling.Profiler));
	}
}
