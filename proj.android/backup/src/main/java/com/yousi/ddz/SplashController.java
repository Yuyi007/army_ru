package com.yousi.ddz;

import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.FrameLayout;

import android.app.Activity;
import com.unity3d.player.*;
import android.widget.ImageView.ScaleType;
import android.view.ViewParent;
import com.yousi.ddz.R;

import com.yousi.lib.AndroidUtils;

/**
 * splash controller
 *
 */
public class SplashController {

  static protected UnityPlayer mUnityPlayer;
  static protected FrameLayout layout;

  public static void onCreate(UnityPlayer unityPlayer)
  {
    mUnityPlayer = unityPlayer;
  }

  public static void showSplashScreen()
  {
    Activity activity = AndroidUtils.getActivity();
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        doShowSplashScreen();
      }
    });
  }

  public static void hideSplashScreen()
  {
    Activity activity = AndroidUtils.getActivity();
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        doHideSplashScreen();
      }
    });
  }

  protected static void doShowSplashScreen()
  {
    Activity activity = AndroidUtils.getActivity();

    if (layout == null)
    {
      layout = new FrameLayout(activity);
    }

    layout.setAnimation(null);

    ViewGroup vg = (ViewGroup)mUnityPlayer.getParent();
    if (vg != null)
    {
      vg.removeView(mUnityPlayer);
    }
    layout.addView(mUnityPlayer);

    ImageView img = new ImageView(activity);
    img.setImageResource(R.mipmap.splash);
    img.setScaleType(ScaleType.FIT_XY);
    img.setAnimation(null);
    layout.addView(img);

    activity.overridePendingTransition(0, 0);
    activity.setContentView(layout);
  }

  protected static void doHideSplashScreen()
  {
    Activity activity = AndroidUtils.getActivity();
    layout.removeAllViews();
    layout = null;

    activity.setContentView(mUnityPlayer);
    mUnityPlayer.requestFocus();
  }

}

