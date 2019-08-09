using UnityEditor;
using UnityEngine;
using CinemaDirector;

/// <summary>
/// A custom inspector for cutscene triggers.
/// </summary>
[CustomEditor(typeof(CutsceneTrigger), true)]
public class CutsceneTriggerInspector : Editor
{
    private SerializedObject trigger;

    private SerializedProperty startMethod;
    private SerializedProperty cutscene;
    private SerializedProperty triggerObject;
    private SerializedProperty skipButton;


    #region 
    private const string startMethodContent = "Start Method";
    #endregion

    /// <summary>
    /// On inspector enable, load the serialized properties
    /// </summary>
    private void OnEnable()
    {
        trigger = new SerializedObject(this.target);

        startMethod = trigger.FindProperty("StartMethod");
        cutscene = trigger.FindProperty("Cutscene");
        triggerObject = trigger.FindProperty("TriggerObject");
        skipButton = trigger.FindProperty("SkipButtonName");
    }

    /// <summary>
    /// Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        trigger.Update();

        EditorGUILayout.PropertyField(cutscene);
        StartMethod newStartMethod = (StartMethod) EditorGUILayout.EnumPopup(startMethodContent, (StartMethod)startMethod.enumValueIndex);
        
        if (newStartMethod != (StartMethod)startMethod.enumValueIndex)
        {
            startMethod.enumValueIndex = (int)newStartMethod;

            if (newStartMethod == StartMethod.OnTrigger)
            {
                CutsceneTrigger cutsceneTrigger = (this.target as CutsceneTrigger);
                if (cutsceneTrigger != null && cutsceneTrigger.gameObject.GetComponent<Collider>() == null)
                {
                    cutsceneTrigger.gameObject.AddComponent<BoxCollider>();
                }
            }
            else
            {
                // Can't cleanly destroy collider yet.
                //CutsceneTrigger cutsceneTrigger = (this.target as CutsceneTrigger);
                //if (cutsceneTrigger != null && cutsceneTrigger.gameObject.GetComponent<Collider>() != null)
                //{
                //    Collider c = cutsceneTrigger.gameObject.GetComponent<Collider>();
                //    DestroyImmediate(c, true);
                //}
            }
        }

        if (newStartMethod == StartMethod.OnTrigger)
        {
            EditorGUILayout.PropertyField(triggerObject);
        }

        EditorGUILayout.PropertyField(skipButton);

        trigger.ApplyModifiedProperties();
    }
}
