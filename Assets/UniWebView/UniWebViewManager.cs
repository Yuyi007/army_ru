using UnityEngine;

public class UniWebViewManager
{

    private static GameObject _webViewGo = null;
#if UNITY_IOS || UNITY_ANDROID ||    UNITY_WP8
    private static UniWebView _webView = null ;
#endif

    public static void CreateWebView(bool fade, int top, int left, int bottom, int right)
    {
#if UNITY_IOS || UNITY_ANDROID ||    UNITY_WP8
        Debug.Log("[uniweb] createwebview");
        if (_webViewGo != null) {
            return;
        }
        _webViewGo = new GameObject("WebView");
        var webView = _webViewGo.AddComponent<UniWebView>();

        // We just set a ready flag to make sure we could show a page when the "Open" button is clicked.
        webView.OnLoadComplete += (view, success, errorMessage) => {
            if (success) {
                //_webViewReady = true;
            } else {
                Debug.LogError("Loading failed: " + errorMessage);
            }
        };

        // The `OnWebViewShouldClose` will be called when user pressed Back button or Done button to exit the web view.
        // It will hide the web view without animation if you do not listen to this method or return true in this method.

        // If you want customized transition for hide,
        // You should at least listen to OnWebViewShouldClose, call Hide() with animation options and return false. 
        webView.OnWebViewShouldClose += (view) => {
            if (fade)
            {
                webView.Hide(true, (UniWebViewTransitionEdge)1, 0.1f, ()=>{
                    Debug.Log("Hide Finished.");
                });
            }
            else webView.Hide();
           webView.HideToolBar(true);
            return false;
        };

        webView.insets = new UniWebViewEdgeInsets(top, left, bottom, right);

        if (fade)
        {
            webView.Show(true, (UniWebViewTransitionEdge)1, 0.1f, () => {
                Debug.Log("Show Finished.");
            });
        }
        else webView.Show();
 
        webView.ShowToolBar(false);

        _webView = webView;
#endif
    }

    public static void CreateWebView(bool fade)
    {
        CreateWebView(fade,0,0,200,0);
    }


    public static void LoadUrl(string url)
    {
#if UNITY_IOS || UNITY_ANDROID ||    UNITY_WP8
        if(_webViewGo == null)
        {
            CreateWebView(false);
        }

        if (url == string.Empty)
        {
            Debug.LogError("url not exit");
            return;
        }

        if (_webView)
        {
            _webView.Load(url);
        }
#endif
    }

    public static void Close()
    {
#if UNITY_IOS || UNITY_ANDROID ||    UNITY_WP8
        if(_webViewGo != null)
        {
           Object.Destroy(_webViewGo);
            _webViewGo = null;
            _webView = null;
        }
#endif
    }

}
