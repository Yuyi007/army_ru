using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoSpline : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			GoSpline o;
			if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>),typeof(bool))){
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				o=new GoSpline(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]),typeof(bool))){
				UnityEngine.Vector3[] a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				o=new GoSpline(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(bool))){
				System.String a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				o=new GoSpline(a1,a2);
				pushValue(l,o);
				return 1;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getLastNode(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			var ret=self.getLastNode();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int buildPath(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			self.buildPath();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getPointOnPath(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.getPointOnPath(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int closePath(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			self.closePath();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int reverseNodes(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			self.reverseNodes();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int unreverseNodes(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			self.unreverseNodes();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int drawGizmos(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.drawGizmos(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int bytesToVector3List_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=GoSpline.bytesToVector3List(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int drawGizmos_s(IntPtr l) {
		try {
			UnityEngine.Vector3[] a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			GoSpline.drawGizmos(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentSegment(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			pushValue(l,self.currentSegment);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isClosed(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			pushValue(l,self.isClosed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_splineType(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			pushEnum(l,(int)self.splineType);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_nodes(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			pushValue(l,self.nodes);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pathLength(IntPtr l) {
		try {
			GoSpline self=(GoSpline)checkSelf(l);
			pushValue(l,self.pathLength);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GoSpline");
		addMember(l,getLastNode);
		addMember(l,buildPath);
		addMember(l,getPointOnPath);
		addMember(l,closePath);
		addMember(l,reverseNodes);
		addMember(l,unreverseNodes);
		addMember(l,drawGizmos);
		addMember(l,bytesToVector3List_s);
		addMember(l,drawGizmos_s);
		addMember(l,"currentSegment",get_currentSegment,null,true);
		addMember(l,"isClosed",get_isClosed,null,true);
		addMember(l,"splineType",get_splineType,null,true);
		addMember(l,"nodes",get_nodes,null,true);
		addMember(l,"pathLength",get_pathLength,null,true);
		createTypeMetatable(l,constructor, typeof(GoSpline));
	}
}
