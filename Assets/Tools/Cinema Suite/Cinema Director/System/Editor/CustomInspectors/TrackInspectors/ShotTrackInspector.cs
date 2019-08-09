// Cinema Suite Inc. 2014
using UnityEditor;
using UnityEngine;
using CinemaDirector;

[CustomEditor(typeof(ShotTrack))]
public class ShotTrackInspector : Editor
{
    // Properties
    private SerializedObject visualTrack;
    private bool shotFoldout = true;

    /// <summary>
    /// On inspector enable, load serialized objects
    /// </summary>
    public void OnEnable()
    {
        visualTrack = new SerializedObject(this.target);
    }

    /// <summary>
    /// Update and Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        visualTrack.Update();

        EditorGUILayout.Foldout(shotFoldout, "Shot List");
        ShotTrack track = base.serializedObject.targetObject as ShotTrack;
        foreach (CinemaShot shot in track.TimelineItems)
        {
            shot.name = EditorGUILayout.TextField(new GUIContent("Shot Name"), shot.name);

            EditorGUI.indentLevel++;
                shot.shotCamera = EditorGUILayout.ObjectField(new GUIContent("Camera"), shot.shotCamera, typeof(Camera), true) as Camera;
                shot.CutTime = EditorGUILayout.FloatField(new GUIContent("Cut Time"), shot.CutTime);
                shot.ShotLength = EditorGUILayout.FloatField(new GUIContent("Shot Length"), shot.ShotLength);
            EditorGUI.indentLevel--;
        }

        if(GUILayout.Button("Add New Shot"))
        {
            CutsceneItemFactory.CreateNewShot(track);
        }
        visualTrack.ApplyModifiedProperties();

    }
}
