using UnityEngine;
using System.IO;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CommonUtils
{
    static public string findPrefabPath(string prefabName)
    {
        #if UNITY_EDITOR
        string[] lookFor = new string[] { "Assets/Prefab" };
        string[] guids2 = AssetDatabase.FindAssets(prefabName, lookFor);
        if (guids2.Length > 0)
        {
            foreach (var guid in guids2)
            {
                var prefabPath = AssetDatabase.GUIDToAssetPath(guid);
                var tprefabName = Path.GetFileNameWithoutExtension(prefabPath);
                if (tprefabName == prefabName)
                {
                    return prefabPath;
                }
            }
        }
        #endif
        return null;
    }

    static public float getScreenKeyboardHeight()
    {
#if UNITY_ANDROID
		  using(AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		  {
		     AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");
		     using(AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
		     {
		       View.Call("getWindowVisibleDisplayFrame", Rct);
		       return Screen.height - Rct.Call<int>("height");
		     }
		  }
#elif UNITY_IOS
        return TouchScreenKeyboard.area.height;
#else
        return 0f;
#endif

    }

    static public GameObject makePrefabGameObject(string prefabName)
    {
        string path = CommonUtils.findPrefabPath(prefabName);
        return doMakePrefabGameObject(path);
    }

    static public GameObject doMakePrefabGameObject(string path)
    {
#if UNITY_EDITOR
        GameObject prefabc = null;
        if (path != null)
        {
            prefabc = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        if (prefabc == null)
            return null;

        var pgo = PrefabUtility.InstantiatePrefab(prefabc) as GameObject;
        return pgo;
#else
        return null;
#endif
        
    }
}
