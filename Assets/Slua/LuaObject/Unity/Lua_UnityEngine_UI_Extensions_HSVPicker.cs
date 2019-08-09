using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_HSVPicker : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AssignColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.Color a1;
			checkType(l,2,out a1);
			self.AssignColor(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MoveCursor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			var ret=self.MoveCursor(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.GetColor(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MovePointer(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			var ret=self.MovePointer(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateInputs(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			self.UpdateInputs();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hexrgb(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.hexrgb);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hexrgb(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Extensions.HexRGB v;
			checkType(l,2,out v);
			self.hexrgb=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.currentColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentColor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.currentColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.colorImage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.colorImage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pointer(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.pointer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pointer(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.pointer=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cursor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.cursor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cursor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.cursor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hsvSlider(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.hsvSlider);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hsvSlider(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.RawImage v;
			checkType(l,2,out v);
			self.hsvSlider=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hsvImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.hsvImage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hsvImage(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.RawImage v;
			checkType(l,2,out v);
			self.hsvImage=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderR);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderR(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Slider v;
			checkType(l,2,out v);
			self.sliderR=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderG(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderG);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderG(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Slider v;
			checkType(l,2,out v);
			self.sliderG=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderB(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderB);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderB(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Slider v;
			checkType(l,2,out v);
			self.sliderB=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderRText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderRText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderRText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.sliderRText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderGText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderGText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderGText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.sliderGText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sliderBText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.sliderBText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sliderBText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.sliderBText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pointerPos(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.pointerPos);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pointerPos(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.pointerPos=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cursorX(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.cursorX);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cursorX(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.cursorX=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cursorY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			pushValue(l,self.cursorY);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cursorY(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.cursorY=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
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
			UnityEngine.UI.Extensions.HSVPicker self=(UnityEngine.UI.Extensions.HSVPicker)checkSelf(l);
			UnityEngine.UI.Extensions.HSVSliderEvent v;
			checkType(l,2,out v);
			self.onValueChanged=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.HSVPicker");
		addMember(l,AssignColor);
		addMember(l,MoveCursor);
		addMember(l,GetColor);
		addMember(l,MovePointer);
		addMember(l,UpdateInputs);
		addMember(l,"hexrgb",get_hexrgb,set_hexrgb,true);
		addMember(l,"currentColor",get_currentColor,set_currentColor,true);
		addMember(l,"colorImage",get_colorImage,set_colorImage,true);
		addMember(l,"pointer",get_pointer,set_pointer,true);
		addMember(l,"cursor",get_cursor,set_cursor,true);
		addMember(l,"hsvSlider",get_hsvSlider,set_hsvSlider,true);
		addMember(l,"hsvImage",get_hsvImage,set_hsvImage,true);
		addMember(l,"sliderR",get_sliderR,set_sliderR,true);
		addMember(l,"sliderG",get_sliderG,set_sliderG,true);
		addMember(l,"sliderB",get_sliderB,set_sliderB,true);
		addMember(l,"sliderRText",get_sliderRText,set_sliderRText,true);
		addMember(l,"sliderGText",get_sliderGText,set_sliderGText,true);
		addMember(l,"sliderBText",get_sliderBText,set_sliderBText,true);
		addMember(l,"pointerPos",get_pointerPos,set_pointerPos,true);
		addMember(l,"cursorX",get_cursorX,set_cursorX,true);
		addMember(l,"cursorY",get_cursorY,set_cursorY,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.HSVPicker),typeof(UnityEngine.MonoBehaviour));
	}
}
