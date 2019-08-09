// Cinema Suite

// #define PROFILE_FILE

using System;
using UnityEngine;

namespace CinemaDirector
{
    public delegate void ShotBeginsEventHandler(object sender,ShotEventArgs e);
    public delegate void ShotEndsEventHandler(object sender,ShotEventArgs e);

    public class ShotEventArgs : EventArgs
    {
        public CinemaShot shot;

        public ShotEventArgs(CinemaShot shot)
        {
            this.shot = shot;
        }
    }

    /// <summary>
    /// A track that sorts shots and manages associated cameras.
    /// </summary>
    [TimelineTrackAttribute("Shot Track", TimelineTrackGenre.GlobalTrack, CutsceneItemGenre.CameraShot)]
    public class ShotTrack : TimelineTrack
    {
        public event ShotEndsEventHandler ShotEnds;
        public event ShotBeginsEventHandler ShotBegins;

        /// <summary>
        /// Initialize the shot track by enabling the first Camera and disabling all others in the track.
        /// </summary>
        public override void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ShotTrack.Initialize");
#endif // PROFILE_FILE
            base.elapsedTime = 0f;

            CinemaShot firstCamera = null;

            var list = this.GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var shot = list[i] as CinemaShot;
                shot.Initialize();
            }

            for (var i = 0; i < length; i++)
            {
                var shot = list[i] as CinemaShot;
                if (shot.Firetime == 0)
                {
                    firstCamera = shot;
                }
                else
                {
                    shot.End();
                }
            }

            if (firstCamera != null)
            {
                firstCamera.Trigger();
                if (ShotBegins != null)
                {
                    ShotBegins(this, new ShotEventArgs(firstCamera));
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update the Shot Track by deltaTime. Will fire ShotBegins and ShotEnds events.
        /// </summary>
        /// <param name="time">The current running time.</param>
        /// <param name="deltaTime">The deltaTime since the last update.</param>
        public override void UpdateTrack(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ShotTrack.UpdateTrack");
#endif // PROFILE_FILE
            float previousTime = base.elapsedTime;
            base.elapsedTime = time;

            var list = this.GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var shot = list[i] as CinemaShot;
                float endTime = shot.CutTime + shot.Duration;
                if ((previousTime <= shot.CutTime) && (base.elapsedTime >= shot.CutTime) && (base.elapsedTime < endTime))
                {
                    shot.Trigger();
                    if (ShotBegins != null)
                    {
                        ShotBegins(this, new ShotEventArgs(shot));
                    }
                }
                else if ((previousTime >= endTime) && (base.elapsedTime < endTime) && (base.elapsedTime >= shot.CutTime))
                {
                    shot.Trigger();
                    if (ShotBegins != null)
                    {
                        ShotBegins(this, new ShotEventArgs(shot));
                    }
                }
                else if ((previousTime >= shot.CutTime) && (previousTime < endTime) && (base.elapsedTime >= endTime))
                {
                    shot.End();
                    if (ShotEnds != null)
                    {
                        ShotEnds(this, new ShotEventArgs(shot));
                    }
                }
                else if ((previousTime > shot.CutTime) && (previousTime < endTime) && (base.elapsedTime < shot.CutTime))
                {
                    shot.End();
                    if (ShotEnds != null)
                    {
                        ShotEnds(this, new ShotEventArgs(shot));
                    }
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// The shot track will jump to the given time. Disabling the current shot and enabling the new one.
        /// </summary>
        /// <param name="time">The new running time.</param>
        public override void SetTime(float time)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("ShotTrack.SetTime");
#endif // PROFILE_FILE
            CinemaShot previousShot = null;
            CinemaShot newShot = null;

            // Get the old shot and the new shot

            var list = this.GetTimelineItems();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var shot = list[i] as CinemaShot;
                float endTime = shot.CutTime + shot.Duration;
                if ((elapsedTime >= shot.CutTime) && (elapsedTime < endTime))
                {
                    previousShot = shot;
                }
                if ((time >= shot.CutTime) && (time < endTime))
                {
                    newShot = shot;
                }
            }

            // Trigger them as appropriate.
            if (newShot != previousShot)
            {
                if (previousShot != null)
                {
                    previousShot.End();
                    if (ShotEnds != null)
                    {
                        ShotEnds(this, new ShotEventArgs(previousShot));
                    }
                }
                if (newShot != null)
                {
                    newShot.Trigger();
                    if (ShotBegins != null)
                    {
                        ShotBegins(this, new ShotEventArgs(newShot));
                    }
                }
            }

            elapsedTime = time;
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }
    }
}