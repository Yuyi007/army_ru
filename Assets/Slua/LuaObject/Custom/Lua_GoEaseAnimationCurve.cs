using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoEaseAnimationCurve : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EaseCurve_s(IntPtr l) {
		try {
			GoTween a1;
			checkType(l,1,out a1);
			var ret=GoEaseAnimationCurve.EaseCurve(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoEaseAnimationCurve");
		addMember(l,EaseCurve_s);
		createTypeMetatable(l,null, typeof(GoEaseAnimationCurve));
	}
}
