using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenChain : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			GoTweenChain o;
			if(argc==1){
				o=new GoTweenChain();
				pushValue(l,o);
				return 1;
			}
			else if(argc==2){
				GoTweenCollectionConfig a1;
				checkType(l,2,out a1);
				o=new GoTweenChain(a1);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int append(IntPtr l) {
		try {
			GoTweenChain self=(GoTweenChain)checkSelf(l);
			AbstractGoTween a1;
			checkType(l,2,out a1);
			var ret=self.append(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int appendDelay(IntPtr l) {
		try {
			GoTweenChain self=(GoTweenChain)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.appendDelay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int prepend(IntPtr l) {
		try {
			GoTweenChain self=(GoTweenChain)checkSelf(l);
			AbstractGoTween a1;
			checkType(l,2,out a1);
			var ret=self.prepend(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int prependDelay(IntPtr l) {
		try {
			GoTweenChain self=(GoTweenChain)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.prependDelay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTweenChain");
		addMember(l,append);
		addMember(l,appendDelay);
		addMember(l,prepend);
		addMember(l,prependDelay);
		createTypeMetatable(l,constructor, typeof(GoTweenChain),typeof(AbstractGoTweenCollection));
	}
}
