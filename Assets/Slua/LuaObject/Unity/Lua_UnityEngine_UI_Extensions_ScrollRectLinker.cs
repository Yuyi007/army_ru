using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ScrollRectLinker : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clamp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectLinker self=(UnityEngine.UI.Extensions.ScrollRectLinker)checkSelf(l);
			pushValue(l,self.clamp);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clamp(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ScrollRectLinker self=(UnityEngine.UI.Extensions.ScrollRectLinker)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.clamp=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ScrollRectLinker");
		addMember(l,"clamp",get_clamp,set_clamp,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.ScrollRectLinker),typeof(UnityEngine.MonoBehaviour));
	}
}
