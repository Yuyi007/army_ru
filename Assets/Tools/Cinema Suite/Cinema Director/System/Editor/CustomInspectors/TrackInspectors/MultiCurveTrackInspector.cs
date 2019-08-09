using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using CinemaDirector;

[CustomEditor(typeof(MultiCurveTrack))]
public class MultiCurveTrackInspector : Editor
{
    // Properties
    private SerializedObject curveTrack;
    private GUIContent addClip = new GUIContent("Add Clip Curve", "Add a new clip curve to this track.");

    /// <summary>
    /// On inspector enable, load serialized objects
    /// </summary>
    public void OnEnable()
    {
        curveTrack = new SerializedObject(this.target);
    }


    /// <summary>
    /// Update and Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        curveTrack.Update();

        foreach (CinemaMultiActorCurveClip clip in (target as MultiCurveTrack).TimelineItems)
        {
            EditorGUILayout.ObjectField(clip.name, clip, typeof(CinemaMultiActorCurveClip), true);
        }

        if (GUILayout.Button(addClip))
        {
            Undo.RegisterCreatedObjectUndo(CutsceneItemFactory.CreateMultiActorClipCurve((target as MultiCurveTrack)).gameObject, "Create Curve Clip");
        }

        curveTrack.ApplyModifiedProperties();
    }
}
