using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SphereTransform))]
public class SphereTransform : Editor 
{
    
    private SerializedObject obj;
    SerializedProperty pos;

    private void OnEnable()
    {
        obj = new SerializedObject(target);
        pos = obj.FindProperty("pos");
    }
    // 重写Inspector检视面板
    public override void OnInspectorGUI()
    {
        obj.Update();

        EditorGUILayout.PropertyField(pos);

        obj.ApplyModifiedProperties();
    } 
}
