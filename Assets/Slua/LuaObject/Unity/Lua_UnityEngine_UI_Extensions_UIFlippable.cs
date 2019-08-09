using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIFlippable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ModifyMesh(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Mesh))){
				UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				self.ModifyMesh(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.UI.VertexHelper))){
				UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
				UnityEngine.UI.VertexHelper a1;
				checkType(l,2,out a1);
				self.ModifyMesh(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
			pushValue(l,self.horizontal);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.horizontal=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_vertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
			pushValue(l,self.vertical);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_vertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIFlippable self=(UnityEngine.UI.Extensions.UIFlippable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.vertical=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIFlippable");
		addMember(l,ModifyMesh);
		addMember(l,"horizontal",get_horizontal,set_horizontal,true);
		addMember(l,"vertical",get_vertical,set_vertical,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIFlippable),typeof(UnityEngine.MonoBehaviour));
	}
}
