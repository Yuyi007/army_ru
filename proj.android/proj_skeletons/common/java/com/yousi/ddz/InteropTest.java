package com.yousi.ddz;

import org.cocos2dx.lib.CCLuaJavaBridge;

import android.util.Log;

public class InteropTest {

	final static String MODULE = "InteropTest";
	
	public static void testCall(String str, float i, boolean b, int cb) {
		Log.d(MODULE, "testCall");
		Log.d(MODULE, "str=" + str);
		Log.d(MODULE, "i=" + i);
		Log.d(MODULE, "b=" + b);
		Log.d(MODULE, "callback=" + cb);
		
		CCLuaJavaBridge.callLuaFunctionWithString(cb, "happy reply");
		CCLuaJavaBridge.releaseLuaFunction(cb);
	}
}
