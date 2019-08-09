using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_LinkObject : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.LinkObject o;
			o=new UnityEngine.UI.LinkObject();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_action(IntPtr l) {
		try {
			UnityEngine.UI.LinkObject self=(UnityEngine.UI.LinkObject)checkSelf(l);
			System.Action<System.String> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.action=v;
			else if(op==1) self.action+=v;
			else if(op==2) self.action-=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.LinkObject");
		addMember(l,"action",null,set_action,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.LinkObject));
	}
}
