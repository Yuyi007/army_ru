using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ReorderableList : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestReOrderableListTarget(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct a1;
			checkValueType(l,2,out a1);
			self.TestReOrderableListTarget(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ContentLayout(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.ContentLayout);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ContentLayout(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.UI.LayoutGroup v;
			checkType(l,2,out v);
			self.ContentLayout=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DraggableArea(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.DraggableArea);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DraggableArea(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.DraggableArea=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsDraggable(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.IsDraggable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsDraggable(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.IsDraggable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CloneDraggedObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.CloneDraggedObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CloneDraggedObject(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.CloneDraggedObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsDropable(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.IsDropable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsDropable(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.IsDropable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnElementDropped(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.OnElementDropped);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnElementDropped(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler v;
			checkType(l,2,out v);
			self.OnElementDropped=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnElementGrabbed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.OnElementGrabbed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnElementGrabbed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler v;
			checkType(l,2,out v);
			self.OnElementGrabbed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnElementRemoved(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.OnElementRemoved);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnElementRemoved(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			UnityEngine.UI.Extensions.ReorderableList.ReorderableListHandler v;
			checkType(l,2,out v);
			self.OnElementRemoved=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Content(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ReorderableList self=(UnityEngine.UI.Extensions.ReorderableList)checkSelf(l);
			pushValue(l,self.Content);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ReorderableList");
		addMember(l,TestReOrderableListTarget);
		addMember(l,"ContentLayout",get_ContentLayout,set_ContentLayout,true);
		addMember(l,"DraggableArea",get_DraggableArea,set_DraggableArea,true);
		addMember(l,"IsDraggable",get_IsDraggable,set_IsDraggable,true);
		addMember(l,"CloneDraggedObject",get_CloneDraggedObject,set_CloneDraggedObject,true);
		addMember(l,"IsDropable",get_IsDropable,set_IsDropable,true);
		addMember(l,"OnElementDropped",get_OnElementDropped,set_OnElementDropped,true);
		addMember(l,"OnElementGrabbed",get_OnElementGrabbed,set_OnElementGrabbed,true);
		addMember(l,"OnElementRemoved",get_OnElementRemoved,set_OnElementRemoved,true);
		addMember(l,"Content",get_Content,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ReorderableList),typeof(UnityEngine.MonoBehaviour));
	}
}
