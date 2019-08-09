using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_SceneObject : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject o;
			o=new UnityEngine.UI.Extensions.SceneObject();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.name);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_name(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.name=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_prefabName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.prefabName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_prefabName(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.prefabName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.id);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.id=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_idParent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.idParent);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_idParent(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.idParent=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_active(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.active);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_active(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.active=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.position);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_position(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.position=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_localScale(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.localScale);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_localScale(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.localScale=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.rotation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.rotation=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_objectComponents(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			pushValue(l,self.objectComponents);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_objectComponents(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.SceneObject self=(UnityEngine.UI.Extensions.SceneObject)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UI.Extensions.ObjectComponent> v;
			checkType(l,2,out v);
			self.objectComponents=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.SceneObject");
		addMember(l,"name",get_name,set_name,true);
		addMember(l,"prefabName",get_prefabName,set_prefabName,true);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"idParent",get_idParent,set_idParent,true);
		addMember(l,"active",get_active,set_active,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"localScale",get_localScale,set_localScale,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"objectComponents",get_objectComponents,set_objectComponents,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.SceneObject));
	}
}
