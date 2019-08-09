using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GizmosColorWindow : EditorWindow {

    DrawGizmosTest grawGizmosTest;

    public void Init()
    {
        grawGizmosTest = (DrawGizmosTest)FindObjectOfType(typeof(DrawGizmosTest));
    }

    private void OnGUI()
    {
        grawGizmosTest.color = EditorGUILayout.ColorField(grawGizmosTest.color, GUILayout.Width(200));
    }
}
