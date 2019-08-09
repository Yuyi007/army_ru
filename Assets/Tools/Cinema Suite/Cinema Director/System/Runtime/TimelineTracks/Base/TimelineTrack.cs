
// #define PROFILE_FILE

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    public abstract class TimelineTrack : MonoBehaviour, IOptimizable
    {
        [SerializeField]
        private int ordinal = -1;
        // Ordering of Tracks

        [SerializeField]
        private bool canOptimize = true;
        // If true, this Track will load all items into cache on Optimize().

        // Options for when this Track will execute its Timeline Items.
        public PlaybackMode PlaybackMode = PlaybackMode.RuntimeAndEdit;

        protected float elapsedTime = -1f;

        // A cache of the TimelineItems for optimization purposes.
        protected TimelineItem[] itemCache;

        // A list of the cutscene item types that this Track is allowed to contain.
        protected List<Type> allowedItemTypes;

        private bool hasBeenOptimized = false;
        private TrackGroup _trackGroup = null;

        /// <summary>
        /// Prepares the TimelineTrack by caching all TimelineItems contained inside of it.
        /// </summary>
        public virtual void Optimize()
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.Optimize");
#endif // PROFILE_FILE
            if (canOptimize)
            {
                itemCache = GetTimelineItems();
                hasBeenOptimized = true;
            }

            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                if (item is IOptimizable)
                {
                    (item as IOptimizable).Optimize();
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Perform any initialization before the cutscene begins a fresh playback
        /// </summary>
        public virtual void Initialize()
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.Initialize");
#endif // PROFILE_FILE
            elapsedTime = -1f;
            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                item.Initialize();
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update the track to the given time
        /// </summary>
        /// <param name="time"></param>
        public virtual void UpdateTrack(float runningTime, float deltaTime)
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.UpdateTrack");
#endif // PROFILE_FILE
            float previousTime = elapsedTime;
            elapsedTime = runningTime;

#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.UpdateTrack.seg_1");
#endif // PROFILE_FILE
            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                CinemaGlobalEvent cinemaEvent = item as CinemaGlobalEvent;
                if (cinemaEvent == null)
                    continue;

                if ((previousTime < cinemaEvent.Firetime) && (((elapsedTime >= cinemaEvent.Firetime))))
                {
                    cinemaEvent.Trigger();
                }
                else if (((previousTime >= cinemaEvent.Firetime) && (elapsedTime < cinemaEvent.Firetime)))
                {
                    cinemaEvent.Reverse();
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE


#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.UpdateTrack.seg_2");
#endif // PROFILE_FILE
            timeLines = GetTimelineItems();
            length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                CinemaGlobalAction action = item as CinemaGlobalAction;
                if (action == null)
                    continue;
                if ((previousTime < action.Firetime && elapsedTime >= action.Firetime) && elapsedTime < action.EndTime)
                {
                    action.Trigger();
                }
                else if ((previousTime < action.EndTime) && (elapsedTime >= action.EndTime))
                {
                    action.End();
                }
                else if (previousTime > action.Firetime && previousTime <= action.EndTime && elapsedTime < action.Firetime)
                {
                    action.ReverseTrigger();
                }
                else if ((previousTime > (action.EndTime) && (elapsedTime > action.Firetime) && (elapsedTime <= action.EndTime)))
                {
                    action.ReverseEnd();
                }
                else if ((elapsedTime > action.Firetime) && (elapsedTime < action.EndTime))
                {
                    float t = runningTime - action.Firetime;
                    action.UpdateTime(t, deltaTime);
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE

#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Notify track items that the cutscene has been paused
        /// </summary>
        public virtual void Pause()
        {
        }

        /// <summary>
        /// Notify track items that the cutscene has been resumed from a paused state.
        /// </summary>
        public virtual void Resume()
        {
        }

        /// <summary>
        /// The cutscene has been set to an arbitrary time by the user.
        /// Processing must take place to catch up to the new time.
        /// </summary>
        /// <param name="time">The new cutscene running time</param>
        public virtual void SetTime(float time)
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.SetTime");
#endif // PROFILE_FILE
            float previousTime = elapsedTime;
            elapsedTime = time;

            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                // Check if it is a global event.
                CinemaGlobalEvent cinemaEvent = item as CinemaGlobalEvent;
                if (cinemaEvent != null)
                {
                    if ((previousTime < cinemaEvent.Firetime) && (((elapsedTime >= cinemaEvent.Firetime))))
                    {
                        cinemaEvent.Trigger();
                    }
                    else if (((previousTime >= cinemaEvent.Firetime) && (elapsedTime < cinemaEvent.Firetime)))
                    {
                        cinemaEvent.Reverse();
                    }
                }

                // Check if it is a global action.
                CinemaGlobalAction action = item as CinemaGlobalAction;
                if (action != null)
                {
                    action.SetTime((time - action.Firetime), time - previousTime);
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Retrieve a list of important times for this track within the given range.
        /// </summary>
        /// <param name="from">The starting point of the range.</param>
        /// <param name="to">The end point of the range.</param>
        /// <returns>A list of ordered milestone times within the given range.</returns>

        private Dictionary<float, bool> timeDict1 = new Dictionary<float, bool>();

        public virtual List<float> GetMilestones(float from, float to)
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.GetMilestones");
#endif // PROFILE_FILE
            bool isReverse = from > to;

            List<float> times = new List<float>();
            timeDict1.Clear();
            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                if ((!isReverse && from < item.Firetime && to >= item.Firetime) || (isReverse && from > item.Firetime && to <= item.Firetime))
                {
                    if (!timeDict1.ContainsKey(item.Firetime))
                    {
                        times.Add(item.Firetime);
                        timeDict1.Add(item.Firetime, true);
                    }
                }

                if (item is TimelineAction)
                {
                    float endTime = (item as TimelineAction).EndTime;
                    if ((!isReverse && from < endTime && to >= endTime) || (isReverse && from > endTime && to <= endTime))
                    {
                        if (!timeDict1.ContainsKey(endTime))
                        {
                            times.Add(endTime);
                            timeDict1.Add(endTime, true);
                        }
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
        /// Notify the track items that the cutscene has been stopped
        /// </summary>
        public virtual void Stop()
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.Stop");
#endif // PROFILE_FILE
            var timeLines = GetTimelineItems();
            var length = timeLines.Length;
            for (var i = 0; i < length; i++)
            {
                var item = timeLines[i];
                item.Stop();
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Returns all allowed Timeline Item types.
        /// </summary>
        /// <returns>A list of allowed cutscene item types.</returns>
        public List<Type> GetAllowedCutsceneItems()
        {
            if (allowedItemTypes == null)
            {
                allowedItemTypes = DirectorRuntimeHelper.GetAllowedItemTypes(this);
            }
            return allowedItemTypes;
        }

        /// <summary>
        /// The Cutscene that this Track is associated with. Can return null.
        /// </summary>
        public Cutscene Cutscene
        {
            get { return ((this.TrackGroup == null) ? null : this.TrackGroup.Cutscene); }
        }

        /// <summary>
        /// The TrackGroup associated with this Track. Can return null.
        /// </summary>
        public TrackGroup TrackGroup
        {
            get
            {
                if (_trackGroup == null)
                {
                    // GetComponentInParent does not seem to work in Unity 5.3.
                    // This means that the Cutscene hierarchy structure has to be strictly maintained.
                    var parent = transform.parent;
                    if (parent != null)
                    {
#if UNITY_5_3_OR_NEWER
                        _trackGroup = parent.GetComponent<TrackGroup>();
#else
                    _trackGroup = parent.GetComponentInParent<TrackGroup>();
#endif
                    }
                    else
                    {
                        Debug.LogError("Track has no parent.", this);
                    }
                }

                return _trackGroup;
            }
        }

        /// <summary>
        /// Ordinal for UI ranking.
        /// </summary>
        public int Ordinal
        {
            get
            {
                return ordinal;
            }
            set
            {
                ordinal = value;
            }
        }

        /// <summary>
        /// Enable this if the Track does not have Items added/removed during running.
        /// </summary>
        public bool CanOptimize
        {
            get { return canOptimize; }
            set { canOptimize = value; }
        }

        /// <summary>
        /// Get all TimelineItems that are allowed to be in this Track.
        /// </summary>
        /// <returns>A filtered list of Timeline Items.</returns>
        public TimelineItem[] GetTimelineItems()
        {
#if PROFILE_FILE
            Profiler.BeginSample("TimelineTrack.GetTimelineItems");
#endif // PROFILE_FILE
            // Return the cache if possible
            if (hasBeenOptimized)
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return itemCache;
            }

            List<TimelineItem> items = new List<TimelineItem>();
            var types = GetAllowedCutsceneItems();
            var length = types.Count;
            for (var i = 0; i < length; i++)
            {
                var t = types[i];
                var components = GetComponentsInChildren(t);
                var length2 = components.Length;
                for (var j = 0; j < length2; j++)
                {
                    var component = components[j];
                    items.Add((TimelineItem)component);
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return items.ToArray();
        }

        public virtual TimelineItem[] TimelineItems
        {
            get { return base.GetComponentsInChildren<TimelineItem>(); }
        }
    }

}