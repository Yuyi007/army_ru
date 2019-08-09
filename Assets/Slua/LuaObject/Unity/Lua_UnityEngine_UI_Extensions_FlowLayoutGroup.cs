using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_FlowLayoutGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup o;
			o=new UnityEngine.UI.Extensions.FlowLayoutGroup();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			self.SetLayoutHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			self.SetLayoutVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateLayoutInputVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			self.CalculateLayoutInputVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayout(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.SetLayout(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetGreatestMinimumChildWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			var ret=self.GetGreatestMinimumChildWidth();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SpacingX(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			pushValue(l,self.SpacingX);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SpacingX(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.SpacingX=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SpacingY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			pushValue(l,self.SpacingY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SpacingY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.SpacingY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ExpandHorizontalSpacing(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			pushValue(l,self.ExpandHorizontalSpacing);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ExpandHorizontalSpacing(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ExpandHorizontalSpacing=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ChildForceExpandWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			pushValue(l,self.ChildForceExpandWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ChildForceExpandWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ChildForceExpandWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ChildForceExpandHeight(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			pushValue(l,self.ChildForceExpandHeight);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ChildForceExpandHeight(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.FlowLayoutGroup self=(UnityEngine.UI.Extensions.FlowLayoutGroup)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ChildForceExpandHeight=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.FlowLayoutGroup");
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,SetLayout);
		addMember(l,GetGreatestMinimumChildWidth);
		addMember(l,"SpacingX",get_SpacingX,set_SpacingX,true);
		addMember(l,"SpacingY",get_SpacingY,set_SpacingY,true);
		addMember(l,"ExpandHorizontalSpacing",get_ExpandHorizontalSpacing,set_ExpandHorizontalSpacing,true);
		addMember(l,"ChildForceExpandWidth",get_ChildForceExpandWidth,set_ChildForceExpandWidth,true);
		addMember(l,"ChildForceExpandHeight",get_ChildForceExpandHeight,set_ChildForceExpandHeight,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.FlowLayoutGroup),typeof(UnityEngine.UI.LayoutGroup));
	}
}
