using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Gradient : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient o;
			o=new UnityEngine.UI.Extensions.Gradient();
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
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
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
	static public int get_gradientMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			pushEnum(l,(int)self.gradientMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gradientMode(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			UnityEngine.UI.Extensions.GradientMode v;
			checkEnum(l,2,out v);
			self.gradientMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gradientDir(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			pushEnum(l,(int)self.gradientDir);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gradientDir(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			UnityEngine.UI.Extensions.GradientDir v;
			checkEnum(l,2,out v);
			self.gradientDir=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_overwriteAllColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			pushValue(l,self.overwriteAllColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_overwriteAllColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.overwriteAllColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_vertex1(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			pushValue(l,self.vertex1);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_vertex1(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.vertex1=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_vertex2(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			pushValue(l,self.vertex2);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_vertex2(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Gradient self=(UnityEngine.UI.Extensions.Gradient)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.vertex2=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.Gradient");
		addMember(l,ModifyMesh);
		addMember(l,"gradientMode",get_gradientMode,set_gradientMode,true);
		addMember(l,"gradientDir",get_gradientDir,set_gradientDir,true);
		addMember(l,"overwriteAllColor",get_overwriteAllColor,set_overwriteAllColor,true);
		addMember(l,"vertex1",get_vertex1,set_vertex1,true);
		addMember(l,"vertex2",get_vertex2,set_vertex2,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.Gradient),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
