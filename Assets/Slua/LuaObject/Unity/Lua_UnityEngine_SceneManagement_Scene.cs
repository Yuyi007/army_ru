using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SceneManagement_Scene : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene o;
			o=new UnityEngine.SceneManagement.Scene();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsValid(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			var ret=self.IsValid();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRootGameObjects(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.SceneManagement.Scene self;
				checkValueType(l,1,out self);
				var ret=self.GetRootGameObjects();
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.SceneManagement.Scene self;
				checkValueType(l,1,out self);
				System.Collections.Generic.List<UnityEngine.GameObject> a1;
				checkType(l,2,out a1);
				self.GetRootGameObjects(a1);
				setBack(l,self);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_path(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.path);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.name);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isLoaded(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.isLoaded);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_buildIndex(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.buildIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isDirty(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.isDirty);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rootCount(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,self.rootCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SceneManagement.Scene");
		addMember(l,IsValid);
		addMember(l,GetRootGameObjects);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"path",get_path,null,true);
		addMember(l,"name",get_name,null,true);
		addMember(l,"isLoaded",get_isLoaded,null,true);
		addMember(l,"buildIndex",get_buildIndex,null,true);
		addMember(l,"isDirty",get_isDirty,null,true);
		addMember(l,"rootCount",get_rootCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SceneManagement.Scene),typeof(System.ValueType));
	}
}
