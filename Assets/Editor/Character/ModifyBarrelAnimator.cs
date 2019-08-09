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

public class ModifyBarrelAnimator : ModifyAnimatorBase
{
    public ModifyBarrelAnimator(ModifyModel cm)
        : base(cm)
    {
    }

    override protected string GetClipFolder()
    {
        return "Assets/Model/animations/" + this.Tid;
    }

    override protected string GetClipPath(string clipname)
    {
        return this.GetClipFolder() + "/" + clipname + ".anim";
    }

    override protected string GetAnimatorPath()
    {
        return "Assets/Animator/" + this.GetControllerName() + ".controller"; 
    }

    override protected string GetControllerName()
    {
        return this.Tid + "_controller";
    }

    public void Setup()
    {
        var controllerName = this.GetControllerName();
        var control = this.GetController();

        this.Controller = control;

        // get all animation in clip folder
        Dictionary<string, string> stateName2ClipName = new Dictionary<string, string>();
        stateName2ClipName["hit_normal"] = GetClipPath("flu0001_state01");
        stateName2ClipName["hit_to_deform"] = GetClipPath("flu0001_state02");
        stateName2ClipName["hit_deform"] = GetClipPath("flu0001_state03");
        stateName2ClipName["hit_destroy"] = GetClipPath("flu0001_state04");

        var sm = stateMachine;
        foreach (KeyValuePair<string, string> entry in stateName2ClipName)
        {
            var stateName = entry.Key;
            var clipPath = entry.Value;
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
            ChildAnimatorState? st = FindChildState(stateName);
            AnimatorState state = null;
            if (st != null)
            {
                state = st.Value.state;
            }
            else
            {
                state = sm.AddState(stateName);
            }
			
            if (clip != null)
            {
                state.motion = clip;
            }
            else
            {
                sm.RemoveState(state);
                LogUtil.Error(clipPath + " doesnt exist");
            }
        }

        ClearTransitions();
        this.FixTransitions();
        AssetDatabase.SaveAssets();
    }

    private void FixTransitions()
    {
        if (this.Animator == null)
            return;
        if (this.Controller == null)
            return;

        var states = stateMachine.states;
        SetStatesLoop(states, false);

        foreach (var s in states)
        {
            CreateAnyTransition(s.state, 0.05f);
        }

        var start = -60 * states.Length / 2;
        var list = new List<ChildAnimatorState>();
        for (var i = 0; i < states.Length; i++)
        {
            var s = states[i];
            s.position = new Vector3(-300, start + i * 60, 0);
            list.Add(s);
        }
        stateMachine.states = list.ToArray();
    }
}
















