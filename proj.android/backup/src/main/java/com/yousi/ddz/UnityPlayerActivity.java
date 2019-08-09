package com.yousi.ddz;

import com.yousi.lib.AndroidUtils;
import com.yousi.lib.AndroidUtilsSupport;
import com.unity3d.player.*;

import com.yousi.ddz.SplashController;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.MappedByteBuffer;
import java.nio.channels.FileChannel;

import android.app.Activity;
import android.content.Intent;
import android.content.res.Configuration;
import android.graphics.PixelFormat;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.util.Log;



public class UnityPlayerActivity extends Activity implements AndroidUtilsSupport
{
	private static final String TAG = "Unity";

	protected UnityPlayer mUnityPlayer; // don't change the name of this variable; referenced from native code

	// Setup activity layout
	@Override protected void onCreate (Bundle savedInstanceState)
	{
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		super.onCreate(savedInstanceState);

		getWindow().setFormat(PixelFormat.RGBX_8888); // <--- This makes xperia play happy

		mUnityPlayer = new UnityPlayer(this);
		setContentView(mUnityPlayer);
		mUnityPlayer.requestFocus();

		Log.d(TAG, "UnityPlayerActivity onCreate");

		AppLifecycle.onCreate(this, savedInstanceState);
		SDKLifecycle.onCreate(this, savedInstanceState);
		SplashController.onCreate(mUnityPlayer);
		SplashController.doShowSplashScreen();
	}

  @Override protected void onStart()
  {
    super.onStart();
    AppLifecycle.onStart(this);
    SDKLifecycle.onStart(this);
  }

	// Quit Unity
	@Override protected void onDestroy ()
	{
		mUnityPlayer.quit();
		super.onDestroy();

		SDKLifecycle.onDestroy(this);
		AppLifecycle.onDestroy(this);
	}

	// Pause Unity
	@Override protected void onPause()
	{
		super.onPause();
		mUnityPlayer.pause();

		SDKLifecycle.onPause(this);
		AppLifecycle.onPause(this);
	}

	// Resume Unity
	@Override protected void onResume()
	{
		super.onResume();
		mUnityPlayer.resume();

		SDKLifecycle.onResume(this);
		AppLifecycle.onResume(this);
	}

	@Override protected void onStop()
	{
		super.onStop();

		SDKLifecycle.onStop(this);
		AppLifecycle.onStop(this);
	}

	@Override
  protected void onActivityResult(int requestCode, int resultCode, Intent data) {
      super.onActivityResult(requestCode, resultCode, data);

	    SDKLifecycle.onActivityResult(this, requestCode, resultCode, data);
	    AppLifecycle.onActivityResult(this, requestCode, resultCode, data);
  }

  @Override
  protected void onNewIntent(Intent intent) {
      super.onNewIntent(intent);
      SDKLifecycle.onNewIntent(intent);
  }

	// This ensures the layout will be correct.
	@Override public void onConfigurationChanged(Configuration newConfig)
	{
		super.onConfigurationChanged(newConfig);
		mUnityPlayer.configurationChanged(newConfig);

		SDKLifecycle.onConfigurationChanged(this, newConfig);
		AppLifecycle.onConfigurationChanged(this, newConfig);
	}

	// Notify Unity of the focus change.
	@Override public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		mUnityPlayer.windowFocusChanged(hasFocus);

		SDKLifecycle.onWindowFocusChanged(this, hasFocus);
		AppLifecycle.onWindowFocusChanged(this, hasFocus);
	}

	// For some reason the multiple keyevent type is not supported by the ndk.
	// Force event injection by overriding dispatchKeyEvent().
	@Override public boolean dispatchKeyEvent(KeyEvent event)
	{
		if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
			return mUnityPlayer.injectEvent(event);
		return super.dispatchKeyEvent(event);
	}

	// Pass any events not handled by (unfocused) views straight to UnityPlayer
	@Override public boolean onKeyUp(int keyCode, KeyEvent event)     { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onKeyDown(int keyCode, KeyEvent event)   { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onTouchEvent(MotionEvent event)          { return mUnityPlayer.injectEvent(event); }
	/*API12*/ public boolean onGenericMotionEvent(MotionEvent event)  { return mUnityPlayer.injectEvent(event); }



	public void showAllViews()
	{
		mUnityPlayer.setVisibility(View.VISIBLE);
	}

	public void hideAllViews()
	{
		mUnityPlayer.setVisibility(View.INVISIBLE);
	}

	public void runOnGLThread(final Runnable r) throws RuntimeException
	{
		throw new RuntimeException("not implemented yet");
	}

}
