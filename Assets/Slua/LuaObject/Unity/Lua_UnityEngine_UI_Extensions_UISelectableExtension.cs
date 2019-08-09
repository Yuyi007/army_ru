using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UISelectableExtension : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestClicked(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			self.TestClicked();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestPressed(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			self.TestPressed();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestReleased(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			self.TestReleased();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestHold(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			self.TestHold();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnButtonPress(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			pushValue(l,self.OnButtonPress);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnButtonPress(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent v;
			checkType(l,2,out v);
			self.OnButtonPress=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnButtonRelease(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			pushValue(l,self.OnButtonRelease);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnButtonRelease(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent v;
			checkType(l,2,out v);
			self.OnButtonRelease=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_OnButtonHeld(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			pushValue(l,self.OnButtonHeld);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnButtonHeld(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UISelectableExtension self=(UnityEngine.UI.Extensions.UISelectableExtension)checkSelf(l);
			UnityEngine.UI.Extensions.UISelectableExtension.UIButtonEvent v;
			checkType(l,2,out v);
			self.OnButtonHeld=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UISelectableExtension");
		addMember(l,TestClicked);
		addMember(l,TestPressed);
		addMember(l,TestReleased);
		addMember(l,TestHold);
		addMember(l,"OnButtonPress",get_OnButtonPress,set_OnButtonPress,true);
		addMember(l,"OnButtonRelease",get_OnButtonRelease,set_OnButtonRelease,true);
		addMember(l,"OnButtonHeld",get_OnButtonHeld,set_OnButtonHeld,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.UISelectableExtension),typeof(UnityEngine.MonoBehaviour));
	}
}
