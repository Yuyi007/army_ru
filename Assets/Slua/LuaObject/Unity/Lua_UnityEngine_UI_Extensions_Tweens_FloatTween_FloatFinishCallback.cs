using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_Tweens_FloatTween_FloatFinishCallback : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.Tweens.FloatTween.FloatFinishCallback o;
			o=new UnityEngine.UI.Extensions.Tweens.FloatTween.FloatFinishCallback();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.Tweens.FloatTween.FloatFinishCallback");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.Tweens.FloatTween.FloatFinishCallback),typeof(UnityEngine.Events.UnityEvent));
	}
}
