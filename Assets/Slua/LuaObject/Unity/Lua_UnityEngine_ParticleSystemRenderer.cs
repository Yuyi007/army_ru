﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystemRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer o;
			o=new UnityEngine.ParticleSystemRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetMeshes(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Mesh[] a1;
			checkType(l,2,out a1);
			var ret=self.GetMeshes(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetMeshes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh[] a1;
				checkType(l,2,out a1);
				self.SetMeshes(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh[] a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetMeshes(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetActiveVertexStreams(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.ParticleSystemVertexStream> a1;
			checkType(l,2,out a1);
			self.SetActiveVertexStreams(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetActiveVertexStreams(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.ParticleSystemVertexStream> a1;
			checkType(l,2,out a1);
			self.GetActiveVertexStreams(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushEnum(l,(int)self.renderMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemRenderMode v;
			checkEnum(l,2,out v);
			self.renderMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lengthScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.lengthScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lengthScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lengthScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.velocityScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_velocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.velocityScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cameraVelocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.cameraVelocityScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cameraVelocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.cameraVelocityScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_normalDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.normalDirection);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_normalDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.normalDirection=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
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
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemRenderSpace v;
			checkEnum(l,2,out v);
			self.alignment=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pivot(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.pivot);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pivot(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.pivot=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushEnum(l,(int)self.sortMode);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemSortMode v;
			checkEnum(l,2,out v);
			self.sortMode=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingFudge(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.sortingFudge);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingFudge(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.sortingFudge=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.minParticleSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_minParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minParticleSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.maxParticleSize);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxParticleSize=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.mesh);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_meshCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.meshCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trailMaterial(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.trailMaterial);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_trailMaterial(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.trailMaterial=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activeVertexStreamsCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,self.activeVertexStreamsCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maskInteraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushEnum(l,(int)self.maskInteraction);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maskInteraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.SpriteMaskInteraction v;
			checkEnum(l,2,out v);
			self.maskInteraction=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystemRenderer");
		addMember(l,GetMeshes);
		addMember(l,SetMeshes);
		addMember(l,SetActiveVertexStreams);
		addMember(l,GetActiveVertexStreams);
		addMember(l,"renderMode",get_renderMode,set_renderMode,true);
		addMember(l,"lengthScale",get_lengthScale,set_lengthScale,true);
		addMember(l,"velocityScale",get_velocityScale,set_velocityScale,true);
		addMember(l,"cameraVelocityScale",get_cameraVelocityScale,set_cameraVelocityScale,true);
		addMember(l,"normalDirection",get_normalDirection,set_normalDirection,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"pivot",get_pivot,set_pivot,true);
		addMember(l,"sortMode",get_sortMode,set_sortMode,true);
		addMember(l,"sortingFudge",get_sortingFudge,set_sortingFudge,true);
		addMember(l,"minParticleSize",get_minParticleSize,set_minParticleSize,true);
		addMember(l,"maxParticleSize",get_maxParticleSize,set_maxParticleSize,true);
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"meshCount",get_meshCount,null,true);
		addMember(l,"trailMaterial",get_trailMaterial,set_trailMaterial,true);
		addMember(l,"activeVertexStreamsCount",get_activeVertexStreamsCount,null,true);
		addMember(l,"maskInteraction",get_maskInteraction,set_maskInteraction,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystemRenderer),typeof(UnityEngine.Renderer));
	}
}
