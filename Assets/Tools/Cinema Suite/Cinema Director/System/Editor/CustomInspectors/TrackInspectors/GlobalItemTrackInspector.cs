using System;
using UnityEditor;
using UnityEngine;
using CinemaDirector;

[CustomEditor(typeof(GlobalItemTrack))]
public class GlobalItemTrackInspector : Editor
{
    // Properties
    private SerializedObject eventTrack;
    private bool actionFoldout = true;

    GUIContent addActionContent = new GUIContent("Add New Action", "Add a new action to this track.");
    GUIContent actionContent = new GUIContent("Actions", "The actions associated with this track.");
    /// <summary>
    /// On inspector enable, load serialized objects
    /// </summary>
    public void OnEnable()
    {
        eventTrack = new SerializedObject(this.target);
    }

    /// <summary>
    /// Update and Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        eventTrack.Update();
        GlobalItemTrack track = base.serializedObject.targetObject as GlobalItemTrack;

        CinemaGlobalAction[] actions = track.Actions;
        CinemaGlobalEvent[] events = track.Events;

        if (actions.Length > 0 || events.Length > 0)
        {
            actionFoldout = EditorGUILayout.Foldout(actionFoldout, actionContent);
            if (actionFoldout)
            {
                EditorGUI.indentLevel++;

                foreach (CinemaGlobalAction action in actions)
                {
                    EditorGUILayout.ObjectField(action.name, action, typeof(CinemaGlobalAction), true);
                }
                foreach (CinemaGlobalEvent globalEvent in events)
                {
                    EditorGUILayout.ObjectField(globalEvent.name, globalEvent, typeof(CinemaGlobalEvent), true);
                }
                EditorGUI.indentLevel--;
            }
        }

        if (GUILayout.Button(addActionContent))
        {
            GenericMenu createMenu = new GenericMenu();

            foreach (Type type in DirectorHelper.GetAllSubTypes(typeof(CinemaGlobalAction)))
            {
                string text = string.Empty;
                string category = string.Empty;
                string label = string.Empty;
                foreach (CutsceneItemAttribute attribute in type.GetCustomAttributes(typeof(CutsceneItemAttribute), true))
                {
                    if (attribute != null)
                    {
                        category = attribute.Category;
                        label = attribute.Label;
                        text = string.Format("{0}/{1}", attribute.Category, attribute.Label);
                        break;
                    }
                }
                if (label != string.Empty)
                {
                    ContextData userData = new ContextData { Type = type, Label = label, Category = category };
                    createMenu.AddItem(new GUIContent(text), false, new GenericMenu.MenuFunction2(AddEvent), userData);
                }
            }

            foreach (Type type in DirectorHelper.GetAllSubTypes(typeof(CinemaGlobalEvent)))
            {
                string text = string.Empty;
                string category = string.Empty;
                string label = string.Empty;
                foreach (CutsceneItemAttribute attribute in type.GetCustomAttributes(typeof(CutsceneItemAttribute), true))
                {
                    if (attribute != null)
                    {
                        category = attribute.Category;
                        label = attribute.Label;
                        text = string.Format("{0}/{1}", attribute.Category, attribute.Label);
                        break;
                    }
                }
                if (label != string.Empty)
                {
                    ContextData userData = new ContextData { Type = type, Label = label, Category = category };
                    createMenu.AddItem(new GUIContent(text), false, new GenericMenu.MenuFunction2(AddEvent), userData);
                }
            }
            createMenu.ShowAsContext();
        }

        eventTrack.ApplyModifiedProperties();
    }

    private void AddEvent(object userData)
    {
        ContextData data = userData as ContextData;
        if (data != null)
        {
            string name = DirectorHelper.getCutsceneItemName(data.Label, data.Type);
            GameObject trackEvent = new GameObject(name);
            trackEvent.AddComponent(data.Type);
            trackEvent.transform.parent = (this.target as GlobalItemTrack).transform;
        }
    }

    private class ContextData
    {
        public Type Type;
        public string Category;
        public string Label;
    }
}
