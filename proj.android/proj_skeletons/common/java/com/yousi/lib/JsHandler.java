package com.yousi.lib;

import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;

import android.webkit.JavascriptInterface;

public class JsHandler {
    private WebViewActivity m_wa;

    public JsHandler(WebViewActivity wa) {
        m_wa = wa;
    }

    @JavascriptInterface
    public void jsFnCall(String jsonString) {
        try {
            m_wa.finishWithResult(URLDecoder.decode(jsonString, "utf-8"));
        } catch (UnsupportedEncodingException e) {
            m_wa.finishWithError(-1002, e.getLocalizedMessage());
        }
    }
}
