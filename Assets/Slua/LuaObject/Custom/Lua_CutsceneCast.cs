using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CutsceneCast : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RefreshData(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			self.RefreshData();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getAllBillboards_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=CutsceneCast.getAllBillboards(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Cutscene(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.Cutscene);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Cutscene(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			CinemaDirector.Cutscene v;
			checkType(l,2,out v);
			self.Cutscene=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllRigidBodies(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllRigidBodies);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllAtgs(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllAtgs);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllTexts(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllTexts);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllCams(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllCams);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllBillboards(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllBillboards);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AllActors(IntPtr l) {
		try {
			CutsceneCast self=(CutsceneCast)checkSelf(l);
			pushValue(l,self.AllActors);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CutsceneCast");
		addMember(l,RefreshData);
		addMember(l,getAllBillboards_s);
		addMember(l,"Cutscene",get_Cutscene,set_Cutscene,true);
		addMember(l,"AllRigidBodies",get_AllRigidBodies,null,true);
		addMember(l,"AllAtgs",get_AllAtgs,null,true);
		addMember(l,"AllTexts",get_AllTexts,null,true);
		addMember(l,"AllCams",get_AllCams,null,true);
		addMember(l,"AllBillboards",get_AllBillboards,null,true);
		addMember(l,"AllActors",get_AllActors,null,true);
		createTypeMetatable(l,null, typeof(CutsceneCast),typeof(UnityEngine.MonoBehaviour));
	}
}
