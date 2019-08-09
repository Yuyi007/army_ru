// Cinema Suite

// #define PROFILE_FILE

using CinemaDirector.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// The character track group is a type of actor group, specialized for humanoid characters.
    /// </summary>
    [TrackGroupAttribute("Character Track Group", TimelineTrackGenre.CharacterTrack)]
    public class CharacterTrackGroup : ActorTrackGroup, IRevertable, IBakeable
    {
        // Options for reverting in editor.
        [SerializeField]
        private RevertMode editorRevertMode = RevertMode.Revert;

        // Options for reverting during runtime.
        [SerializeField]
        private RevertMode runtimeRevertMode = RevertMode.Revert;

        // Has a bake been called on this track group?
        private bool hasBeenBaked = false;

        /// <summary>
        /// Bake the Mecanim preview data.
        /// </summary>
        public void Bake()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("CharacterTrackGroup.Bake");
#endif // PROFILE_FILE
            if (Actor == null || Application.isPlaying) 
            {
#if PROFILE_FILE 
                Profiler.EndSample();
#endif // PROFILE_FILE
                return;
            }
            Animator animator = Actor.GetComponent<Animator>();
            if (animator == null)
            { 
#if PROFILE_FILE 
                Profiler.EndSample();
#endif // PROFILE_FILE
                return;
            }

            List<RevertInfo> revertCache = new List<RevertInfo>();

            // Build the cache of revert info.
            var comps = this.GetComponentsInChildren<MonoBehaviour>();
            for (var i = 0; i < comps.Length; ++i)
            {
                MonoBehaviour mb = comps[i];
                IRevertable revertable = mb as IRevertable;
                if (revertable != null)
                {
                    revertCache.AddRange(revertable.CacheState());
                }
            }

            Vector3 position = Actor.transform.localPosition;
            Quaternion rotation = Actor.transform.localRotation;
            Vector3 scale = Actor.transform.localScale;

            float frameRate = 30;
            int frameCount = (int)((Cutscene.Duration * frameRate) + 2);
            animator.StopPlayback();
            animator.recorderStartTime = 0;
            animator.StartRecording(frameCount);

            base.SetRunningTime(0);

            for (int i = 0; i < frameCount - 1; i++)
            {
                var tracks = GetTracks();
                for (int j = 0; j < tracks.Length; ++j)
                {
                    TimelineTrack track = tracks[j];
                    if (!(track is DialogueTrack))
                    {
                        track.UpdateTrack(i * (1.0f / frameRate), (1.0f / frameRate));
                    }
                }
                animator.Update(1.0f / frameRate);
            }
            animator.recorderStopTime = frameCount * (1.0f / frameRate);
            animator.StopRecording();
            animator.StartPlayback();

            hasBeenBaked = true;

            // Return the Actor to his initial position.
            Actor.transform.localPosition = position;
            Actor.transform.localRotation = rotation;
            Actor.transform.localScale = scale;

            for (int i = 0; i < revertCache.Count; ++i)
            {
                RevertInfo revertable = revertCache[i];
                if (revertable != null)
                {
                    if ((revertable.EditorRevert == RevertMode.Revert && !Application.isPlaying) ||
                        (revertable.RuntimeRevert == RevertMode.Revert && Application.isPlaying))
                    {
                        revertable.Revert();
                    }
                }
            }

            base.Initialize();
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Cache the Actor Transform.
        /// </summary>
        /// <returns>The revert info for the Actor's transform.</returns>
        public RevertInfo[] CacheState()
        {
            RevertInfo[] reverts = new RevertInfo[3];
            if (Actor == null)
                return new RevertInfo[0];
            reverts[0] = new RevertInfo(this, Actor.transform, "localPosition", Actor.transform.localPosition);
            reverts[1] = new RevertInfo(this, Actor.transform, "localRotation", Actor.transform.localRotation);
            reverts[2] = new RevertInfo(this, Actor.transform, "localScale", Actor.transform.localScale);
            return reverts;
        }

        /// <summary>
        /// Initialize the Track Group as normal and initialize the Animator if in Editor Mode.
        /// </summary>
        public override void Initialize()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("CharacterTrackGroup.Initialize");
#endif // PROFILE_FILE
            base.Initialize();
            if (!Application.isPlaying)
            {
                if (Actor == null) 
                {
#if PROFILE_FILE 
                    Profiler.EndSample();
#endif // PROFILE_FILE
                    return;
                }

                Animator animator = Actor.GetComponent<Animator>();
                if (animator == null)
                {
#if PROFILE_FILE 
                    Profiler.EndSample();
#endif // PROFILE_FILE
                    return;
                }
                animator.StartPlayback();
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Update the Track Group over time. If in editor mode, play the baked animator data.
        /// </summary>
        /// <param name="time">The new running time.</param>
        /// <param name="deltaTime">the deltaTime since last update.</param>
        public override void UpdateTrackGroup(float time, float deltaTime)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("CharacterTrackGroup.UpdateTrackGroup");
#endif // PROFILE_FILE
            if (Application.isPlaying)
            {
                base.UpdateTrackGroup(time, deltaTime);
            }
            else
            {
                var list = GetTracks();
                var length = list.Length;
                for (var i = 0; i < length; i++)
                {
                    var track = list[i];
                    if (!(track is MecanimTrack))
                    {
                        track.UpdateTrack(time, deltaTime);
                    } 
                }

                if (Actor == null)
                {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE 
                    return;
                }

                Animator animator = Actor.GetComponent<Animator>();
                if (animator == null)
                {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                    return;
                }

                if (Actor.gameObject.activeInHierarchy)
                {
                    animator.playbackTime = time;
                    animator.Update(0);
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public override void SetRunningTime(float time)
        {
#if PROFILE_FILE 
            Profiler.BeginSample("CharacterTrackGroup.SetRunningTime");
#endif // PROFILE_FILE
            if (Application.isPlaying)
            {
                var list = GetTracks();
                var length = list.Length;
                for (var i = 0; i < length; i++)
                {
                    var track = list[i];
                    track.SetTime(time);
                }
            }
            else
            {
                var list = GetTracks();
                var length = list.Length;
                for (var i = 0; i < length; i++)
                {
                    var track = list[i];
                    if (!(track is MecanimTrack))
                    {
                        track.SetTime(time);
                    }
                }

                if (Actor == null) 
                {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                    return;
                }

                Animator animator = Actor.GetComponent<Animator>();
                if (animator == null)
                {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                    return;
                }
                if (Actor.gameObject.activeInHierarchy)
                {
                    animator.playbackTime = time;
                    animator.Update(0);
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Stop this track group and stop playback on animator.
        /// </summary>
        public override void Stop()
        {
#if PROFILE_FILE 
            Profiler.BeginSample("CharacterTrackGroup.Stop");
#endif // PROFILE_FILE
            base.Stop();

            if (!Application.isPlaying)
            {
                if (hasBeenBaked)
                {
                    hasBeenBaked = false;
                    Animator animator = Actor.GetComponent<Animator>();
                    if (animator == null)
                    {
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
                        return;
                    }

                    if (animator.recorderStopTime > 0)
                    {
                        if (Actor.gameObject.activeInHierarchy)
                        {
                            animator.StartPlayback();
                            animator.playbackTime = 0;


                            animator.Update(0);

                            animator.StopPlayback();

                            animator.Rebind();
                        }
                    }
                    
                }
            }
#if PROFILE_FILE 
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Option for choosing when this Event will Revert to initial state in Editor.
        /// </summary>
        public RevertMode EditorRevertMode
        {
            get { return editorRevertMode; }
            set { editorRevertMode = value; }
        }

        /// <summary>
        /// Option for choosing when this Event will Revert to initial state in Runtime.
        /// </summary>
        public RevertMode RuntimeRevertMode
        {
            get { return runtimeRevertMode; }
            set { runtimeRevertMode = value; }
        }
    }
}