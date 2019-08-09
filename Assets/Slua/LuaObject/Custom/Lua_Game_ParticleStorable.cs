using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_ParticleStorable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duration(IntPtr l) {
		try {
			Game.ParticleStorable self=(Game.ParticleStorable)checkSelf(l);
			pushValue(l,self.duration);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duration(IntPtr l) {
		try {
			Game.ParticleStorable self=(Game.ParticleStorable)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.duration=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_characterEmitterRoot(IntPtr l) {
		try {
			Game.ParticleStorable self=(Game.ParticleStorable)checkSelf(l);
			pushValue(l,self.characterEmitterRoot);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_characterEmitterRoot(IntPtr l) {
		try {
			Game.ParticleStorable self=(Game.ParticleStorable)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.characterEmitterRoot=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.ParticleStorable");
		addMember(l,"duration",get_duration,set_duration,true);
		addMember(l,"characterEmitterRoot",get_characterEmitterRoot,set_characterEmitterRoot,true);
		createTypeMetatable(l,null, typeof(Game.ParticleStorable),typeof(UnityEngine.MonoBehaviour));
	}
}
