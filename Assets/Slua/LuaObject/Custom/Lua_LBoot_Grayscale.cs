using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_Grayscale : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.Grayscale o;
			o=new LBoot.Grayscale();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ModifyMesh(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			UnityEngine.UI.VertexHelper a1;
			checkType(l,2,out a1);
			self.ModifyMesh(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fill(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			pushValue(l,self.fill);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fill(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fill=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_grayScale(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			pushValue(l,self.grayScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_grayScale(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.grayScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fillDirection(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			pushEnum(l,(int)self.fillDirection);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fillDirection(IntPtr l) {
		try {
			LBoot.Grayscale self=(LBoot.Grayscale)checkSelf(l);
			LBoot.Grayscale.FillDirection v;
			checkEnum(l,2,out v);
			self.fillDirection=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.Grayscale");
		addMember(l,ModifyMesh);
		addMember(l,"fill",get_fill,set_fill,true);
		addMember(l,"grayScale",get_grayScale,set_grayScale,true);
		addMember(l,"fillDirection",get_fillDirection,set_fillDirection,true);
		createTypeMetatable(l,constructor, typeof(LBoot.Grayscale),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
