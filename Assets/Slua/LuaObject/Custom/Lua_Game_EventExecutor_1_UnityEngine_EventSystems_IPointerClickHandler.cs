using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_EventExecutor_1_UnityEngine_EventSystems_IPointerClickHandler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler> o;
			o=new Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Execute(IntPtr l) {
		try {
			Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler> self=(Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			UnityEngine.EventSystems.BaseEventData a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			var ret=self.Execute(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ExecuteHierarchy(IntPtr l) {
		try {
			Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler> self=(Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			UnityEngine.EventSystems.BaseEventData a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			var ret=self.ExecuteHierarchy(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetEventHandler(IntPtr l) {
		try {
			Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler> self=(Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			var ret=self.GetEventHandler(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CanHandleEvent(IntPtr l) {
		try {
			Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler> self=(Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			var ret=self.CanHandleEvent(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"PointClickExecutor");
		addMember(l,Execute);
		addMember(l,ExecuteHierarchy);
		addMember(l,GetEventHandler);
		addMember(l,CanHandleEvent);
		createTypeMetatable(l,constructor, typeof(Game.EventExecutor<UnityEngine.EventSystems.IPointerClickHandler>));
	}
}
