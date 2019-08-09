using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ShineEffect : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect o;
			o=new UnityEngine.UI.Extensions.ShineEffect();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Triangulate(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect self=(UnityEngine.UI.Extensions.ShineEffect)checkSelf(l);
			UnityEngine.UI.VertexHelper a1;
			checkType(l,2,out a1);
			self.Triangulate(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Yoffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect self=(UnityEngine.UI.Extensions.ShineEffect)checkSelf(l);
			pushValue(l,self.Yoffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Yoffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect self=(UnityEngine.UI.Extensions.ShineEffect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Yoffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Width(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect self=(UnityEngine.UI.Extensions.ShineEffect)checkSelf(l);
			pushValue(l,self.Width);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Width(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ShineEffect self=(UnityEngine.UI.Extensions.ShineEffect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Width=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ShineEffect");
		addMember(l,Triangulate);
		addMember(l,"Yoffset",get_Yoffset,set_Yoffset,true);
		addMember(l,"Width",get_Width,set_Width,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.ShineEffect),typeof(UnityEngine.UI.MaskableGraphic));
	}
}
