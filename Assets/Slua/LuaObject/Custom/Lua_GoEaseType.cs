using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GoEaseType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"GoEaseType");
		addMember(l,0,"Linear");
		addMember(l,1,"SineIn");
		addMember(l,2,"SineOut");
		addMember(l,3,"SineInOut");
		addMember(l,4,"QuadIn");
		addMember(l,5,"QuadOut");
		addMember(l,6,"QuadInOut");
		addMember(l,7,"CubicIn");
		addMember(l,8,"CubicOut");
		addMember(l,9,"CubicInOut");
		addMember(l,10,"QuartIn");
		addMember(l,11,"QuartOut");
		addMember(l,12,"QuartInOut");
		addMember(l,13,"QuintIn");
		addMember(l,14,"QuintOut");
		addMember(l,15,"QuintInOut");
		addMember(l,16,"ExpoIn");
		addMember(l,17,"ExpoOut");
		addMember(l,18,"ExpoInOut");
		addMember(l,19,"CircIn");
		addMember(l,20,"CircOut");
		addMember(l,21,"CircInOut");
		addMember(l,22,"ElasticIn");
		addMember(l,23,"ElasticOut");
		addMember(l,24,"ElasticInOut");
		addMember(l,25,"Punch");
		addMember(l,26,"BackIn");
		addMember(l,27,"BackOut");
		addMember(l,28,"BackInOut");
		addMember(l,29,"BounceIn");
		addMember(l,30,"BounceOut");
		addMember(l,31,"BounceInOut");
		addMember(l,32,"AnimationCurve");
		LuaDLL.lua_pop(l, 1);
	}
}
