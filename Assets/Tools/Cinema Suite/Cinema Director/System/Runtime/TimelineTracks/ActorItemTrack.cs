
//#define PROFILE_FILE

using System;

// Cinema Suite
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// A track which maintains all timeline items marked for actor tracks and multi actor tracks.
    /// </summary>
    [TimelineTrackAttribute("Actor Track", new TimelineTrackGenre[] { TimelineTrackGenre.ActorTrack, TimelineTrackGenre.MultiActorTrack }, CutsceneItemGenre.ActorItem)]
    public class ActorItemTrack : TimelineTrack, IActorTrack, IMultiActorTrack
    {
        /// <summary>
        /// Initialize this Track and all the timeline items contained within.
        /// </summary>
        public override void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ActorItemTrack.Initialize");
#endif // PROFILE_FILE
            base.Initialize();
            var list = this.ActorEvents;
            var length = list.Length;

            for (var i = 0; i < length; i++)
            {
                var cinemaEvent = list[i] as CinemaActorEvent;
                var actorList = Actors;
                var count = actorList.Count;
                for (var j = 0; j < count; j++)
                {
                    var actor = actorList[j];
                    if (actor != null)
                    {
                        cinemaEvent.Initialize(actor.gameObject);
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// The cutscene has been set to an arbitrary time by the user.
        /// Processing must take place to catch up to the new time.
        /// </summary>
        /// <param name="time">The new cutscene running time</param>
        public override void SetTime(float time)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ActorItemTrack.SetTime");
#endif // PROFILE_FILE
            float previousTime = elapsedTime;
            base.SetTime(time);

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                // Check if it is an actor event.
                CinemaActorEvent cinemaEvent = item as CinemaActorEvent;
                if (cinemaEvent != null)
                {
                    if (((previousTime < cinemaEvent.Firetime) || (previousTime <= 0f)) && (((time >= cinemaEvent.Firetime))))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                cinemaEvent.Trigger(actor.gameObject);
                            }
                        }
                    }
                    else if (((previousTime >= cinemaEvent.Firetime) && (time < cinemaEvent.Firetime)))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                                cinemaEvent.Reverse(actor.gameObject);
                        }
                    }
                }

                // Check if it is an actor action.
                CinemaActorAction action = item as CinemaActorAction;
                if (action != null)
                {
                    var actorList = Actors;
                    var count = actorList.Count;
                    for (var j = 0; j < count; j++)
                    {
                        var actor = actorList[j];
                        if (actor != null)
                            action.SetTime(actor.gameObject, (time - action.Firetime), time - previousTime);
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update this track since the last frame.
        /// </summary>
        /// <param name="time">The new running time.</param>
        /// <param name="deltaTime">The deltaTime since last update.</param>
        public override void UpdateTrack(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ActorItemTrack.UpdateTrack");
#endif // PROFILE_FILE
            float previousTime = base.elapsedTime;
            base.UpdateTrack(time, deltaTime);

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                // Check if it is an actor event.
                CinemaActorEvent cinemaEvent = item as CinemaActorEvent;
                if (cinemaEvent != null)
                {
                    if (((previousTime < cinemaEvent.Firetime) || (previousTime <= 0f)) && (((base.elapsedTime >= cinemaEvent.Firetime))))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                                cinemaEvent.Trigger(actor.gameObject);
                        }
                    }
                    if (((previousTime >= cinemaEvent.Firetime) && (base.elapsedTime < cinemaEvent.Firetime)))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                                cinemaEvent.Reverse(actor.gameObject);
                        }
                    }
                }

                CinemaActorAction action = item as CinemaActorAction;
                if (action != null)
                {
                    if ((previousTime < action.Firetime && base.elapsedTime >= action.Firetime) && base.elapsedTime < action.EndTime)
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                action.Trigger(actor.gameObject);
                            }
                        }
                    }
                    else if (previousTime <= action.EndTime && base.elapsedTime > action.EndTime)
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                action.End(actor.gameObject);
                            }
                        }
                    }
                    else if (previousTime >= action.Firetime && previousTime < action.EndTime && base.elapsedTime < action.Firetime)
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                action.ReverseTrigger(actor.gameObject);
                            }
                        }
                    }
                    else if ((previousTime > action.EndTime && (base.elapsedTime > action.Firetime) && (base.elapsedTime <= action.EndTime)))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                action.ReverseEnd(actor.gameObject);
                            }
                        }
                    }
                    else if ((base.elapsedTime > action.Firetime) && (base.elapsedTime <= action.EndTime))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                float runningTime = time - action.Firetime;
                                action.UpdateTime(actor.gameObject, runningTime, deltaTime);
                            }
                        }
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Resume playback after being paused.
        /// </summary>
        public override void Resume()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ActorItemTrack.UpdateTrack");
#endif // PROFILE_FILE
            base.Resume();

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaActorAction action = item as CinemaActorAction;
                if (action != null)
                {
                    if (((elapsedTime > action.Firetime)) && (elapsedTime < (action.Firetime + action.Duration)))
                    {
                        var actorList = Actors;
                        var count = actorList.Count;
                        for (var j = 0; j < count; j++)
                        {
                            var actor = actorList[j];
                            if (actor != null)
                            {
                                action.Resume(actor.gameObject);
                            }
                        }
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Stop the playback of this track.
        /// </summary>
        public override void Stop()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ActorItemTrack.Stop");
#endif // PROFILE_FILE
            base.Stop();
            base.elapsedTime = 0f;

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaActorEvent cinemaEvent = item as CinemaActorEvent;
                if (cinemaEvent != null)
                {
                    var actorList = Actors;
                    var count = actorList.Count;
                    for (var j = 0; j < count; j++)
                    {
                        var actor = actorList[j];
                        if (actor != null)
                            cinemaEvent.Stop(actor.gameObject);
                    }
                }

                CinemaActorAction action = item as CinemaActorAction;
                if (action != null)
                {
                    var actorList = Actors;
                    var count = actorList.Count;
                    for (var j = 0; j < count; j++)
                    {
                        var actor = actorList[j];
                        if (actor != null)
                            action.Stop(actor.gameObject);
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Get the Actor associated with this track. Can return null.
        /// </summary>
        public Transform Actor
        {
            get
            {
                ActorTrackGroup atg = this.TrackGroup as ActorTrackGroup;
                if (atg == null)
                {
                    Debug.LogError("No ActorTrackGroup found on parent.", this);
                    return null;
                }
                return atg.Actor;
            }
        }

        /// <summary>
        /// Get the Actors associated with this track. Can return null.
        /// In the case of MultiActors it will return the full list.
        /// </summary>
        public List<Transform> Actors
        {
            get
            {
                ActorTrackGroup trackGroup = TrackGroup as ActorTrackGroup;
                if (trackGroup != null)
                {
                    List<Transform> actors = new List<Transform>() { };
                    actors.Add(trackGroup.Actor);
                    return actors;
                }

                MultiActorTrackGroup multiActorTrackGroup = TrackGroup as MultiActorTrackGroup;
                if (multiActorTrackGroup != null)
                {
                    return multiActorTrackGroup.Actors;
                }
                return null;
            }
        }

        public CinemaActorEvent[] ActorEvents
        {
            get
            {
                return base.GetComponentsInChildren<CinemaActorEvent>();
            }
        }

        public CinemaActorAction[] ActorActions
        {
            get
            {
                return base.GetComponentsInChildren<CinemaActorAction>();
            }
        }
    }
}