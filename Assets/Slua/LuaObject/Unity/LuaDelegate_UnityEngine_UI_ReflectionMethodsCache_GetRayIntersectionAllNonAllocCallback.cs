
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

  //      static internal int checkDelegate(IntPtr l,int p,out UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllNonAllocCallback ua) {
  //          int op = extractFunction(l,p);
		//	if(LuaDLL.lua_isnil(l,p)) {
		//		ua=null;
		//		return op;
		//	}
  //          else if (LuaDLL.lua_isuserdata(l, p)==1)
  //          {
  //              ua = (UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllNonAllocCallback)checkObj(l, p);
  //              return op;
  //          }
  //          LuaDelegate ld;
  //          checkType(l, -1, out ld);
  //          if(ld.d!=null)
  //          {
  //              ua = (UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllNonAllocCallback)ld.d;
  //              return op;
  //          }
		//	LuaDLL.lua_pop(l,1);

		//	l = LuaState.get(l).L;
  //          ua = (UnityEngine.Ray a1,UnityEngine.RaycastHit2D[] a2,float a3,int a4) =>
  //          {
  //              int error = pushTry(l);

		//		pushValue(l,a1);
		//		pushValue(l,a2);
		//		pushValue(l,a3);
		//		pushValue(l,a4);
		//		ld.pcall(4, error);
		//		int ret;
		//		checkType(l,error+1,out ret);
		//		LuaDLL.lua_settop(l, error-1);
		//		return ret;
		//	};
		//	ld.d=ua;
		//	return op;
		//}
	}
}
