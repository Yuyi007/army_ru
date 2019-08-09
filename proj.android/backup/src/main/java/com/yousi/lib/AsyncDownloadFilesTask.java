package com.yousi.lib;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.ByteBuffer;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.concurrent.Executors;

import org.apache.http.Header;

import android.app.Activity;
import android.os.HandlerThread;
import android.util.Log;

import com.yousi.lib.http.AsyncHttpClient;
import com.yousi.lib.http.FileAsyncHttpResponseHandler2;

class AsyncDownloadFilesTask extends HandlerThread {

	final static String TAG = AsyncDownloadFilesTask.class.getCanonicalName();
	static int _id = 0;

	AsyncHttpClient httpClient;

	String [] fileurls;
	String [] filepaths;
	String [] compresses;
	String [] hashes;
	String hashMethod;
	MessageDigest hasher;
	int concurrentDownloads;
	int onProgress;
	int onError;
	int onFileComplete;
	int onComplete;

	List<Integer> toDownload = new ArrayList<Integer>();
	List<Integer> downloading = new ArrayList<Integer>(4);
	HashMap<Integer, Integer> downloadingSizes = new HashMap<Integer, Integer>();
	int sizeDone = 0;
	long lastUpdateProgressTime = 0;
	boolean paused = false;
	boolean cancelled = false;

	public AsyncDownloadFilesTask(final String [] fileurls, final String [] filepaths,
			final String [] compresses, final String [] hashes, final String hashMethod, final String seed,
			final int concurrentDownloads, final int onProgress,
			final int onError, final int onFileComplete, final int onComplete) {
		super(TAG + (_id++), Thread.MIN_PRIORITY);

		this.httpClient = new AsyncHttpClient();
		this.httpClient.setThreadPool(Executors.newFixedThreadPool(concurrentDownloads));

		this.fileurls = fileurls;
		this.filepaths = filepaths;
		this.compresses = compresses;
		this.hashes = hashes;
		this.hashMethod = hashMethod;
		try {
			if (hashMethod.equals("none")) {
				this.hasher = null;
			} else if (hashMethod.equals("xxhash")) {
				XXHash.init();
				this.hasher = new XXHashMessageDigest(Integer.valueOf(seed));
			} else {
				this.hasher = MessageDigest.getInstance("MD5");
			}
		} catch (NoSuchAlgorithmException e) {
			e.printStackTrace();
		}
		this.concurrentDownloads = concurrentDownloads;
		this.onProgress = onProgress;
		this.onError = onError;
		this.onFileComplete = onFileComplete;
		this.onComplete = onComplete;
	}

	private Activity getActivity() {
		return AndroidUtils.getActivity();
	}

	public boolean isPaused() {
		return paused;
	}

	public void setPaused(boolean paused) {
		this.paused = paused;

		if (! paused) {
			continueDownloads();
		}
	}

	public boolean isCancelled() {
		return cancelled;
	}

	public void cancel(boolean cancelled) {
		this.cancelled = cancelled;
	}

	@Override
	protected void onLooperPrepared() {
		for (int i = 0; i < fileurls.length; ++i) {
			toDownload.add(i);
		}

		Log.d(TAG, "thread name: " + Thread.currentThread().getName());
		Log.d(TAG, "start: downloading=" + downloading.size() + " toDownload=" + toDownload.size());

		continueDownloads();
	}

	private void publishProgress(final Integer... progress) {
		AndroidUtils.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				onProgressUpdate(progress);
			}
		});
	}

	private void terminate() {
		this.quit();
		AndroidUtils.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				onPostExecute(0L);
			}
		});
	}

	private synchronized void continueDownloads() {
		for (int i = 0; i < toDownload.size(); ++i) {
			int k = toDownload.get(i);
			if (this.isCancelled()) {
				break;
			} else if (this.isPaused()) {
				break;
			} else if (downloading.size() >= this.concurrentDownloads) {
				break;
			} else {
				downloading.add(k);
				downloadingSizes.put(k, 0);
				toDownload.remove(i--);
				startDownloadFile(k, fileurls[k], filepaths[k], compresses[k], hashes[k]);
			}
		}

		if (toDownload.size() + downloading.size() == 0 || this.isCancelled()) {
			terminate();
		}
	}

	private synchronized void startDownloadFile(final int index, final String fileurl, final String outfile,
		final String compress, final String hash) {
		File ofile = new File(outfile);
		if (ofile.getParentFile() != null) {
			ofile.getParentFile().mkdirs();
		}

		Log.d(TAG, "downloading: [" + index + "] " + ofile.getName());

		boolean inflate = ("gz".equals(compress));

		URL url = null;
		try {
			if (inflate) {
				url = new URL(fileurl + ".gz");
			} else {
				url = new URL(fileurl);
			}
			URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
			url = uri.toURL();
		} catch (MalformedURLException e) {
			Log.e(TAG, "encoding url: malformed url");
			e.printStackTrace();
		} catch (URISyntaxException e) {
			Log.e(TAG, "encoding url: syntax error");
			e.printStackTrace();
		}

		final AsyncDownloadFilesTask self = this;
		AsyncHttpClient client = httpClient;
        client.setURLEncodingEnabled(false);
        client.get(url.toString(), new FileAsyncHttpResponseHandler2(ofile, false, inflate) {

        	@Override
        	public void onProgress(int bytesWritten, int totalSize) {
        		long now = System.currentTimeMillis();
        		if (now - lastUpdateProgressTime > 50) {
	        		//Log.d(TAG, "onProgress [" + index + "] " + bytesWritten);
	        		int sizeProgress = 0;
	        		for (int i = 0; i < downloading.size(); ++i) {
	        			int k = downloading.get(i);
	        			if (k == index) downloadingSizes.put(k, bytesWritten);
	        			sizeProgress += downloadingSizes.get(k);
	        		}
	        		publishProgress(sizeDone + sizeProgress);
	        		lastUpdateProgressTime = now;
        		}
          }

          @Override
          public void onFailure(int statusCode, Header[] headers, Throwable throwable, File file) {
          	Log.w(TAG, "failed when downloading: [" + index + "] " +  file.getName());
          	luaOnError(index);
          	retryDownloadFile(index, fileurl, outfile, compress, hash);
          }

          @Override
          public void onSuccess(int statusCode, Header[] headers, File file) {
          	boolean verified = verifyFile(index, file, self.hashes[index]);

          	if (verified) {
          		Log.d(TAG, "download success: [" + index + "] " + file.getName());
          		sizeDone += downloadingSizes.get(index);
          		for (int i = 0; i < downloading.size(); ++i) {
          			if (downloading.get(i) == index) {
          				downloading.remove(i);
          				break;
          			}
          		}
          		downloadingSizes.remove(index);
          		luaOnFileComplete(index);
          		continueDownloads();
          	} else {
          		Log.w(TAG, "failed when downloading (checksum incorrect): [" + index + "] " +  file.getName());
          		luaOnError(index);
          		retryDownloadFile(index, fileurl, outfile, compress, hash);
          	}
          }

        });
	}

	private synchronized void retryDownloadFile(int index, String fileurl, String outfile, String compress, String hash) {
		for (int i = 0; i < downloading.size(); ++i) {
			if (downloading.get(i) == index) {
				downloading.remove(i);
				downloadingSizes.put(index, 0);
				break;
			}
		}

		if (this.isCancelled() || this.isPaused()) {
			toDownload.add(0, index);
		} else {
			startDownloadFile(index, fileurl, outfile, compress, hash);
		}
	}

	private synchronized boolean verifyFile(int index, File file, String hash) {
		if (this.hasher == null || hash.length() == 0 || this.hashMethod.length() == 0) {
			// verification skipped
			return true;
		}

		try {
			this.hasher.reset();

			final int BUF_SIZE = 256 * 1024;
			byte [] buf = new byte[BUF_SIZE];
			InputStream is = new FileInputStream(file);
			int len = is.read(buf);
			while (len > 0) {
				this.hasher.update(buf, 0, len);
				len = is.read(buf);
			}

			is.close();

			String hashResult = null;
			if (this.hashMethod.equals("xxhash")) {
				hashResult = String.valueOf(ByteBuffer.wrap(this.hasher.digest()).getInt() & 0x00000000ffffffffL);
			} else {
				hashResult = toHex(this.hasher.digest());
			}
			//Log.d(TAG, "hash: [" + index + "] " + file.getName() + " expected=" + hash + " calculated=" + hashResult);

			return hash.equals(hashResult);
		} catch (IOException e) {
			Log.e(TAG, "verifyFile IOException " + e.getMessage());
			e.printStackTrace();
		}

		return false;
	}

	private static String toHex(byte[] bytes) {
		char[] hexArray = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
	    char[] hexChars = new char[bytes.length * 2];
	    int v;
	    for ( int j = 0; j < bytes.length; j++ ) {
	        v = bytes[j] & 0xFF;
	        hexChars[j*2] = hexArray[v/16];
	        hexChars[j*2 + 1] = hexArray[v%16];
	    }
	    return new String(hexChars);
	}

	private synchronized void luaOnError(int index) {
		Log.d(TAG, "onError: " + index);
		LuaUtils.invokeLuaCallbackNoRelease(onError, String.valueOf(index));
		try {
			Thread.sleep(500);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}

	private synchronized void luaOnFileComplete(int index) {
		LuaUtils.invokeLuaCallbackNoRelease(onFileComplete, String.valueOf(index));
	}

	//@Override
	protected synchronized void onProgressUpdate(final Integer... progress) {
		//Log.d(TAG, "onProgressUpdate: " + progress[0]);
		LuaUtils.invokeLuaCallbackNoRelease(onProgress, String.valueOf(progress[0]));
	}

	//@Override
	protected synchronized void onPostExecute(Long result) {
		Log.d(TAG, "onPostExecute: downloading=" + downloading.size() +
				" toDownload=" + toDownload.size() + " result=" + result);

		String resultStr = "false";
		if (toDownload.size() + downloading.size() == 0) {
			resultStr = "true";
		}

		LuaUtils.invokeLuaCallbackNoRelease(onComplete, resultStr);

		cleanup();
	}

	private void cleanup() {
		Log.d(TAG, "cleanup");

		LuaUtils.releaseLuaCallback(onProgress);
		LuaUtils.releaseLuaCallback(onError);
		LuaUtils.releaseLuaCallback(onFileComplete);
		LuaUtils.releaseLuaCallback(onComplete);

		AndroidUtils.asyncDownloadFilesTask = null;
	}
}
