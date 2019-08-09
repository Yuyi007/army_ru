using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_UI3D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddToScene(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.AddToScene(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uiTexture(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.uiTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uiTexture(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.RenderTexture v;
			checkType(l,2,out v);
			self.uiTexture=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_camera(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.camera);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_camera(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.camera=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rawImg(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.rawImg);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_rawImg(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.UI.RawImage v;
			checkType(l,2,out v);
			self.rawImg=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_goScenery(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.goScenery);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_goScenery(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.goScenery=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_preview(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.preview);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_preview(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.preview=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_width(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.width);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_width(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.width=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_height(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.height);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_height(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.height=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_modelRotation(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.modelRotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_modelRotation(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.modelRotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_modelPosition(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.modelPosition);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_modelPosition(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.modelPosition=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_modelScale(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			pushValue(l,self.modelScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_modelScale(IntPtr l) {
		try {
			Game.UI3D self=(Game.UI3D)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.modelScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.UI3D");
		addMember(l,AddToScene);
		addMember(l,"uiTexture",get_uiTexture,set_uiTexture,true);
		addMember(l,"camera",get_camera,set_camera,true);
		addMember(l,"rawImg",get_rawImg,set_rawImg,true);
		addMember(l,"goScenery",get_goScenery,set_goScenery,true);
		addMember(l,"preview",get_preview,set_preview,true);
		addMember(l,"width",get_width,set_width,true);
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"modelRotation",get_modelRotation,set_modelRotation,true);
		addMember(l,"modelPosition",get_modelPosition,set_modelPosition,true);
		addMember(l,"modelScale",get_modelScale,set_modelScale,true);
		createTypeMetatable(l,null, typeof(Game.UI3D),typeof(UnityEngine.MonoBehaviour));
	}
}
