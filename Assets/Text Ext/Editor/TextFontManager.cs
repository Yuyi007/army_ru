using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class TextFontManager : EditorWindow
{
    delegate bool textOperate(Text text, bool check = false);
    textOperate onTextOperate;

    Font mOriginFont;
    Font mSelectFont;

    Font mSelectFontForMissing;

    string mPath = "Text_Ext/Resources/UI/Prefab/";

    [MenuItem("Edit/UI/Text Font Manager")]
    static void Init()
    {
        EditorWindow.GetWindow<TextFontManager>(false, "Font Manager", true);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Space(10f);

        GUILayout.Label("UI Prefab Path", EditorStyles.boldLabel);

        GUILayout.Label("in \"Assets\" directory");

        mPath = EditorGUILayout.TextArea(mPath, GUI.skin.textArea, GUILayout.Height(20f), GUILayout.Width(Screen.width - 10f));

        EditorGUILayout.HelpBox("The \"Origin TTF\" font text will replace by \"Target TTF\". if \"Origin TTF\" set None, \"Replace All\" will replace all type font Text", MessageType.Info);

        mOriginFont = EditorGUILayout.ObjectField("Origin TTF", mOriginFont, typeof(Font), false) as Font;

        GUILayout.Space(10f);

        mSelectFont = EditorGUILayout.ObjectField("Target TTF", mSelectFont, typeof(Font), false) as Font;

        GUILayout.Space(7f);

        //-------------------------
        GUILayout.BeginHorizontal();
        GUILayout.Space(90f);

        if (GUILayout.Button("Replace All", GUILayout.Width(100f)))
        {
            if (null != mSelectFont)
            {
                replaceUIFont(replaceAll);
                if (null == mOriginFont)
                    Debug.Log("Replace all UI prefab Text font to " + mSelectFont.name);
                else
                    Debug.Log("UI prefab Text font which is " + mOriginFont.name + " replace to " + mSelectFont.name);
            }
        }

        GUILayout.EndHorizontal();
        //-------------------------

        GUILayout.Space(10f);

        EditorGUILayout.HelpBox("Set a \"Target TTF\" to replace missing font Text", MessageType.Info);

        mSelectFontForMissing = EditorGUILayout.ObjectField("Target TTF", mSelectFontForMissing, typeof(Font), false) as Font;

        GUILayout.Space(7f);

        //-------------------------
        GUILayout.BeginHorizontal();
        GUILayout.Space(90f);

        if (GUILayout.Button("Replace Missing", GUILayout.Width(100f)))
        {
            if (null != mSelectFontForMissing)
            {
                replaceUIFont(replaceMissing);
                Debug.Log("Replace all UI prefab Text missing font to " + mSelectFontForMissing.name);
            }
        }

        GUILayout.EndHorizontal();
        //-------------------------

        GUILayout.EndVertical();

    }

    void replaceUIFont(textOperate act)
    {
        List<GameObject> changeObjs = new List<GameObject>();

        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/" + mPath);
        foreach (FileInfo file in rootDirInfo.GetFiles("*.prefab", SearchOption.AllDirectories))
        {
            string allPath = file.FullName;
            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));

#if UNITY_5_2 || UNITY_5_3_OR_NEWER
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
#else
            GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject));
#endif
            if (null == prefab)
                continue;

            Text[] texts = prefab.GetComponentsInChildren<Text>(true);
            foreach (var text in texts)
            {
                if (act(text, true))
                {
                    changeObjs.Add(prefab);
                }
            }
        }

        if (changeObjs.Count > 0)
        {
            foreach (GameObject obj in changeObjs)
            {
                if (null == obj) continue;

                UnityEditor.Undo.RegisterFullObjectHierarchyUndo(obj, "Text font change");
                Text[] texts = obj.GetComponentsInChildren<Text>(true);
                foreach (var text in texts)
                {
                    if (act(text))
                    {
                        Debug.Log(obj.name + "'s child " + text.gameObject.name + " font be changed.");
                    }
                }
                EditorUtility.SetDirty(obj);
            }
        }
    }

    bool replaceAll(Text text, bool check = false)
    {
        if (null != mOriginFont)
        {
            if (mOriginFont == text.font)
            {
                if(!check)
                    text.font = mSelectFont;
                return true;
            }
            return false;
        }
        else
        {
            if (!check)
                text.font = mSelectFont;
            return true;
        }
    }

    bool replaceMissing(Text text, bool check = false)
    {
        if (null == text.font)
        {
            if (!check)
                text.font = mSelectFontForMissing;
            return true;
        }

        return false;
    }

}
