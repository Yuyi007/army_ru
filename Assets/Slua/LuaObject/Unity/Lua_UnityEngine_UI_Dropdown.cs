using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Dropdown : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RefreshShownValue(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.RefreshShownValue();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddOptions(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.Sprite>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Sprite> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(List<System.String>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<System.String> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.UI.Dropdown.OptionData>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearOptions(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.ClearOptions();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerClick(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerClick(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSubmit(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnCancel(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnCancel(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Show(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.Show();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Hide(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.Hide();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_template(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.template);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_template(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.template=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_captionText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.captionText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_captionText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.captionText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_captionImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.captionImage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_captionImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.captionImage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.itemText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.itemText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.itemImage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.itemImage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_options(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.options);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_options(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			List<UnityEngine.UI.Dropdown.OptionData> v;
			checkType(l,2,out v);
			self.options=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.onValueChanged);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Dropdown.DropdownEvent v;
			checkType(l,2,out v);
			self.onValueChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_value(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,self.value);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_value(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.value=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Dropdown");
		addMember(l,RefreshShownValue);
		addMember(l,AddOptions);
		addMember(l,ClearOptions);
		addMember(l,OnPointerClick);
		addMember(l,OnSubmit);
		addMember(l,OnCancel);
		addMember(l,Show);
		addMember(l,Hide);
		addMember(l,"template",get_template,set_template,true);
		addMember(l,"captionText",get_captionText,set_captionText,true);
		addMember(l,"captionImage",get_captionImage,set_captionImage,true);
		addMember(l,"itemText",get_itemText,set_itemText,true);
		addMember(l,"itemImage",get_itemImage,set_itemImage,true);
		addMember(l,"options",get_options,set_options,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		addMember(l,"value",get_value,set_value,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Dropdown),typeof(UnityEngine.UI.Selectable));
	}
}
