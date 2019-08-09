package com.yousi.lib;

import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.SystemClock;
import android.util.Log;

/**
 * Polling Tools
 *
 * @Author Ryan
 * @Create 2013-7-13 上午10:14:43
 */
public class PollingUtils {
    final private static String TAG     = PollingUtils.class.getCanonicalName();

    private static Class<?>     cls     = PollingService.class;
    private static String       action  = PollingService.ACTION;

    /**
     * @param id
     *            : different timer clock
     * @param startTime
     *            : from now to timeDis, 24 hours per day
     * @param msg
     *            : shown message
     */
    public static void startPollingService(int id, long waitSec, String msg) {
        Context context = AndroidUtils.getContext();
        AlarmManager manager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
        Intent intent = new Intent(context, cls);
        intent.setAction(action);
        intent.putExtra("msg", msg); // 设置传递的参数

        Log.d(TAG, "Polling util start New message!=======" + msg + "," + id + "," + waitSec);

        PendingIntent pendingIntent = PendingIntent.getService(context, id, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        waitSec = SystemClock.elapsedRealtime() + waitSec * 1000;

        manager.setRepeating(AlarmManager.ELAPSED_REALTIME, waitSec, 24 * 3600 * 1000, pendingIntent); // 1*24*3600
    }

    /**
     *
     * @param id
     *            : used to close service.
     */
    public static void stopPollingService(int id) {
        Context context = AndroidUtils.getContext();
        AlarmManager manager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
        Intent intent = new Intent(context, cls);
        intent.setAction(action);
        PendingIntent pendingIntent = PendingIntent.getService(context, id, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        manager.cancel(pendingIntent);
    }
}
