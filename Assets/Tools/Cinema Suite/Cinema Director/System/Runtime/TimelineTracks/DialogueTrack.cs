// Cinema Suite 2014

// #define PROFILE_FILE

using UnityEngine;

namespace CinemaDirector
{
    [TimelineTrackAttribute("Dialogue Track", TimelineTrackGenre.CharacterTrack, CutsceneItemGenre.AudioClipItem)]
    public class DialogueTrack : AudioTrack, IActorTrack
    {
        
        [SerializeField]
        private Transform anchor = null;

        public override void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("DialogueTrack.Initialize");
#endif // PROFILE_FILE
            base.Initialize();
            setTransform();
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public override void UpdateTrack(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("DialogueTrack.UpdateTrack");
#endif // PROFILE_FILE
            setTransform();
            base.UpdateTrack(time, deltaTime);
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        private void setTransform()
        {
            if (anchor != null)
            {
                this.transform.position = anchor.position;
            }
            else if (Actor != null)
            {
                this.transform.position = Actor.transform.position;
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