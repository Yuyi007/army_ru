using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_SpriteAsset : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LBoot.SpriteAsset o;
			o=new LBoot.SpriteAsset();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSprite(IntPtr l) {
		try {
			LBoot.SpriteAsset self=(LBoot.SpriteAsset)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetSprite(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetMaterial(IntPtr l) {
		try {
			LBoot.SpriteAsset self=(LBoot.SpriteAsset)checkSelf(l);
			var ret=self.GetMaterial();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Unload(IntPtr l) {
		try {
			LBoot.SpriteAsset self=(LBoot.SpriteAsset)checkSelf(l);
			self.Unload();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_material(IntPtr l) {
		try {
			LBoot.SpriteAsset self=(LBoot.SpriteAsset)checkSelf(l);
			pushValue(l,self.material);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_material(IntPtr l) {
		try {
			LBoot.SpriteAsset self=(LBoot.SpriteAsset)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.SpriteAsset");
		addMember(l,GetSprite);
		addMember(l,GetMaterial);
		addMember(l,Unload);
		addMember(l,"material",get_material,set_material,true);
		createTypeMetatable(l,constructor, typeof(LBoot.SpriteAsset),typeof(UnityEngine.ScriptableObject));
	}
}
