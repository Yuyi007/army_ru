
// #define PROFILE_FILE

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// The main organizational unit of a Cutscene, The TrackGroup contains tracks.
    /// </summary>
    [TrackGroupAttribute("Track Group", TimelineTrackGenre.GlobalTrack)]
    public abstract class TrackGroup : MonoBehaviour, IOptimizable
    {
        [SerializeField]
        private int ordinal = -1;
        // For ordering in UI

        [SerializeField]
        private bool canOptimize = true;
        // If true, this Track Group will load all tracks into cache on Optimize().






        // A cache of the tracks for optimization purposes.
        protected TimelineTrack[] trackCache;

        // A list of the types that this Track Group is allowed to contain.
        protected List<Type> allowedTrackTypes;

        private bool hasBeenOptimized = false;

        /// <summary>
        /// Prepares the TrackGroup by caching all TimelineTracks.
        /// </summary>
        public virtual void Optimize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.Optimize");
#endif // PROFILE_FILE
            if (canOptimize)
            {
                trackCache = GetTracks();
                hasBeenOptimized = true;
            }

            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.Optimize();
            }

#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Initialize all Tracks before beginning a fresh playback.
        /// </summary>
        public virtual void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.Initialize");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.Initialize();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update the track group to the current running time of the cutscene.
        /// </summary>
        /// <param name="time">The current running time</param>
        /// <param name="deltaTime">The deltaTime since the last update call</param>
        public virtual void UpdateTrackGroup(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.UpdateTrackGroup");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.UpdateTrack(time, deltaTime);
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Pause all Track Items that this TrackGroup contains.
        /// </summary>
        public virtual void Pause()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.Pause");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.Pause();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Stop all Track Items that this TrackGroup contains.
        /// </summary>
        public virtual void Stop()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.Stop");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.Stop();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Resume all Track Items that this TrackGroup contains.
        /// </summary>
        public virtual void Resume()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.Resume");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.Resume();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Set this TrackGroup to the state of a given new running time.
        /// </summary>
        /// <param name="time">The new running time</param>
        public virtual void SetRunningTime(float time)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.SetRunningTime");
#endif // PROFILE_FILE
            var tracks = GetTracks();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                track.SetTime(time);
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Retrieve a list of important times for this track group within the given range.
        /// </summary>
        /// <param name="from">the starting time</param>
        /// <param name="to">the ending time</param>
        /// <returns>A list of ordered milestone times within the given range.</returns>
        private Dictionary<float, bool> timeDict = new Dictionary<float, bool>();

        public virtual List<float> GetMilestones(float from, float to)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.GetMilestones");
#endif // PROFILE_FILE
            List<float> times = new List<float>();
            var tracks = GetTracks();
            timeDict.Clear();
            var length = tracks.Length;
            for (var i = 0; i < length; i++)
            {
                var track = tracks[i];
                List<float> trackTimes = track.GetMilestones(from, to);
                var count = trackTimes.Count;
                for (var j = 0; j < count; j++)
                {
                    var f = trackTimes[j];
                    if (!timeDict.ContainsKey(f))
                    {
                        times.Add(f);
                        timeDict.Add(f, true);
                    }
                }
            }
            times.Sort();
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
            return times;
        }

        /// <summary>
        /// The Cutscene that this TrackGroup is associated with. Will return null if TrackGroup does not have a Cutscene as a parent.
        /// </summary>
        private Cutscene _cutscene;
        public Cutscene Cutscene
        {
            get
            {
                if (_cutscene == null && transform.parent != null)
                {
                    _cutscene = transform.parent.GetComponentInParent<Cutscene>();
                }
                return _cutscene;
            }
        }

        /// <summary>
        /// The TimelineTracks that this TrackGroup contains.
        /// </summary>
        public virtual TimelineTrack[] GetTracks()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("TrackGroup.GetTracks");
#endif // PROFILE_FILE
            // Return the cache if possible
            if (hasBeenOptimized)
            {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                return trackCache;
            }

            List<TimelineTrack> tracks = new List<TimelineTrack>();
            var types = GetAllowedTrackTypes();
            var count = types.Count;
            for (var i = 0; i < count; i++)
            {
                var t = types[i];
                var components = GetComponentsInChildren(t);
                var length = components.Length;
                for (var j = 0; j < length; j++)
                {
                    var component = components[j];
                    tracks.Add((TimelineTrack)component);
                }
            }

            tracks.Sort(
                delegate(TimelineTrack track1, TimelineTrack track2)
                {
                    return track1.Ordinal - track2.Ordinal;
                });
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
            return tracks.ToArray();
        }

        /// <summary>
        /// Provides a list of Types this Track Group is allowed to contain. Loaded by looking at Attributes.
        /// </summary>
        /// <returns>The list of track types.</returns>
        public List<Type> GetAllowedTrackTypes()
        {
            if (allowedTrackTypes == null)
            {
                allowedTrackTypes = DirectorRuntimeHelper.GetAllowedTrackTypes(this);
            }
            return allowedTrackTypes;
        }

        /// <summary>
        /// Ordinal for UI ranking.
        /// </summary>
        public int Ordinal
        {
            get { return ordinal; }
            set { ordinal = value; }
        }

        /// <summary>
        /// Enable this if the TrackGroup does not have Tracks added/removed during running.
        /// </summary>
        public bool CanOptimize
        {
            get { return canOptimize; }
            set { canOptimize = value; }
        }
    }
}