using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIGradient : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UIGradient o;
			o=new UIGradient();
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
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.UI.VertexHelper))){
				UIGradient self=(UIGradient)checkSelf(l);
				UnityEngine.UI.VertexHelper a1;
				checkType(l,2,out a1);
				self.ModifyMesh(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Mesh))){
				UIGradient self=(UIGradient)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				self.ModifyMesh(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIGradient");
		addMember(l,ModifyMesh);
		createTypeMetatable(l,constructor, typeof(UIGradient),typeof(UnityEngine.UI.BaseMeshEffect));
	}
}
