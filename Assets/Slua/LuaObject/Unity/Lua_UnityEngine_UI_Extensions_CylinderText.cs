using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_CylinderText : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CylinderText o;
			o=new UnityEngine.UI.Extensions.CylinderText();
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
			UnityEngine.UI.Extensions.CylinderText self=(UnityEngine.UI.Extensions.CylinderText)checkSelf(l);
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
	static public int get_radius(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CylinderText self=(UnityEngine.UI.Extensions.CylinderText)checkSelf(l);
			pushValue(l,self.radius);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_radius(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.CylinderText self=(UnityEngine.UI.Extensions.CylinderText)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.radius=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.CylinderText");
		addMember(l,ModifyMesh);
		addMember(l,"radius",get_radius,set_radius,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.CylinderText),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
