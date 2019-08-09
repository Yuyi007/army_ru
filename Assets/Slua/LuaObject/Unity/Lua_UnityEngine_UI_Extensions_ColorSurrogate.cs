using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_ColorSurrogate : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorSurrogate o;
			o=new UnityEngine.UI.Extensions.ColorSurrogate();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetObjectData(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorSurrogate self=(UnityEngine.UI.Extensions.ColorSurrogate)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Runtime.Serialization.SerializationInfo a2;
			checkType(l,3,out a2);
			System.Runtime.Serialization.StreamingContext a3;
			checkValueType(l,4,out a3);
			self.GetObjectData(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetObjectData(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.ColorSurrogate self=(UnityEngine.UI.Extensions.ColorSurrogate)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Runtime.Serialization.SerializationInfo a2;
			checkType(l,3,out a2);
			System.Runtime.Serialization.StreamingContext a3;
			checkValueType(l,4,out a3);
			System.Runtime.Serialization.ISurrogateSelector a4;
			checkType(l,5,out a4);
			var ret=self.SetObjectData(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.ColorSurrogate");
		addMember(l,GetObjectData);
		addMember(l,SetObjectData);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.ColorSurrogate));
	}
}
