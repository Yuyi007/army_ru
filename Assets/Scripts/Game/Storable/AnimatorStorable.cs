using UnityEngine;

using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using LBoot;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
#endif

namespace Game
{
    [System.Serializable]
    [SLua.CustomLuaClass]
    public class StateClipPair : System.Object
    {
        public string stateName;
        public string clipName;
        public float clipLength;
        public float clipFrameRate;
    }

    [SLua.CustomLuaClass]
    /// <summary>
	/// Animator storable. - It stores the animator state and clip correspondance
	/// as the unity runtime API doesn't have means to retrieve this correspondance.
	/// </summary>
    public class AnimatorStorable : MonoBehaviour, ISerializationCallbackReceiver
    {
        public StateClipPair[] stateClipPairs = null;
        private Dictionary<string, StateClipPair> dict = null;
        private Dictionary<string, List<string>> clipToStates = null;

        [SLua.DoNotToLua]
        public void OnBeforeSerialize()
        {
        }

        [SLua.DoNotToLua]
        public void OnAfterDeserialize()
        {
            #if UNITY_EDITOR

            if (LBootApp.Running)
                return;

            dict = new Dictionary<string, StateClipPair>();
            clipToStates = new Dictionary<string, List<string>>();
            var length = stateClipPairs.Length;
            for (var i = 0; i < length; i++)
            {
                var v = stateClipPairs[i];
                dict[v.stateName] = v;
                dict[v.clipName] = v;
                List<string> clipStates = null;
                clipToStates.TryGetValue(v.clipName, out clipStates);
                if (clipStates == null)
                {
                    clipStates = new List<string>();
                    clipToStates[v.clipName] = clipStates;
                }
                clipStates.Add(v.stateName);
            }
            #endif
        }

        public StateClipPair findState(string stateName)
        {
            #if UNITY_EDITOR
            if (LBootApp.Running)
                return null;
            StateClipPair pair = null;
            dict.TryGetValue(stateName, out pair);
            return pair;
            #endif
            return null;
        }

        public List<string> findStatesByClip(string clipName)
        {
            #if UNITY_EDITOR
            if (LBootApp.Running)
                return null;
            List<string> list = null;
            clipToStates.TryGetValue(clipName, out list);
            return list;
            #endif
            return null;
        }

        public StateClipPair findClip(string clipName)
        {
            #if UNITY_EDITOR
            if (LBootApp.Running)
                return null;
            StateClipPair pair = null;
            dict.TryGetValue(clipName, out pair);
            return pair;
            #endif
            return null;
        }

#if UNITY_EDITOR

        void Reset()
        {
            if (!LBoot.LBootApp.Running)
                Populate();
        }

        void OnValidate()
        {
            if (!LBoot.LBootApp.Running)
                Populate();
        }

        [SLua.DoNotToLua]
        public void Populate()
        {
            if (LBootApp.Running)
                return;
            
            var animator = GetComponent<Animator>();
            if (animator == null)
                return;
            if (animator.runtimeAnimatorController == null)
                return;

            var stateClipList = new List<StateClipPair>();

            // if (this.gameObject)
            // {
            //     LogUtil.Debug("Populate animator " + this.gameObject.name);
            // }
            // else
            // {
            //     LogUtil.Debug("Populate animator unknown");
            // }

            var controller = animator.runtimeAnimatorController;
            var editorAnimatorController = controller as UnityEditor.Animations.AnimatorController;
            if (editorAnimatorController.layers.Length == 0)
                return;
            
            var layer = editorAnimatorController.layers.ElementAt(0);
            var sm = layer.stateMachine;

            int i = 0;
            foreach (var child in sm.states)
            {
                var pair = new StateClipPair();
                var state = child.state;
                var motion = state.motion;
                if (motion != null)
                {
                    // AnimationClip clip = null;
                    // foreach (var clip2 in editorAnimatorController.animationClips)
                    // {
                    //     if (clip2.name == motion.name)
                    //     {
                    //         clip = clip2;
                    //     }
                    // }
                    var clip = motion as AnimationClip;
                    pair.stateName = state.name;
                    pair.clipName = clip.name;
                    pair.clipLength = clip.length;
                    pair.clipFrameRate = clip.frameRate;
                    stateClipList.Add(pair);
                    i++;
                }
            }

            this.stateClipPairs = stateClipList.ToArray();
        }

#endif
    }
}
