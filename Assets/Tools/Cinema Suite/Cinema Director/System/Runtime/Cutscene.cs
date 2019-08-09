// Cinema Suite

// #define PROFILE_FILE

using CinemaDirector.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// The Cutscene is the main Behaviour of Cinema Director.
    /// </summary>
    [ExecuteInEditMode, Serializable]
    public class Cutscene : MonoBehaviour, IOptimizable
    {
#region Fields

        [SerializeField]
        private float duration = 30f;
        // Duration of cutscene in seconds.

        [SerializeField]
        private float playbackSpeed = 1f;
        // Multiplier for playback speed.

        [SerializeField]
        private bool isSkippable = true;

        [SerializeField]
        private bool isLooping = false;

        [SerializeField]
        private bool canOptimize = true;

        [NonSerialized]
        private float runningTime = 0f;

        [NonSerialized]
        private bool useFastEval = false;

        public bool UseFastEval
        {
            get
            {
                return useFastEval;
            }
            set
            {
                useFastEval = value;
            }
        }

        // Running time of the cutscene in seconds.

        [NonSerialized]
        private CutsceneState state = CutsceneState.Inactive;

        // Keeps track of the previous time an update was made.
        //private float previousTime = 0;

        // Has the Cutscene been optimized yet.
        private bool hasBeenOptimized = false;

        // Has the Cutscene been initialized yet.
        private bool hasBeenInitialized = false;

        // The cache of Track Groups that this Cutscene contains.
        private TrackGroup[] trackGroupCache;

        // A list of all the Tracks and Items revert info, to revert states on Cutscene entering and exiting play mode.
        private List<RevertInfo> revertCache = new List<RevertInfo>();

#endregion

        // Event fired when Cutscene's runtime reaches it's duration.
        public event CutsceneHandler CutsceneFinished;

        // Event fired when Cutscene has been paused.
        public event CutsceneHandler CutscenePaused;

        /// <summary>
        /// Optimizes the Cutscene by preparing all tracks and timeline items into a cache.
        /// Call this on scene load in most cases. (Avoid calling in edit mode).
        /// </summary>
        public void Optimize()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.Optimize");
#endif // PROFILE_FILE
            var list = GetTrackGroups();
            if (canOptimize)
            {
                trackGroupCache = list;
                hasBeenOptimized = true;
            }

            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var tg = list[i];
                tg.Optimize();
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Plays/Resumes the cutscene from inactive/paused states using a Coroutine.
        /// </summary>
        public void Play()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.Play");
#endif // PROFILE_FILE
            if (state == CutsceneState.Inactive)
            {
                StartCoroutine("freshPlay");
            }
            else if (state == CutsceneState.Paused)
            {
                state = CutsceneState.Playing;
                StartCoroutine("updateCoroutine");
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        private IEnumerator freshPlay()
        {
            PreparePlay();

            // Wait one frame.
            yield return null;

            // Beging playing
            state = CutsceneState.Playing;
            StartCoroutine("updateCoroutine");
        }

        /// <summary>
        /// Pause the playback of this cutscene.
        /// </summary>
        public void Pause()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.Pause");
#endif // PROFILE_FILE
            if (state == CutsceneState.Playing)
            {
                StopCoroutine("updateCoroutine");
            }
            if (state == CutsceneState.PreviewPlaying || state == CutsceneState.Playing || state == CutsceneState.Scrubbing)
            {
                var list = GetTrackGroups();
                var length = list.Length;
                for (var i = 0; i < length; i++)
                {
                    var trackGroup = list[i];
                    trackGroup.Pause();
                }
            }
            state = CutsceneState.Paused;

            if (CutscenePaused != null)
            {
                CutscenePaused(this, new CutsceneEventArgs());
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Skip the cutscene to the end and stop it
        /// </summary>
        public void Skip()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.Skip");
#endif // PROFILE_FILE
            if (isSkippable)
            {
                SetRunningTime(this.Duration);
                state = CutsceneState.Inactive;
                Stop();
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
            }
        }

        /// <summary>
        /// Stops the cutscene.
        /// </summary>
        public void Stop()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.Stop");
#endif // PROFILE_FILE
            this.RunningTime = 0f;
            var list = GetTrackGroups();

            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var group = list[i];
                group.Stop();
            }

            revert();

            if (state == CutsceneState.Playing)
            {
                StopCoroutine("updateCoroutine");
                if (state == CutsceneState.Playing && isLooping)
                {
                    state = CutsceneState.Inactive;
                    Play();
                }
                else
                {
                    state = CutsceneState.Inactive;
                }
            }
            else
            {
                state = CutsceneState.Inactive;
            }

            if (state == CutsceneState.Inactive)
            {
                if (CutsceneFinished != null)
                {
                    CutsceneFinished(this, new CutsceneEventArgs());
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Updates the cutscene by the amount of time passed.
        /// </summary>
        /// <param name="deltaTime">The delta in time between the last update call and this one.</param>
        public void UpdateCutscene(float deltaTime)
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.UpdateCutscene");
#endif // PROFILE_FILE
            this.RunningTime += (deltaTime * playbackSpeed);
            var list = GetTrackGroups();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var group = list[i];
                group.UpdateTrackGroup(RunningTime, deltaTime * playbackSpeed);

                if (isLooping)
                {
                    if (runningTime >= duration || runningTime < 0f)
                    {
                        group.Stop();
                    }
                }
            }

            if (isLooping)
            {
                if (runningTime >= duration || runningTime < 0f)
                {
                    runningTime = 0f;
                    revert();
                }
            }
            else if (state != CutsceneState.Scrubbing)
            {
                if (runningTime >= duration || runningTime < 0f)
                {
                    Stop();
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Preview play readies the cutscene to be played in edit mode. Never use for runtime.
        /// This is necessary for playing the cutscene in edit mode.
        /// </summary>
        public void PreviewPlay()
        {
            if (state == CutsceneState.Inactive)
            {
                EnterPreviewMode();
            }
            else if (state == CutsceneState.Paused)
            {
                resume();
            }

            if (Application.isPlaying)
            {
                state = CutsceneState.Playing;
            }
            else
            {
                state = CutsceneState.PreviewPlaying;
            }
        }

        /// <summary>
        /// Play the cutscene from it's given running time to a new time
        /// </summary>
        /// <param name="newTime">The new time to make up for</param>
        public void ScrubToTime(float newTime)
        {
            float deltaTime = Mathf.Clamp(newTime, 0, Duration) - this.RunningTime;

            state = CutsceneState.Scrubbing;
            if (deltaTime != 0)
            {
                if (deltaTime > (1 / 30f))
                {
                    float prevTime = RunningTime;
                    var list = getMilestones(RunningTime + deltaTime);
                    var count = list.Count;
                    for (var i = 0; i < count; i++)
                    {
                        var milestone = list[i];
                        float delta = milestone - prevTime;
                        UpdateCutscene(delta);
                        prevTime = milestone;
                    }
                }
                else
                {
                    UpdateCutscene(deltaTime);
                }
            }
            else
            {
                Pause();
            }
        }

        /// <summary>
        /// Set the cutscene to the state of a given new running time and do not proceed to play the cutscene
        /// </summary>
        /// <param name="time">The new running time to be set.</param>
        public void SetRunningTime(float time)
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.SetRunningTime");
#endif // PROFILE_FILE
            var milestones = getMilestones(time);
            var count = milestones.Count;
            for (var i = 0; i < count; i++)
            {
                var milestone = milestones[i];
                var list = TrackGroups;
                var length = list.Length;
                for (var j = 0; j < length; j++)
                {
                    var group = list[j];
                    group.SetRunningTime(milestone);
                }
            }

            this.RunningTime = time;
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        private void SetMileStones(float time)
        {

        }

        /// <summary>
        /// Set the cutscene into an active state.
        /// </summary>
        public void EnterPreviewMode()
        {
            if (state == CutsceneState.Inactive)
            {
                initialize();
                bake();
                SetRunningTime(RunningTime);
                state = CutsceneState.Paused;
            }
        }

        /// <summary>
        /// Set the cutscene into an inactive state.
        /// </summary>
        public void ExitPreviewMode()
        {
            Stop();
        }

        /// <summary>
        /// Cutscene has been destroyed. Revert everything if necessary.
        /// </summary>
        protected void OnDestroy()
        {
            if (!Application.isPlaying)
            {
                Stop();
            }
        }

        /// <summary>
        /// Exit and Re-enter preview mode at the current running time.
        /// Important for Mecanim Previewing.
        /// </summary>
        public void Refresh()
        {
            if (state != CutsceneState.Inactive)
            {
                float tempTime = runningTime;
                Stop();
                EnterPreviewMode();
                SetRunningTime(tempTime);
            }
        }

        /// <summary>
        /// Bake all Track Groups who are Bakeable.
        /// This is necessary for things like mecanim previewing.
        /// </summary>
        private void bake()
        {
            if (Application.isEditor)
            {
                var list = GetTrackGroups();
                var length = list.Length;
                for (var i = 0; i < length; i++)
                {
                    var group = list[i];
                    if (group is IBakeable)
                    {
                        (group as IBakeable).Bake();
                    }
                }
            }
        }

        /// <summary>
        /// The duration of this cutscene in seconds.
        /// </summary>
        public float Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
                if (this.duration <= 0f)
                {
                    this.duration = 0.1f;
                }
            }
        }

        /// <summary>
        /// Returns true if this cutscene is currently playing.
        /// </summary>
        public CutsceneState State
        {
            get
            {
                return this.state;
            }
        }

        /// <summary>
        /// The current running time of this cutscene in seconds. Values are restricted between 0 and duration.
        /// </summary>
        public float RunningTime
        {
            get
            {
                return this.runningTime;
            }
            set
            {
                runningTime = Mathf.Clamp(value, 0, duration);
            }
        }

        /// <summary>
        /// Get all Track Groups in this Cutscene. Will return cache if possible.
        /// </summary>
        /// <returns></returns>
        public TrackGroup[] GetTrackGroups()
        {
            // Return the cache if possible
            if (hasBeenOptimized)
            {
                return trackGroupCache;
            }

            return TrackGroups;
        }

        /// <summary>
        /// Get all track groups in this cutscene.
        /// </summary>
        public TrackGroup[] TrackGroups
        {
            get
            {
                return base.GetComponentsInChildren<TrackGroup>(true);
            }
        }

        /// <summary>
        /// Get the director group of this cutscene.
        /// </summary>
        public DirectorGroup DirectorGroup
        {
            get
            {
                return base.GetComponentInChildren<DirectorGroup>();
            }
        }

        /// <summary>
        /// Cutscene state is used to determine if the cutscene is currently Playing, Previewing (In edit mode), paused, scrubbing or inactive.
        /// </summary>
        public enum CutsceneState
        {
            Inactive,
            Playing,
            PreviewPlaying,
            Scrubbing,
            Paused
        }

        /// <summary>
        /// Enable this if the Cutscene does not have TrackGroups added/removed during running.
        /// </summary>
        public bool CanOptimize
        {
            get { return canOptimize; }
            set { canOptimize = value; }
        }

        /// <summary>
        /// True if Cutscene can be skipped.
        /// </summary>
        public bool IsSkippable
        {
            get { return isSkippable; }
            set { isSkippable = value; }
        }

        /// <summary>
        /// Will the Cutscene loop upon completion.
        /// </summary>
        public bool IsLooping
        {
            get { return isLooping; }
            set { isLooping = value; }
        }

        /// <summary>
        /// An important call to make before sampling the cutscene, to initialize all track groups
        /// and save states of all actors/game objects.
        /// </summary>
        private void initialize()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.initialize");
#endif // PROFILE_FILE
            saveRevertData();

            // Initialize each track group.
            var list = GetTrackGroups();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var tg = list[i];
                tg.Initialize();
            }
            hasBeenInitialized = true;
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Cache all the revert data.
        /// </summary>
        private void saveRevertData()
        {
            revertCache.Clear();
            // Build the cache of revert info.
            var comps = this.GetComponentsInChildren<MonoBehaviour>();
            for (var i = 0; i < comps.Length; ++i)
            {
                MonoBehaviour mb = comps[i];
                IRevertable revertable = mb as IRevertable;
                if (revertable != null)
                {
                    RevertInfo[] ri = revertable.CacheState();
                    if (ri == null || ri.Length < 1)
                    {
                        Debug.Log(string.Format("Cinema Director tried to cache the state of {0}, but failed.", mb.name));
                    }
                    else
                    {
                        revertCache.AddRange(ri);
                    }
                }
            }
        }

        /// <summary>
        /// Revert all data that has been manipulated by the Cutscene.
        /// </summary>
        private void revert()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.revert");
#endif // PROFILE_FILE
            for (var i = 0; i < revertCache.Count; ++i)
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
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Get the milestones between the current running time and the given time.
        /// </summary>
        /// <param name="time">The time to progress towards</param>
        /// <returns>A list of times that state changes are made in the Cutscene.</returns>

        private Dictionary<float, bool> milestoneDict = new Dictionary<float, bool>();

        private List<float> getMilestones(float time)
        {
            // Create a list of ordered milestone times.
            var milestoneTimes = new List<float>();
            milestoneDict.Clear();
            milestoneTimes.Add(time);
            milestoneDict.Add(time, true);

            var list = GetTrackGroups();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var group = list[i];
                List<float> times = group.GetMilestones(RunningTime, time);
                for (var j = 0; j < times.Count; j++)
                {
                    var f = times[j];
                    if (!milestoneDict.ContainsKey(f))
                    {
                        milestoneDict.Add(f, true);
                        milestoneTimes.Add(f);
                    }
                }
            }

            if (time < RunningTime)
            {
                milestoneTimes.Reverse();
            }

            return milestoneTimes;
        }

        public void PreparePlay()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene");
#endif // PROFILE_FILE
            if (!hasBeenOptimized)
            {
                Optimize();
            }
            if (!hasBeenInitialized)
            {
                initialize();
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        /// <summary>
        /// Couroutine to call UpdateCutscene while the cutscene is in the playing state.
        /// </summary>
        /// <returns></returns>
        private IEnumerator updateCoroutine()
        {
            bool firstFrame = true;
            while (state == CutsceneState.Playing)
            {
#if PROFILE_FILE
                Profiler.BeginSample("Cutscene.updateCoroutine");
#endif // PROFILE_FILE
                if (firstFrame)
                {
                    UpdateCutscene(0);
                    firstFrame = false;
                }
                else
                {
                    UpdateCutscene(Time.deltaTime);
                }
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                yield return null;
            }
        }

        /// <summary>
        /// Prepare all track groups for resuming from pause.
        /// </summary>
        private void resume()
        {
#if PROFILE_FILE
            Profiler.BeginSample("Cutscene.resume");
#endif // PROFILE_FILE
            var list = GetTrackGroups();
            var length = list.Length;
            for (var i = 0; i < length; i++)
            {
                var group = list[i];
                if (group != null)
                {
                    group.Resume();
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }
    }

    // Delegate for handling Cutscene Events
    public delegate void CutsceneHandler(object sender,CutsceneEventArgs e);

    /// <summary>
    /// Cutscene event arguments. Blank for now.
    /// </summary>
    public class CutsceneEventArgs : EventArgs
    {
        public CutsceneEventArgs()
        {
        }
    }

}
