/**
 * ObbHelper.java
 *
 */
package com.yousi.lib;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Vector;

import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager.NameNotFoundException;
import android.os.AsyncTask;
import android.os.Environment;
import android.os.Messenger;
import android.util.Log;

import com.android.vending.expansion.zipfile.APKExpansionSupport;
import com.android.vending.expansion.zipfile.ZipResourceFile;
import com.android.vending.expansion.zipfile.ZipResourceFile.ZipEntryRO;
import com.google.android.vending.expansion.downloader.DownloadProgressInfo;
import com.google.android.vending.expansion.downloader.DownloaderClientMarshaller;
import com.google.android.vending.expansion.downloader.DownloaderServiceMarshaller;
import com.google.android.vending.expansion.downloader.IDownloaderClient;
import com.google.android.vending.expansion.downloader.IDownloaderService;
import com.google.android.vending.expansion.downloader.IStub;
import com.google.android.vending.expansion.downloader.impl.DownloaderService;

/**
 * Helper with OBB Package related
 *
 * NOTE:
 * The file downloading part is not tested, because we rely on in-game update in case that
 * the obb file is not downloaded by Google
 *
 */
public class ObbHelper {

  final private static String TAG = ObbHelper.class.getCanonicalName();

  final private static int BUF_SIZE = 256 * 1024;

  final private static int FIRST_MAIN_EXPANSION_FILE_VERSION = 5;
  final private static int FIRST_PATCH_EXPANSION_FILE_VERSION = 5;

  // 2014-12-08 lt:
  // Just copied from SampleDownloaderActivity
  // The hard coding of version and file length just sucks
  /**
   * Here is where you place the data that the validator will use to determine
   * if the file was delivered correctly. This is encoded in the source code
   * so the application can easily determine whether the file has been
   * properly delivered without having to talk to the server. If the
   * application is using LVL for licensing, it may make sense to eliminate
   * these checks and to just rely on the server.
   */
  private static final XAPKFile[] xAPKS = {
    new XAPKFile(
        true, // true signifies a main file
        FIRST_MAIN_EXPANSION_FILE_VERSION,
        // against
        687801613L // the length of the file in bytes
        ),
        new XAPKFile(
            false, // false signifies a patch file
            FIRST_PATCH_EXPANSION_FILE_VERSION, // the version of the APK that the patch file was uploaded
            // against
            512860L // the length of the patch file in bytes
            )
  };

  // The shared path to all app expansion files
  final private static String EXP_PATH = "/Android/obb/";

  static Activity activity = null;
  static int versionCode = -1;
  static AsyncTask<String, Integer, Long> uncompressExpansionFileTask = null;
  static AsyncTask<String, Integer, Long> uncompressFilesTask = null;
  static AsyncTask<String, Integer, Long> uncompressOneFileTask = null;
  static ObbDownloaderClient downloadClient = null;

  public static void init(Activity act, int version) {
    activity = act;
    versionCode = version;
  }

  private static int getMainExpansionFileVersion() {
    return versionCode;
  }

  private static int getPatchExpansionFileVersion() {
    return versionCode;
  }

  /** Lua Interface begin **/

  public static void getExpansionFilesLua(final int onComplete) {
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        final String files [] = getAPKExpansionFiles(activity,
            getMainExpansionFileVersion(), getPatchExpansionFileVersion());

        if (onComplete > 0) {
          AndroidUtils.runOnGLThread(new Runnable() {
            @Override
            public void run() {
              JSONObject result = new JSONObject();
              try {
                if (files.length > 0) {
                  result.put("main", files[0]);
                }
                if (files.length > 1) {
                  result.put("patch", files[1]);
                }
              } catch (JSONException e) {
                Log.e(TAG, "Json Error " + e.getMessage());
                e.printStackTrace();
              }
              LuaUtils.invokeLuaCallback(onComplete, result.toString());
            }
          });
        }
      }
    });
  }

  public static void uncompressExpansionFileLua(final String destpath, final int onProgress, final int onComplete) {
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        if (uncompressExpansionFileTask != null) {
          uncompressExpansionFileTask.cancel(true);
        }
        uncompressExpansionFileTask = new UncompressExpansionFileTask(destpath, onProgress, onComplete);
        uncompressExpansionFileTask.execute("");
      }
    });
  }

  public static void uncompressFilesLua(final String destpath, final String filesStr, final int onProgress, final int onComplete) {
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        if (uncompressFilesTask != null) {
          uncompressFilesTask.cancel(true);
        }
        final String [] files = filesStr.split("\n");
        uncompressFilesTask = new UncompressFilesTask(destpath, files, onProgress, onComplete);
        uncompressFilesTask.execute("");
      }
    });
  }

  public static void uncompressOneFileLua(final String filepath, final String destfile, final int onComplete) {
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        if (uncompressOneFileTask != null) {
          uncompressOneFileTask.cancel(true);
        }
        uncompressOneFileTask = new UncompressOneFileTask(filepath, destfile, onComplete);
        uncompressOneFileTask.execute("");
      }
    });
  }

  public static void downloadExpansionFileLua(final int onProgress, final int onComplete) {
    activity.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        downloadExpansionFile(onProgress, onComplete);
      }
    });
  }

  /** Lua Interface end **/

  public static void onResume() {
    if (null != downloadClient) {
      downloadClient.onResume();
    }
  }

  public static void onStop() {
    if (null != downloadClient) {
      downloadClient.onStop();
    }

    // There is no need to stop the async tasks as checksum and retry is
    // built into ObbLocalUpdater and UpdateManager
  }

  /**
   * Taken from google code
   */
  public static String[] getAPKExpansionFiles(Context ctx, int mainVersion, int patchVersion) {
    String packageName = ctx.getPackageName();
    Vector<String> ret = new Vector<String>();
    if (Environment.getExternalStorageState().equals(
        Environment.MEDIA_MOUNTED)) {
      // Build the full path to the app's expansion files
      File [] roots = new File [] { Environment.getExternalStorageDirectory(), new File("/sdcard"), new File("/sdcard/0") };
      for (File root : roots) {
        if (! ret.isEmpty()) {
          break;
        }

        File expPath = new File(root.toString() + EXP_PATH + packageName);
        Log.d(TAG, "checking directory " + expPath.toString());

        // Check that expansion file path exists
        if (expPath.exists()) {
          if ( mainVersion > 0 ) {
            String strMainPath = expPath + File.separator + "main." + mainVersion + "." + packageName + ".obb";
            Log.d(TAG, "checking file " + strMainPath);
            File main = new File(strMainPath);
            if ( main.isFile() ) {
              ret.add(strMainPath);
            }
          }
          if ( patchVersion > 0 ) {
            String strPatchPath = expPath + File.separator + "patch." + mainVersion + "." + packageName + ".obb";
            Log.d(TAG, "checking file " + strPatchPath);
            File main = new File(strPatchPath);
            if ( main.isFile() ) {
              ret.add(strPatchPath);
            }
          }
        }
      }
    }

    String[] retArray = new String[ret.size()];
    ret.toArray(retArray);
    return retArray;
  }

  public static ZipResourceFile getAPKExpansionZipFile(Context context, int mainVersion, int patchVersion) throws IOException {
    String [] expansionFiles = getAPKExpansionFiles(context, mainVersion, patchVersion);
    return APKExpansionSupport.getResourceZipFile(expansionFiles);
  }

  /**
   * uncompress the expansion file content to specified path
   */
  static class UncompressExpansionFileTask extends AsyncTask<String, Integer, Long> {

    String destpath;
    int onProgress = -1;
    int onComplete = -1;
    boolean success = false;

    public UncompressExpansionFileTask(final String destpath, final int onProgress, final int onComplete) {
      this.destpath = destpath;
      this.onProgress = onProgress;
      this.onComplete = onComplete;
    }

    @Override
    protected Long doInBackground(String... arg0) {
      try {
        final ZipResourceFile zipFile = getAPKExpansionZipFile(activity,
            getMainExpansionFileVersion(), getPatchExpansionFileVersion());
        final ZipEntryRO [] entries = zipFile.getAllEntries();
        int lastCur = 0;
        for (int i = 0; i < entries.length; ++i) {
          ZipEntryRO entry = entries[i];

          String outfile = destpath + '/' + entry.mFileName;
          File ofile = new File(outfile);

          if (entry.mUncompressedLength > 0) {
            ofile.getParentFile().mkdirs();

            InputStream is = zipFile.getInputStream(entry.mFileName);
            OutputStream os = new FileOutputStream(outfile);
            MessageDigest digestIn = getDigest();

            Log.d(TAG, "copying obb file " + entry.mFileName + " to " + outfile + "...");

            byte [] buf = new byte [BUF_SIZE];
            int len = is.read(buf);
            while (len > 0) {
              digestIn.update(buf, 0, len);
              os.write(buf, 0, len);
              len = is.read(buf);
            }

            os.close();
            is.close();

            // verify checksum
            InputStream is2 = new FileInputStream(outfile);
            MessageDigest digestOut = getDigest();

            len = is2.read(buf);
            while (len > 0) {
              digestOut.update(buf, 0, len);
              len = is2.read(buf);
            }

            is2.close();

            if (! Arrays.equals(digestIn.digest(), digestOut.digest())) {
              throw new IOException("checksum not match");
            }
          }
          else {
            Log.d(TAG, "skipping obb file " + entry.mFileName);
          }

          final int cur = (i * 100 / entries.length);
          if (cur > lastCur) {
            lastCur = cur;
            publishProgress(cur);
            if (isCancelled()) break;
          }
        }

        success = true;
      } catch (IOException e) {
        Log.e(TAG, "uncompressExpansionFile IOException " + e.getMessage());
      } catch (NoSuchAlgorithmException e1) {
        Log.e(TAG, "uncompressExpansionFile NoSuchAlgorithmException " + e1.getMessage());
        e1.printStackTrace();
      }

      return null;
    }

    @Override
    protected void onProgressUpdate(final Integer... progress) {
      if (onProgress > 0) {
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();
            try {
              result.put("cur", progress[0]);
              result.put("total", 100);
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallbackNoRelease(onProgress, result.toString());
          }
        });
      }
    }

    @Override
    protected void onPostExecute(Long result) {
      if (onProgress > 0) {
        LuaUtils.releaseLuaCallback(onProgress);
        onProgress = -1;
      }

      if (onComplete > 0) {
        final boolean res = success;
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();
            try {
              result.put("success", res);
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallback(onComplete, result.toString());
            onComplete = -1;
          }
        });
      }

      uncompressExpansionFileTask = null;
    }
  }

  /**
   * uncompress specified files content to specified path
   */
  static class UncompressFilesTask extends AsyncTask<String, Integer, Long> {

    String destpath;
    String [] files;
    int onProgress = -1;
    int onComplete = -1;
    List<String> failedFiles = new ArrayList<String>();
    boolean success = false;

    public UncompressFilesTask(final String destpath, final String [] files, final int onProgress, final int onComplete) {
      this.destpath = destpath;
      this.files = files;
      this.onProgress = onProgress;
      this.onComplete = onComplete;
    }

    @Override
    protected Long doInBackground(String... arg0) {
      ZipResourceFile zipFile = null;

      try {
        zipFile = getAPKExpansionZipFile(activity,
            getMainExpansionFileVersion(), getPatchExpansionFileVersion());
      } catch (IOException e2) {
        Log.e(TAG, "uncompressFiles getExpansionFiles IOException " + e2.getMessage());
        e2.printStackTrace();
      }

      if (zipFile != null) {
        int lastCur = 0;
        for (int i = 0; i < files.length; ++i) {
          String file = files[i];
          boolean fileSuccess = false;

          if (file == null || file.length() == 0)
            continue;

          try {
            String outfile = destpath + '/' + file;
            File ofile = new File(outfile);

            ofile.getParentFile().mkdirs();

            InputStream is = zipFile.getInputStream(file);
            OutputStream os = new FileOutputStream(outfile);
            MessageDigest digestIn = getDigest();

            Log.d(TAG, "copying obb file " + file + " to " + destpath + "...");

            if (is == null || os == null) {
              throw new IOException("can't open file for reading/writing");
            }

            byte [] buf = new byte [BUF_SIZE];
            int len = is.read(buf);
            while (len > 0) {
              digestIn.update(buf, 0, len);
              os.write(buf, 0, len);
              len = is.read(buf);
            }

            os.close();
            is.close();

            // verify checksum
            InputStream is2 = new FileInputStream(outfile);
            MessageDigest digestOut = getDigest();

            len = is2.read(buf);
            while (len > 0) {
              digestOut.update(buf, 0, len);
              len = is2.read(buf);
            }

            is2.close();

            if (! Arrays.equals(digestIn.digest(), digestOut.digest())) {
              throw new IOException("checksum not match");
            }

            fileSuccess = true;

            final int k = i;
            final int cur = (i * 100 / files.length);
            if (cur > lastCur && onProgress > 0) {
              lastCur = cur;
              publishProgress(cur, k);
              if (isCancelled()) break;
            }
          } catch (IOException e) {
            Log.e(TAG, "uncompressFiles IOException " + e.getMessage());
            e.printStackTrace();
          } catch (NoSuchAlgorithmException e1) {
            Log.e(TAG, "uncompressFiles NoSuchAlgorithmException " + e1.getMessage());
            e1.printStackTrace();
          }

          if (! fileSuccess) {
            failedFiles.add(file);
          }
        }

        success = true;
      }

      return null;
    }

    @Override
    protected void onProgressUpdate(final Integer... progress) {
      if (onProgress > 0) {
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();
            try {
              result.put("k", progress[1] + 1);
              result.put("cur", progress[0]);
              result.put("total", 100);
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallbackNoRelease(onProgress, result.toString());
          }
        });
      }
    }

    @Override
    protected void onPostExecute(Long result) {
      if (onProgress > 0) {
        LuaUtils.releaseLuaCallback(onProgress);
        onProgress = -1;
      }

      if (onComplete > 0) {
        final boolean res = success;
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();

            StringBuilder sb = new StringBuilder();
            for (String file : failedFiles) {
              sb.append(file);
              sb.append("\n");
            }

            try {
              result.put("success", res);
              result.put("failed", sb.toString());
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallback(onComplete, result.toString());
            onComplete = -1;
          }
        });
      }

      uncompressFilesTask = null;
    }
  }

  /**
   * uncompress a specific file content from obb file to specified path
   */
  static class UncompressOneFileTask extends AsyncTask<String, Integer, Long> {

    String filepath;
    String destfile;
    int onProgress = -1;
    int onComplete = -1;
    boolean success = false;

    public UncompressOneFileTask(final String filepath, final String destfile, final int onComplete) {
      this.filepath = filepath;
      this.destfile = destfile;
      // this.onProgress = onProgress;
      this.onComplete = onComplete;
    }

    @Override
    protected Long doInBackground(String... arg0) {
      try {
        final ZipResourceFile zipFile = getAPKExpansionZipFile(activity,
            getMainExpansionFileVersion(), getPatchExpansionFileVersion());

        File ofile = new File(destfile);
        ofile.getParentFile().mkdirs();

        InputStream is = zipFile.getInputStream(filepath);
        OutputStream os = new FileOutputStream(destfile);
        MessageDigest digestIn = getDigest();

        if (is == null || os == null) {
          Log.d(TAG, "can't copy obb file " + filepath + " to " + destfile + "...");
        } else {
          Log.d(TAG, "copying obb file " + filepath + " to " + destfile + "...");

          byte [] buf = new byte [BUF_SIZE];
          int len = is.read(buf);
          while (len > 0) {
            digestIn.update(buf, 0, len);
            os.write(buf, 0, len);
            len = is.read(buf);
          }

          os.close();
          is.close();

          Log.d(TAG, "verifing obb file checksum...");

          // verify checksum
          InputStream is2 = new FileInputStream(destfile);
          MessageDigest digestOut = getDigest();

          len = is2.read(buf);
          while (len > 0) {
            digestOut.update(buf, 0, len);
            len = is2.read(buf);
          }

          is2.close();

          if (! Arrays.equals(digestIn.digest(), digestOut.digest())) {
            throw new IOException("checksum not match");
          }

          Log.d(TAG, "obb file checksum verified");

          success = true;
        }
      } catch (IOException e) {
        Log.e(TAG, "uncompressOneFile IOException " + e.getMessage());
      } catch (NoSuchAlgorithmException e1) {
        Log.e(TAG, "uncompressOneFile NoSuchAlgorithmException " + e1.getMessage());
        e1.printStackTrace();
      }

      return null;
    }

    @Override
    protected void onProgressUpdate(Integer... progress) {
    }

    @Override
    protected void onPostExecute(Long result) {
      if (onProgress > 0) {
        LuaUtils.releaseLuaCallback(onProgress);
        onProgress = -1;
      }

      if (onComplete > 0) {
        final boolean res = success;
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();
            try {
              result.put("success", res);
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallback(onComplete, result.toString());
            onComplete = -1;
          }
        });
      }

      uncompressOneFileTask = null;
    }
  }

  private static MessageDigest getDigest() throws NoSuchAlgorithmException {
    return MessageDigest.getInstance("MD5");
  }

  /**
   * download the expansion file to default path
   * @param filepath
   * @param onProgress
   * @param onComplete
   * @return
   */
  public static boolean downloadExpansionFile(final int onProgress, final int onComplete) {
    boolean success = false;

    if (null != downloadClient) {
      downloadClient = new ObbDownloaderClient(onProgress, onComplete);

      try {
        success = downloadClient.startDownload();
      } catch (NameNotFoundException e) {
        Log.e(TAG, "downloadExpansionFile NameNotFoundException " + e.getMessage());
        e.printStackTrace();
      }

      downloadClient = null;
    }
    else {
      Log.e(TAG, "downloadExpansionFile: downloadClient already exists!");
    }

    return success;
  }

  private static class XAPKFile {
    public final boolean mIsMain;
    public final int mFileVersion;
    public final long mFileSize;

    XAPKFile(boolean isMain, int fileVersion, long fileSize) {
      mIsMain = isMain;
      mFileVersion = fileVersion;
      mFileSize = fileSize;
    }
  }

  static class ObbDownloaderClient implements IDownloaderClient {

    IDownloaderService mRemoteService;
    IStub mDownloaderClientStub = null;

    int onProgress = -1;
    int onComplete = -1;

    public ObbDownloaderClient(int onProgress, int onComplete) {
      this.onProgress = onProgress;
      this.onComplete = onComplete;
    }

    @Override
    public void onServiceConnected(Messenger m) {
      mRemoteService = DownloaderServiceMarshaller.CreateProxy(m);
      mRemoteService.onClientUpdated(mDownloaderClientStub.getMessenger());
    }

    @Override
    public void onDownloadStateChanged(int newState) {
      Log.d(TAG, "ObbDownloaderClient onDownloadStateChanged " + newState);
    }

    @Override
    public void onDownloadProgress(final DownloadProgressInfo progress) {
      Log.d(TAG, "ObbDownloaderClient onDownloadProgress " + progress.toString());

      if (onProgress > 0) {
        AndroidUtils.runOnGLThread(new Runnable() {
          @Override
          public void run() {
            JSONObject result = new JSONObject();
            try {
              result.put("cur", progress.mOverallProgress);
              result.put("total", progress.mOverallTotal);
              result.put("timeRemaining", progress.mTimeRemaining);
              result.put("speed", progress.mCurrentSpeed);
            } catch (JSONException e) {
              Log.e(TAG, "Json Error " + e.getMessage());
              e.printStackTrace();
            }
            LuaUtils.invokeLuaCallbackNoRelease(onProgress, result.toString());
          }});
      }

      if (progress.mOverallProgress >= progress.mOverallTotal) {
        if (onProgress > 0) {
          LuaUtils.releaseLuaCallback(onProgress);
          onProgress = -1;
        }

        if (onComplete > 0) {
          AndroidUtils.runOnGLThread(new Runnable() {
            @Override
            public void run() {
              JSONObject result = new JSONObject();
              try {
                result.put("success", true);
              } catch (JSONException e) {
                Log.e(TAG, "Json Error " + e.getMessage());
                e.printStackTrace();
              }
              LuaUtils.invokeLuaCallback(onComplete, result.toString());
              onComplete = -1;
            }
          });
        }
      }
    }

    public void onResume() {
      if (null != mDownloaderClientStub) {
        mDownloaderClientStub.connect(activity);
      }
    }

    public void onStop() {
      if (null != mDownloaderClientStub) {
        mDownloaderClientStub.disconnect(activity);
      }
    }

    boolean expansionFilesDelivered() {
      //      for (XAPKFile xf : xAPKS) {
      //        String fileName = Helpers.getExpansionAPKFileName(activity, xf.mIsMain,
      //            xf.mFileVersion);
      //        if (!Helpers.doesFileExist(activity, fileName, xf.mFileSize, false))
      //          return false;
      //      }
      //      return true;

      // just force to download
      return false;
    }

    public boolean startDownload() throws NameNotFoundException {
      // Check if expansion files are available before going any further
      if (! expansionFilesDelivered()) {
        // Build an Intent to start this activity from the Notification
        Intent notifierIntent = new Intent(activity, activity.getClass());
        notifierIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK |
            Intent.FLAG_ACTIVITY_CLEAR_TOP);

        PendingIntent pendingIntent = PendingIntent.getActivity(activity, 0,
            notifierIntent, PendingIntent.FLAG_UPDATE_CURRENT);

        // Start the download service (if required)
        int startResult = DownloaderClientMarshaller.startDownloadServiceIfRequired(activity,
            pendingIntent, ObbDownloaderService.class);
        Log.d(TAG, "ObbDownloaderClient startDownload startResult=" + startResult);

        // If download has started, initialize this activity to show download progress
        if (startResult != DownloaderClientMarshaller.NO_DOWNLOAD_REQUIRED) {
          // Instantiate a member instance of IStub
          mDownloaderClientStub = DownloaderClientMarshaller.CreateStub(this,
              ObbDownloaderClient.class);
          // This is where you do set up to display the download
          // progress (next step)
          return true;
        }
        else {
          // If the download wasn't necessary, fall through to start the app
          Log.d(TAG, "ObbDownloaderClient startDownload download not necessary");
          return false;
        }
      }
      else {
        Log.d(TAG, "ObbDownloaderClient startDownload expansionFilesDelivered");
        return false;
      }
    }
  }

  static class ObbDownloaderService extends DownloaderService {

    public static final String BASE64_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqyTczrojEIORf1LZTbGPOAmoW30SJt98EB/C+CSKJRb6YSMJ9wpTFeRZYG/hiGeyUeve4TvomdsSqRhV5msRy4daX0JJqEEQbW/cGPFqbL3fWEKrgETKtLHpcRne2DU1qJMx+eGLxXh/3mNAi50pWOGvaPSzVuUJidxAd/qjh/MHs8iPqd3EYrcpo5GOdgbeqTdPlwV7wVzyk/mwpsAow9Uk7Jf4t3re5bAWSHNbLwTRIB4TbkjkTFNuoR77HwtOTMOokzkdDgd9DqvNh3a2lQZrcLDJZxqh56Oz9O8wCu9c6D1vS1h/TAq7nS4PbuN4yeWyAGAl/LUulRkbK+KoIwIDAQAB";

    public static final byte[] SALT = new byte[] {
      13, 22, 72, -11, 4, 38, -10, -42, 43, 2, -87, -4, 9, 5, -32, -10, -31, 25, -2, 84
    };

    @Override
    public String getPublicKey() {
      return BASE64_PUBLIC_KEY;
    }

    @Override
    public byte[] getSALT() {
      return SALT;
    }

    @Override
    public String getAlarmReceiverClassName() {
      return ObbAlarmReceiver.class.getName();
    }
  }

  static class ObbAlarmReceiver extends BroadcastReceiver {

    @Override
    public void onReceive(Context context, Intent intent) {
      try {
        DownloaderClientMarshaller.startDownloadServiceIfRequired(context,
            intent, ObbDownloaderService.class);
      } catch (NameNotFoundException e) {
        Log.e(TAG, "ObbAlarmReceiver " + e.getMessage());
        e.printStackTrace();
      }
    }

  }

}
