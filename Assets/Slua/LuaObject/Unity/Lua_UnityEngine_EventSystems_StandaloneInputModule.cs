﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_StandaloneInputModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			self.UpdateModule();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsModuleSupported(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			var ret=self.IsModuleSupported();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShouldActivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			var ret=self.ShouldActivateModule();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ActivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			self.ActivateModule();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DeactivateModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			self.DeactivateModule();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Process(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			self.Process();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceModuleActive(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.forceModuleActive);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forceModuleActive(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.forceModuleActive=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inputActionsPerSecond(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.inputActionsPerSecond);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inputActionsPerSecond(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.inputActionsPerSecond=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_repeatDelay(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.repeatDelay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_repeatDelay(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.repeatDelay=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalAxis(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.horizontalAxis);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalAxis(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.horizontalAxis=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalAxis(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.verticalAxis);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalAxis(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.verticalAxis=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_submitButton(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.submitButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_submitButton(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.submitButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cancelButton(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			pushValue(l,self.cancelButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cancelButton(IntPtr l) {
		try {
			UnityEngine.EventSystems.StandaloneInputModule self=(UnityEngine.EventSystems.StandaloneInputModule)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.cancelButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.StandaloneInputModule");
		addMember(l,UpdateModule);
		addMember(l,IsModuleSupported);
		addMember(l,ShouldActivateModule);
		addMember(l,ActivateModule);
		addMember(l,DeactivateModule);
		addMember(l,Process);
		addMember(l,"forceModuleActive",get_forceModuleActive,set_forceModuleActive,true);
		addMember(l,"inputActionsPerSecond",get_inputActionsPerSecond,set_inputActionsPerSecond,true);
		addMember(l,"repeatDelay",get_repeatDelay,set_repeatDelay,true);
		addMember(l,"horizontalAxis",get_horizontalAxis,set_horizontalAxis,true);
		addMember(l,"verticalAxis",get_verticalAxis,set_verticalAxis,true);
		addMember(l,"submitButton",get_submitButton,set_submitButton,true);
		addMember(l,"cancelButton",get_cancelButton,set_cancelButton,true);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.StandaloneInputModule),typeof(UnityEngine.EventSystems.PointerInputModule));
	}
}
