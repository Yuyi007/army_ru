package com.yousi.lib;

import android.app.Notification;
import android.app.Notification.Builder;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.util.Log;
import android.os.Bundle;

import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;

/**
 * Polling service
 *
 * @Author Ryan
 * @Create 2013-7-13 上午10:18:44
 */
public class PollingService extends Service {

    public static final String  ACTION  = "com.yousi.lib.PollingService";

    final private static String TAG     = PollingService.class.getCanonicalName();

    private Builder        nBuild;
    private NotificationManager mManager;
    private String              msg     = "";
    private String              appName = "";

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        // initNotifiManager();
    }

    @Override
    public void onStart(Intent intent, int startId) {
        if (intent != null) {
            Bundle bundle = intent.getExtras();
            if (bundle != null) {
                Log.d("Coclua", "show notification mesage" + bundle.getString("msg"));
                String newMsg = bundle.getString("msg");
                if (newMsg != "") {
                    msg = newMsg;
                }

            }
            new PollingThread().start();
        }

    }

    private void initNotifiManager() {
        mManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        nBuild = new Notification.Builder(this);
        try {
            PackageManager pm = this.getPackageManager();
            ApplicationInfo appInfo = pm.getApplicationInfo(this.getPackageName(), 0);
            appName = pm.getApplicationLabel(appInfo).toString();
            nBuild.setSmallIcon(appInfo.icon)
                .setContentTitle(appName)
                .setAutoCancel(true);
        } catch (Exception e) {
            Log.e(TAG, e.getLocalizedMessage());
        }
    }

    private void showNotification() {
        initNotifiManager();
        nBuild.setWhen(System.currentTimeMillis())
                    .setContentText(msg);
        Intent i;
        try {
            i = new Intent(this, Class.forName("com.yousi.coclua.Main"));
            i.setAction("android.intent.action.MAIN");
            i.addCategory("android.intent.category.LAUNCHER");
            PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, i, Intent.FLAG_ACTIVITY_NEW_TASK);
            nBuild.setContentIntent(pendingIntent);
            Notification n = nBuild.getNotification();
            n.defaults = Notification.DEFAULT_SOUND;
            mManager.notify(0, n);
        } catch (ClassNotFoundException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    /**
     * Polling thread
     *
     * @Author Ryan
     * @Create 2013-7-13 上午10:18:34
     */
    int count = 0;

    class PollingThread extends Thread {
        @Override
        public void run() {
            showNotification();
            Log.d(TAG, "======================================= New message!");
        }
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        Log.d(TAG, "=========================================== Service:onDestroy");
    }

}
