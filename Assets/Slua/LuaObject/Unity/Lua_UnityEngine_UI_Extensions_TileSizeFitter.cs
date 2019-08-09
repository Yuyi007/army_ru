using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_TileSizeFitter : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter o;
			o=new UnityEngine.UI.Extensions.TileSizeFitter();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			self.SetLayoutHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			self.SetLayoutVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Border(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			pushValue(l,self.Border);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Border(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.Border=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TileSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			pushValue(l,self.TileSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_TileSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.TileSizeFitter self=(UnityEngine.UI.Extensions.TileSizeFitter)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.TileSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.TileSizeFitter");
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,"Border",get_Border,set_Border,true);
		addMember(l,"TileSize",get_TileSize,set_TileSize,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.TileSizeFitter),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
