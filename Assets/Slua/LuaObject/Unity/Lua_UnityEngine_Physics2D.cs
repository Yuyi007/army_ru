﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Physics2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Physics2D o;
			o=new UnityEngine.Physics2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Linecast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.Linecast(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.Linecast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.Linecast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.Linecast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.Linecast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LinecastAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.LinecastAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.LinecastAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.LinecastAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.LinecastAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LinecastNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.LinecastNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.LinecastNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.LinecastNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.LinecastNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Raycast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.Raycast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RaycastAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.RaycastAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.RaycastAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.RaycastAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.RaycastAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.RaycastAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RaycastNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.RaycastNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.RaycastNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.RaycastNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.RaycastNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.RaycastNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CircleCast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CircleCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CircleCastAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.CircleCastAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.CircleCastAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CircleCastAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CircleCastAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CircleCastAll(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CircleCastNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.CircleCastNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CircleCastNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CircleCastNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CircleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.CircleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BoxCast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.BoxCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BoxCastAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.BoxCastAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.BoxCastAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.BoxCastAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.BoxCastAll(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.BoxCastAll(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BoxCastNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.BoxCastNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.BoxCastNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.BoxCastNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.BoxCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==9){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				System.Single a9;
				checkType(l,9,out a9);
				var ret=UnityEngine.Physics2D.BoxCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CapsuleCast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.ContactFilter2D a6;
				checkValueType(l,6,out a6);
				UnityEngine.RaycastHit2D[] a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.ContactFilter2D a6;
				checkValueType(l,6,out a6);
				UnityEngine.RaycastHit2D[] a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==9){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				System.Single a9;
				checkType(l,9,out a9);
				var ret=UnityEngine.Physics2D.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CapsuleCastAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.CapsuleCastAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CapsuleCastAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CapsuleCastAll(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.CapsuleCastAll(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==9){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				System.Single a9;
				checkType(l,9,out a9);
				var ret=UnityEngine.Physics2D.CapsuleCastAll(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CapsuleCastNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.CapsuleCastNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.CapsuleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.CapsuleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==9){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				System.Single a9;
				checkType(l,9,out a9);
				var ret=UnityEngine.Physics2D.CapsuleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==10){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,5,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				System.Single a9;
				checkType(l,9,out a9);
				System.Single a10;
				checkType(l,10,out a10);
				var ret=UnityEngine.Physics2D.CapsuleCastNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRayIntersection_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.Physics2D.GetRayIntersection(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetRayIntersection(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetRayIntersection(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRayIntersectionAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.Physics2D.GetRayIntersectionAll(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetRayIntersectionAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetRayIntersectionAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRayIntersectionNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetRayIntersectionNonAlloc(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetRayIntersectionNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Ray a1;
				checkValueType(l,1,out a1);
				UnityEngine.RaycastHit2D[] a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.GetRayIntersectionNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapPoint_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Physics2D.OverlapPoint(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapPoint(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapPoint(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapPoint(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapPoint(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapPointAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Physics2D.OverlapPointAll(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapPointAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapPointAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapPointAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapPointNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapPointNonAlloc(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapPointNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapPointNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapPointNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCircle_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapCircle(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapCircle(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCircle(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCircle(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCircle(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCircleAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapCircleAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapCircleAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCircleAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCircleAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCircleNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapCircleNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCircleNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCircleNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapCircleNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapBox_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapBox(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapBox(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,4,out a4);
				UnityEngine.Collider2D[] a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapBox(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapBox(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapBox(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapBoxAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapBoxAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapBoxAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapBoxAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapBoxAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapBoxNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapBoxNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapBoxNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapBoxNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.OverlapBoxNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapArea_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapArea(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapArea(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.Collider2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapArea(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapArea(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapArea(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapAreaAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.OverlapAreaAll(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapAreaAll(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapAreaAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapAreaAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapAreaNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.OverlapAreaNonAlloc(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapAreaNonAlloc(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapAreaNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapAreaNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCapsule_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCapsule(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCapsule(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,5,out a5);
				UnityEngine.Collider2D[] a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapCapsule(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapCapsule(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.OverlapCapsule(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCapsuleAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.OverlapCapsuleAll(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCapsuleAll(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapCapsuleAll(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.OverlapCapsuleAll(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCapsuleNonAlloc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Collider2D[] a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.Physics2D.OverlapCapsuleNonAlloc(a1,a2,a3,a4,a5);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Collider2D[] a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Physics2D.OverlapCapsuleNonAlloc(a1,a2,a3,a4,a5,a6);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Collider2D[] a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.Physics2D.OverlapCapsuleNonAlloc(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Vector2 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				UnityEngine.CapsuleDirection2D a3;
				checkEnum(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				UnityEngine.Collider2D[] a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Single a7;
				checkType(l,7,out a7);
				System.Single a8;
				checkType(l,8,out a8);
				var ret=UnityEngine.Physics2D.OverlapCapsuleNonAlloc(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OverlapCollider_s(IntPtr l) {
		try {
			UnityEngine.Collider2D a1;
			checkType(l,1,out a1);
			UnityEngine.ContactFilter2D a2;
			checkValueType(l,2,out a2);
			UnityEngine.Collider2D[] a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Physics2D.OverlapCollider(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetContacts_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody2D),typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Rigidbody2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactPoint2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Rigidbody2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactPoint2D[] a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody2D),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Rigidbody2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody2D),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Rigidbody2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.ContactPoint2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.ContactPoint2D[]))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.ContactPoint2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				UnityEngine.ContactPoint2D[] a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Physics2D.GetContacts(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Simulate_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Physics2D.Simulate(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SyncTransforms_s(IntPtr l) {
		try {
			UnityEngine.Physics2D.SyncTransforms();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IgnoreCollision_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D a2;
				checkType(l,2,out a2);
				UnityEngine.Physics2D.IgnoreCollision(a1,a2);
				return 0;
			}
			else if(argc==3){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Physics2D.IgnoreCollision(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetIgnoreCollision_s(IntPtr l) {
		try {
			UnityEngine.Collider2D a1;
			checkType(l,1,out a1);
			UnityEngine.Collider2D a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.Physics2D.GetIgnoreCollision(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IgnoreLayerCollision_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Physics2D.IgnoreLayerCollision(a1,a2);
				return 0;
			}
			else if(argc==3){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Physics2D.IgnoreLayerCollision(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetIgnoreLayerCollision_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.Physics2D.GetIgnoreLayerCollision(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayerCollisionMask_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.Physics2D.SetLayerCollisionMask(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLayerCollisionMask_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Physics2D.GetLayerCollisionMask(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsTouching_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				var ret=UnityEngine.Physics2D.IsTouching(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.Collider2D))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.IsTouching(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D a2;
				checkType(l,2,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,3,out a3);
				var ret=UnityEngine.Physics2D.IsTouching(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsTouchingLayers_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Physics2D.IsTouchingLayers(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Physics2D.IsTouchingLayers(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Distance_s(IntPtr l) {
		try {
			UnityEngine.Collider2D a1;
			checkType(l,1,out a1);
			UnityEngine.Collider2D a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.Physics2D.Distance(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IgnoreRaycastLayer(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.IgnoreRaycastLayer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DefaultRaycastLayers(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.DefaultRaycastLayers);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllLayers(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.AllLayers);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocityIterations(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.velocityIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_velocityIterations(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.velocityIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_positionIterations(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.positionIterations);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_positionIterations(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.positionIterations=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gravity(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.gravity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_gravity(IntPtr l) {
		try {
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.gravity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_queriesHitTriggers(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.queriesHitTriggers);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_queriesHitTriggers(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.queriesHitTriggers=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_queriesStartInColliders(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.queriesStartInColliders);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_queriesStartInColliders(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.queriesStartInColliders=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_changeStopsCallbacks(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.changeStopsCallbacks);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_changeStopsCallbacks(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.changeStopsCallbacks=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_callbacksOnDisable(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.callbacksOnDisable);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_callbacksOnDisable(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.callbacksOnDisable=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoSyncTransforms(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.autoSyncTransforms);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoSyncTransforms(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.autoSyncTransforms=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoSimulation(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.autoSimulation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoSimulation(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.autoSimulation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocityThreshold(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.velocityThreshold);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_velocityThreshold(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.velocityThreshold=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxLinearCorrection(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.maxLinearCorrection);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxLinearCorrection(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.maxLinearCorrection=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxAngularCorrection(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.maxAngularCorrection);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxAngularCorrection(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.maxAngularCorrection=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxTranslationSpeed(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.maxTranslationSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxTranslationSpeed(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.maxTranslationSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxRotationSpeed(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.maxRotationSpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxRotationSpeed(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.maxRotationSpeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultContactOffset(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.defaultContactOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultContactOffset(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.defaultContactOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_baumgarteScale(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.baumgarteScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_baumgarteScale(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.baumgarteScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_baumgarteTOIScale(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.baumgarteTOIScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_baumgarteTOIScale(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.baumgarteTOIScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeToSleep(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.timeToSleep);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeToSleep(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.timeToSleep=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_linearSleepTolerance(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.linearSleepTolerance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_linearSleepTolerance(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.linearSleepTolerance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_angularSleepTolerance(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.angularSleepTolerance);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_angularSleepTolerance(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.angularSleepTolerance=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alwaysShowColliders(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.alwaysShowColliders);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alwaysShowColliders(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.alwaysShowColliders=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showColliderSleep(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.showColliderSleep);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showColliderSleep(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.showColliderSleep=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showColliderContacts(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.showColliderContacts);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showColliderContacts(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.showColliderContacts=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showColliderAABB(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.showColliderAABB);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showColliderAABB(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.showColliderAABB=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_contactArrowScale(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.contactArrowScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_contactArrowScale(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.contactArrowScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colliderAwakeColor(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.colliderAwakeColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colliderAwakeColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.colliderAwakeColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colliderAsleepColor(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.colliderAsleepColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colliderAsleepColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.colliderAsleepColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colliderContactColor(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.colliderContactColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colliderContactColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.colliderContactColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colliderAABBColor(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Physics2D.colliderAABBColor);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colliderAABBColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.Physics2D.colliderAABBColor=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Physics2D");
		addMember(l,Linecast_s);
		addMember(l,LinecastAll_s);
		addMember(l,LinecastNonAlloc_s);
		addMember(l,Raycast_s);
		addMember(l,RaycastAll_s);
		addMember(l,RaycastNonAlloc_s);
		addMember(l,CircleCast_s);
		addMember(l,CircleCastAll_s);
		addMember(l,CircleCastNonAlloc_s);
		addMember(l,BoxCast_s);
		addMember(l,BoxCastAll_s);
		addMember(l,BoxCastNonAlloc_s);
		addMember(l,CapsuleCast_s);
		addMember(l,CapsuleCastAll_s);
		addMember(l,CapsuleCastNonAlloc_s);
		addMember(l,GetRayIntersection_s);
		addMember(l,GetRayIntersectionAll_s);
		addMember(l,GetRayIntersectionNonAlloc_s);
		addMember(l,OverlapPoint_s);
		addMember(l,OverlapPointAll_s);
		addMember(l,OverlapPointNonAlloc_s);
		addMember(l,OverlapCircle_s);
		addMember(l,OverlapCircleAll_s);
		addMember(l,OverlapCircleNonAlloc_s);
		addMember(l,OverlapBox_s);
		addMember(l,OverlapBoxAll_s);
		addMember(l,OverlapBoxNonAlloc_s);
		addMember(l,OverlapArea_s);
		addMember(l,OverlapAreaAll_s);
		addMember(l,OverlapAreaNonAlloc_s);
		addMember(l,OverlapCapsule_s);
		addMember(l,OverlapCapsuleAll_s);
		addMember(l,OverlapCapsuleNonAlloc_s);
		addMember(l,OverlapCollider_s);
		addMember(l,GetContacts_s);
		addMember(l,Simulate_s);
		addMember(l,SyncTransforms_s);
		addMember(l,IgnoreCollision_s);
		addMember(l,GetIgnoreCollision_s);
		addMember(l,IgnoreLayerCollision_s);
		addMember(l,GetIgnoreLayerCollision_s);
		addMember(l,SetLayerCollisionMask_s);
		addMember(l,GetLayerCollisionMask_s);
		addMember(l,IsTouching_s);
		addMember(l,IsTouchingLayers_s);
		addMember(l,Distance_s);
		addMember(l,"IgnoreRaycastLayer",get_IgnoreRaycastLayer,null,false);
		addMember(l,"DefaultRaycastLayers",get_DefaultRaycastLayers,null,false);
		addMember(l,"AllLayers",get_AllLayers,null,false);
		addMember(l,"velocityIterations",get_velocityIterations,set_velocityIterations,false);
		addMember(l,"positionIterations",get_positionIterations,set_positionIterations,false);
		addMember(l,"gravity",get_gravity,set_gravity,false);
		addMember(l,"queriesHitTriggers",get_queriesHitTriggers,set_queriesHitTriggers,false);
		addMember(l,"queriesStartInColliders",get_queriesStartInColliders,set_queriesStartInColliders,false);
		addMember(l,"changeStopsCallbacks",get_changeStopsCallbacks,set_changeStopsCallbacks,false);
		addMember(l,"callbacksOnDisable",get_callbacksOnDisable,set_callbacksOnDisable,false);
		addMember(l,"autoSyncTransforms",get_autoSyncTransforms,set_autoSyncTransforms,false);
		addMember(l,"autoSimulation",get_autoSimulation,set_autoSimulation,false);
		addMember(l,"velocityThreshold",get_velocityThreshold,set_velocityThreshold,false);
		addMember(l,"maxLinearCorrection",get_maxLinearCorrection,set_maxLinearCorrection,false);
		addMember(l,"maxAngularCorrection",get_maxAngularCorrection,set_maxAngularCorrection,false);
		addMember(l,"maxTranslationSpeed",get_maxTranslationSpeed,set_maxTranslationSpeed,false);
		addMember(l,"maxRotationSpeed",get_maxRotationSpeed,set_maxRotationSpeed,false);
		addMember(l,"defaultContactOffset",get_defaultContactOffset,set_defaultContactOffset,false);
		addMember(l,"baumgarteScale",get_baumgarteScale,set_baumgarteScale,false);
		addMember(l,"baumgarteTOIScale",get_baumgarteTOIScale,set_baumgarteTOIScale,false);
		addMember(l,"timeToSleep",get_timeToSleep,set_timeToSleep,false);
		addMember(l,"linearSleepTolerance",get_linearSleepTolerance,set_linearSleepTolerance,false);
		addMember(l,"angularSleepTolerance",get_angularSleepTolerance,set_angularSleepTolerance,false);
		addMember(l,"alwaysShowColliders",get_alwaysShowColliders,set_alwaysShowColliders,false);
		addMember(l,"showColliderSleep",get_showColliderSleep,set_showColliderSleep,false);
		addMember(l,"showColliderContacts",get_showColliderContacts,set_showColliderContacts,false);
		addMember(l,"showColliderAABB",get_showColliderAABB,set_showColliderAABB,false);
		addMember(l,"contactArrowScale",get_contactArrowScale,set_contactArrowScale,false);
		addMember(l,"colliderAwakeColor",get_colliderAwakeColor,set_colliderAwakeColor,false);
		addMember(l,"colliderAsleepColor",get_colliderAsleepColor,set_colliderAsleepColor,false);
		addMember(l,"colliderContactColor",get_colliderContactColor,set_colliderContactColor,false);
		addMember(l,"colliderAABBColor",get_colliderAABBColor,set_colliderAABBColor,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Physics2D));
	}
}
