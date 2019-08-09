package com.yousi.ddz;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.app.Activity;

public class SplashActivity extends Activity {

    private static int SPLASH_TIME_OUT = 500;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        // Intent intent = new Intent(this, UnityPlayerActivity.class);
        // startActivity(intent);
        // finish();


        new Handler().postDelayed(new Runnable() {
        /*
         * Showing splash screen with a timer. This will be useful when you
         * want to show case your app logo / company
         */
          @Override
          public void run() {
            // This method will be executed once the timer is over
            // Start your app main activity
            Intent i = new Intent(SplashActivity.this, UnityPlayerActivity.class);
            startActivity(i);
            // close this activity
            finish();
          }
       }, SPLASH_TIME_OUT);

    }
}