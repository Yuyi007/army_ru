using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIPrimitiveBase : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase o;
			o=new UnityEngine.UI.Extensions.UIPrimitiveBase();
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
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CalculateLayoutInputVertical(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			self.CalculateLayoutInputVertical();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.IsRaycastLocationValid(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.sprite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.sprite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_overrideSprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.overrideSprite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_overrideSprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.overrideSprite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventAlphaThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.eventAlphaThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_eventAlphaThreshold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.eventAlphaThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainTexture(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.mainTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.pixelsPerUnit);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.minWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_preferredWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.preferredWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flexibleWidth(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.flexibleWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minHeight(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.minHeight);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_preferredHeight(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.preferredHeight);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flexibleHeight(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.flexibleHeight);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_layoutPriority(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIPrimitiveBase self=(UnityEngine.UI.Extensions.UIPrimitiveBase)checkSelf(l);
			pushValue(l,self.layoutPriority);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIPrimitiveBase");
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,IsRaycastLocationValid);
		addMember(l,"sprite",get_sprite,set_sprite,true);
		addMember(l,"overrideSprite",get_overrideSprite,set_overrideSprite,true);
		addMember(l,"eventAlphaThreshold",get_eventAlphaThreshold,set_eventAlphaThreshold,true);
		addMember(l,"mainTexture",get_mainTexture,null,true);
		addMember(l,"pixelsPerUnit",get_pixelsPerUnit,null,true);
		addMember(l,"minWidth",get_minWidth,null,true);
		addMember(l,"preferredWidth",get_preferredWidth,null,true);
		addMember(l,"flexibleWidth",get_flexibleWidth,null,true);
		addMember(l,"minHeight",get_minHeight,null,true);
		addMember(l,"preferredHeight",get_preferredHeight,null,true);
		addMember(l,"flexibleHeight",get_flexibleHeight,null,true);
		addMember(l,"layoutPriority",get_layoutPriority,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UIPrimitiveBase),typeof(UnityEngine.UI.MaskableGraphic));
	}
}
