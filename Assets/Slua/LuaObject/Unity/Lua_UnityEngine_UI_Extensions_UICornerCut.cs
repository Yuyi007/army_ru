using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UICornerCut : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut o;
			o=new UnityEngine.UI.Extensions.UICornerCut();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cornerSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.cornerSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cornerSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.cornerSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutUL(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.cutUL);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutUL(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cutUL=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutUR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.cutUR);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutUR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cutUR=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutLL(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.cutLL);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutLL(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cutLL=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutLR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.cutLR);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutLR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cutLR=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_makeColumns(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.makeColumns);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_makeColumns(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.makeColumns=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useColorUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.useColorUp);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useColorUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useColorUp=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.colorUp);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			UnityEngine.Color32 v;
			checkValueType(l,2,out v);
			self.colorUp=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useColorDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.useColorDown);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useColorDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useColorDown=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			pushValue(l,self.colorDown);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UICornerCut self=(UnityEngine.UI.Extensions.UICornerCut)checkSelf(l);
			UnityEngine.Color32 v;
			checkValueType(l,2,out v);
			self.colorDown=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UICornerCut");
		addMember(l,"cornerSize",get_cornerSize,set_cornerSize,true);
		addMember(l,"cutUL",get_cutUL,set_cutUL,true);
		addMember(l,"cutUR",get_cutUR,set_cutUR,true);
		addMember(l,"cutLL",get_cutLL,set_cutLL,true);
		addMember(l,"cutLR",get_cutLR,set_cutLR,true);
		addMember(l,"makeColumns",get_makeColumns,set_makeColumns,true);
		addMember(l,"useColorUp",get_useColorUp,set_useColorUp,true);
		addMember(l,"colorUp",get_colorUp,set_colorUp,true);
		addMember(l,"useColorDown",get_useColorDown,set_useColorDown,true);
		addMember(l,"colorDown",get_colorDown,set_colorDown,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UICornerCut),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
