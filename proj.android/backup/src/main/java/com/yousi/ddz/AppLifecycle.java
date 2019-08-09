package com.yousi.ddz;

import java.nio.MappedByteBuffer;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.util.DisplayMetrics;

import com.yousi.lib.AndroidUtils;

/**
 * Game related lifecycle utils
 *
 */
public class AppLifecycle {

	static int screenWidth = 0;
	static int screenHeight = 0;

	static MappedByteBuffer mem = null;
	static {
		/* try {
			File f = new File("/sdcard/ddz/a.txt");
			f.delete();
			FileChannel fc = new RandomAccessFile(f, "rw").getChannel();
			mem = fc.map(FileChannel.MapMode.PRIVATE, 0, 128 * 1024 * 1024);
			Log.d("Unity", "Memory mapping file success");

			System.loadLibrary("luajit");
			Log.d("Unity", "luajit loaded");
		} catch (FileNotFoundException e) {
			throw new RuntimeException("Creating memory-mapped file failed! " + e.getMessage());
		} catch (IOException e) {
			throw new RuntimeException("Memory mapping file failed! " + e.getMessage());
		} finally {
			// mem = null;
			System.gc();
		}*/

		System.loadLibrary("luajit");
		System.loadLibrary("sodium");
		System.loadLibrary("slua");
	}

	public static void onCreate(UnityPlayerActivity activity, Bundle savedInstanceState)
	{
		AndroidUtils.setActivity(activity, activity);

		DisplayMetrics dm = activity.getResources().getDisplayMetrics();
		screenWidth = dm.widthPixels;
		screenHeight = dm.heightPixels;
	}

  public static void onStart(UnityPlayerActivity activity)
  {

  }

	public static void onDestroy(UnityPlayerActivity activity)
	{

	}

	public static void onPause(UnityPlayerActivity activity)
	{

	}

	public static void onResume(UnityPlayerActivity activity)
	{

	}

	public static void onStop(UnityPlayerActivity activity)
	{

	}

	public static void onActivityResult(UnityPlayerActivity activity, int requestCode, int resultCode, Intent data)
	{

	}

	public static void onConfigurationChanged(UnityPlayerActivity activity, Configuration newConfig)
	{
		// fix android screen glitch after configuration change
//		mUnityPlayer.getView().getLayoutParams().width = screenWidth;
//		mUnityPlayer.getView().getLayoutParams().height = screenHeight;
	}

	public static void onWindowFocusChanged(UnityPlayerActivity activity, boolean hasFocus)
	{

	}

}
