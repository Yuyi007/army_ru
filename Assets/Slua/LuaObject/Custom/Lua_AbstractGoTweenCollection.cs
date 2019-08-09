using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AbstractGoTweenCollection : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			AbstractGoTweenCollection o;
			GoTweenCollectionConfig a1;
			checkType(l,2,out a1);
			o=new AbstractGoTweenCollection(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int tweensWithTarget(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.tweensWithTarget(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTweenProperty(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			AbstractTweenProperty a1;
			checkType(l,2,out a1);
			var ret=self.removeTweenProperty(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int containsTweenProperty(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			AbstractTweenProperty a1;
			checkType(l,2,out a1);
			var ret=self.containsTweenProperty(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int allTweenProperties(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			var ret=self.allTweenProperties();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isValid(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			var ret=self.isValid();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int play(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			self.play();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int pause(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			self.pause();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int update(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.update(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int reverse(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			self.reverse();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int goTo(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.goTo(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clearDidInitFlag(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			self.clearDidInitFlag();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int prepareAllTweenProperties(IntPtr l) {
		try {
			AbstractGoTweenCollection self=(AbstractGoTweenCollection)checkSelf(l);
			self.prepareAllTweenProperties();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AbstractGoTweenCollection");
		addMember(l,tweensWithTarget);
		addMember(l,removeTweenProperty);
		addMember(l,containsTweenProperty);
		addMember(l,allTweenProperties);
		addMember(l,isValid);
		addMember(l,play);
		addMember(l,pause);
		addMember(l,update);
		addMember(l,reverse);
		addMember(l,goTo);
		addMember(l,clearDidInitFlag);
		addMember(l,prepareAllTweenProperties);
		createTypeMetatable(l,constructor, typeof(AbstractGoTweenCollection),typeof(AbstractGoTween));
	}
}
