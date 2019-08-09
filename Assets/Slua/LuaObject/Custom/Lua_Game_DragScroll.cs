using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_DragScroll : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int registDragStart(IntPtr l) {
		try {
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
			SLua.LuaFunction a1;
			checkType(l,2,out a1);
			self.registDragStart(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int registDragEnd(IntPtr l) {
		try {
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
			SLua.LuaFunction a1;
			checkType(l,2,out a1);
			self.registDragEnd(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
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
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
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
	static public int get_isDrag(IntPtr l) {
		try {
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
			pushValue(l,self.isDrag);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isDrag(IntPtr l) {
		try {
			Game.DragScroll self=(Game.DragScroll)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isDrag=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.DragScroll");
		addMember(l,registDragStart);
		addMember(l,registDragEnd);
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,"isDrag",get_isDrag,set_isDrag,true);
		createTypeMetatable(l,null, typeof(Game.DragScroll),typeof(UnityEngine.MonoBehaviour));
	}
}
