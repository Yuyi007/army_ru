using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollSnap : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FirstScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			self.FirstScreen();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetItemSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetItemSize(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateListItemsSize(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			self.UpdateListItemsSize();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateListItemPositions(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			self.UpdateListItemPositions();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetPage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			self.ResetPage();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int NextScreen(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
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
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			self.PreviousScreen();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CurrentPage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			var ret=self.CurrentPage();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ChangePage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.ChangePage(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
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
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
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
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
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
	static public int set_onPageChange(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			UnityEngine.UI.Extensions.ScrollSnap.PageSnapChange v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onPageChange=v;
			else if(op==1) self.onPageChange+=v;
			else if(op==2) self.onPageChange-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_direction(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushEnum(l,(int)self.direction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_direction(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			UnityEngine.UI.Extensions.ScrollSnap.ScrollDirection v;
			checkEnum(l,2,out v);
			self.direction=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_nextButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.nextButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_nextButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			UnityEngine.UI.Button v;
			checkType(l,2,out v);
			self.nextButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_prevButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.prevButton);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_prevButton(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			UnityEngine.UI.Button v;
			checkType(l,2,out v);
			self.prevButton=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemsVisibleAtOnce(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.itemsVisibleAtOnce);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemsVisibleAtOnce(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.itemsVisibleAtOnce=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoLayoutItems(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.autoLayoutItems);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoLayoutItems(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.autoLayoutItems=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_linkScrolbarSteps(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.linkScrolbarSteps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_linkScrolbarSteps(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.linkScrolbarSteps=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_linkScrolrectScrollSensitivity(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.linkScrolrectScrollSensitivity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_linkScrolrectScrollSensitivity(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.linkScrolrectScrollSensitivity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useFastSwipe(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.useFastSwipe);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useFastSwipe(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useFastSwipe=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fastSwipeThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.fastSwipeThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fastSwipeThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.fastSwipeThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_StartingPage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			pushValue(l,self.StartingPage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_StartingPage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollSnap self=(UnityEngine.UI.Extensions.ScrollSnap)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.StartingPage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ScrollSnap");
		addMember(l,FirstScreen);
		addMember(l,SetItemSize);
		addMember(l,UpdateListItemsSize);
		addMember(l,UpdateListItemPositions);
		addMember(l,ResetPage);
		addMember(l,NextScreen);
		addMember(l,PreviousScreen);
		addMember(l,CurrentPage);
		addMember(l,ChangePage);
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,OnDrag);
		addMember(l,"onPageChange",null,set_onPageChange,true);
		addMember(l,"direction",get_direction,set_direction,true);
		addMember(l,"nextButton",get_nextButton,set_nextButton,true);
		addMember(l,"prevButton",get_prevButton,set_prevButton,true);
		addMember(l,"itemsVisibleAtOnce",get_itemsVisibleAtOnce,set_itemsVisibleAtOnce,true);
		addMember(l,"autoLayoutItems",get_autoLayoutItems,set_autoLayoutItems,true);
		addMember(l,"linkScrolbarSteps",get_linkScrolbarSteps,set_linkScrolbarSteps,true);
		addMember(l,"linkScrolrectScrollSensitivity",get_linkScrolrectScrollSensitivity,set_linkScrolrectScrollSensitivity,true);
		addMember(l,"useFastSwipe",get_useFastSwipe,set_useFastSwipe,true);
		addMember(l,"fastSwipeThreshold",get_fastSwipeThreshold,set_fastSwipeThreshold,true);
		addMember(l,"StartingPage",get_StartingPage,set_StartingPage,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ScrollSnap),typeof(UnityEngine.MonoBehaviour));
	}
}
