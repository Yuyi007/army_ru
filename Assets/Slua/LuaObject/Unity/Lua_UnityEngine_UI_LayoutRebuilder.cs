using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_LayoutRebuilder : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder o;
			o=new UnityEngine.UI.LayoutRebuilder();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsDestroyed(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder self=(UnityEngine.UI.LayoutRebuilder)checkSelf(l);
			var ret=self.IsDestroyed();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder self=(UnityEngine.UI.LayoutRebuilder)checkSelf(l);
			UnityEngine.UI.CanvasUpdate a1;
			checkEnum(l,2,out a1);
			self.Rebuild(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LayoutComplete(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder self=(UnityEngine.UI.LayoutRebuilder)checkSelf(l);
			self.LayoutComplete();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GraphicUpdateComplete(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder self=(UnityEngine.UI.LayoutRebuilder)checkSelf(l);
			self.GraphicUpdateComplete();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceRebuildLayoutImmediate_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MarkLayoutForRebuild_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.UI.LayoutRebuilder self=(UnityEngine.UI.LayoutRebuilder)checkSelf(l);
			pushValue(l,self.transform);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.LayoutRebuilder");
		addMember(l,IsDestroyed);
		addMember(l,Rebuild);
		addMember(l,LayoutComplete);
		addMember(l,GraphicUpdateComplete);
		addMember(l,ForceRebuildLayoutImmediate_s);
		addMember(l,MarkLayoutForRebuild_s);
		addMember(l,"transform",get_transform,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.LayoutRebuilder));
	}
}
