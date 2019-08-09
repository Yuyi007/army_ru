using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Dropdown_OptionData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.UI.Dropdown.OptionData o;
			if(argc==1){
				o=new UnityEngine.UI.Dropdown.OptionData();
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				System.String a1;
				checkType(l,2,out a1);
				o=new UnityEngine.UI.Dropdown.OptionData(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Sprite))){
				UnityEngine.Sprite a1;
				checkType(l,2,out a1);
				o=new UnityEngine.UI.Dropdown.OptionData(a1);
				pushValue(l,o);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.Sprite a2;
				checkType(l,3,out a2);
				o=new UnityEngine.UI.Dropdown.OptionData(a1,a2);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionData self=(UnityEngine.UI.Dropdown.OptionData)checkSelf(l);
			pushValue(l,self.text);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_text(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionData self=(UnityEngine.UI.Dropdown.OptionData)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.text=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_image(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionData self=(UnityEngine.UI.Dropdown.OptionData)checkSelf(l);
			pushValue(l,self.image);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_image(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionData self=(UnityEngine.UI.Dropdown.OptionData)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.image=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Dropdown.OptionData");
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"image",get_image,set_image,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Dropdown.OptionData));
	}
}
