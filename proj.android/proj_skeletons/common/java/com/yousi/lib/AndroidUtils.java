
package com.yousi.lib;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.IOException;

import java.net.HttpURLConnection;
import java.net.URL;

import java.util.LinkedList;
import java.util.List;
import java.util.TimeZone;

import java.util.zip.ZipInputStream;
import java.util.zip.ZipEntry;

import org.OpenUDID.OpenUDID_manager;
import org.apache.http.Header;
import org.json.JSONException;
import org.json.JSONObject;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DownloadManager;
import android.app.DownloadManager.Query;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.content.res.AssetManager;
import android.database.Cursor;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.provider.Settings.Secure;
import android.text.TextUtils;
import android.util.Log;

import android.support.v4.content.ContextCompat;
import android.support.v4.app.ActivityCompat;

import com.yousi.lib.AudioHelper.MyPlayerListener;
import com.yousi.lib.AudioHelper.MyRecorderListener;
import com.yousi.lib.http.AsyncHttpClient;
import com.yousi.lib.http.AsyncHttpResponseHandler;
import com.yousi.lib.http.TextHttpResponseHandler;

public class AndroidUtils
{
    final static String TAG = "AndroidUtils";

    private static Activity activity = null;
    private static AndroidUtilsSupport support = null;

    private static LinkedList<Activity> activities = new LinkedList<Activity>();
    private static AssetManager assetManager = null;
    public static AsyncDownloadFilesTask asyncDownloadFilesTask = null;

    public static String                versionName   = "";
    public static int                   versionCode   = -1;
    public static String                packageId     = "";
    public static String                appName       = "";
    public static int                   appIconId     = -1;

    public static final int REQUEST_RECORD_AUDIO = 0;

    public static void setActivity(final Activity activity, final AndroidUtilsSupport support)
    {
      AndroidUtils.activity = activity;
      AndroidUtils.support = support;
      AndroidUtils.assetManager = activity.getAssets();
      AndroidUtils.nativeSetContext((Context) activity, AndroidUtils.assetManager);

        try {
            PackageManager pm = activity.getPackageManager();
            ApplicationInfo appInfo = pm.getApplicationInfo(activity.getPackageName(), 0);
            PackageInfo packageInfo = pm.getPackageInfo(activity.getPackageName(), 0);

            versionName = packageInfo.versionName;
            versionCode = packageInfo.versionCode;
            packageId = packageInfo.packageName;
            appIconId = appInfo.icon;
            appName = pm.getApplicationLabel(appInfo).toString();
        } catch (Exception e) {
            Log.w(TAG, e.getMessage());
        }

        addActivity(activity);

        // Uncomment this for Google Play Market
        // ObbHelper.init(activity, versionCode);
    }

    public static Activity getActivity() {
      return activity;
    }

    public static Context getContext() {
      return activity;
    }

    public static AndroidUtilsSupport getSupport() {
      return support;
    }

    public static AssetManager getAssets() {
      return assetManager;
    }

    public static void hideAllViews() {
      support.hideAllViews();
    }

    public static void showAllViews() {
      support.showAllViews();
    }

    public static void runOnGLThread(final Runnable runnable) {
      support.runOnGLThread(runnable);
    }

    public static native void nativeSetContext(final Context pContext, final AssetManager pAssetManager);

    public static void addActivity(Activity activity) {
        activities.add(activity);
    }

    public static void removeActivity(Activity activity) {
        activities.remove(activity);
    }

    private static void finishAll() {
        for (Activity activity : activities) {
            activity.finish();
        }

        activities.clear();
    }

    public static void finishActivities() {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                finishAll();
            }
        });
    }

    public static void exit() {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                finishAll();
                android.os.Process.killProcess(android.os.Process.myPid());
                System.exit(0);
            }
        });
    }

    // for passing multiple strings to lua
    public static String encodeStrings(final String ... strings) {
        return TextUtils.join("||", strings);
    }

    public static String [] decodeStrings(final String string) {
        return TextUtils.split(string, "||");
    }

    public static void runOnUiThread(final Runnable runnable) {
      activity.runOnUiThread(runnable);
    }

    public static boolean isEmulator() {
        return isAndroidEmulator();
    }

    protected final static boolean isAndroidEmulator() {
      String model = Build.MODEL;
      // Log.d(TAG, "model=" + model);
      String product = Build.PRODUCT;
      // Log.d(TAG, "product=" + product);
      boolean isEmulator = false;
      if (product != null) {
        isEmulator = product.equals("sdk") || product.contains("_sdk") ||
          product.contains("sdk_") || product.contains("vbox");
      }
      // Log.d(TAG, "isEmulator=" + isEmulator);
      return isEmulator;
    }

    public static String getModel() {
        return Build.MODEL;
    }

    public static String getProduct() {
        return Build.PRODUCT;
    }

    public static String getDeviceId() {
        String deviceId;

        deviceId = "android_id." + Secure.getString(activity.getContentResolver(), Secure.ANDROID_ID);

        return deviceId;
    }

    public static String getDeviceModel() {
        // Log.d(TAG, "getDeviceModel: ");

        String manufacturer = Build.MANUFACTURER;
        String model = Build.MODEL;
        String result;

        if (model.startsWith(manufacturer)) {
            result = model;
        } else {
            result = manufacturer + "|" + model;
        }

        // Log.d(TAG, "getDeviceModel......." + result);

        return result;
    }

    public static String getVersionName() {
        // Log.d(TAG, "getVersionName.......");
        return versionName;
    }

    public static String getVersionCode() {
        // Log.d(TAG, "getVersionCode.......");
        return Integer.toString(versionCode);
    }

    public static String getPackageName() {
        // Log.d(TAG, "getPackageName.......");
        return packageId;
    }

    public static String getAppName() {
        // Log.d(TAG, "getAppName.......");
        return appName;
    }

    public static String getAppIconId() {
        // Log.d(TAG, "getAppIconId.......");
        return Integer.toString(appIconId);
    }

    public static String getTimezoneName() {
        // Log.d(TAG, "getTimezoneName: " + TimeZone.getDefault().getDisplayName());
        return TimeZone.getDefault().getID();
    }

    public static void showNotice(String time, String info, int id, int onComplete) {
        // Log.d(TAG, "showNotice: ");
        Long rtime = Long.parseLong(time);
        PollingUtils.startPollingService(id, rtime, info);
    }

    public static String getOpenUDID() {
        if (!OpenUDID_manager.isInitialized()) {
            OpenUDID_manager.sync(activity);
        }

        String result = OpenUDID_manager.getOpenUDID();
        // Log.d(TAG, "openUDID :: " + result);
        return result;
    }

    public static void openUrl(final String url) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Intent i = new Intent(Intent.ACTION_VIEW);
                i.setData(Uri.parse(url));
                activity.startActivity(i);
            }
        });
    }

    public static void showMessageBox(final String title, final String message,
                                      final String button, final int onComplete, final boolean cancelable) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                new AlertDialog.Builder(activity)
                .setTitle(title)
                .setMessage(message)
                .setNegativeButton(button, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        LuaUtils.invokeLuaCallback(onComplete, "");
                    }
                })
                .setCancelable(cancelable)
                .create().show();
            }
        });
    }

    public static void showDialog(final String title, final String message,
                                  final String ok, final String cancel, final int onOk, final int onCancel,
                                  final boolean cancelable) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                new AlertDialog.Builder(activity)
                .setTitle(title)
                .setMessage(message)
                .setNegativeButton(cancel, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        LuaUtils.invokeLuaCallback(onCancel, "");
                        LuaUtils.releaseLuaCallback(onOk);
                    }
                })
                .setPositiveButton(ok, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        LuaUtils.invokeLuaCallback(onOk, "");
                        LuaUtils.releaseLuaCallback(onCancel);
                    }
                })
                .setCancelable(cancelable)
                .create().show();
            }
        });
    }

    public static boolean isInternetConnectionAvailable() {
        ConnectivityManager connectivityManager
            = (ConnectivityManager) activity.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }

    public static boolean isLocalWifiAvailable() {
        ConnectivityManager connectivityManager
            = (ConnectivityManager) activity.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo wifi = connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI);
        return wifi != null && wifi.isConnected();
    }

    private static boolean isDownloadManagerAvailable() {
        try {
            if (Build.VERSION.SDK_INT < 9) { // GINGERBREAD
                return false;
            }
            Intent intent = new Intent(Intent.ACTION_MAIN);
            intent.addCategory(Intent.CATEGORY_LAUNCHER);
            intent.setClassName("com.android.providers.downloads.ui",
                                "com.android.providers.downloads.ui.DownloadList");
            List<ResolveInfo> list = activity.getPackageManager().queryIntentActivities(intent,
                                     PackageManager.MATCH_DEFAULT_ONLY);
            return list.size() > 0;
        } catch (Exception e) {
            return false;
        }
    }

    @SuppressLint("NewApi")
    public static void downloadFile(final String url, final String filename,
                                    final String title, final String desc, final int onRequestSuccess) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // Log.d(TAG, "downloadFile");
                if (isDownloadManagerAvailable()) {
                    // Log.d(TAG, "Trying to download from " + url);
                    DownloadManager.Request request = new DownloadManager.Request(Uri.parse(url));
                    request.setDescription(desc);
                    request.setTitle(title);
                    // in order for this if to run, you must use the android 3.2 to compile your app
                    if (Build.VERSION.SDK_INT >= 11) { // HONEYCOMB
                        request.allowScanningByMediaScanner();
                        request.setNotificationVisibility(DownloadManager.Request.VISIBILITY_VISIBLE_NOTIFY_COMPLETED);
                    }
                    request.setDestinationInExternalPublicDir(Environment.DIRECTORY_DOWNLOADS, filename);

                    // get download service and enqueue file
                    final DownloadManager manager = (DownloadManager) activity.getSystemService(Context.DOWNLOAD_SERVICE);
                    final long enqueue = manager.enqueue(request);

                    // add complete handler
                    // TODO refactor this, downloadFile should provide a general onComplete callback
                    // FIXME doesn't work if the app exits, might need a service instead
                    // FIXME a downloader service per game, too heavy?
                    final BroadcastReceiver onComplete = new BroadcastReceiver() {
                        public void onReceive(Context ctx, Intent intent) {
                            // Log.d(TAG, "Received download complete: " + url);
                            String action = intent.getAction();
                            if (DownloadManager.ACTION_DOWNLOAD_COMPLETE.equals(action)) {
                                long downloadId = intent.getLongExtra(DownloadManager.EXTRA_DOWNLOAD_ID, 0);
                                Query query = new Query();
                                query.setFilterById(enqueue);
                                Cursor c = manager.query(query);
                                if (c.moveToFirst()) {
                                    int columnIndex = c.getColumnIndex(DownloadManager.COLUMN_STATUS);
                                    if (DownloadManager.STATUS_SUCCESSFUL == c.getInt(columnIndex)) {
                                        String uriString = c.getString(c.getColumnIndex(DownloadManager.COLUMN_LOCAL_URI));
                                        // Log.d(TAG, "download complete enqueue=" + enqueue +
                                        //       " downloadId=" + downloadId +
                                        //       " uri=" + uriString);
                                        installApk(uriString);
                                    }
                                }
                            }
                        }
                    };
                    activity.registerReceiver(onComplete, new IntentFilter(DownloadManager.ACTION_DOWNLOAD_COMPLETE));

                    // invoking callback
                    LuaUtils.invokeLuaCallback(onRequestSuccess, "");
                } else {
                    Log.e(TAG, "DownloadManager is not available");
                }
            }
        });
    }

    public static boolean downloadFileHttp(final String fileurl, final String filename) {
        return downloadFileHttp_(fileurl, filename, 0);
    }

    private static boolean downloadFileHttp_(final String fileurl, final String filename, final int redirects) {
        int count;

        try {
            URL url = new URL(fileurl);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setInstanceFollowRedirects(true);
            conn.connect();

            // expect HTTP 200 OK, so we don't mistakenly save error report
            // instead of the file
            if (conn.getResponseCode() != HttpURLConnection.HTTP_OK) {
                // Log.d(TAG, "downloadFileHttp, Server returned HTTP " +
                //     conn.getResponseCode() + " " + conn.getResponseMessage());

                // handles redirect
                if (conn.getResponseCode() == HttpURLConnection.HTTP_MOVED_PERM ||
                    conn.getResponseCode() == HttpURLConnection.HTTP_MOVED_TEMP) {
                    String location = conn.getHeaderField("Location");

                    if (location != null && location.length() != 0) {
                        if (redirects > 5) {
                            Log.e(TAG, "downloadFileHttp, redirect=" + redirects);
                            return false;
                        }
                        else {
                            // Log.d(TAG, "downloadFileHttp, redirect to " + location);
                            return downloadFileHttp_(location, filename, redirects + 1);
                        }
                    } else {
                        return false;
                    }
                }

                return false;
            }

            int lengthOfFile = conn.getContentLength();
            // Log.d(TAG, "downloadFileHttp, Length of file: " + lengthOfFile);

            InputStream input = new BufferedInputStream(url.openStream());
            OutputStream output = new FileOutputStream(filename);
            byte data[] = new byte[4096];

            long total = 0;

            while ((count = input.read(data)) != -1) {
                total += count;
                // Log.d(TAG, "downloading file, " + (int)((total * 100) / lengthOfFile));
                output.write(data, 0, count);
            }

            output.flush();
            output.close();
            input.close();

            return true;
        } catch (Exception e) {
            Log.e(TAG, "download file(" + filename + "), from url[" + fileurl + "], failed: " + e.getLocalizedMessage());
            return false;
        }
    }

    public static void asyncDownloadFile(final String url, final String filename, final int onComplete) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // Log.d(TAG, "downloadFile " + url + " " + filename + " " + onComplete);

                AsyncTask<String, Integer, Boolean> downloadTask = new AsyncTask<String, Integer, Boolean>() {

                    @Override
                    protected Boolean doInBackground(String ... params) {
                        return downloadFileHttp(params[0], params[1]);
                    }

                    @Override
                    protected void onPostExecute(final Boolean result) {
                        LuaUtils.invokeLuaCallback(onComplete, "" + result);
                    }

                };

                downloadTask.execute(url, filename);
            }
        });
    }

    public static void installApk(final String path) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                // Log.d(TAG, "installApk path=" + path);
                File apkFile = new File(path);
                Intent intent = new Intent(Intent.ACTION_VIEW);
                intent.setDataAndType(Uri.fromFile(apkFile), "application/vnd.android.package-archive");
                activity.startActivity(intent);
            }
        });
    }

    public static void asyncHttpText(final String method, final String url, final int onComplete) {
      runOnUiThread(new Runnable() {
        @Override
        public void run() {
          AsyncHttpClient client = new AsyncHttpClient();
          client.setURLEncodingEnabled(false);

          AsyncHttpResponseHandler handler = new TextHttpResponseHandler("utf-8") {

            @Override
            public void onFailure(int statusCode, Header[] headers, String responseString, Throwable throwable) {
              JSONObject result = new JSONObject();

              try {
                result.put("success", false);
                result.put("message", throwable.getLocalizedMessage());

                LuaUtils.invokeLuaCallback(onComplete, result.toString());
              } catch (JSONException e) {
                Log.e(TAG, "json error: " + e.getMessage());
              }
            }

            @Override
            public void onSuccess(int statusCode, Header[] headers, String responseString) {
              JSONObject result = new JSONObject();
              try {
                result.put("success", true);
                result.put("response", responseString);

                LuaUtils.invokeLuaCallback(onComplete, result.toString());

              } catch (JSONException e) {
                Log.e(TAG, "json error: " + e.getMessage());
              }
            }

          };

          if (method.toUpperCase().equals("GET")) {
            client.get(url, handler);
          } else if (method.toUpperCase().equals("POST")) {
            client.post(url, handler);
          } else {
            Log.e(TAG, "unsupport http method: " + method + ", url: " + url);
          }
        }
      });
    }

    public static void asyncDownloadFiles(final String fileurls, final String filepaths,
        final String compresses, final String hashes, final String hasher,
        final String seed, final float concurrentDownloads,
        final int onProgress, final int onError, final int onFileComplete,
        final int onComplete) {
      runOnUiThread(new Runnable() {
        @Override
        public void run() {
          if (asyncDownloadFilesTask != null) {
            Log.e(TAG, "asyncDownloadFiles: an instance is already running");
            return;
          }

          asyncDownloadFilesTask = new AsyncDownloadFilesTask(fileurls
              .split("\n"), filepaths.split("\n"), compresses.split("\n"),
              hashes.split("\n"), hasher, seed,
              (int) concurrentDownloads, onProgress, onError,
              onFileComplete, onComplete);
          asyncDownloadFilesTask.start();

          // Log.d(TAG, "asyncDownloadFiles: started");
        }
      });
    }

    public static void pauseAsyncDownloadFiles(final boolean paused) {
      runOnUiThread(new Runnable() {
        @Override
        public void run() {
          if (asyncDownloadFilesTask != null && ! asyncDownloadFilesTask.isCancelled()) {
            asyncDownloadFilesTask.setPaused(paused);
            // Log.d(TAG, "pauseAsyncDownloadFiles: paused");
          }
        }
      });
    }

    public static void cancelAsyncDownloadFiles() {
      runOnUiThread(new Runnable() {
        @Override
        public void run() {
          if (asyncDownloadFilesTask != null && ! asyncDownloadFilesTask.isCancelled()) {
            asyncDownloadFilesTask.cancel(true);
            // Log.d(TAG, "cancelAsyncDownloadFiles: cancelled");
          }
        }
      });
    }

    private static int luaWebviewOnComplete = -1;

    public static void showWebView(final String url, final int luaOnComplete) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                if (luaOnComplete > 0) {
                    if (luaWebviewOnComplete > 0) {
                        Log.e(TAG, "previously a webview is shown, can't show more than 1 webview at the same time.");
                        LuaUtils.invokeLuaCallback(luaOnComplete, "{\"success\": false}");
                        return;
                    }

                    luaWebviewOnComplete = luaOnComplete;
                }

                // Log.d(TAG, "showWebview: " + url);
                Intent intent = new Intent(activity, WebViewActivity.class);
                Bundle param = new Bundle();

                param.putString("url", url);
                intent.putExtras(param);

                activity.startActivityForResult(intent, RequestCodes.FV_COCLUA_WEBVIEW);
            }
        });
    }

    public static void showLocalHtml(final String fileName, final int luaOnComplete) {
        showWebView("file:///android_asset/www/" + fileName + ".html", luaOnComplete);
    }

    public static void unpackZipFile(final String zipfile, final boolean isFromJar, final String path,
        final int onProgress, final int onComplete) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                AsyncTask<Void, Void, Boolean> unpackTask = new AsyncTask<Void, Void, Boolean>() {

                    @Override
                    protected Boolean doInBackground(Void... params) {
                        return doUnpackZipFile(zipfile, isFromJar, path, onProgress, onComplete);
                    }

                    @Override
                    protected void onPostExecute(final Boolean result) {
                        // Log.d(TAG, "unpackZipFile result=" + result);
                    }

                };

                unpackTask.execute();
            }
        });
    }

    // 2017-7-13 lt: this is slow, and essentially read the whole zip file into memory
    private static boolean doUnpackZipFile(final String zipfile, final boolean isFromJar, final String path,
        final int onProgress, final int onComplete) {
         final int BUF_SIZE = 128 * 1024;

         InputStream is;
         ZipInputStream zis;

         // Log.d(TAG, "unpackZipFile: zipfile=" + zipfile + " isFromJar=" + isFromJar + " path=" + path +
         //    " onProgress=" + onProgress + " onComplete=" + onComplete);

         try {
             String filename;
             if (isFromJar) {
                // is = assetManager.open(zipfile, AssetManager.ACCESS_RANDOM);
                is = assetManager.openFd(zipfile).createInputStream();
             } else {
                is = new FileInputStream(zipfile);
             }
             zis = new ZipInputStream(new BufferedInputStream(is, BUF_SIZE));
             ZipEntry ze;
             byte[] buffer = new byte[BUF_SIZE];
             int count;
             int i = 1;

             while ((ze = zis.getNextEntry()) != null) {
                 filename = ze.getName();

                 // Log.d(TAG, "unpackZipFile: unpack " + filename);

                 // Need to create directories if not exists, or
                 // it will generate an Exception...
                 if (ze.isDirectory()) {
                    File fmd = new File(path + filename);
                    fmd.mkdirs();
                    continue;
                 }

                 OutputStream os = new BufferedOutputStream(new FileOutputStream(path + filename), BUF_SIZE);

                 while ((count = zis.read(buffer)) != -1) {
                     os.write(buffer, 0, count);
                 }

                 os.close();
                 zis.closeEntry();

                 JSONObject result = new JSONObject();
                 try {
                     result.put("index", i);
                     result.put("filename", path + filename);
                     LuaUtils.invokeLuaCallbackNoRelease(onProgress, result.toString());
                 } catch (JSONException e) {
                     Log.e(TAG, "json error: " + e.getMessage());
                 }

                 ++i;
             }

             zis.close();

             JSONObject result = new JSONObject();
             try {
                 result.put("success", true);
                 LuaUtils.invokeLuaCallbackNoRelease(onComplete, result.toString());
             } catch (JSONException e) {
                 Log.e(TAG, "json error: " + e.getMessage());
             }

         }
         catch(IOException e) {
             Log.e(TAG, "unpackZipFile: " + e.getMessage());

             JSONObject result = new JSONObject();
             try {
                 result.put("success", false);
                 LuaUtils.invokeLuaCallbackNoRelease(onComplete, result.toString());
             } catch (JSONException e1) {
                 Log.e(TAG, "json error: " + e1.getMessage());
             }
         }
         finally {
            LuaUtils.releaseLuaCallback(onProgress);
            LuaUtils.releaseLuaCallback(onComplete);
         }

        return true;
    }

    public static boolean checkRecordingPermission() {
        if (Build.VERSION.SDK_INT >= 23) { // Build.VERSION_CODES.MARSHMALLOW
            if (ContextCompat.checkSelfPermission(activity, Manifest.permission.RECORD_AUDIO)
                    != PackageManager.PERMISSION_GRANTED) {
                ActivityCompat.requestPermissions(activity,
                    new String[]{Manifest.permission.RECORD_AUDIO},
                    REQUEST_RECORD_AUDIO);
                // Log.d(TAG, "requestPermissions RECORD_AUDIO");
                return false;
            }
        }

        return true;
    }

    public static void startRecordAudio(final String outfile, final float maxTime, final float sampleRate,
        final float channels, final float bitRate, final int onComplete) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                if (! checkRecordingPermission()) {
                    // Log.d(TAG, "checkRecordingPermission fails");

                    JSONObject result = new JSONObject();
                    try {
                        result.put("success", false);
                        result.put("status", -100);
                    } catch (JSONException e) {
                        Log.e(TAG, "json error: " + e.getMessage());
                    }
                    LuaUtils.invokeLuaCallback(onComplete, result.toString());
                    return;
                }

                // Log.d(TAG, "startRecordAudio " + outfile + " " + maxTime + " " + onComplete);

                AudioHelper.startRecording(outfile, (int) maxTime, (int) sampleRate,
                    (int) channels, (int) bitRate, new MyRecorderListener() {

                    @Override
                    public void onRecordStarted() {
                    }

                    @Override
                    public void onRecordFinished(int status) {
                        // Log.d(TAG, "startRecordAudio status=" + status);
                        JSONObject result = new JSONObject();
                        try {
                            result.put("success", (status >= 0));
                            result.put("status", status);
                        } catch (JSONException e) {
                            Log.e(TAG, "json error: " + e.getMessage());
                        }
                        LuaUtils.invokeLuaCallback(onComplete, result.toString());
                    }

                });
            }
        });
    }

    public static void stopRecordAudio() {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                AudioHelper.stopRecording();
            }
        });
    }

    public static void startPlayAudio(final String infile, final float volume, final int onStart, final int onComplete) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                int status = AudioHelper.startPlayAudio(infile, volume, new MyPlayerListener() {

                    @Override
                    public void onPlayStarted() {
                        JSONObject result = new JSONObject();
                        try {
                            result.put("success", true);
                            result.put("status", 0);
                        } catch (JSONException e) {
                            Log.e(TAG, "json error: " + e.getMessage());
                        }
                        LuaUtils.invokeLuaCallback(onStart, result.toString());
                    }

                    @Override
                    public void onPlayFinished(int status) {
                        JSONObject result = new JSONObject();
                        try {
                            result.put("success", (status >= 0));
                            result.put("status", status);
                        } catch (JSONException e) {
                            Log.e(TAG, "json error: " + e.getMessage());
                        }
                        LuaUtils.invokeLuaCallback(onComplete, result.toString());
                    }

                });

                if (status < 0) {
                    JSONObject result = new JSONObject();
                    try {
                        result.put("success", (status >= 0));
                        result.put("status", status);
                    } catch (JSONException e) {
                        Log.e(TAG, "json error: " + e.getMessage());
                    }
                    LuaUtils.invokeLuaCallback(onComplete, result.toString());
                    LuaUtils.releaseLuaCallback(onStart);
                }
            }
        });
    }

    public static void stopPlayAudio() {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                AudioHelper.stopPlayAudio();
            }
        });
    }

}
