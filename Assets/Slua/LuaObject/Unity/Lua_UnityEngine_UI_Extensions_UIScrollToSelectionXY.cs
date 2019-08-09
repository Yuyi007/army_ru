using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIScrollToSelectionXY : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrollSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIScrollToSelectionXY self=(UnityEngine.UI.Extensions.UIScrollToSelectionXY)checkSelf(l);
			pushValue(l,self.scrollSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrollSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIScrollToSelectionXY self=(UnityEngine.UI.Extensions.UIScrollToSelectionXY)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.scrollSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIScrollToSelectionXY");
		addMember(l,"scrollSpeed",get_scrollSpeed,set_scrollSpeed,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UIScrollToSelectionXY),typeof(UnityEngine.MonoBehaviour));
	}
}
