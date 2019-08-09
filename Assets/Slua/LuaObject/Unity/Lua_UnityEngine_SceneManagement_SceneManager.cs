﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SceneManagement_SceneManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SceneManagement.SceneManager o;
			o=new UnityEngine.SceneManagement.SceneManager();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetActiveScene_s(IntPtr l) {
		try {
			var ret=UnityEngine.SceneManagement.SceneManager.GetActiveScene();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetActiveScene_s(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.SetActiveScene(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSceneByPath_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.GetSceneByPath(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSceneByName_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.GetSceneByName(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSceneByBuildIndex_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSceneAt_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.GetSceneAt(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadScene_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.SceneManager.LoadScene(a1);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.SceneManager.LoadScene(a1);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.SceneManagement.LoadSceneMode))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.LoadSceneMode a2;
				checkEnum(l,2,out a2);
				UnityEngine.SceneManagement.SceneManager.LoadScene(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.SceneManagement.LoadSceneMode))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.LoadSceneMode a2;
				checkEnum(l,2,out a2);
				UnityEngine.SceneManagement.SceneManager.LoadScene(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadSceneAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.SceneManagement.LoadSceneMode))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.LoadSceneMode a2;
				checkEnum(l,2,out a2);
				var ret=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.SceneManagement.LoadSceneMode))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.SceneManagement.LoadSceneMode a2;
				checkEnum(l,2,out a2);
				var ret=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateScene_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.SceneManagement.SceneManager.CreateScene(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnloadSceneAsync_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.SceneManagement.Scene))){
				UnityEngine.SceneManagement.Scene a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(a1);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MergeScenes_s(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			UnityEngine.SceneManagement.SceneManager.MergeScenes(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MoveGameObjectToScene_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sceneCount(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SceneManagement.SceneManager.sceneCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sceneCountInBuildSettings(IntPtr l) {
		try {
			pushValue(l,UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SceneManagement.SceneManager");
		addMember(l,GetActiveScene_s);
		addMember(l,SetActiveScene_s);
		addMember(l,GetSceneByPath_s);
		addMember(l,GetSceneByName_s);
		addMember(l,GetSceneByBuildIndex_s);
		addMember(l,GetSceneAt_s);
		addMember(l,LoadScene_s);
		addMember(l,LoadSceneAsync_s);
		addMember(l,CreateScene_s);
		addMember(l,UnloadSceneAsync_s);
		addMember(l,MergeScenes_s);
		addMember(l,MoveGameObjectToScene_s);
		addMember(l,"sceneCount",get_sceneCount,null,false);
		addMember(l,"sceneCountInBuildSettings",get_sceneCountInBuildSettings,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SceneManagement.SceneManager));
	}
}
