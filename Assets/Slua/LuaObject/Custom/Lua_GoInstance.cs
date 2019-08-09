using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoInstance : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int warn(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Object[] a2;
			checkParams(l,3,out a2);
			self.warn(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int error(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Object[] a2;
			checkParams(l,3,out a2);
			self.error(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int to(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				GoInstance self=(GoInstance)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				GoTweenConfig a3;
				checkType(l,4,out a3);
				var ret=self.to(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				GoInstance self=(GoInstance)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				GoSpline a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				GoTweenConfig a4;
				checkType(l,5,out a4);
				var ret=self.to(a1,a2,a3,a4);
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
	static public int from(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				GoInstance self=(GoInstance)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				GoTweenConfig a3;
				checkType(l,4,out a3);
				var ret=self.from(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				GoInstance self=(GoInstance)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				GoSpline a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				GoTweenConfig a4;
				checkType(l,5,out a4);
				var ret=self.from(a1,a2,a3,a4);
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
	static public int addTween(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			AbstractGoTween a1;
			checkType(l,2,out a1);
			self.addTween(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTween(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			AbstractGoTween a1;
			checkType(l,2,out a1);
			var ret=self.removeTween(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTweenWithTag(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.removeTweenWithTag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithTag(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.tweensWithTag(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithId(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.tweensWithId(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithTarget(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.tweensWithTarget(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int killAllTweensWithTarget(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.killAllTweensWithTarget(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushEnum(l,(int)self.defaultEaseType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			GoEaseType v;
			checkEnum(l,2,out v);
			self.defaultEaseType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultLoopType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushEnum(l,(int)self.defaultLoopType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultLoopType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			GoLoopType v;
			checkEnum(l,2,out v);
			self.defaultLoopType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultUpdateType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushEnum(l,(int)self.defaultUpdateType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultUpdateType(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			GoUpdateType v;
			checkEnum(l,2,out v);
			self.defaultUpdateType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duplicatePropertyRule(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushEnum(l,(int)self.duplicatePropertyRule);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duplicatePropertyRule(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			GoDuplicatePropertyRuleType v;
			checkEnum(l,2,out v);
			self.duplicatePropertyRule=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logLevel(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushEnum(l,(int)self.logLevel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logLevel(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			GoLogLevel v;
			checkEnum(l,2,out v);
			self.logLevel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_validateTargetObjectsEachTick(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			pushValue(l,self.validateTargetObjectsEachTick);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_validateTargetObjectsEachTick(IntPtr l) {
		try {
			GoInstance self=(GoInstance)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.validateTargetObjectsEachTick=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoInstance");
		addMember(l,warn);
		addMember(l,error);
		addMember(l,to);
		addMember(l,from);
		addMember(l,addTween);
		addMember(l,removeTween);
		addMember(l,removeTweenWithTag);
		addMember(l,tweensWithTag);
		addMember(l,tweensWithId);
		addMember(l,tweensWithTarget);
		addMember(l,killAllTweensWithTarget);
		addMember(l,"defaultEaseType",get_defaultEaseType,set_defaultEaseType,true);
		addMember(l,"defaultLoopType",get_defaultLoopType,set_defaultLoopType,true);
		addMember(l,"defaultUpdateType",get_defaultUpdateType,set_defaultUpdateType,true);
		addMember(l,"duplicatePropertyRule",get_duplicatePropertyRule,set_duplicatePropertyRule,true);
		addMember(l,"logLevel",get_logLevel,set_logLevel,true);
		addMember(l,"validateTargetObjectsEachTick",get_validateTargetObjectsEachTick,set_validateTargetObjectsEachTick,true);
		createTypeMetatable(l,null, typeof(GoInstance),typeof(UnityEngine.MonoBehaviour));
	}
}
