
// #define PROFILE_FILE

using UnityEngine;

namespace CinemaDirector
{
    [TimelineTrackAttribute("Global Track", TimelineTrackGenre.GlobalTrack, CutsceneItemGenre.GlobalItem)]
    public class GlobalItemTrack : TimelineTrack
    {
        public CinemaGlobalEvent[] Events
        {
            get
            {
                return base.GetComponentsInChildren<CinemaGlobalEvent>();
            }
        }

        public CinemaGlobalAction[] Actions
        {
            get
            {
                return base.GetComponentsInChildren<CinemaGlobalAction>();
            }
        }

        public override TimelineItem[] TimelineItems
        {
            get
            {
#if PROFILE_FILE 
            Profiler.BeginSample("GlobalItemTrack.TimelineItems");
#endif // PROFILE_FILE
                CinemaGlobalEvent[] events = Events;
                CinemaGlobalAction[] actions = Actions;

                TimelineItem[] items = new TimelineItem[events.Length + actions.Length];
                var eventLength = events.Length;
                for (int i = 0; i < eventLength; i++)
                {
                    items[i] = events[i];
                }

                var actionLength = actions.Length;
                for (int i = 0; i < actionLength; i++)
                {
                    items[i + eventLength] = actions[i];
                }

#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                return items;
            }
        }
    }
}