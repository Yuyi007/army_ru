using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Skidmarks : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddSkidMark(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Int32 a4;
			checkType(l,5,out a4);
			var ret=self.AddSkidMark(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MAX_MARKS(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			pushValue(l,self.MAX_MARKS);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MAX_MARKS(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.MAX_MARKS=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MARK_WIDTH(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			pushValue(l,self.MARK_WIDTH);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MARK_WIDTH(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MARK_WIDTH=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_GROUND_OFFSET(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			pushValue(l,self.GROUND_OFFSET);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GROUND_OFFSET(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.GROUND_OFFSET=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SHOW_MARK_TIME(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			pushValue(l,self.SHOW_MARK_TIME);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_SHOW_MARK_TIME(IntPtr l) {
		try {
			Skidmarks self=(Skidmarks)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.SHOW_MARK_TIME=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Skidmarks");
		addMember(l,AddSkidMark);
		addMember(l,"MAX_MARKS",get_MAX_MARKS,set_MAX_MARKS,true);
		addMember(l,"MARK_WIDTH",get_MARK_WIDTH,set_MARK_WIDTH,true);
		addMember(l,"GROUND_OFFSET",get_GROUND_OFFSET,set_GROUND_OFFSET,true);
		addMember(l,"SHOW_MARK_TIME",get_SHOW_MARK_TIME,set_SHOW_MARK_TIME,true);
		createTypeMetatable(l,null, typeof(Skidmarks),typeof(UnityEngine.MonoBehaviour));
	}
}
