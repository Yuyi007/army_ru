using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenFlow : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			GoTweenFlow o;
			if(argc==1){
				o=new GoTweenFlow();
				pushValue(l,o);
				return 1;
			}
			else if(argc==2){
				GoTweenCollectionConfig a1;
				checkType(l,2,out a1);
				o=new GoTweenFlow(a1);
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
	static public int insert(IntPtr l) {
		try {
			GoTweenFlow self=(GoTweenFlow)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			AbstractGoTween a2;
			checkType(l,3,out a2);
			var ret=self.insert(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTweenFlow");
		addMember(l,insert);
		createTypeMetatable(l,constructor, typeof(GoTweenFlow),typeof(AbstractGoTweenCollection));
	}
}
