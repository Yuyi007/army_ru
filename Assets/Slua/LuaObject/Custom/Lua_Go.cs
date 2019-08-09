using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Go : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int destroyAll_s(IntPtr l) {
		try {
			Go.destroyAll();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int warn_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			Go.warn(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int error_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			Go.error(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int to_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.Object a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				GoTweenConfig a3;
				checkType(l,3,out a3);
				var ret=Go.to(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Object a1;
				checkType(l,1,out a1);
				GoSpline a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				GoTweenConfig a4;
				checkType(l,4,out a4);
				var ret=Go.to(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int from_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.Object a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				GoTweenConfig a3;
				checkType(l,3,out a3);
				var ret=Go.from(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Object a1;
				checkType(l,1,out a1);
				GoSpline a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				GoTweenConfig a4;
				checkType(l,4,out a4);
				var ret=Go.from(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int addTween_s(IntPtr l) {
		try {
			AbstractGoTween a1;
			checkType(l,1,out a1);
			Go.addTween(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTween_s(IntPtr l) {
		try {
			AbstractGoTween a1;
			checkType(l,1,out a1);
			var ret=Go.removeTween(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTweenWithTag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Go.removeTweenWithTag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithTag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=Go.tweensWithTag(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithId_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=Go.tweensWithId(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithTarget_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=Go.tweensWithTarget(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int killAllTweensWithTarget_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			Go.killAllTweensWithTarget(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseType(IntPtr l) {
		try {
			pushEnum(l,(int)Go.defaultEaseType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseType(IntPtr l) {
		try {
			GoEaseType v;
			checkEnum(l,2,out v);
			Go.defaultEaseType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultLoopType(IntPtr l) {
		try {
			pushEnum(l,(int)Go.defaultLoopType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultLoopType(IntPtr l) {
		try {
			GoLoopType v;
			checkEnum(l,2,out v);
			Go.defaultLoopType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultUpdateType(IntPtr l) {
		try {
			pushEnum(l,(int)Go.defaultUpdateType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultUpdateType(IntPtr l) {
		try {
			GoUpdateType v;
			checkEnum(l,2,out v);
			Go.defaultUpdateType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duplicatePropertyRule(IntPtr l) {
		try {
			pushEnum(l,(int)Go.duplicatePropertyRule);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duplicatePropertyRule(IntPtr l) {
		try {
			GoDuplicatePropertyRuleType v;
			checkEnum(l,2,out v);
			Go.duplicatePropertyRule=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logLevel(IntPtr l) {
		try {
			pushEnum(l,(int)Go.logLevel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logLevel(IntPtr l) {
		try {
			GoLogLevel v;
			checkEnum(l,2,out v);
			Go.logLevel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_validateTargetObjectsEachTick(IntPtr l) {
		try {
			pushValue(l,Go.validateTargetObjectsEachTick);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_validateTargetObjectsEachTick(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			Go.validateTargetObjectsEachTick=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_instance(IntPtr l) {
		try {
			pushValue(l,Go.instance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Go");
		addMember(l,destroyAll_s);
		addMember(l,warn_s);
		addMember(l,error_s);
		addMember(l,to_s);
		addMember(l,from_s);
		addMember(l,addTween_s);
		addMember(l,removeTween_s);
		addMember(l,removeTweenWithTag_s);
		addMember(l,tweensWithTag_s);
		addMember(l,tweensWithId_s);
		addMember(l,tweensWithTarget_s);
		addMember(l,killAllTweensWithTarget_s);
		addMember(l,"defaultEaseType",get_defaultEaseType,set_defaultEaseType,false);
		addMember(l,"defaultLoopType",get_defaultLoopType,set_defaultLoopType,false);
		addMember(l,"defaultUpdateType",get_defaultUpdateType,set_defaultUpdateType,false);
		addMember(l,"duplicatePropertyRule",get_duplicatePropertyRule,set_duplicatePropertyRule,false);
		addMember(l,"logLevel",get_logLevel,set_logLevel,false);
		addMember(l,"validateTargetObjectsEachTick",get_validateTargetObjectsEachTick,set_validateTargetObjectsEachTick,false);
		addMember(l,"instance",get_instance,null,false);
		createTypeMetatable(l,null, typeof(Go),typeof(UnityEngine.MonoBehaviour));
	}
}
