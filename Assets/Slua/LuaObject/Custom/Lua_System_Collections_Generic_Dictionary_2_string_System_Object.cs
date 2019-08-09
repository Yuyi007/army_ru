using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Collections_Generic_Dictionary_2_string_System_Object : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			System.Collections.Generic.Dictionary<System.String,System.Object> o;
			if(argc==1){
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>();
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(IEqualityComparer<System.String>))){
				System.Collections.Generic.IEqualityComparer<System.String> a1;
				checkType(l,2,out a1);
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(IDictionary<System.String,object>))){
				System.Collections.Generic.IDictionary<System.String,System.Object> a1;
				checkType(l,2,out a1);
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(IDictionary<System.String,object>),typeof(IEqualityComparer<System.String>))){
				System.Collections.Generic.IDictionary<System.String,System.Object> a1;
				checkType(l,2,out a1);
				System.Collections.Generic.IEqualityComparer<System.String> a2;
				checkType(l,3,out a2);
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(IEqualityComparer<System.String>))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.IEqualityComparer<System.String> a2;
				checkType(l,3,out a2);
				o=new System.Collections.Generic.Dictionary<System.String,System.Object>(a1,a2);
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
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Object a2;
			checkType(l,3,out a2);
			self.Add(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			self.Clear();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ContainsKey(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.ContainsKey(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ContainsValue(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.ContainsValue(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetObjectData(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.Runtime.Serialization.SerializationInfo a1;
			checkType(l,2,out a1);
			System.Runtime.Serialization.StreamingContext a2;
			checkValueType(l,3,out a2);
			self.GetObjectData(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDeserialization(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.OnDeserialization(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Remove(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.String a1;
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
	static public int TryGetValue(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Object a2;
			var ret=self.TryGetValue(a1,out a2);
			pushValue(l,ret);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Count(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			pushValue(l,self.Count);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Comparer(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			pushValue(l,self.Comparer);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Keys(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			pushValue(l,self.Keys);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Values(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			pushValue(l,self.Values);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getItem(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			string v;
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
			System.Collections.Generic.Dictionary<System.String,System.Object> self=(System.Collections.Generic.Dictionary<System.String,System.Object>)checkSelf(l);
			string v;
			checkType(l,2,out v);
			System.Object c;
			checkType(l,3,out c);
			self[v]=c;
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DictObject");
		addMember(l,Add);
		addMember(l,Clear);
		addMember(l,ContainsKey);
		addMember(l,ContainsValue);
		addMember(l,GetObjectData);
		addMember(l,OnDeserialization);
		addMember(l,Remove);
		addMember(l,TryGetValue);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"Count",get_Count,null,true);
		addMember(l,"Comparer",get_Comparer,null,true);
		addMember(l,"Keys",get_Keys,null,true);
		addMember(l,"Values",get_Values,null,true);
		createTypeMetatable(l,constructor, typeof(System.Collections.Generic.Dictionary<System.String,System.Object>));
	}
}
