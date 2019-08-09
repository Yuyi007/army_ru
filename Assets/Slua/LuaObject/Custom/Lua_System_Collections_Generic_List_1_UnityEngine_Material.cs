using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Collections_Generic_List_1_UnityEngine_Material : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			System.Collections.Generic.List<UnityEngine.Material> o;
			if(argc==1){
				o=new System.Collections.Generic.List<UnityEngine.Material>();
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(IEnumerable<UnityEngine.Material>))){
				System.Collections.Generic.IEnumerable<UnityEngine.Material> a1;
				checkType(l,2,out a1);
				o=new System.Collections.Generic.List<UnityEngine.Material>(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				o=new System.Collections.Generic.List<UnityEngine.Material>(a1);
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
	static public int Add(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			self.Add(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddRange(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Collections.Generic.IEnumerable<UnityEngine.Material> a1;
			checkType(l,2,out a1);
			self.AddRange(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AsReadOnly(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			var ret=self.AsReadOnly();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int BinarySearch(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				var ret=self.BinarySearch(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				System.Collections.Generic.IComparer<UnityEngine.Material> a2;
				checkType(l,3,out a2);
				var ret=self.BinarySearch(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==5){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Material a3;
				checkType(l,4,out a3);
				System.Collections.Generic.IComparer<UnityEngine.Material> a4;
				checkType(l,5,out a4);
				var ret=self.BinarySearch(a1,a2,a3,a4);
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
	static public int Clear(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			self.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Contains(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			var ret=self.Contains(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Exists(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.Exists(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Find(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.Find(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindAll(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.FindAll(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindIndex(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Predicate<UnityEngine.Material> a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				var ret=self.FindIndex(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Predicate<UnityEngine.Material> a2;
				LuaDelegation.checkDelegate(l,3,out a2);
				var ret=self.FindIndex(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Predicate<UnityEngine.Material> a3;
				LuaDelegation.checkDelegate(l,4,out a3);
				var ret=self.FindIndex(a1,a2,a3);
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
	static public int FindLast(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.FindLast(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindLastIndex(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Predicate<UnityEngine.Material> a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				var ret=self.FindLastIndex(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Predicate<UnityEngine.Material> a2;
				LuaDelegation.checkDelegate(l,3,out a2);
				var ret=self.FindLastIndex(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Predicate<UnityEngine.Material> a3;
				LuaDelegation.checkDelegate(l,4,out a3);
				var ret=self.FindLastIndex(a1,a2,a3);
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
	static public int ForEach(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Action<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.ForEach(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRange(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetRange(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IndexOf(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				var ret=self.IndexOf(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.IndexOf(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.IndexOf(a1,a2,a3);
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
	static public int Insert(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Material a2;
			checkType(l,3,out a2);
			self.Insert(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InsertRange(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Collections.Generic.IEnumerable<UnityEngine.Material> a2;
			checkType(l,3,out a2);
			self.InsertRange(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LastIndexOf(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				var ret=self.LastIndexOf(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.LastIndexOf(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==4){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				UnityEngine.Material a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.LastIndexOf(a1,a2,a3);
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
	static public int Remove(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			var ret=self.Remove(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveAll(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.RemoveAll(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveAt(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.RemoveAt(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveRange(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.RemoveRange(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reverse(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				self.Reverse();
				return 0;
			}
			else if(argc==3){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.Reverse(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Sort(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				self.Sort();
				return 0;
			}
			else if(matchType(l,argc,2,typeof(System.Comparison<UnityEngine.Material>))){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Comparison<UnityEngine.Material> a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				self.Sort(a1);
				return 0;
			}
			else if(matchType(l,argc,2,typeof(IComparer<UnityEngine.Material>))){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Collections.Generic.IComparer<UnityEngine.Material> a1;
				checkType(l,2,out a1);
				self.Sort(a1);
				return 0;
			}
			else if(argc==4){
				System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Collections.Generic.IComparer<UnityEngine.Material> a3;
				checkType(l,4,out a3);
				self.Sort(a1,a2,a3);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToArray(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			var ret=self.ToArray();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TrimExcess(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			self.TrimExcess();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TrueForAll(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			System.Predicate<UnityEngine.Material> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.TrueForAll(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Capacity(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			pushValue(l,self.Capacity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Capacity(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.Capacity=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Count(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			pushValue(l,self.Count);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getItem(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			int v;
			checkType(l,2,out v);
			var ret = self[v];
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setItem(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Material> self=(System.Collections.Generic.List<UnityEngine.Material>)checkSelf(l);
			int v;
			checkType(l,2,out v);
			UnityEngine.Material c;
			checkType(l,3,out c);
			self[v]=c;
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"ListMaterial");
		addMember(l,Add);
		addMember(l,AddRange);
		addMember(l,AsReadOnly);
		addMember(l,BinarySearch);
		addMember(l,Clear);
		addMember(l,Contains);
		addMember(l,Exists);
		addMember(l,Find);
		addMember(l,FindAll);
		addMember(l,FindIndex);
		addMember(l,FindLast);
		addMember(l,FindLastIndex);
		addMember(l,ForEach);
		addMember(l,GetRange);
		addMember(l,IndexOf);
		addMember(l,Insert);
		addMember(l,InsertRange);
		addMember(l,LastIndexOf);
		addMember(l,Remove);
		addMember(l,RemoveAll);
		addMember(l,RemoveAt);
		addMember(l,RemoveRange);
		addMember(l,Reverse);
		addMember(l,Sort);
		addMember(l,ToArray);
		addMember(l,TrimExcess);
		addMember(l,TrueForAll);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"Capacity",get_Capacity,set_Capacity,true);
		addMember(l,"Count",get_Count,null,true);
		createTypeMetatable(l,constructor, typeof(System.Collections.Generic.List<UnityEngine.Material>));
	}
}
