using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_QuaternionExt : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Normalized_s(IntPtr l) {
		try {
			UnityEngine.Quaternion a1;
			checkType(l,1,out a1);
			var ret=QuaternionExt.Normalized(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"QuaternionExt");
		addMember(l,Normalized_s);
		createTypeMetatable(l,null, typeof(QuaternionExt));
	}
}
