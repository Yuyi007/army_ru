﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_IO_File : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendAllText_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IO.File.AppendAllText(a1,a2);
				return 0;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Text.Encoding a3;
				checkType(l,3,out a3);
				System.IO.File.AppendAllText(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendText_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.AppendText(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Copy_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IO.File.Copy(a1,a2);
				return 0;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				System.IO.File.Copy(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Create_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.IO.File.Create(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=System.IO.File.Create(a1,a2);
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
	static public int CreateText_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.CreateText(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Delete_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.IO.File.Delete(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Exists_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.Exists(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAttributes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetAttributes(a1);
			pushEnum(l,(int)ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCreationTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetCreationTime(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCreationTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetCreationTimeUtc(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLastAccessTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetLastAccessTime(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLastAccessTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetLastAccessTimeUtc(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLastWriteTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetLastWriteTime(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLastWriteTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.GetLastWriteTimeUtc(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Move_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.IO.File.Move(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Open_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.IO.FileMode a2;
				checkEnum(l,2,out a2);
				var ret=System.IO.File.Open(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.IO.FileMode a2;
				checkEnum(l,2,out a2);
				System.IO.FileAccess a3;
				checkEnum(l,3,out a3);
				var ret=System.IO.File.Open(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.IO.FileMode a2;
				checkEnum(l,2,out a2);
				System.IO.FileAccess a3;
				checkEnum(l,3,out a3);
				System.IO.FileShare a4;
				checkEnum(l,4,out a4);
				var ret=System.IO.File.Open(a1,a2,a3,a4);
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
	static public int OpenRead_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.OpenRead(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OpenText_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.OpenText(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OpenWrite_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.OpenWrite(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Replace_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.IO.File.Replace(a1,a2,a3);
				return 0;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				System.IO.File.Replace(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetAttributes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.IO.FileAttributes a2;
			checkEnum(l,2,out a2);
			System.IO.File.SetAttributes(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCreationTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetCreationTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCreationTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetCreationTimeUtc(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLastAccessTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetLastAccessTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLastAccessTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetLastAccessTimeUtc(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLastWriteTime_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetLastWriteTime(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLastWriteTimeUtc_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.DateTime a2;
			checkValueType(l,2,out a2);
			System.IO.File.SetLastWriteTimeUtc(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReadAllBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=System.IO.File.ReadAllBytes(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReadAllLines_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.IO.File.ReadAllLines(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Text.Encoding a2;
				checkType(l,2,out a2);
				var ret=System.IO.File.ReadAllLines(a1,a2);
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
	static public int ReadAllText_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.IO.File.ReadAllText(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Text.Encoding a2;
				checkType(l,2,out a2);
				var ret=System.IO.File.ReadAllText(a1,a2);
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
	static public int WriteAllBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			System.IO.File.WriteAllBytes(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteAllLines_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String[] a2;
				checkType(l,2,out a2);
				System.IO.File.WriteAllLines(a1,a2);
				return 0;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String[] a2;
				checkType(l,2,out a2);
				System.Text.Encoding a3;
				checkType(l,3,out a3);
				System.IO.File.WriteAllLines(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteAllText_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IO.File.WriteAllText(a1,a2);
				return 0;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Text.Encoding a3;
				checkType(l,3,out a3);
				System.IO.File.WriteAllText(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Encrypt_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.IO.File.Encrypt(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Decrypt_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.IO.File.Decrypt(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"System.IO.File");
		addMember(l,AppendAllText_s);
		addMember(l,AppendText_s);
		addMember(l,Copy_s);
		addMember(l,Create_s);
		addMember(l,CreateText_s);
		addMember(l,Delete_s);
		addMember(l,Exists_s);
		addMember(l,GetAttributes_s);
		addMember(l,GetCreationTime_s);
		addMember(l,GetCreationTimeUtc_s);
		addMember(l,GetLastAccessTime_s);
		addMember(l,GetLastAccessTimeUtc_s);
		addMember(l,GetLastWriteTime_s);
		addMember(l,GetLastWriteTimeUtc_s);
		addMember(l,Move_s);
		addMember(l,Open_s);
		addMember(l,OpenRead_s);
		addMember(l,OpenText_s);
		addMember(l,OpenWrite_s);
		addMember(l,Replace_s);
		addMember(l,SetAttributes_s);
		addMember(l,SetCreationTime_s);
		addMember(l,SetCreationTimeUtc_s);
		addMember(l,SetLastAccessTime_s);
		addMember(l,SetLastAccessTimeUtc_s);
		addMember(l,SetLastWriteTime_s);
		addMember(l,SetLastWriteTimeUtc_s);
		addMember(l,ReadAllBytes_s);
		addMember(l,ReadAllLines_s);
		addMember(l,ReadAllText_s);
		addMember(l,WriteAllBytes_s);
		addMember(l,WriteAllLines_s);
		addMember(l,WriteAllText_s);
		addMember(l,Encrypt_s);
		addMember(l,Decrypt_s);
		createTypeMetatable(l,null, typeof(System.IO.File));
	}
}
