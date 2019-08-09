using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Tweens_FloatTween_FloatTweenCallback : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween.FloatTweenCallback o;
			o=new UnityEngine.UI.Extensions.Tweens.FloatTween.FloatTweenCallback();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		LuaUnityEvent_float.reg(l);
		getTypeTable(l,"UnityEngine.UI.Extensions.Tweens.FloatTween.FloatTweenCallback");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.Tweens.FloatTween.FloatTweenCallback),typeof(LuaUnityEvent_float));
	}
}
