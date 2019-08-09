package com.yousi.lib;

import java.net.MalformedURLException;
import java.net.URL;

import org.json.JSONException;
import org.json.JSONObject;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.webkit.CookieSyncManager;
import android.webkit.JsResult;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebSettings.LayoutAlgorithm;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class WebViewActivity extends Activity {

    private WebView             m_webview;
    private String              m_url;
    private ProgressDialog      m_progressDialog;

    final private static String TAG = WebViewActivity.class.getCanonicalName();

    @SuppressLint("SetJavaScriptEnabled")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
//        setContentView(R.layout.fv_webview);
//        m_webview = (WebView) findViewById(R.id.fv_webview);

        CookieSyncManager.createInstance(this);
        CookieSyncManager.getInstance().startSync();

        WebSettings settings = m_webview.getSettings();
        settings.setJavaScriptEnabled(true);
        settings.setJavaScriptCanOpenWindowsAutomatically(true);
        
        settings.setLayoutAlgorithm(LayoutAlgorithm.NORMAL);
        settings.setSaveFormData(false);
        settings.setSavePassword(false);

        String cachePath = getBaseContext().getApplicationContext().getDir("cache", Context.MODE_PRIVATE).getPath();
        settings.setDatabaseEnabled(true);

        settings.setAppCachePath(cachePath);
        settings.setAppCacheEnabled(true);

        JsHandler jsHandler = new JsHandler(this);
        m_webview.addJavascriptInterface(jsHandler, "JsHandler");

        Bundle data = getIntent().getExtras();
        m_url = data.getString("url");

        createProgressDialog();
        // m_isCallbackInvoked = false;
        
        m_webview.setWebChromeClient(new WebChromeClient() {

            @Override
            public boolean onJsAlert(WebView view, String url, String message, JsResult result) {
//                Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG).show();
                return super.onJsAlert(view, url, message, result);
            }
            
        });

        m_webview.setWebViewClient(new WebViewClient() {
            @Override
            public void onPageStarted(WebView view, String url, Bitmap favicon) {
                super.onPageStarted(view, url, favicon);
                Log.d(TAG, "start loading web page: " + url);

                if (null != m_progressDialog) {
                    m_progressDialog.show();
                }
            }

            @Override
            public void onPageFinished(WebView view, String url) {
                super.onPageFinished(view, url);
                Log.d(TAG, "finish loading web page: " + url);

                if (null != m_progressDialog) {
                    m_progressDialog.hide();
                }
            }

            @Override
            public void onReceivedError(WebView view, int errorCode, String description, String failingUrl) {
                super.onReceivedError(view, errorCode, description, failingUrl);

                Log.e(TAG, "load url: " + failingUrl + "failed: " + description);

                if (null != m_progressDialog) {
                    m_progressDialog.hide();
                }

                try {
                    URL origin = new URL(m_url);
                    URL failed = new URL(failingUrl);

                    String host = origin.getHost();
                    String fhost = failed.getHost();

                    // load page from target host failed, finish this activity
                    // with error
                    if (host.equals(fhost)) {
                        finishWithError(errorCode, description);
                    }

                } catch (MalformedURLException e) {
                    Log.e(TAG, "target url: " + m_url + "is malformed: " + e.getLocalizedMessage());

                    finishWithError(10001, "malformed url: " + m_url);
                }
            }
        });

        m_webview.loadUrl(m_url);
        Log.d(TAG, "start loading web page: " + m_url);
    }

    @Override
    protected void onPause() {
        super.onPause();
        CookieSyncManager.getInstance().sync();
        Log.d(TAG, "onPause");

        dismissProgressDialog();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.d(TAG, "onDestroy");

        dismissProgressDialog();
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        Log.d(TAG, "onKeyDown");

        if ((keyCode == KeyEvent.KEYCODE_BACK)) {
            finishWithError(-1001, "user cancelled");
        }

        return super.onKeyDown(keyCode, event);
    }

    @Override
    protected void onResume() {
        super.onResume();
        CookieSyncManager.getInstance().stopSync();
        Log.d(TAG, "onResume");
        createProgressDialog();
    }

    public void finishWithError(int errorCode, String message) {
        JSONObject result = new JSONObject();

        try {
            result.put("success", false);
            result.put("errCode", Integer.valueOf(errorCode));
            result.put("message", message);
        } catch (JSONException e) {
            Log.e(TAG, "construct json result failed" + e.getLocalizedMessage());
        }

        CookieSyncManager.getInstance().sync();
        dismissProgressDialog();
        
        Intent resultData = new Intent();
        resultData.putExtra("jsonResult", result.toString());
        
        setResult(Activity.RESULT_CANCELED, resultData);
        finish();
    }

    public void finishWithResult(String jsonResult) {
        Log.d(TAG, "finishWithResult: " + jsonResult);
        CookieSyncManager.getInstance().sync();
        dismissProgressDialog();

        Intent result = new Intent();
        result.putExtra("jsonResult", jsonResult);
        
        setResult(Activity.RESULT_OK, result);
        finish();
    }

    private void createProgressDialog() {
        Log.d(TAG, "create progress dialog");

        if (null == m_progressDialog) {
//            m_progressDialog = new ProgressDialog(this, R.style.TransparentTheme);
//            m_progressDialog.setProgressStyle(android.R.style.Widget_ProgressBar_Small);
//            m_progressDialog.setCancelable(false);
       }
    }

    private void dismissProgressDialog() {
        Log.d(TAG, "dismiss progress dialog");

        if (null != m_progressDialog) {
            m_progressDialog.dismiss();
            m_progressDialog = null;
        }
    }

}
