namespace SLua
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using LuaInterface;
	using UnityEngine;
	using System.Runtime.InteropServices;

	public partial class LuaObject
	{

		public static bool checkType(IntPtr l, int p, out CombineInstance[] t)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			int n = LuaDLL.lua_rawlen(l, p);
			t = new CombineInstance[n];
			for (int k = 0; k < n; k++) {
				LuaDLL.lua_rawgeti(l, p, k + 1);
				checkValueType(l, -1, out t[k]);
				LuaDLL.lua_pop(l, 1);
			}
			return true;
		}


		public static bool checkType(IntPtr l, int p, out Material[] t)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			int n = LuaDLL.lua_rawlen(l, p);
			t = new Material[n];
			for (int k = 0; k < n; k++) {
				LuaDLL.lua_rawgeti(l, p, k + 1);
				checkType(l, -1, out t[k]);
				LuaDLL.lua_pop(l, 1);
			}
			return true;
		}


		public static bool checkType(IntPtr l, int p, out Transform[] t)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			int n = LuaDLL.lua_rawlen(l, p);
			t = new Transform[n];
			for (int k = 0; k < n; k++) {
				LuaDLL.lua_rawgeti(l, p, k + 1);
				checkType(l, -1, out t[k]);
				LuaDLL.lua_pop(l, 1);
			}
			return true;
		}

		public static bool checkType(IntPtr l, int p, out System.Int32[] t)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			int n = LuaDLL.lua_rawlen(l, p);
			t = new System.Int32[n];
			for (int k = 0; k < n; k++) {
				LuaDLL.lua_rawgeti(l, p, k + 1);
				checkType(l, -1, out t[k]);
				LuaDLL.lua_pop(l, 1);
			}
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out System.Int64[] pars)
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0) {
				pars = new System.Int64[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++) {
					checkType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new System.Int64[0];
			return true;
		}

		public static bool checkType(IntPtr l, int p, out UnityEngine.EventSystems.PointerEventData.InputButton o)
		{
			return checkEnum(l, p, out o);
		}

		public static bool checkType(IntPtr l, int p, out UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct o)
		{
			// FIXME check for it if you need it
			o = new UnityEngine.UI.Extensions.ReorderableList.ReorderableListEventStruct();
			return false;
		}

		public static bool checkType(IntPtr l, int p, out LightmapData[] t)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			int n = LuaDLL.lua_rawlen(l, p);
			t = new LightmapData[n];
			for (int k = 0; k < n; k++) {
				LuaDLL.lua_rawgeti(l, p, k + 1);
				checkType(l, -1, out t[k]);
				LuaDLL.lua_pop(l, 1);
			}
			return true;
		}

		static public bool checkType(IntPtr l, int p, out UnityEngine.Vector3[] pars)
		{
		    LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
		    int n = LuaDLL.lua_rawlen(l, p);
		    pars = new UnityEngine.Vector3[n];
		    for (int k = 0; k < n; k++)
		    {
		        LuaDLL.lua_rawgeti(l, p, k + 1);
		        checkType(l, -1, out pars[k]);
		        LuaDLL.lua_pop(l, 1);
		    }
		    return true;
		}

		static public bool checkType(IntPtr l, int p, out UnityEngine.Vector2[] pars)
		{
		    LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TTABLE);
		    int n = LuaDLL.lua_rawlen(l, p);
		    pars = new UnityEngine.Vector2[n];
		    for (int k = 0; k < n; k++)
		    {
		        LuaDLL.lua_rawgeti(l, p, k + 1);
		        checkType(l, -1, out pars[k]);
		        LuaDLL.lua_pop(l, 1);
		    }
		    return true;
		}
	}
}