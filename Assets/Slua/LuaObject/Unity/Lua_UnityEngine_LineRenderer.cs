using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_LineRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LineRenderer o;
			o=new UnityEngine.LineRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetPositions(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.Vector3[] a1;
			checkType(l,2,out a1);
			self.SetPositions(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPositions(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.Vector3[] a1;
			checkType(l,2,out a1);
			var ret=self.GetPositions(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetPosition(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetPosition(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPosition(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Simplify(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.Simplify(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_widthCurve(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.widthCurve);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_widthCurve(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.widthCurve=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorGradient(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.colorGradient);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colorGradient(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.Gradient v;
			checkType(l,2,out v);
			self.colorGradient=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startWidth(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.startWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startWidth(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.startWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_endWidth(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.endWidth);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_endWidth(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.endWidth=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_widthMultiplier(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.widthMultiplier);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_widthMultiplier(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.widthMultiplier=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_numCornerVertices(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.numCornerVertices);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_numCornerVertices(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.numCornerVertices=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_numCapVertices(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.numCapVertices);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_numCapVertices(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.numCapVertices=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useWorldSpace(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.useWorldSpace);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useWorldSpace(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useWorldSpace=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loop(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.loop);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loop(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.loop=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startColor(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.startColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startColor(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.startColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_endColor(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.endColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_endColor(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.endColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_positionCount(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.positionCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_positionCount(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.positionCount=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_generateLightingData(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushValue(l,self.generateLightingData);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_generateLightingData(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.generateLightingData=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_textureMode(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushEnum(l,(int)self.textureMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_textureMode(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.LineTextureMode v;
			checkEnum(l,2,out v);
			self.textureMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			pushEnum(l,(int)self.alignment);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alignment(IntPtr l) {
		try {
			UnityEngine.LineRenderer self=(UnityEngine.LineRenderer)checkSelf(l);
			UnityEngine.LineAlignment v;
			checkEnum(l,2,out v);
			self.alignment=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LineRenderer");
		addMember(l,SetPositions);
		addMember(l,GetPositions);
		addMember(l,SetPosition);
		addMember(l,GetPosition);
		addMember(l,Simplify);
		addMember(l,"widthCurve",get_widthCurve,set_widthCurve,true);
		addMember(l,"colorGradient",get_colorGradient,set_colorGradient,true);
		addMember(l,"startWidth",get_startWidth,set_startWidth,true);
		addMember(l,"endWidth",get_endWidth,set_endWidth,true);
		addMember(l,"widthMultiplier",get_widthMultiplier,set_widthMultiplier,true);
		addMember(l,"numCornerVertices",get_numCornerVertices,set_numCornerVertices,true);
		addMember(l,"numCapVertices",get_numCapVertices,set_numCapVertices,true);
		addMember(l,"useWorldSpace",get_useWorldSpace,set_useWorldSpace,true);
		addMember(l,"loop",get_loop,set_loop,true);
		addMember(l,"startColor",get_startColor,set_startColor,true);
		addMember(l,"endColor",get_endColor,set_endColor,true);
		addMember(l,"positionCount",get_positionCount,set_positionCount,true);
		addMember(l,"generateLightingData",get_generateLightingData,set_generateLightingData,true);
		addMember(l,"textureMode",get_textureMode,set_textureMode,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LineRenderer),typeof(UnityEngine.Renderer));
	}
}
