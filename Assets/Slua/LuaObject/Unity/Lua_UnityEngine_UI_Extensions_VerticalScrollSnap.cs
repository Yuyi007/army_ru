using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_VerticalScrollSnap : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int NextScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			self.NextScreen();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PreviousScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			self.PreviousScreen();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GoToScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.GoToScreen(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CurrentScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			var ret=self.CurrentScreen();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DistributePages(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			self.DistributePages();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddChild(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.AddChild(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveChild(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.GameObject a2;
			self.RemoveChild(a1,out a2);
			pushValue(l,a2);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Pagination(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.Pagination);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Pagination(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.Pagination=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_NextButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.NextButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_NextButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.NextButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PrevButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.PrevButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_PrevButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.PrevButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transitionSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.transitionSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_transitionSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.transitionSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UseFastSwipe(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.UseFastSwipe);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UseFastSwipe(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.UseFastSwipe=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FastSwipeThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.FastSwipeThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FastSwipeThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.FastSwipeThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_StartingScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.StartingScreen);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_StartingScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.StartingScreen=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PageStep(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.PageStep);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_PageStep(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.PageStep=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CurrentPage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.VerticalScrollSnap self=(UnityEngine.UI.Extensions.VerticalScrollSnap)checkSelf(l);
			pushValue(l,self.CurrentPage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.VerticalScrollSnap");
		addMember(l,NextScreen);
		addMember(l,PreviousScreen);
		addMember(l,GoToScreen);
		addMember(l,CurrentScreen);
		addMember(l,DistributePages);
		addMember(l,AddChild);
		addMember(l,RemoveChild);
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,OnDrag);
		addMember(l,"Pagination",get_Pagination,set_Pagination,true);
		addMember(l,"NextButton",get_NextButton,set_NextButton,true);
		addMember(l,"PrevButton",get_PrevButton,set_PrevButton,true);
		addMember(l,"transitionSpeed",get_transitionSpeed,set_transitionSpeed,true);
		addMember(l,"UseFastSwipe",get_UseFastSwipe,set_UseFastSwipe,true);
		addMember(l,"FastSwipeThreshold",get_FastSwipeThreshold,set_FastSwipeThreshold,true);
		addMember(l,"StartingScreen",get_StartingScreen,set_StartingScreen,true);
		addMember(l,"PageStep",get_PageStep,set_PageStep,true);
		addMember(l,"CurrentPage",get_CurrentPage,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.VerticalScrollSnap),typeof(UnityEngine.MonoBehaviour));
	}
}
