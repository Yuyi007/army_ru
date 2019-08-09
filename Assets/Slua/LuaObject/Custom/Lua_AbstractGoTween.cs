using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AbstractGoTween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			AbstractGoTween o;
			o=new AbstractGoTween();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setOnInitHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setOnInitHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setOnBeginHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setOnBeginHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setonIterationStartHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setonIterationStartHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setOnUpdateHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setOnUpdateHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setonIterationEndHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setonIterationEndHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setOnCompleteHandler(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Action<AbstractGoTween> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.setOnCompleteHandler(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int update(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			var ret=self.isValid();
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.destroy();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int pause(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.pause();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int play(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.play();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playForward(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.playForward();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int playBackwards(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.playBackwards();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int rewind(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.rewind(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int restart(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.restart(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int reverse(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.reverse();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int complete(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.complete();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int goTo(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				AbstractGoTween self=(AbstractGoTween)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.goTo(a1);
				return 0;
			}
			else if(argc==3){
				AbstractGoTween self=(AbstractGoTween)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.goTo(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int goToAndPlay(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.goToAndPlay(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int waitForCompletion(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			var ret=self.waitForCompletion();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clearDidInitFlag(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			self.prepareAllTweenProperties();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
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
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.id=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tag(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.tag);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tag(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.tag=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_state(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushEnum(l,(int)self.state);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duration(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.duration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_totalDuration(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.totalDuration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.timeScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.timeScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateType(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushEnum(l,(int)self.updateType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loopType(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushEnum(l,(int)self.loopType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_iterations(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.iterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoRemoveOnComplete(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.autoRemoveOnComplete);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoRemoveOnComplete(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autoRemoveOnComplete=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isReversed(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.isReversed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_allowEvents(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.allowEvents);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_allowEvents(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.allowEvents=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_totalElapsedTime(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.totalElapsedTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isLoopingBackOnPingPong(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.isLoopingBackOnPingPong);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_completedIterations(IntPtr l) {
		try {
			AbstractGoTween self=(AbstractGoTween)checkSelf(l);
			pushValue(l,self.completedIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AbstractGoTween");
		addMember(l,setOnInitHandler);
		addMember(l,setOnBeginHandler);
		addMember(l,setonIterationStartHandler);
		addMember(l,setOnUpdateHandler);
		addMember(l,setonIterationEndHandler);
		addMember(l,setOnCompleteHandler);
		addMember(l,update);
		addMember(l,isValid);
		addMember(l,removeTweenProperty);
		addMember(l,containsTweenProperty);
		addMember(l,allTweenProperties);
		addMember(l,destroy);
		addMember(l,pause);
		addMember(l,play);
		addMember(l,playForward);
		addMember(l,playBackwards);
		addMember(l,rewind);
		addMember(l,restart);
		addMember(l,reverse);
		addMember(l,complete);
		addMember(l,goTo);
		addMember(l,goToAndPlay);
		addMember(l,waitForCompletion);
		addMember(l,clearDidInitFlag);
		addMember(l,prepareAllTweenProperties);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"tag",get_tag,set_tag,true);
		addMember(l,"state",get_state,null,true);
		addMember(l,"duration",get_duration,null,true);
		addMember(l,"totalDuration",get_totalDuration,null,true);
		addMember(l,"timeScale",get_timeScale,set_timeScale,true);
		addMember(l,"updateType",get_updateType,null,true);
		addMember(l,"loopType",get_loopType,null,true);
		addMember(l,"iterations",get_iterations,null,true);
		addMember(l,"autoRemoveOnComplete",get_autoRemoveOnComplete,set_autoRemoveOnComplete,true);
		addMember(l,"isReversed",get_isReversed,null,true);
		addMember(l,"allowEvents",get_allowEvents,set_allowEvents,true);
		addMember(l,"totalElapsedTime",get_totalElapsedTime,null,true);
		addMember(l,"isLoopingBackOnPingPong",get_isLoopingBackOnPingPong,null,true);
		addMember(l,"completedIterations",get_completedIterations,null,true);
		createTypeMetatable(l,constructor, typeof(AbstractGoTween));
	}
}
