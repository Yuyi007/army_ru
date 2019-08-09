using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_AccordionElement : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.AccordionElement self=(UnityEngine.UI.Extensions.AccordionElement)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.OnValueChanged(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.AccordionElement");
		addMember(l,OnValueChanged);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.AccordionElement),typeof(UnityEngine.UI.Toggle));
	}
}
