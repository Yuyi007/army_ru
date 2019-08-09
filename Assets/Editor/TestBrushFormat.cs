using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BrushFormat))]
public class TestBrushFormat : Editor {

    public override void OnInspectorGUI()
    {
        BrushFormat model = target as BrushFormat;
        model.StartPoint = EditorGUILayout.Vector3Field("StartPoint", model.StartPoint);
        if (GUILayout.Button("拾取起点"))
        {
            model.StartPoint = model.transform.position;
        }


        model.EndPoint = EditorGUILayout.Vector3Field("EndPoint", model.EndPoint);
        if (GUILayout.Button("拾取终点"))
        {
            model.EndPoint = model.transform.position;
        }

        if (GUILayout.Button("计算"))
        {
            model.IsCalculate = true;
        }
        //model.IsCalculate = EditorGUILayout.Toggle("IsCalculate", model.IsCalculate);
        model.CubeSize = EditorGUILayout.Vector2Field("CubeSize", model.CubeSize);

        //base.OnInspectorGUI();
    }
}
