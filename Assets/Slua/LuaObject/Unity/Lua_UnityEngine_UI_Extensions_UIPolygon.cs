using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIPolygon : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon o;
			o=new UnityEngine.UI.Extensions.UIPolygon();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawPolygon(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.DrawPolygon(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				self.DrawPolygon(a1,a2);
				return 0;
			}
			else if(argc==4){
				UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single[] a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.DrawPolygon(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fill(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
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
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.fill=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_thickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			pushValue(l,self.thickness);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_thickness(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.thickness=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sides(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			pushValue(l,self.sides);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sides(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.sides=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			pushValue(l,self.rotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.rotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_VerticesDistances(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			pushValue(l,self.VerticesDistances);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_VerticesDistances(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPolygon self=(UnityEngine.UI.Extensions.UIPolygon)checkSelf(l);
			System.Single[] v;
			checkType(l,2,out v);
			self.VerticesDistances=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIPolygon");
		addMember(l,DrawPolygon);
		addMember(l,"fill",get_fill,set_fill,true);
		addMember(l,"thickness",get_thickness,set_thickness,true);
		addMember(l,"sides",get_sides,set_sides,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"VerticesDistances",get_VerticesDistances,set_VerticesDistances,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UIPolygon),typeof(UnityEngine.UI.Extensions.UIPrimitiveBase));
	}
}
