using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIVerticalScroller : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Awake(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			self.Awake();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Start(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			self.Start();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Update(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			self.Update();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetResults(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			var ret=self.GetResults();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SnapToElement(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.SnapToElement(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollUp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			self.ScrollUp();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScrollDown(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			self.ScrollDown();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__scrollingPanel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self._scrollingPanel);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__scrollingPanel(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self._scrollingPanel=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__arrayOfElements(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self._arrayOfElements);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__arrayOfElements(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.GameObject[] v;
			checkType(l,2,out v);
			self._arrayOfElements=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__center(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self._center);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__center(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self._center=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_StartingIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self.StartingIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_StartingIndex(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.StartingIndex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScrollUpButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self.ScrollUpButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ScrollUpButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.ScrollUpButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ScrollDownButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self.ScrollDownButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ScrollDownButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.ScrollDownButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ButtonClicked(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			pushValue(l,self.ButtonClicked);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ButtonClicked(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIVerticalScroller self=(UnityEngine.UI.Extensions.UIVerticalScroller)checkSelf(l);
			UnityEngine.Events.UnityEvent<System.Int32> v;
			checkType(l,2,out v);
			self.ButtonClicked=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIVerticalScroller");
		addMember(l,Awake);
		addMember(l,Start);
		addMember(l,Update);
		addMember(l,GetResults);
		addMember(l,SnapToElement);
		addMember(l,ScrollUp);
		addMember(l,ScrollDown);
		addMember(l,"_scrollingPanel",get__scrollingPanel,set__scrollingPanel,true);
		addMember(l,"_arrayOfElements",get__arrayOfElements,set__arrayOfElements,true);
		addMember(l,"_center",get__center,set__center,true);
		addMember(l,"StartingIndex",get_StartingIndex,set_StartingIndex,true);
		addMember(l,"ScrollUpButton",get_ScrollUpButton,set_ScrollUpButton,true);
		addMember(l,"ScrollDownButton",get_ScrollDownButton,set_ScrollDownButton,true);
		addMember(l,"ButtonClicked",get_ButtonClicked,set_ButtonClicked,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIVerticalScroller),typeof(UnityEngine.MonoBehaviour));
	}
}
