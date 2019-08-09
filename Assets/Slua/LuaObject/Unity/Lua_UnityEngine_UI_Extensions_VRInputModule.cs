using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_VRInputModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VRInputModule o;
			o=new UnityEngine.UI.Extensions.VRInputModule();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Process(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VRInputModule self=(UnityEngine.UI.Extensions.VRInputModule)checkSelf(l);
			self.Process();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PointerSubmit_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.VRInputModule.PointerSubmit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PointerExit_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.VRInputModule.PointerExit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PointerEnter_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.UI.Extensions.VRInputModule.PointerEnter(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_targetObject(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Extensions.VRInputModule.targetObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_targetObject(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			UnityEngine.UI.Extensions.VRInputModule.targetObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cursorPosition(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Extensions.VRInputModule.cursorPosition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cursorPosition(IntPtr l) {
		try {
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			UnityEngine.UI.Extensions.VRInputModule.cursorPosition=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.VRInputModule");
		addMember(l,Process);
		addMember(l,PointerSubmit_s);
		addMember(l,PointerExit_s);
		addMember(l,PointerEnter_s);
		addMember(l,"targetObject",get_targetObject,set_targetObject,false);
		addMember(l,"cursorPosition",get_cursorPosition,set_cursorPosition,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.VRInputModule),typeof(UnityEngine.EventSystems.BaseInputModule));
	}
}
