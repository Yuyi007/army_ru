using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SpriteRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer o;
			o=new UnityEngine.SpriteRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sprite(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.sprite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sprite(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.sprite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_drawMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushEnum(l,(int)self.drawMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_drawMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteDrawMode v;
			checkEnum(l,2,out v);
			self.drawMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_size(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.size);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_size(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.size=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_adaptiveModeThreshold(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.adaptiveModeThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_adaptiveModeThreshold(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.adaptiveModeThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tileMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushEnum(l,(int)self.tileMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tileMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteTileMode v;
			checkEnum(l,2,out v);
			self.tileMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.color);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flipX(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.flipX);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flipX(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.flipX=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flipY(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,self.flipY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flipY(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.flipY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskInteraction(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushEnum(l,(int)self.maskInteraction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskInteraction(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteMaskInteraction v;
			checkEnum(l,2,out v);
			self.maskInteraction=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SpriteRenderer");
		addMember(l,"sprite",get_sprite,set_sprite,true);
		addMember(l,"drawMode",get_drawMode,set_drawMode,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"adaptiveModeThreshold",get_adaptiveModeThreshold,set_adaptiveModeThreshold,true);
		addMember(l,"tileMode",get_tileMode,set_tileMode,true);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"flipX",get_flipX,set_flipX,true);
		addMember(l,"flipY",get_flipY,set_flipY,true);
		addMember(l,"maskInteraction",get_maskInteraction,set_maskInteraction,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SpriteRenderer),typeof(UnityEngine.Renderer));
	}
}
