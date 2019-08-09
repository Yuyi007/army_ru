using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_DropDownListItem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem o;
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			UnityEngine.Sprite a3;
			checkType(l,4,out a3);
			System.Boolean a4;
			checkType(l,5,out a4);
			System.Action a5;
			LuaDelegation.checkDelegate(l,6,out a5);
			o=new UnityEngine.UI.Extensions.DropDownListItem(a1,a2,a3,a4,a5);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnSelect(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			System.Action v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.OnSelect=v;
			else if(op==1) self.OnSelect+=v;
			else if(op==2) self.OnSelect-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Caption(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			pushValue(l,self.Caption);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Caption(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.Caption=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Image(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			pushValue(l,self.Image);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Image(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.Image=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsDisabled(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			pushValue(l,self.IsDisabled);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsDisabled(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.IsDisabled=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ID(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			pushValue(l,self.ID);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ID(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.DropDownListItem self=(UnityEngine.UI.Extensions.DropDownListItem)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.ID=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.DropDownListItem");
		addMember(l,"OnSelect",null,set_OnSelect,true);
		addMember(l,"Caption",get_Caption,set_Caption,true);
		addMember(l,"Image",get_Image,set_Image,true);
		addMember(l,"IsDisabled",get_IsDisabled,set_IsDisabled,true);
		addMember(l,"ID",get_ID,set_ID,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.DropDownListItem));
	}
}
