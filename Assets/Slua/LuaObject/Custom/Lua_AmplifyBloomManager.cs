using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AmplifyBloomManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnOff(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			self.OnOff();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Threshold(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.Threshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Threshold(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.Threshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BloomEnable(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.BloomEnable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BloomEnable(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.BloomEnable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Realistic(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.Realistic);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Realistic(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.Realistic=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_HighPrecision(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.HighPrecision);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_HighPrecision(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.HighPrecision=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LensDirt(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.LensDirt);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LensDirt(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.LensDirt=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lensStarburst(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.lensStarburst);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lensStarburst(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.lensStarburst=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_BokehFilter(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.BokehFilter);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_BokehFilter(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.BokehFilter=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LensFlare(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.LensFlare);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LensFlare(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.LensFlare=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LensGlare(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			pushValue(l,self.LensGlare);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LensGlare(IntPtr l) {
		try {
			AmplifyBloomManager self=(AmplifyBloomManager)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.LensGlare=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AmplifyBloomManager");
		addMember(l,OnOff);
		addMember(l,"Threshold",get_Threshold,set_Threshold,true);
		addMember(l,"BloomEnable",get_BloomEnable,set_BloomEnable,true);
		addMember(l,"Realistic",get_Realistic,set_Realistic,true);
		addMember(l,"HighPrecision",get_HighPrecision,set_HighPrecision,true);
		addMember(l,"LensDirt",get_LensDirt,set_LensDirt,true);
		addMember(l,"lensStarburst",get_lensStarburst,set_lensStarburst,true);
		addMember(l,"BokehFilter",get_BokehFilter,set_BokehFilter,true);
		addMember(l,"LensFlare",get_LensFlare,set_LensFlare,true);
		addMember(l,"LensGlare",get_LensGlare,set_LensGlare,true);
		createTypeMetatable(l,null, typeof(AmplifyBloomManager),typeof(UnityEngine.MonoBehaviour));
	}
}
