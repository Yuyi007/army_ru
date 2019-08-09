using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_WaterCtrl : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DoRefresh(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			self.DoRefresh();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_watchGameObject(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self.watchGameObject);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_watchGameObject(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.watchGameObject=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__texScale(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._texScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__texScale(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self._texScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__texSpeed(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._texSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__texSpeed(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self._texSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__normalScale(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._normalScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__normalScale(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self._normalScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__waterColor(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._waterColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__waterColor(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self._waterColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__texIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._texIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__texIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self._texIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__reflectionIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._reflectionIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__reflectionIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self._reflectionIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__texDisturbIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._texDisturbIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__texDisturbIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self._texDisturbIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get__reflectionDisturbIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			pushValue(l,self._reflectionDisturbIntensity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set__reflectionDisturbIntensity(IntPtr l) {
		try {
			WaterCtrl self=(WaterCtrl)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self._reflectionDisturbIntensity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PbBlock(IntPtr l) {
		try {
			pushValue(l,WaterCtrl.PbBlock);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"WaterCtrl");
		addMember(l,DoRefresh);
		addMember(l,"watchGameObject",get_watchGameObject,set_watchGameObject,true);
		addMember(l,"_texScale",get__texScale,set__texScale,true);
		addMember(l,"_texSpeed",get__texSpeed,set__texSpeed,true);
		addMember(l,"_normalScale",get__normalScale,set__normalScale,true);
		addMember(l,"_waterColor",get__waterColor,set__waterColor,true);
		addMember(l,"_texIntensity",get__texIntensity,set__texIntensity,true);
		addMember(l,"_reflectionIntensity",get__reflectionIntensity,set__reflectionIntensity,true);
		addMember(l,"_texDisturbIntensity",get__texDisturbIntensity,set__texDisturbIntensity,true);
		addMember(l,"_reflectionDisturbIntensity",get__reflectionDisturbIntensity,set__reflectionDisturbIntensity,true);
		addMember(l,"PbBlock",get_PbBlock,null,false);
		createTypeMetatable(l,null, typeof(WaterCtrl),typeof(UnityEngine.MonoBehaviour));
	}
}
