using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_DateTimeOffset : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			System.DateTimeOffset o;
			if(argc==2){
				System.DateTime a1;
				checkValueType(l,2,out a1);
				o=new System.DateTimeOffset(a1);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.DateTime),typeof(System.TimeSpan))){
				System.DateTime a1;
				checkValueType(l,2,out a1);
				System.TimeSpan a2;
				checkValueType(l,3,out a2);
				o=new System.DateTimeOffset(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int64),typeof(System.TimeSpan))){
				System.Int64 a1;
				checkType(l,2,out a1);
				System.TimeSpan a2;
				checkValueType(l,3,out a2);
				o=new System.DateTimeOffset(a1,a2);
				pushValue(l,o);
				return 1;
			}
			else if(argc==8){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				System.TimeSpan a7;
				checkValueType(l,8,out a7);
				o=new System.DateTimeOffset(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,o);
				return 1;
			}
			else if(argc==9){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				System.TimeSpan a8;
				checkValueType(l,9,out a8);
				o=new System.DateTimeOffset(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,o);
				return 1;
			}
			else if(argc==10){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				System.Globalization.Calendar a8;
				checkType(l,9,out a8);
				System.TimeSpan a9;
				checkValueType(l,10,out a9);
				o=new System.DateTimeOffset(a1,a2,a3,a4,a5,a6,a7,a8,a9);
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
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.TimeSpan a1;
			checkValueType(l,2,out a1);
			var ret=self.Add(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddDays(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Double a1;
			checkType(l,2,out a1);
			var ret=self.AddDays(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddHours(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Double a1;
			checkType(l,2,out a1);
			var ret=self.AddHours(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddMilliseconds(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Double a1;
			checkType(l,2,out a1);
			var ret=self.AddMilliseconds(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddMinutes(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Double a1;
			checkType(l,2,out a1);
			var ret=self.AddMinutes(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddMonths(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.AddMonths(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddSeconds(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Double a1;
			checkType(l,2,out a1);
			var ret=self.AddSeconds(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddTicks(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Int64 a1;
			checkType(l,2,out a1);
			var ret=self.AddTicks(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddYears(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.AddYears(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompareTo(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.DateTimeOffset a1;
			checkValueType(l,2,out a1);
			var ret=self.CompareTo(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EqualsExact(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.DateTimeOffset a1;
			checkValueType(l,2,out a1);
			var ret=self.EqualsExact(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Subtract(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(System.TimeSpan))){
				System.DateTimeOffset self;
				checkValueType(l,1,out self);
				System.TimeSpan a1;
				checkValueType(l,2,out a1);
				var ret=self.Subtract(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.DateTimeOffset))){
				System.DateTimeOffset self;
				checkValueType(l,1,out self);
				System.DateTimeOffset a1;
				checkValueType(l,2,out a1);
				var ret=self.Subtract(a1);
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
	static public int ToFileTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			var ret=self.ToFileTime();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToLocalTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			var ret=self.ToLocalTime();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToOffset(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			System.TimeSpan a1;
			checkValueType(l,2,out a1);
			var ret=self.ToOffset(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToUniversalTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			var ret=self.ToUniversalTime();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Compare_s(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=System.DateTimeOffset.Compare(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FromFileTime_s(IntPtr l) {
		try {
			System.Int64 a1;
			checkType(l,1,out a1);
			var ret=System.DateTimeOffset.FromFileTime(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Parse_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.DateTimeOffset.Parse(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.IFormatProvider a2;
				checkType(l,2,out a2);
				var ret=System.DateTimeOffset.Parse(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.IFormatProvider a2;
				checkType(l,2,out a2);
				System.Globalization.DateTimeStyles a3;
				checkEnum(l,3,out a3);
				var ret=System.DateTimeOffset.Parse(a1,a2,a3);
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
	static public int ParseExact_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				var ret=System.DateTimeOffset.ParseExact(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.String[]),typeof(System.IFormatProvider),typeof(System.Globalization.DateTimeStyles))){
				System.String a1;
				checkType(l,1,out a1);
				System.String[] a2;
				checkType(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				System.Globalization.DateTimeStyles a4;
				checkEnum(l,4,out a4);
				var ret=System.DateTimeOffset.ParseExact(a1,a2,a3,a4);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(string),typeof(System.IFormatProvider),typeof(System.Globalization.DateTimeStyles))){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				System.Globalization.DateTimeStyles a4;
				checkEnum(l,4,out a4);
				var ret=System.DateTimeOffset.ParseExact(a1,a2,a3,a4);
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
	static public int TryParse_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.DateTimeOffset a2;
				var ret=System.DateTimeOffset.TryParse(a1,out a2);
				pushValue(l,ret);
				pushValue(l,a2);
				return 2;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.IFormatProvider a2;
				checkType(l,2,out a2);
				System.Globalization.DateTimeStyles a3;
				checkEnum(l,3,out a3);
				System.DateTimeOffset a4;
				var ret=System.DateTimeOffset.TryParse(a1,a2,a3,out a4);
				pushValue(l,ret);
				pushValue(l,a4);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TryParseExact_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(System.String[]),typeof(System.IFormatProvider),typeof(System.Globalization.DateTimeStyles),typeof(LuaOut))){
				System.String a1;
				checkType(l,1,out a1);
				System.String[] a2;
				checkType(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				System.Globalization.DateTimeStyles a4;
				checkEnum(l,4,out a4);
				System.DateTimeOffset a5;
				var ret=System.DateTimeOffset.TryParseExact(a1,a2,a3,a4,out a5);
				pushValue(l,ret);
				pushValue(l,a5);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(string),typeof(System.IFormatProvider),typeof(System.Globalization.DateTimeStyles),typeof(LuaOut))){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.IFormatProvider a3;
				checkType(l,3,out a3);
				System.Globalization.DateTimeStyles a4;
				checkEnum(l,4,out a4);
				System.DateTimeOffset a5;
				var ret=System.DateTimeOffset.TryParseExact(a1,a2,a3,a4,out a5);
				pushValue(l,ret);
				pushValue(l,a5);
				return 2;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Addition(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.TimeSpan a2;
			checkValueType(l,2,out a2);
			var ret=a1+a2;
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Equality(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_GreaterThan(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a2<a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_GreaterThanOrEqual(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a2<=a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Inequality(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_LessThan(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a1<a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_LessThanOrEqual(IntPtr l) {
		try {
			System.DateTimeOffset a1;
			checkValueType(l,1,out a1);
			System.DateTimeOffset a2;
			checkValueType(l,2,out a2);
			var ret=(a1<=a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Subtraction(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(System.DateTimeOffset),typeof(System.TimeSpan))){
				System.DateTimeOffset a1;
				checkValueType(l,1,out a1);
				System.TimeSpan a2;
				checkValueType(l,2,out a2);
				var ret=a1-a2;
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(System.DateTimeOffset),typeof(System.DateTimeOffset))){
				System.DateTimeOffset a1;
				checkValueType(l,1,out a1);
				System.DateTimeOffset a2;
				checkValueType(l,2,out a2);
				var ret=a1-a2;
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
	static public int get_MaxValue(IntPtr l) {
		try {
			pushValue(l,System.DateTimeOffset.MaxValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinValue(IntPtr l) {
		try {
			pushValue(l,System.DateTimeOffset.MinValue);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Date(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Date);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DateTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.DateTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Day(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Day);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DayOfWeek(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushEnum(l,(int)self.DayOfWeek);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DayOfYear(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.DayOfYear);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Hour(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Hour);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_LocalDateTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.LocalDateTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Millisecond(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Millisecond);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Minute(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Minute);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Month(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Month);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Now(IntPtr l) {
		try {
			pushValue(l,System.DateTimeOffset.Now);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Offset(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Offset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Second(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Second);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Ticks(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Ticks);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TimeOfDay(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.TimeOfDay);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UtcDateTime(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.UtcDateTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UtcNow(IntPtr l) {
		try {
			pushValue(l,System.DateTimeOffset.UtcNow);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UtcTicks(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.UtcTicks);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Year(IntPtr l) {
		try {
			System.DateTimeOffset self;
			checkValueType(l,1,out self);
			pushValue(l,self.Year);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"System.DateTimeOffset");
		addMember(l,Add);
		addMember(l,AddDays);
		addMember(l,AddHours);
		addMember(l,AddMilliseconds);
		addMember(l,AddMinutes);
		addMember(l,AddMonths);
		addMember(l,AddSeconds);
		addMember(l,AddTicks);
		addMember(l,AddYears);
		addMember(l,CompareTo);
		addMember(l,EqualsExact);
		addMember(l,Subtract);
		addMember(l,ToFileTime);
		addMember(l,ToLocalTime);
		addMember(l,ToOffset);
		addMember(l,ToUniversalTime);
		addMember(l,Compare_s);
		addMember(l,FromFileTime_s);
		addMember(l,Parse_s);
		addMember(l,ParseExact_s);
		addMember(l,TryParse_s);
		addMember(l,TryParseExact_s);
		addMember(l,op_Addition);
		addMember(l,op_Equality);
		addMember(l,op_GreaterThan);
		addMember(l,op_GreaterThanOrEqual);
		addMember(l,op_Inequality);
		addMember(l,op_LessThan);
		addMember(l,op_LessThanOrEqual);
		addMember(l,op_Subtraction);
		addMember(l,"MaxValue",get_MaxValue,null,false);
		addMember(l,"MinValue",get_MinValue,null,false);
		addMember(l,"Date",get_Date,null,true);
		addMember(l,"DateTime",get_DateTime,null,true);
		addMember(l,"Day",get_Day,null,true);
		addMember(l,"DayOfWeek",get_DayOfWeek,null,true);
		addMember(l,"DayOfYear",get_DayOfYear,null,true);
		addMember(l,"Hour",get_Hour,null,true);
		addMember(l,"LocalDateTime",get_LocalDateTime,null,true);
		addMember(l,"Millisecond",get_Millisecond,null,true);
		addMember(l,"Minute",get_Minute,null,true);
		addMember(l,"Month",get_Month,null,true);
		addMember(l,"Now",get_Now,null,false);
		addMember(l,"Offset",get_Offset,null,true);
		addMember(l,"Second",get_Second,null,true);
		addMember(l,"Ticks",get_Ticks,null,true);
		addMember(l,"TimeOfDay",get_TimeOfDay,null,true);
		addMember(l,"UtcDateTime",get_UtcDateTime,null,true);
		addMember(l,"UtcNow",get_UtcNow,null,false);
		addMember(l,"UtcTicks",get_UtcTicks,null,true);
		addMember(l,"Year",get_Year,null,true);
		createTypeMetatable(l,constructor, typeof(System.DateTimeOffset),typeof(System.ValueType));
	}
}
