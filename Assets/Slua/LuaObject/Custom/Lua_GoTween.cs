using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			GoTween o;
			if(argc==4){
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				GoTweenConfig a3;
				checkType(l,4,out a3);
				o=new GoTween(a1,a2,a3);
				pushValue(l,o);
				return 1;
			}
			else if(argc==5){
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				GoTweenConfig a3;
				checkType(l,4,out a3);
				System.Action<AbstractGoTween> a4;
				LuaDelegation.checkDelegate(l,5,out a4);
				o=new GoTween(a1,a2,a3,a4);
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
	static public int update(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
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
	static public int isValid(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			var ret=self.isValid();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int addTweenProperty(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			AbstractTweenProperty a1;
			checkType(l,2,out a1);
			self.addTweenProperty(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeTweenProperty(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
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
			GoTween self=(GoTween)checkSelf(l);
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
	static public int clearTweenProperties(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			self.clearTweenProperties();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int allTweenProperties(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			var ret=self.allTweenProperties();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int destroy(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			self.destroy();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int goTo(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
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
	static public int complete(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			self.complete();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clearDidInitFlag(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
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
			GoTween self=(GoTween)checkSelf(l);
			self.prepareAllTweenProperties();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			pushValue(l,self.target);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_delay(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			pushValue(l,self.delay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isFrom(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			pushValue(l,self.isFrom);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easeType(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			pushEnum(l,(int)self.easeType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeType(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			GoEaseType v;
			checkEnum(l,2,out v);
			self.easeType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easeCurve(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			pushValue(l,self.easeCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeCurve(IntPtr l) {
		try {
			GoTween self=(GoTween)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.easeCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTween");
		addMember(l,update);
		addMember(l,isValid);
		addMember(l,addTweenProperty);
		addMember(l,removeTweenProperty);
		addMember(l,containsTweenProperty);
		addMember(l,clearTweenProperties);
		addMember(l,allTweenProperties);
		addMember(l,destroy);
		addMember(l,goTo);
		addMember(l,complete);
		addMember(l,clearDidInitFlag);
		addMember(l,prepareAllTweenProperties);
		addMember(l,"target",get_target,null,true);
		addMember(l,"delay",get_delay,null,true);
		addMember(l,"isFrom",get_isFrom,null,true);
		addMember(l,"easeType",get_easeType,set_easeType,true);
		addMember(l,"easeCurve",get_easeCurve,set_easeCurve,true);
		createTypeMetatable(l,constructor, typeof(GoTween),typeof(AbstractGoTween));
	}
}
