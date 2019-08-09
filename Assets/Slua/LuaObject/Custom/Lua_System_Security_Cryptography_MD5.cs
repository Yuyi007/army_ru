using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_System_Security_Cryptography_MD5 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Create_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				var ret=System.Security.Cryptography.MD5.Create();
				pushValue(l,ret);
				return 1;
			}
			else if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=System.Security.Cryptography.MD5.Create(a1);
				pushValue(l,ret);
				return 1;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"System.Security.Cryptography.MD5");
		addMember(l,Create_s);
		createTypeMetatable(l,null, typeof(System.Security.Cryptography.MD5),typeof(System.Security.Cryptography.HashAlgorithm));
	}
}
