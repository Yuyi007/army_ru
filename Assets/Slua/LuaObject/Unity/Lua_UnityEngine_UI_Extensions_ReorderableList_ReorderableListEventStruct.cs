using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableList_ReorderableListEventStruct : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct o;
			o=new UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DroppedObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.DroppedObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DroppedObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.DroppedObject=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FromIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.FromIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FromIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.FromIndex=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FromList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.FromList);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FromList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Extensions.ReorderableList v;
			checkType(l,2,out v);
			self.FromList=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsAClone(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.IsAClone);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsAClone(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.IsAClone=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SourceObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.SourceObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SourceObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.SourceObject=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ToIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.ToIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ToIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.ToIndex=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ToList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			pushValue(l,self.ToList);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ToList(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Extensions.ReorderableList v;
			checkType(l,2,out v);
			self.ToList=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct");
		addMember(l,"DroppedObject",get_DroppedObject,set_DroppedObject,true);
		addMember(l,"FromIndex",get_FromIndex,set_FromIndex,true);
		addMember(l,"FromList",get_FromList,set_FromList,true);
		addMember(l,"IsAClone",get_IsAClone,set_IsAClone,true);
		addMember(l,"SourceObject",get_SourceObject,set_SourceObject,true);
		addMember(l,"ToIndex",get_ToIndex,set_ToIndex,true);
		addMember(l,"ToList",get_ToList,set_ToList,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct),typeof(System.ValueType));
	}
}
