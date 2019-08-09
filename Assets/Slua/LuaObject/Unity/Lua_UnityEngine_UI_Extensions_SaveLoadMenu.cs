using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SaveLoadMenu : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SaveGame(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
				self.SaveGame();
				return 0;
			}
			else if(argc==2){
				UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.SaveGame(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadGame(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
				self.LoadGame();
				return 0;
			}
			else if(argc==2){
				UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.LoadGame(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearScene(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			self.ClearScene();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PackGameObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			var ret=self.PackGameObject(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PackComponent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.PackComponent(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnpackGameObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			UnityEngine.UI.Extensions.SceneObject a1;
			checkType(l,2,out a1);
			var ret=self.UnpackGameObject(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnpackComponents(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			UnityEngine.UI.Extensions.SceneObject a2;
			checkType(l,3,out a2);
			self.UnpackComponents(ref a1,a2);
			pushValue(l,a1);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showMenu(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			pushValue(l,self.showMenu);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showMenu(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.showMenu=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_usePersistentDataPath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			pushValue(l,self.usePersistentDataPath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_usePersistentDataPath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.usePersistentDataPath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_savePath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			pushValue(l,self.savePath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_savePath(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.savePath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_prefabDictionary(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			pushValue(l,self.prefabDictionary);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_prefabDictionary(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveLoadMenu self=(UnityEngine.UI.Extensions.SaveLoadMenu)checkSelf(l);
			System.Collections.Generic.Dictionary<System.String,UnityEngine.GameObject> v;
			checkType(l,2,out v);
			self.prefabDictionary=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SaveLoadMenu");
		addMember(l,SaveGame);
		addMember(l,LoadGame);
		addMember(l,ClearScene);
		addMember(l,PackGameObject);
		addMember(l,PackComponent);
		addMember(l,UnpackGameObject);
		addMember(l,UnpackComponents);
		addMember(l,"showMenu",get_showMenu,set_showMenu,true);
		addMember(l,"usePersistentDataPath",get_usePersistentDataPath,set_usePersistentDataPath,true);
		addMember(l,"savePath",get_savePath,set_savePath,true);
		addMember(l,"prefabDictionary",get_prefabDictionary,set_prefabDictionary,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.SaveLoadMenu),typeof(UnityEngine.MonoBehaviour));
	}
}
