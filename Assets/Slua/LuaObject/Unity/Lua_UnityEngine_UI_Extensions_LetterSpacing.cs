using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_LetterSpacing : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ModifyMesh(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.LetterSpacing self=(UnityEngine.UI.Extensions.LetterSpacing)checkSelf(l);
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
	static public int get_spacing(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.LetterSpacing self=(UnityEngine.UI.Extensions.LetterSpacing)checkSelf(l);
			pushValue(l,self.spacing);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spacing(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.LetterSpacing self=(UnityEngine.UI.Extensions.LetterSpacing)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spacing=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.LetterSpacing");
		addMember(l,ModifyMesh);
		addMember(l,"spacing",get_spacing,set_spacing,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Extensions.LetterSpacing),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
