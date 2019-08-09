using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_UGUIText_Extend : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetExactCharacterIndex_s(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.UGUIText_Extend.GetExactCharacterIndex(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetVertexHelperUIVertex_s(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.UGUIText_Extend.GetVertexHelperUIVertex(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrintText_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Collections.Generic.List<System.Int32> a2;
			checkType(l,2,out a2);
			System.Collections.Generic.List<UnityEngine.UI.TextSegmentFlag> a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.UI.UGUIText_Extend.PrintText(ref a1,a2,a3);
			pushValue(l,ret);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ParseSymbol_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.UGUIText_Extend.ParseSymbol(ref a1,ref a2);
			pushValue(l,ret);
			pushValue(l,a1);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ParseSegmentFlag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.UI.TextSegmentFlag a3;
			checkValueType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			System.Text.StringBuilder a5;
			checkType(l,5,out a5);
			var ret=UnityEngine.UI.UGUIText_Extend.ParseSegmentFlag(ref a1,ref a2,ref a3,ref a4,ref a5);
			pushValue(l,ret);
			pushValue(l,a1);
			pushValue(l,a2);
			pushValue(l,a3);
			pushValue(l,a4);
			pushValue(l,a5);
			return 6;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessLinkObjectText_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.UI.UGUIText_Extend.ProcessLinkObjectText(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessURLLink_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.UI.UGUIText_Extend.ProcessURLLink(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_linkAction(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.UGUIText_Extend.linkAction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_segmentFlag(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.UGUIText_Extend.segmentFlag);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.UGUIText_Extend");
		addMember(l,GetExactCharacterIndex_s);
		addMember(l,GetVertexHelperUIVertex_s);
		addMember(l,PrintText_s);
		addMember(l,ParseSymbol_s);
		addMember(l,ParseSegmentFlag_s);
		addMember(l,ProcessLinkObjectText_s);
		addMember(l,ProcessURLLink_s);
		addMember(l,"linkAction",get_linkAction,null,false);
		addMember(l,"segmentFlag",get_segmentFlag,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.UGUIText_Extend));
	}
}
