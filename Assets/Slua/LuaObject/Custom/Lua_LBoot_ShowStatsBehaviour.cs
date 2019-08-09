using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LBoot_ShowStatsBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_f_UpdateInterval(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.f_UpdateInterval);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_f_UpdateInterval(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.f_UpdateInterval=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Rect(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.Rect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Rect(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			UnityEngine.Rect v;
			checkValueType(l,2,out v);
			self.Rect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ShowDetailed(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.ShowDetailed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ShowDetailed(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ShowDetailed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UpdateDetailed(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.UpdateDetailed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UpdateDetailed(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.UpdateDetailed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_CustomStats(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.CustomStats);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_CustomStats(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.CustomStats=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Image(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
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
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.Image=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ImageRect(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.ImageRect);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ImageRect(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			UnityEngine.Rect v;
			checkValueType(l,2,out v);
			self.ImageRect=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Fps(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.Fps);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Tris(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.Tris);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Verts(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.Verts);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MemUsage(IntPtr l) {
		try {
			LBoot.ShowStatsBehaviour self=(LBoot.ShowStatsBehaviour)checkSelf(l);
			pushValue(l,self.MemUsage);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LBoot.ShowStatsBehaviour");
		addMember(l,"f_UpdateInterval",get_f_UpdateInterval,set_f_UpdateInterval,true);
		addMember(l,"Rect",get_Rect,set_Rect,true);
		addMember(l,"ShowDetailed",get_ShowDetailed,set_ShowDetailed,true);
		addMember(l,"UpdateDetailed",get_UpdateDetailed,set_UpdateDetailed,true);
		addMember(l,"CustomStats",get_CustomStats,set_CustomStats,true);
		addMember(l,"Image",get_Image,set_Image,true);
		addMember(l,"ImageRect",get_ImageRect,set_ImageRect,true);
		addMember(l,"Fps",get_Fps,null,true);
		addMember(l,"Tris",get_Tris,null,true);
		addMember(l,"Verts",get_Verts,null,true);
		addMember(l,"MemUsage",get_MemUsage,null,true);
		createTypeMetatable(l,null, typeof(LBoot.ShowStatsBehaviour),typeof(UnityEngine.MonoBehaviour));
	}
}
