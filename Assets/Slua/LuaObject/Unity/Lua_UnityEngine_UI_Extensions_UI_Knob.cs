using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UI_Knob : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerUp(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerEnter(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerEnter(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerExit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerExit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_direction(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushEnum(l,(int)self.direction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_direction(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.UI.Extensions.UI_Knob.Direction v;
			checkEnum(l,2,out v);
			self.direction=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_knobValue(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.knobValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_knobValue(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.knobValue=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxValue(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.maxValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxValue(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.maxValue=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loops(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.loops);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loops(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.loops=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clampOutput01(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.clampOutput01);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clampOutput01(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.clampOutput01=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_snapToPosition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.snapToPosition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_snapToPosition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.snapToPosition=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_snapStepsPerLoop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.snapStepsPerLoop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_snapStepsPerLoop(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.snapStepsPerLoop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			pushValue(l,self.OnValueChanged);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UI_Knob self=(UnityEngine.UI.Extensions.UI_Knob)checkSelf(l);
			UnityEngine.UI.Extensions.KnobFloatValueEvent v;
			checkType(l,2,out v);
			self.OnValueChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UI_Knob");
		addMember(l,OnPointerDown);
		addMember(l,OnPointerUp);
		addMember(l,OnPointerEnter);
		addMember(l,OnPointerExit);
		addMember(l,OnBeginDrag);
		addMember(l,OnDrag);
		addMember(l,"direction",get_direction,set_direction,true);
		addMember(l,"knobValue",get_knobValue,set_knobValue,true);
		addMember(l,"maxValue",get_maxValue,set_maxValue,true);
		addMember(l,"loops",get_loops,set_loops,true);
		addMember(l,"clampOutput01",get_clampOutput01,set_clampOutput01,true);
		addMember(l,"snapToPosition",get_snapToPosition,set_snapToPosition,true);
		addMember(l,"snapStepsPerLoop",get_snapStepsPerLoop,set_snapStepsPerLoop,true);
		addMember(l,"OnValueChanged",get_OnValueChanged,set_OnValueChanged,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UI_Knob),typeof(UnityEngine.MonoBehaviour));
	}
}
