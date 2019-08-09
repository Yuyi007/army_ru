using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Game.AnimatorStorable))]
class AnimatorStorableInpspector :Editor
{
    private bool foldout;
    private Dictionary<string, string> paths;

    public override void OnInspectorGUI()
    {
        if (this.paths == null)
        {
            this.paths = new Dictionary<string, string>();
        }

        var storable = target as Game.AnimatorStorable;
        EditorGUILayout.LabelField("Count", storable.stateClipPairs.Length.ToString());
        foldout = EditorGUILayout.Foldout(foldout, "States and Clips");
        if (foldout)
        {
            foreach (var pair in storable.stateClipPairs)
            {
                EditorGUILayout.LabelField("state", pair.stateName);
                EditorGUILayout.LabelField("clip", pair.clipName);
                EditorGUILayout.LabelField("clipLength", Convert.ToString(pair.clipLength));
                EditorGUILayout.LabelField("clipFrameRate", Convert.ToString(pair.clipFrameRate));
            }
        }
    }
}

