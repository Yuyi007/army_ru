using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Gizmos : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Gizmos o;
			o=new UnityEngine.Gizmos();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawRay_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				UnityEngine.Gizmos.DrawRay(a1);
				return 0;
			}
			else if(argc==2){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawRay(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawLine_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			UnityEngine.Gizmos.DrawLine(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawWireSphere_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			UnityEngine.Gizmos.DrawWireSphere(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawSphere_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			UnityEngine.Gizmos.DrawSphere(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawWireCube_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			UnityEngine.Gizmos.DrawWireCube(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawCube_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			UnityEngine.Gizmos.DrawCube(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawMesh_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Gizmos.DrawMesh(a1);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawMesh(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawMesh(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawMesh(a1,a2,a3);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawMesh(a1,a2,a3);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Quaternion a4;
				checkType(l,4,out a4);
				UnityEngine.Gizmos.DrawMesh(a1,a2,a3,a4);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Vector3 a4;
				checkType(l,4,out a4);
				UnityEngine.Gizmos.DrawMesh(a1,a2,a3,a4);
				return 0;
			}
			else if(argc==5){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Quaternion a4;
				checkType(l,4,out a4);
				UnityEngine.Vector3 a5;
				checkType(l,5,out a5);
				UnityEngine.Gizmos.DrawMesh(a1,a2,a3,a4,a5);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawWireMesh_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Gizmos.DrawWireMesh(a1);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2,a3);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2,a3);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Quaternion a4;
				checkType(l,4,out a4);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2,a3,a4);
				return 0;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Vector3))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Vector3 a4;
				checkType(l,4,out a4);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2,a3,a4);
				return 0;
			}
			else if(argc==5){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				UnityEngine.Quaternion a4;
				checkType(l,4,out a4);
				UnityEngine.Vector3 a5;
				checkType(l,5,out a5);
				UnityEngine.Gizmos.DrawWireMesh(a1,a2,a3,a4,a5);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawIcon_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawIcon(a1,a2);
				return 0;
			}
			else if(argc==3){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawIcon(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawGUITexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Gizmos.DrawGUITexture(a1,a2);
				return 0;
			}
			else if(argc==3){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Gizmos.DrawGUITexture(a1,a2,a3);
				return 0;
			}
			else if(argc==6){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Gizmos.DrawGUITexture(a1,a2,a3,a4,a5,a6);
				return 0;
			}
			else if(argc==7){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Material a7;
				checkType(l,7,out a7);
				UnityEngine.Gizmos.DrawGUITexture(a1,a2,a3,a4,a5,a6,a7);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawFrustum_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			UnityEngine.Gizmos.DrawFrustum(a1,a2,a3,a4,a5);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Gizmos.color);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.Gizmos.color=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_matrix(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Gizmos.matrix);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_matrix(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 v;
			checkValueType(l,2,out v);
			UnityEngine.Gizmos.matrix=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Gizmos");
		addMember(l,DrawRay_s);
		addMember(l,DrawLine_s);
		addMember(l,DrawWireSphere_s);
		addMember(l,DrawSphere_s);
		addMember(l,DrawWireCube_s);
		addMember(l,DrawCube_s);
		addMember(l,DrawMesh_s);
		addMember(l,DrawWireMesh_s);
		addMember(l,DrawIcon_s);
		addMember(l,DrawGUITexture_s);
		addMember(l,DrawFrustum_s);
		addMember(l,"color",get_color,set_color,false);
		addMember(l,"matrix",get_matrix,set_matrix,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Gizmos));
	}
}
