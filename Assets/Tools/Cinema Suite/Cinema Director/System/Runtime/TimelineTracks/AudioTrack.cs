
// #define PROFILE_FILE

using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// A track designed specifically to hold audio items.
    /// </summary>
    [TimelineTrackAttribute("Audio Track", TimelineTrackGenre.GlobalTrack, CutsceneItemGenre.AudioClipItem)]
    public class AudioTrack : TimelineTrack
    {
        /// <summary>
        /// Set the track to an arbitrary time.
        /// </summary>
        /// <param name="time">The new time.</param>
        public override void SetTime(float time)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("AudioTrack.SetTime");
#endif // PROFILE_FILE
            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaAudio cinemaAudio = item as CinemaAudio;
                if (cinemaAudio != null)
                {
                    float audioTime = time - cinemaAudio.Firetime;
                    cinemaAudio.SetTime(audioTime);
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Pause all Audio Clips that are currently playing.
        /// </summary>
        public override void Pause()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("AudioTrack.Pause");
#endif // PROFILE_FILE
            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaAudio cinemaAudio = item as CinemaAudio;
                if (cinemaAudio != null)
                {
                    cinemaAudio.Pause();
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update the track and play any newly triggered items.
        /// </summary>
        /// <param name="time">The new running time.</param>
        /// <param name="deltaTime">The deltaTime since the last update call.</param>
        public override void UpdateTrack(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("AudioTrack.UpdateTrack");
#endif // PROFILE_FILE
            float elapsedTime = base.elapsedTime;
            base.elapsedTime = time;

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaAudio cinemaAudio = item as CinemaAudio;
                if (cinemaAudio != null)
                {
                    if (((elapsedTime < cinemaAudio.Firetime) || (elapsedTime <= 0f)) && (((base.elapsedTime >= cinemaAudio.Firetime))))
                    {
                        cinemaAudio.Trigger();
                    }
                    if ((base.elapsedTime > cinemaAudio.Firetime) && (base.elapsedTime <= (cinemaAudio.Firetime + cinemaAudio.Duration)))
                    {
                        float audioTime = time - cinemaAudio.Firetime;
                        cinemaAudio.UpdateTime(audioTime, deltaTime);
                    }
                    if (((elapsedTime <= (cinemaAudio.Firetime + cinemaAudio.Duration)) && (base.elapsedTime > (cinemaAudio.Firetime + cinemaAudio.Duration))))
                    {
                        cinemaAudio.End();
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Resume playing audio clips after calling a Pause.
        /// </summary>
        public override void Resume()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("AudioTrack.Resume");
#endif // PROFILE_FILE
            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaAudio cinemaAudio = item as CinemaAudio;
                if (cinemaAudio != null)
                {
                    if (((base.Cutscene.RunningTime > cinemaAudio.Firetime)) && (base.Cutscene.RunningTime < (cinemaAudio.Firetime + cinemaAudio.Duration)))
                    {
                        cinemaAudio.Resume();
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Stop playback of all playing audio items.
        /// </summary>
        public override void Stop()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("AudioTrack.Stop");
#endif // PROFILE_FILE
            base.elapsedTime = 0f;

            var list = GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var item = list[i];
                CinemaAudio cinemaAudio = item as CinemaAudio;
                if (cinemaAudio != null)
                {
                    cinemaAudio.Stop();
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Get all cinema audio objects associated with this audio track
        /// </summary>
        public CinemaAudio[] AudioClips
        {
            get
            {
                return GetComponentsInChildren<CinemaAudio>();
            }
        }
    }
}