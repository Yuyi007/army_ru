using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Accordion : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Accordion self=(UnityEngine.UI.Extensions.Accordion)checkSelf(l);
			pushEnum(l,(int)self.transition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_transition(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Accordion self=(UnityEngine.UI.Extensions.Accordion)checkSelf(l);
			UnityEngine.UI.Extensions.Accordion.Transition v;
			checkEnum(l,2,out v);
			self.transition=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transitionDuration(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Accordion self=(UnityEngine.UI.Extensions.Accordion)checkSelf(l);
			pushValue(l,self.transitionDuration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_transitionDuration(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Accordion self=(UnityEngine.UI.Extensions.Accordion)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.transitionDuration=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.Accordion");
		addMember(l,"transition",get_transition,set_transition,true);
		addMember(l,"transitionDuration",get_transitionDuration,set_transitionDuration,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.Accordion),typeof(UnityEngine.MonoBehaviour));
	}
}
