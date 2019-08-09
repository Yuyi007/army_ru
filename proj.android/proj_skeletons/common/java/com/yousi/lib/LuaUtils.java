package com.yousi.lib;

import org.cocos2dx.lib.CCLuaJavaBridge;

import com.unity3d.player.UnityPlayer;

public class LuaUtils {

	final static String TAG = LuaUtils.class.getCanonicalName();

	public static void invokeLuaCallback(final int luaCallbackFun,
			final String result) {
		invokeLuaCallback_unity(luaCallbackFun, result);
	}

	public static void invokeLuaCallbackNoRelease(final int luaCallbackFun,
			final String result) {
		invokeLuaCallbackNoRelease_unity(luaCallbackFun, result);
	}

	public static void releaseLuaCallback(final int luaCallbackFun) {
		releaseLuaCallback_unity(luaCallbackFun);
	}

	/// using runOnGLThread
	
	protected static void invokeLuaCallback_thread(final int luaCallbackFun,
			final String result) {
		AndroidUtils.runOnGLThread(new Runnable() {
			@Override
			public void run() {
				if (luaCallbackFun > 0) {
					CCLuaJavaBridge.callLuaFunctionWithString(luaCallbackFun,
							"" + result);
					CCLuaJavaBridge.releaseLuaFunction(luaCallbackFun);
				}
			}
		});
	}

	protected static void invokeLuaCallbackNoRelease_thread(final int luaCallbackFun,
			final String result) {
		AndroidUtils.runOnGLThread(new Runnable() {
			@Override
			public void run() {
				if (luaCallbackFun > 0) {
					CCLuaJavaBridge.callLuaFunctionWithString(luaCallbackFun,
							"" + result);
				}
			}
		});
	}

	protected static void releaseLuaCallback_thread(final int luaCallbackFun) {
		AndroidUtils.runOnGLThread(new Runnable() {
			@Override
			public void run() {
				if (luaCallbackFun > 0) {
					CCLuaJavaBridge.releaseLuaFunction(luaCallbackFun);
				}
			}
		});
	}

	/// Using UnitySendMessage
	
	protected static void invokeLuaCallback_unity(final int callback, final String result) 
	{
		UnityPlayer.UnitySendMessage("LBootApp", "invokeLuaCallback", "" +
			String.format("%010d", callback) + result);
	}

	protected static void invokeLuaCallbackNoRelease_unity(final int callback, final String result) 
	{
		UnityPlayer.UnitySendMessage("LBootApp", "invokeLuaCallbackNoRelease", "" +
			String.format("%010d", callback) + result);
	}

	protected static void releaseLuaCallback_unity(final int callback) 
	{
		UnityPlayer.UnitySendMessage("LBootApp", "releaseLuaCallback", "" +
			String.format("%010d", callback));
	}
	
}
