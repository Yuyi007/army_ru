﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_AxisEventData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData o;
			UnityEngine.EventSystems.EventSystem a1;
			checkType(l,2,out a1);
			o=new UnityEngine.EventSystems.AxisEventData(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_moveVector(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			pushValue(l,self.moveVector);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_moveVector(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.moveVector=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_moveDir(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			pushEnum(l,(int)self.moveDir);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_moveDir(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			UnityEngine.EventSystems.MoveDirection v;
			checkEnum(l,2,out v);
			self.moveDir=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.AxisEventData");
		addMember(l,"moveVector",get_moveVector,set_moveVector,true);
		addMember(l,"moveDir",get_moveDir,set_moveDir,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.AxisEventData),typeof(UnityEngine.EventSystems.BaseEventData));
	}
}