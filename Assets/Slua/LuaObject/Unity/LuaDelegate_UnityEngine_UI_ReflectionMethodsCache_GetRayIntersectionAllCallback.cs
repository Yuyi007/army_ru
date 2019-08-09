
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

  //      static internal int checkDelegate(IntPtr l,int p,out UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllCallback ua) {
  //          int op = extractFunction(l,p);
		//	if(LuaDLL.lua_isnil(l,p)) {
		//		ua=null;
		//		return op;
		//	}
  //          else if (LuaDLL.lua_isuserdata(l, p)==1)
  //          {
  //              ua = (UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllCallback)checkObj(l, p);
  //              return op;
  //          }
  //          LuaDelegate ld;
  //          checkType(l, -1, out ld);
  //          if(ld.d!=null)
  //          {
  //              ua = (UnityEngine.UI.ReflectionMethodsCache.GetRayIntersectionAllCallback)ld.d;
  //              return op;
  //          }
		//	LuaDLL.lua_pop(l,1);

		//	l = LuaState.get(l).L;
  //          ua = (UnityEngine.Ray a1,float a2,int a3) =>
  //          {
  //              int error = pushTry(l);

		//		pushValue(l,a1);
		//		pushValue(l,a2);
		//		pushValue(l,a3);
		//		ld.pcall(3, error);
		//		UnityEngine.RaycastHit2D[] ret;
		//		checkType(l,error+1,out ret);
		//		LuaDLL.lua_settop(l, error-1);
		//		return ret;
		//	};
		//	ld.d=ua;
		//	return op;
		//}
	}
}
