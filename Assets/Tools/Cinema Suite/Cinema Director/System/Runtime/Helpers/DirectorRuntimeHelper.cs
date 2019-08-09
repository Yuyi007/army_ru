// Cinema Suite 2014

// #define PROFILE_FILE

using CinemaSuite.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// A helper class for getting useful data from Director Runtime objects.
    /// </summary>
    public static class DirectorRuntimeHelper
    {
        /// <summary>
        /// Returns a list of Track types that are associated with the given Track Group.
        /// </summary>
        /// <param name="trackGroup">The track group to be inspected</param>
        /// <returns>A list of track types that meet the genre criteria of the given track group.</returns>

        private static Dictionary<Type, List<Type>> _allowedTrackTypes = new Dictionary<Type, List<Type>>();
        private static Dictionary<Type, List<Type>> _allowedItemTypes = new Dictionary<Type, List<Type>>();
        private static Dictionary<Type, Type[]> _allSubTypes = new Dictionary<Type, Type[]>();


        public static List<Type> GetAllowedTrackTypes(TrackGroup trackGroup)
        {
#if PROFILE_FILE
            Profiler.BeginSample("DirectorRuntimeHelper.GetAllowedTrackTypes");
#endif // PROFILE_FILE
            // Get all the allowed Genres for this track group
            var t = trackGroup.GetType();
            List<Type> allowedTrackTypes = null;
            if (_allowedTrackTypes.TryGetValue(t, out allowedTrackTypes))
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return allowedTrackTypes;
            }

            TimelineTrackGenre[] genres = new TimelineTrackGenre[0];
            var list = ReflectionHelper.GetCustomAttributes<TrackGroupAttribute>(t, true);
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var attribute = list[i];

                if (attribute != null)
                {
                    genres = attribute.AllowedTrackGenres;
                    break;
                }
            }

            allowedTrackTypes = new List<Type>();
            var typeList = DirectorRuntimeHelper.GetAllSubTypes(typeof(TimelineTrack));
            length = typeList.Length;
            var lengthGenres = genres.Length;
            for (var i = 0; i < length; i++)
            {
                var type = typeList[i];
                var list2 = ReflectionHelper.GetCustomAttributes<TimelineTrackAttribute>(type, true);
                var length2 = list2.Length;
                for (var j = 0; j < length2; j++)
                {
                    var attribute = list2[j];
                    if (attribute != null)
                    {
                        var list3 = attribute.TrackGenres;
                        var length3 = list3.Length;
                        for (var k = 0; k < length3; k++)
                        {
                            for (var x = 0; x < lengthGenres; x++)
                            {
                                if (list3[k] == genres[x])
                                {
                                    allowedTrackTypes.Add(type);
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }

            }

            _allowedTrackTypes[t] = allowedTrackTypes;
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE

            return allowedTrackTypes;
        }

        /// <summary>
        /// Returns a list of Cutscene Item types that are associated with the given Track.
        /// </summary>
        /// <param name="timelineTrack">The track to look up.</param>
        /// <returns>A list of valid cutscene item types.</returns>
        public static List<Type> GetAllowedItemTypes(TimelineTrack timelineTrack)
        {
#if PROFILE_FILE
            Profiler.BeginSample("DirectorRuntimeHelper.GetAllowedItemTypes");
#endif // PROFILE_FILE
            // Get all the allowed Genres for this track
            var t = timelineTrack.GetType();
            List<Type> allowedItemTypes = null;
            if (_allowedItemTypes.TryGetValue(t, out allowedItemTypes))
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return allowedItemTypes;
            }

            CutsceneItemGenre[] genres = new CutsceneItemGenre[0];

            var list = ReflectionHelper.GetCustomAttributes<TimelineTrackAttribute>(t, true);
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var attribute = list[i];

                if (attribute != null)
                {
                    genres = attribute.AllowedItemGenres;
                    break;
                }
            }

            allowedItemTypes = new List<Type>();
            var typeList = DirectorRuntimeHelper.GetAllSubTypes(typeof(TimelineItem));
            length = typeList.Length;
            var lengthGenres = genres.Length;
            for (var i = 0; i < length; i++)
            {
                var type = typeList[i];
                var list2 = ReflectionHelper.GetCustomAttributes<CutsceneItemAttribute>(type, true);
                var length2 = list2.Length;
                for (var j = 0; j < length2; j++)
                {
                    var attribute = list2[j];
                    if (attribute != null)
                    {
                        var list3 = attribute.Genres;
                        var length3 = list3.Length;
                        for (var k = 0; k < length3; k++)
                        {
                            for (var x = 0; x < lengthGenres; x++)
                            {
                                if (list3[k] == genres[x])
                                {
                                    allowedItemTypes.Add(type);
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }

            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            _allowedItemTypes[t] = allowedItemTypes;
            return allowedItemTypes;
        }

        /// <summary>
        /// Get all Sub types from the given parent type.
        /// </summary>
        /// <param name="ParentType">The parent type</param>
        /// <returns>all children types of the parent.</returns>
        private static Type[] GetAllSubTypes(System.Type ParentType)
        {
#if PROFILE_FILE
            Profiler.BeginSample("DirectorRuntimeHelper.GetAllSubTypes");
#endif // PROFILE_FILE
            List<System.Type> list = new List<System.Type>();
            Type[] list2 = null;
            if(_allSubTypes.TryGetValue(ParentType, out list2))
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return list2;
            }

            foreach (Assembly a in ReflectionHelper.GetAssemblies())
            {
                foreach (System.Type type in ReflectionHelper.GetTypes(a))
                {
                    if (type != null && ReflectionHelper.IsSubclassOf(type, ParentType))
                    {
                        list.Add(type);
                    }
                }
            }
            list2 = list.ToArray();
            _allSubTypes[ParentType] = list2;
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return list2;
        }

        /// <summary>
        /// Retrieve all children of a parent Transform recursively.
        /// </summary>
        /// <param name="parent">The parent transform</param>
        /// <returns>All children of that parent.</returns>
        public static List<Transform> GetAllTransformsInHierarchy(Transform parent)
        {
#if PROFILE_FILE
            Profiler.BeginSample("DirectorRuntimeHelper.GetAllTransformsInHierarchy");
#endif // PROFILE_FILE
            List<Transform> children = new List<Transform>();

            foreach (Transform child in parent)
            {
                children.AddRange(GetAllTransformsInHierarchy(child));
                children.Add(child);
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return children;
        }

    }
}
