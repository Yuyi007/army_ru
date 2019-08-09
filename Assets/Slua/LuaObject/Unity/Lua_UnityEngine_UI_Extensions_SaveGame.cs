using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SaveGame : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.UI.Extensions.SaveGame o;
			if(argc==1){
				o=new UnityEngine.UI.Extensions.SaveGame();
				pushValue(l,o);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.UI.Extensions.SceneObject> a2;
				checkType(l,3,out a2);
				o=new UnityEngine.UI.Extensions.SaveGame(a1,a2);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_savegameName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveGame self=(UnityEngine.UI.Extensions.SaveGame)checkSelf(l);
			pushValue(l,self.savegameName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_savegameName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveGame self=(UnityEngine.UI.Extensions.SaveGame)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.savegameName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sceneObjects(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveGame self=(UnityEngine.UI.Extensions.SaveGame)checkSelf(l);
			pushValue(l,self.sceneObjects);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sceneObjects(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SaveGame self=(UnityEngine.UI.Extensions.SaveGame)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UI.Extensions.SceneObject> v;
			checkType(l,2,out v);
			self.sceneObjects=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SaveGame");
		addMember(l,"savegameName",get_savegameName,set_savegameName,true);
		addMember(l,"sceneObjects",get_sceneObjects,set_sceneObjects,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.SaveGame));
	}
}
