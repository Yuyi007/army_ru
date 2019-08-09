// Cinema Suite 2014

// #define PROFILE_FILE

using UnityEngine;

namespace CinemaDirector
{
    [TimelineTrackAttribute("Curve Track", TimelineTrackGenre.MultiActorTrack, CutsceneItemGenre.MultiActorCurveClipItem)]
    public class MultiCurveTrack : TimelineTrack, IActorTrack
    {

        public override void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("MultiCurveTrack.Initialize");
#endif // PROFILE_FILE

            var list = this.TimelineItems;
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var clipCurve = list[i] as CinemaMultiActorCurveClip;
                clipCurve.Initialize();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public override void UpdateTrack(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("MultiCurveTrack.UpdateTrack");
#endif // PROFILE_FILE
            base.elapsedTime = time;

            var list = this.TimelineItems;
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var clipCurve = list[i] as CinemaMultiActorCurveClip;
                clipCurve.SampleTime(time);
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public override void Stop()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("MultiCurveTrack.Stop");
#endif // PROFILE_FILE

            var list = this.TimelineItems;
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var clipCurve = list[i] as CinemaMultiActorCurveClip;
                clipCurve.Revert();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public override TimelineItem[] TimelineItems
        {
            get
            {
                return GetComponentsInChildren<CinemaMultiActorCurveClip>();
            }
        }

        public Transform Actor
        {
            get
            {
                ActorTrackGroup component = base.transform.parent.GetComponent<ActorTrackGroup>();
                if (component == null)
                {
                    return null;
                }
                return component.Actor;
            }
        }
    }
}