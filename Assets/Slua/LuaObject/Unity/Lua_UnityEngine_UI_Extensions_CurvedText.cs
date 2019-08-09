using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_CurvedText : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText o;
			o=new UnityEngine.UI.Extensions.CurvedText();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ModifyMesh(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText self=(UnityEngine.UI.Extensions.CurvedText)checkSelf(l);
			UnityEngine.UI.VertexHelper a1;
			checkType(l,2,out a1);
			self.ModifyMesh(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveForText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText self=(UnityEngine.UI.Extensions.CurvedText)checkSelf(l);
			pushValue(l,self.curveForText);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveForText(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText self=(UnityEngine.UI.Extensions.CurvedText)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.curveForText=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText self=(UnityEngine.UI.Extensions.CurvedText)checkSelf(l);
			pushValue(l,self.curveMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CurvedText self=(UnityEngine.UI.Extensions.CurvedText)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.curveMultiplier=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.CurvedText");
		addMember(l,ModifyMesh);
		addMember(l,"curveForText",get_curveForText,set_curveForText,true);
		addMember(l,"curveMultiplier",get_curveMultiplier,set_curveMultiplier,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.CurvedText),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
