using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_BoundTooltipItem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShowTooltip(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.ShowTooltip(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideTooltip(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			self.HideTooltip();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TooltipText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			pushValue(l,self.TooltipText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_TooltipText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.TooltipText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ToolTipOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			pushValue(l,self.ToolTipOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ToolTipOffset(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.ToolTipOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsActive(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.BoundTooltipItem self=(UnityEngine.UI.Extensions.BoundTooltipItem)checkSelf(l);
			pushValue(l,self.IsActive);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Instance(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Extensions.BoundTooltipItem.Instance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.BoundTooltipItem");
		addMember(l,ShowTooltip);
		addMember(l,HideTooltip);
		addMember(l,"TooltipText",get_TooltipText,set_TooltipText,true);
		addMember(l,"ToolTipOffset",get_ToolTipOffset,set_ToolTipOffset,true);
		addMember(l,"IsActive",get_IsActive,null,true);
		addMember(l,"Instance",get_Instance,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.BoundTooltipItem),typeof(UnityEngine.MonoBehaviour));
	}
}
