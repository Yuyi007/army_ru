using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_TouchScreenKeyboardType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.TouchScreenKeyboardType");
		addMember(l,0,"Default");
		addMember(l,1,"ASCIICapable");
		addMember(l,2,"NumbersAndPunctuation");
		addMember(l,3,"URL");
		addMember(l,4,"NumberPad");
		addMember(l,5,"PhonePad");
		addMember(l,6,"NamePhonePad");
		addMember(l,7,"EmailAddress");
		addMember(l,8,"NintendoNetworkAccount");
		addMember(l,9,"Social");
		addMember(l,10,"Search");
		LuaDLL.lua_pop(l, 1);
	}
}
