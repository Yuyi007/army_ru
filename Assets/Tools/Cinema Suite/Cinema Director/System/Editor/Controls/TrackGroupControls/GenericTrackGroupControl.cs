using CinemaDirector;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

/// <summary>
/// The default track group control.
/// </summary>
[CutsceneTrackGroupAttribute(typeof(TrackGroup))]
public class GenericTrackGroupControl : TrackGroupControl
{
    /// <summary>
    /// Create and show a context menu for adding new Timeline Tracks.
    /// </summary>
    protected override void addTrackContext()
    {
        TrackGroup trackGroup = TrackGroup.Behaviour as TrackGroup;
        if(trackGroup != null)
        {
            // Get the possible tracks that this group can contain.
            List<Type> trackTypes = trackGroup.GetAllowedTrackTypes();
            
            GenericMenu createMenu = new GenericMenu();

            // Get the attributes of each track.
            foreach (Type t in trackTypes)
            {
                MemberInfo info = t;
                string label = string.Empty;
                foreach (TimelineTrackAttribute attribute in info.GetCustomAttributes(typeof(TimelineTrackAttribute), true))
                {
                    label = attribute.Label;
                    break;
                }

                createMenu.AddItem(new GUIContent(string.Format("Add {0}", label)), false, addTrack, new TrackContextData(label, t, trackGroup));
            }

            createMenu.ShowAsContext();
        }
    }

    /// <summary>
    /// Add a new track
    /// </summary>
    /// <param name="userData">TrackContextData for the track to be created.</param>
    private void addTrack(object userData)
    {
        TrackContextData trackData = userData as TrackContextData;
        if (trackData != null)
        {
            GameObject item = CutsceneItemFactory.CreateTimelineTrack(trackData.TrackGroup, trackData.Type, trackData.Label).gameObject;
            this.isExpanded = true;
            Undo.RegisterCreatedObjectUndo(item, string.Format("Create {0}", item.name));
        }
    }

    /// <summary>
    /// Context data for the track to be created.
    /// </summary>
    private class TrackContextData
    {
        public string Label;
        public Type Type;
        public TrackGroup TrackGroup;

        public TrackContextData(string label, Type type, TrackGroup trackGroup)
        {
            this.Label = label;
            this.Type = type;
            this.TrackGroup = trackGroup;
        }
    }
}
