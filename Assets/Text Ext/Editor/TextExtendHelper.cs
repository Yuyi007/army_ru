using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class TextExtendHelper
{
    [MenuItem("GameObject/UI/Text_Extend")]
    public static void CreateNew(MenuCommand menuCommand)
    {
        EditorApplication.ExecuteMenuItem("GameObject/UI/Text");
        UnityEngine.UI.Text text = Selection.activeGameObject.GetComponent<UnityEngine.UI.Text>();
        Color color = text.color;
        GameObject.DestroyImmediate(Selection.activeGameObject.GetComponent<UnityEngine.UI.Shadow>(), true);
        GameObject.DestroyImmediate(text, true);
        Selection.activeGameObject.name = "Text";
        Text_Extend textField = Selection.activeGameObject.AddComponent<Text_Extend>();
        textField.color = color;
        textField.OriginText = "New Text";
        textField.linkObject = true;
        textField.font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Fonts/cn/font_ui.ttf");
        // BUG: for some reason parenting behavior is not inherited when executing built-in menu command
        GameObject parent = menuCommand.context as GameObject;
        if (parent != null && parent.GetComponentInParent<Canvas>() != null)
        {
            #if !UNITY_4_6 && !UNITY_4_7
            textField.gameObject.name =
                GameObjectUtility.GetUniqueNameForSibling(parent.transform, textField.gameObject.name);
            #endif
            GameObjectUtility.SetParentAndAlign(textField.gameObject, parent);
        }
    }


}
