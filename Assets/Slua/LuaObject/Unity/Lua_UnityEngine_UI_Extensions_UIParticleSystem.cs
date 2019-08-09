using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Extensions_UIParticleSystem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem o;
			o=new UnityEngine.UI.Extensions.UIParticleSystem();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_particleTexture(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem self=(UnityEngine.UI.Extensions.UIParticleSystem)checkSelf(l);
			pushValue(l,self.particleTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_particleTexture(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem self=(UnityEngine.UI.Extensions.UIParticleSystem)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.particleTexture=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_particleSprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem self=(UnityEngine.UI.Extensions.UIParticleSystem)checkSelf(l);
			pushValue(l,self.particleSprite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_particleSprite(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem self=(UnityEngine.UI.Extensions.UIParticleSystem)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.particleSprite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainTexture(IntPtr l) {
		try {
			UnityEngine.UI.Extensions.UIParticleSystem self=(UnityEngine.UI.Extensions.UIParticleSystem)checkSelf(l);
			pushValue(l,self.mainTexture);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Extensions.UIParticleSystem");
		addMember(l,"particleTexture",get_particleTexture,set_particleTexture,true);
		addMember(l,"particleSprite",get_particleSprite,set_particleSprite,true);
		addMember(l,"mainTexture",get_mainTexture,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Extensions.UIParticleSystem),typeof(UnityEngine.UI.MaskableGraphic));
	}
}
