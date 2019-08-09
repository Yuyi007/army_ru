using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_UIRadar : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.UIRadar o;
			o=new Game.UIRadar();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setVertices(IntPtr l) {
		try {
			Game.UIRadar self=(Game.UIRadar)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.setVertices(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int apply(IntPtr l) {
		try {
			Game.UIRadar self=(Game.UIRadar)checkSelf(l);
			self.apply();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pos(IntPtr l) {
		try {
			Game.UIRadar self=(Game.UIRadar)checkSelf(l);
			pushValue(l,self.pos);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pos(IntPtr l) {
		try {
			Game.UIRadar self=(Game.UIRadar)checkSelf(l);
			UnityEngine.Vector3[] v;
			checkType(l,2,out v);
			self.pos=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.UIRadar");
		addMember(l,setVertices);
		addMember(l,apply);
		addMember(l,"pos",get_pos,set_pos,true);
		createTypeMetatable(l,constructor, typeof(Game.UIRadar),typeof(UnityEngine.UI.Graphic));
	}
}
