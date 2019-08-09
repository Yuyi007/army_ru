using System;
using UnityEditor;
using UnityEngine;
using CinemaDirector;

[CustomEditor(typeof(ActorItemTrack))]
public class ActorItemTrackInspector : Editor
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
        ActorItemTrack track = base.serializedObject.targetObject as ActorItemTrack;
        CinemaActorAction[] actions = track.ActorActions;
        CinemaActorEvent[] actorEvents = track.ActorEvents;

        if (actions.Length > 0 || actorEvents.Length > 0)
        {
            actionFoldout = EditorGUILayout.Foldout(actionFoldout, actionContent);
            if (actionFoldout)
            {
                EditorGUI.indentLevel++;

                foreach (CinemaActorAction action in actions)
                {
                    EditorGUILayout.ObjectField(action.name, action, typeof(CinemaActorAction), true);
                }
                foreach (CinemaActorEvent actorEvent in actorEvents)
                {
                    EditorGUILayout.ObjectField(actorEvent.name, actorEvent, typeof(CinemaActorEvent), true);
                }
                EditorGUI.indentLevel--;
            }
        }

        if (GUILayout.Button(addActionContent))
        {
            GenericMenu createMenu = new GenericMenu();

            Type actorActionType = typeof(CinemaActorAction);
            foreach (Type type in DirectorHelper.GetAllSubTypes(actorActionType))
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
                        text = string.Format("{0}/{1}", category, label);
                        break;
                    }
                }
                ContextData userData = new ContextData { type = type, label = label, category = category };
                createMenu.AddItem(new GUIContent(text), false, new GenericMenu.MenuFunction2(AddEvent), userData);
            }

            Type actorEventType = typeof(CinemaActorEvent);
            foreach (Type type in DirectorHelper.GetAllSubTypes(actorEventType))
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
                ContextData userData = new ContextData { type = type, label = label, category = category };
                createMenu.AddItem(new GUIContent(text), false, new GenericMenu.MenuFunction2(AddEvent), userData);
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
            GameObject trackEvent = new GameObject(data.label);
            trackEvent.AddComponent(data.type);
            trackEvent.transform.parent = (this.target as ActorItemTrack).transform;
        }
    }

    private class ContextData
    {
        public Type type;
        public string category;
        public string label;
    }
}



