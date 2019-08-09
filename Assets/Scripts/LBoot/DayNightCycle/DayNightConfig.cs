using System;
using UnityEngine;
using SLua;
using System.Collections.Generic;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
#endif

namespace LBoot
{
    interface CtrlClassBase
    {
        void DoRefresh();
    }

    [CustomLuaClassAttribute]
    public class DayNightConfig : MonoBehaviour
    {
        public string[] names;

        private GameObjectCtrl[] allGOCs = null;
        private LightmapSwitcher[] allLSs = null;
        private PostProcessCtrl[] allPPCs = null;
        private SetLightMapWithDynamicLightColor[] allLMs = null;
        private FogCtrl fogCtrl = null;
        [SLua.DoNotToLua]
        private Animator animator = null;

#if UNITY_EDITOR
        [SLua.DoNotToLua]
        private int preIndex = -1;
        [SLua.DoNotToLua]
        [Range(0, 4)]
        public int weatherTest = 0;
        [SLua.DoNotToLua]
        private int maxIndex = 0;
        [SLua.DoNotToLua]
        private string stateName = "";
#endif

        void OnDestroy()
        {
            allGOCs = null;
            allLSs = null;
            allLMs = null;
            fogCtrl = null;
            animator = null;
        }

        // Use this for initialization
        void Start()
        {
#if UNITY_EDITOR
            animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
#endif // UNITY_EDITOR

            allGOCs = this.gameObject.GetComponentsInChildren<GameObjectCtrl>(true);
            allLSs = this.gameObject.GetComponentsInChildren<LightmapSwitcher>(true);
            allPPCs = this.gameObject.GetComponentsInChildren<PostProcessCtrl>(true);
            allLMs = this.gameObject.GetComponentsInChildren<SetLightMapWithDynamicLightColor>(true);
            fogCtrl = this.gameObject.GetComponentInChildren<FogCtrl>();

#if UNITY_EDITOR
            maxIndex = GetKeyFrameNum();
            if (!LBoot.LBootApp.Running)
            {
                animator.enabled = true;
                animator.speed = 0;
            }
#endif

        }

#if UNITY_EDITOR

        [SLua.DoNotToLua]
        private int GetKeyFrameNum()
        {
            if (animator == null)
            {
                return 0;
            }
            AnimationClip ac = GetFirstClip();
            if (ac == null)
            {
                return 0;
            }

            int maxNum = -1;
            EditorCurveBinding[] ecbs = AnimationUtility.GetCurveBindings(ac);
            foreach (EditorCurveBinding ecb in ecbs)
            {
                AnimationCurve curve = AnimationUtility.GetEditorCurve(ac, ecb);
                maxNum = Mathf.Max(maxNum, curve.keys.Length);
            }
            return maxNum;
        }

        [SLua.DoNotToLua]
        private AnimationClip GetFirstClip()
        {
            if (animator == null)
            {
                return null;
            }

            RuntimeAnimatorController rac = animator.runtimeAnimatorController;
            var editorAnimatorController = rac as UnityEditor.Animations.AnimatorController;
            var layer = editorAnimatorController.layers.ElementAt(0);
            var sm = layer.stateMachine;

            foreach (ChildAnimatorState child in sm.states)
            {
                Motion m = child.state.motion;
                AnimationClip clip = m as AnimationClip;
                if (clip != null)
                {
                    stateName = child.state.name;
                    return clip;
                }
            }

            return null;
        }

        void Update()
        {
            if (weatherTest == preIndex || maxIndex <= 0)
                return;
            if (LBoot.LBootApp.Running)
                return;

            weatherTest = Mathf.Clamp(weatherTest, 0, maxIndex - 1);
            float ratio = (float)weatherTest / (maxIndex - 1);
            animator.Play(stateName, 0, ratio);
            preIndex = weatherTest;
        }

        [SLua.DoNotToLua]
        public void SetToWeather(int index)
        {
            animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
            else
            {
                return;
            }

            AnimationClip ac = GetFirstClip();
            if (ac == null)
            {
                return;
            }

            maxIndex = GetKeyFrameNum();
            index = Mathf.Clamp(index, 0, maxIndex - 1);
            float ratio = (float)index / (maxIndex - 1);
//            animator.Play (stateName, 0, ratio);

            AnimationMode.BeginSampling();
            AnimationMode.SampleAnimationClip(this.gameObject, ac, ratio * ac.length);
            AnimationMode.EndSampling();

            SceneView.RepaintAll();
        }

#endif

        public void DoRefreshDayNight()
        {

            _RefreshAll<GameObjectCtrl>(allGOCs);
            _RefreshAll<LightmapSwitcher>(allLSs);
            _RefreshAll<PostProcessCtrl>(allPPCs);
            _RefreshAll<SetLightMapWithDynamicLightColor>(allLMs);
            if (fogCtrl != null)
            {
                fogCtrl.DoRefresh();
            }
        }

        private void _RefreshAll<Type>(Type[] allObjs) where Type : CtrlClassBase
        {
            foreach (Type obj in allObjs)
            {
                obj.DoRefresh();
            }
        }

    }
}
