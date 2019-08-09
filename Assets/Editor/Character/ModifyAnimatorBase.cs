using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using LBootEditor;
using UnityEditor;
using UnityEngine;
using UnityEditor.Animations;
using LBoot;

public abstract class ModifyAnimatorBase : ModifyBase
{
    public ModifyAnimatorBase(ModifyModel cm)
        : base(cm)
    {
    }

    protected abstract string GetClipFolder();

    protected abstract string GetClipPath(string clipname);

    protected abstract string GetAnimatorPath();

    protected abstract string GetControllerName();

    protected UnityEditor.Animations.AnimatorStateMachine stateMachine
    {
        get { return Controller.layers[0].stateMachine; }
    }

    protected AnimatorController GetController()
    {
        var control = AssetDatabase.LoadAssetAtPath<AnimatorController>(this.GetAnimatorPath());

        if (control == null || control.layers.Count() == 0)
        {
            LogUtil.Debug("Creating controller asset for " + Tid);
            control = AnimatorController.CreateAnimatorControllerAtPath(this.GetAnimatorPath());
        }

        return control;
    }
 

    public void ClearTransitions()
    {
        this.Controller.parameters = new AnimatorControllerParameter[0];
        stateMachine.anyStateTransitions = new AnimatorStateTransition[0];
        foreach (var state in stateMachine.states)
        {
            state.state.transitions = new AnimatorStateTransition[0];
        }

//        AssetDatabase.SaveAssets();
    }

    protected ChildAnimatorState[] FindIdleBaseStates()
    {
        var statesWithIdle = stateMachine.states.Where(x => x.state.name.StartsWith("idle_")).ToList();
        List<ChildAnimatorState> res = new List<ChildAnimatorState>();
        foreach (var x in statesWithIdle)
        {
            string stateName = x.state.name;
            string[] nameslices = stateName.Split('_');
            if (nameslices.Length > 0)
            {
                string lastPart = nameslices[nameslices.Length - 1];
                int n;
                bool isNumeric = int.TryParse(lastPart, out n);
                if (!isNumeric)
                {
                    res.Add(x);
                }
            }
        }
        return res.ToArray();
    }

    protected ChildAnimatorState? FindChildState(string stateName)
    {
        foreach (var state in stateMachine.states)
        {
            if (state.state.name == stateName)
            {
                return state;
            }
        }

        return null;
    }

    protected AnimatorControllerParameter FindParameter(string name)
    {
        foreach (var p in Controller.parameters)
        {
            if (p.name == name)
            {
                return p;
            }
        }

        return null;
    }

    protected AnimatorControllerParameter CreateTriggerParameter(string name,
                                                                 AnimatorControllerParameterType t = AnimatorControllerParameterType.Trigger)
    {
        var param = FindParameter(name);
        if (param == null)
        {
            Controller.AddParameter(name, t);
            param = FindParameter(name);
        }

        param.defaultBool = false;

        return param;
    }


    protected AnimatorStateTransition CreateAnyTransition(ChildAnimatorState? cs, float duration = 0.1f, bool allowTransitToSelf = true)
    {
        if (cs != null)
        {
            return CreateAnyTransition(cs.Value.state, duration, allowTransitToSelf);
        }
        return null;
    }

    protected AnimatorStateTransition _CreateAnyTransition(AnimatorState state,
                                                           float duration = 0.1f, bool allowTransitToSelf = true)
    {
        CreateTriggerParameter(state.name);
        var transition = stateMachine.AddAnyStateTransition(state);
        transition.name = state.name;
        transition.AddCondition(AnimatorConditionMode.If, 0, state.name);
        transition.duration = duration;
        transition.canTransitionToSelf = allowTransitToSelf;
        return transition;
    }

    protected AnimatorStateTransition CreateAnyTransition(AnimatorState state,
                                                          float duration = 0.1f, bool allowTransitToSelf = true)
    {
        var any = stateMachine.anyStateTransitions;
        AnimatorStateTransition transition = null;
        foreach (var t in any)
        {
            if (t.name == state.name)
            {
                transition = t;
                break;
            }
        }

        if (transition == null)
        {
            CreateTriggerParameter(state.name);
            transition = stateMachine.AddAnyStateTransition(state);
            transition.name = state.name;
            transition.AddCondition(AnimatorConditionMode.If, 0, state.name);
        }
        transition.duration = duration;
        transition.canTransitionToSelf = allowTransitToSelf;
        // LogUtil.Debug("cantransitoself " + allowTransitToSelf.ToString());

        return transition;
    }

    protected void MakeLoop(params ChildAnimatorState?[] states)
    {
        SetStatesLoop(states.Where(x => x != null).Select(x => x.Value).ToArray(), true);
    }

    protected void MakeLoop(params ChildAnimatorState[] states)
    {
        SetStatesLoop(states, true);
    }

    protected void MakeUnLoop(params ChildAnimatorState?[] states)
    {
        SetStatesLoop(states.Where(x => x != null).Select(x => x.Value).ToArray(), false);
    }

    protected void SetStatesLoop(ChildAnimatorState[] states, bool loop)
    {
        foreach (var state in states)
        {
            var clip = state.state.motion as AnimationClip;
            if (clip != null)
            {
                var setting = AnimationUtility.GetAnimationClipSettings(clip);
                setting.loopTime = loop;
                AnimationUtility.SetAnimationClipSettings(clip, setting);
            }
        }
    }

    protected void FixAnimName(AnimationClip clip, string filename)
    {
        clip.name = filename;
    }


}