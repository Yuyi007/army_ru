using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoTweenCollectionConfig : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			GoTweenCollectionConfig o;
			o=new GoTweenCollectionConfig();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setIterations(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.setIterations(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				GoLoopType a2;
				checkEnum(l,3,out a2);
				var ret=self.setIterations(a1,a2);
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
	static public int setAutoClear(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.setAutoClear(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setUpdateType(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			GoUpdateType a1;
			checkEnum(l,2,out a1);
			var ret=self.setUpdateType(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onInit(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onInit(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onBegin(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onBegin(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onIterationStart(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onIterationStart(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onUpdate(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onUpdate(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onIterationEnd(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onIterationEnd(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onComplete(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.onComplete(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setId(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.setId(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clear(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			self.clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			pushValue(l,self.id);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.id=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_iterations(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			pushValue(l,self.iterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_iterations(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.iterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loopType(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			pushEnum(l,(int)self.loopType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loopType(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			GoLoopType v;
			checkEnum(l,2,out v);
			self.loopType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_propertyUpdateType(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			pushEnum(l,(int)self.propertyUpdateType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_propertyUpdateType(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			GoUpdateType v;
			checkEnum(l,2,out v);
			self.propertyUpdateType=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onInitHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onInitHandler=v;
			else if(op==1) self.onInitHandler+=v;
			else if(op==2) self.onInitHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onBeginHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onBeginHandler=v;
			else if(op==1) self.onBeginHandler+=v;
			else if(op==2) self.onBeginHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onIterationStartHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onIterationStartHandler=v;
			else if(op==1) self.onIterationStartHandler+=v;
			else if(op==2) self.onIterationStartHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onUpdateHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onUpdateHandler=v;
			else if(op==1) self.onUpdateHandler+=v;
			else if(op==2) self.onUpdateHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onIterationEndHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onIterationEndHandler=v;
			else if(op==1) self.onIterationEndHandler+=v;
			else if(op==2) self.onIterationEndHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onCompleteHandler(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Action<AbstractGoTween> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onCompleteHandler=v;
			else if(op==1) self.onCompleteHandler+=v;
			else if(op==2) self.onCompleteHandler-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoClear(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			pushValue(l,self.autoClear);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoClear(IntPtr l) {
		try {
			GoTweenCollectionConfig self=(GoTweenCollectionConfig)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.autoClear=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoTweenCollectionConfig");
		addMember(l,setIterations);
		addMember(l,setAutoClear);
		addMember(l,setUpdateType);
		addMember(l,onInit);
		addMember(l,onBegin);
		addMember(l,onIterationStart);
		addMember(l,onUpdate);
		addMember(l,onIterationEnd);
		addMember(l,onComplete);
		addMember(l,setId);
		addMember(l,clear);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"iterations",get_iterations,set_iterations,true);
		addMember(l,"loopType",get_loopType,set_loopType,true);
		addMember(l,"propertyUpdateType",get_propertyUpdateType,set_propertyUpdateType,true);
		addMember(l,"onInitHandler",null,set_onInitHandler,true);
		addMember(l,"onBeginHandler",null,set_onBeginHandler,true);
		addMember(l,"onIterationStartHandler",null,set_onIterationStartHandler,true);
		addMember(l,"onUpdateHandler",null,set_onUpdateHandler,true);
		addMember(l,"onIterationEndHandler",null,set_onIterationEndHandler,true);
		addMember(l,"onCompleteHandler",null,set_onCompleteHandler,true);
		addMember(l,"autoClear",get_autoClear,set_autoClear,true);
		createTypeMetatable(l,constructor, typeof(GoTweenCollectionConfig));
	}
}
