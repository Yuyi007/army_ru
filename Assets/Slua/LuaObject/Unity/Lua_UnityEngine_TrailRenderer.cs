using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_TrailRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer o;
			o=new UnityEngine.TrailRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPositions(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			self.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_widthCurve(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,self.time);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.time=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startWidth(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
	static public int get_autodestruct(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,self.autodestruct);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autodestruct(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autodestruct=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_numCornerVertices(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
	static public int get_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,self.minVertexDistance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minVertexDistance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startColor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,self.positionCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_generateLightingData(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.TrailRenderer");
		addMember(l,GetPositions);
		addMember(l,GetPosition);
		addMember(l,Clear);
		addMember(l,"widthCurve",get_widthCurve,set_widthCurve,true);
		addMember(l,"colorGradient",get_colorGradient,set_colorGradient,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"startWidth",get_startWidth,set_startWidth,true);
		addMember(l,"endWidth",get_endWidth,set_endWidth,true);
		addMember(l,"widthMultiplier",get_widthMultiplier,set_widthMultiplier,true);
		addMember(l,"autodestruct",get_autodestruct,set_autodestruct,true);
		addMember(l,"numCornerVertices",get_numCornerVertices,set_numCornerVertices,true);
		addMember(l,"numCapVertices",get_numCapVertices,set_numCapVertices,true);
		addMember(l,"minVertexDistance",get_minVertexDistance,set_minVertexDistance,true);
		addMember(l,"startColor",get_startColor,set_startColor,true);
		addMember(l,"endColor",get_endColor,set_endColor,true);
		addMember(l,"positionCount",get_positionCount,null,true);
		addMember(l,"generateLightingData",get_generateLightingData,set_generateLightingData,true);
		addMember(l,"textureMode",get_textureMode,set_textureMode,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.TrailRenderer),typeof(UnityEngine.Renderer));
	}
}
