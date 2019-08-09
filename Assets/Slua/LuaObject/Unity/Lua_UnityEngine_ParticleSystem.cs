using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem o;
			o=new UnityEngine.ParticleSystem();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			UnityEngine.ParticleSystem.Particle[] a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.SetParticles(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			UnityEngine.ParticleSystem.Particle[] a1;
			checkType(l,2,out a1);
			var ret=self.GetParticles(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCustomParticleData(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector4> a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystemCustomData a2;
			checkEnum(l,3,out a2);
			self.SetCustomParticleData(a1,a2);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCustomParticleData(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector4> a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystemCustomData a2;
			checkEnum(l,3,out a2);
			var ret=self.GetCustomParticleData(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Simulate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.Simulate(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.Simulate(a1,a2);
				return 0;
			}
			else if(argc==4){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.Simulate(a1,a2,a3);
				return 0;
			}
			else if(argc==5){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.Simulate(a1,a2,a3,a4);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				self.Play();
				return 0;
			}
			else if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Play(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				self.Pause();
				return 0;
			}
			else if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Pause(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Stop(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				self.Stop();
				return 0;
			}
			else if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Stop(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				UnityEngine.ParticleSystemStopBehavior a2;
				checkEnum(l,3,out a2);
				self.Stop(a1,a2);
				return 0;
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
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				self.Clear();
				return 0;
			}
			else if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Clear(a1);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsAlive(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				var ret=self.IsAlive();
				pushValue(l,ret);
				return 1;
			}
			else if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				var ret=self.IsAlive(a1);
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
	static public int Emit(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.Emit(a1);
				return 0;
			}
			else if(argc==3){
				UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
				UnityEngine.ParticleSystem.EmitParams a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.Emit(a1,a2);
				return 0;
			}
			return error(l,"No matched override function to call");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPlaying(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.isPlaying);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isEmitting(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.isEmitting);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isStopped(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.isStopped);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPaused(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.isPaused);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.time);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.time=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_particleCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.particleCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_randomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.randomSeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_randomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			System.UInt32 v;
			checkType(l,2,out v);
			self.randomSeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useAutoRandomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.useAutoRandomSeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useAutoRandomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useAutoRandomSeed=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_main(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.main);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_emission(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.emission);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shape(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.shape);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocityOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.velocityOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitVelocityOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.limitVelocityOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inheritVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.inheritVelocity);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.forceOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.colorOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorBySpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.colorBySpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sizeOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.sizeOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sizeBySpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.sizeBySpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rotationOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.rotationOverLifetime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rotationBySpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.rotationBySpeed);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_externalForces(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.externalForces);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_noise(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.noise);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_collision(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.collision);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trigger(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.trigger);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_subEmitters(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.subEmitters);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_textureSheetAnimation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.textureSheetAnimation);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lights(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.lights);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trails(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.trails);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_customData(IntPtr l) {
		try {
			UnityEngine.ParticleSystem self=(UnityEngine.ParticleSystem)checkSelf(l);
			pushValue(l,self.customData);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem");
		addMember(l,SetParticles);
		addMember(l,GetParticles);
		addMember(l,SetCustomParticleData);
		addMember(l,GetCustomParticleData);
		addMember(l,Simulate);
		addMember(l,Play);
		addMember(l,Pause);
		addMember(l,Stop);
		addMember(l,Clear);
		addMember(l,IsAlive);
		addMember(l,Emit);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		addMember(l,"isEmitting",get_isEmitting,null,true);
		addMember(l,"isStopped",get_isStopped,null,true);
		addMember(l,"isPaused",get_isPaused,null,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"particleCount",get_particleCount,null,true);
		addMember(l,"randomSeed",get_randomSeed,set_randomSeed,true);
		addMember(l,"useAutoRandomSeed",get_useAutoRandomSeed,set_useAutoRandomSeed,true);
		addMember(l,"main",get_main,null,true);
		addMember(l,"emission",get_emission,null,true);
		addMember(l,"shape",get_shape,null,true);
		addMember(l,"velocityOverLifetime",get_velocityOverLifetime,null,true);
		addMember(l,"limitVelocityOverLifetime",get_limitVelocityOverLifetime,null,true);
		addMember(l,"inheritVelocity",get_inheritVelocity,null,true);
		addMember(l,"forceOverLifetime",get_forceOverLifetime,null,true);
		addMember(l,"colorOverLifetime",get_colorOverLifetime,null,true);
		addMember(l,"colorBySpeed",get_colorBySpeed,null,true);
		addMember(l,"sizeOverLifetime",get_sizeOverLifetime,null,true);
		addMember(l,"sizeBySpeed",get_sizeBySpeed,null,true);
		addMember(l,"rotationOverLifetime",get_rotationOverLifetime,null,true);
		addMember(l,"rotationBySpeed",get_rotationBySpeed,null,true);
		addMember(l,"externalForces",get_externalForces,null,true);
		addMember(l,"noise",get_noise,null,true);
		addMember(l,"collision",get_collision,null,true);
		addMember(l,"trigger",get_trigger,null,true);
		addMember(l,"subEmitters",get_subEmitters,null,true);
		addMember(l,"textureSheetAnimation",get_textureSheetAnimation,null,true);
		addMember(l,"lights",get_lights,null,true);
		addMember(l,"trails",get_trails,null,true);
		addMember(l,"customData",get_customData,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem),typeof(UnityEngine.Component));
	}
}
