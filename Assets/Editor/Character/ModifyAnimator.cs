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

public class ModifyAnimator : ModifyAnimatorBase
{
    public ModifyAnimator(ModifyModel cm)
        : base(cm)
    {
    }

    override protected string GetClipFolder()
    {
        return "Assets/Model/animations/" + this.Skeleton;
    }

    override protected string GetClipPath(string clipname)
    {
        return GetClipFolder() + "/" + clipname + ".anim";
    }

    override protected string GetAnimatorPath()
    {
        return "Assets/Animator/" + this.GetControllerName() + ".controller";
    }

    protected string GetMainSceneAnimatorPath()
    {
        return "Assets/Animator_mainscene/ms_" + this.GetControllerName() + ".controller";
    }

    protected AnimatorController GetController(bool mainScene = false)
    {

        if (mainScene)
        {
            return GetMainSceneController();
        }
        else
        {
            var control = AssetDatabase.LoadAssetAtPath<AnimatorController>(this.GetAnimatorPath());

            if (control == null || control.layers.Count() == 0)
            {
                LogUtil.Debug("Creating controller asset for " + Tid);
                control = AnimatorController.CreateAnimatorControllerAtPath(this.GetAnimatorPath());
            }

            return control;
        }
    }


    protected AnimatorController GetMainSceneController()
    {
        var control = AssetDatabase.LoadAssetAtPath<AnimatorController>(this.GetMainSceneAnimatorPath());

        if (control == null || control.layers.Count() == 0)
        {
            LogUtil.Debug("Creating controller asset for " + Tid);
            control = AnimatorController.CreateAnimatorControllerAtPath(this.GetMainSceneAnimatorPath());
        }

        return control;
    }

    override protected string GetControllerName()
    {
        return this.Skeleton + "_" + this.Tid + "_controller";
    }

    protected string GetAvatarName()
    {
        return this.Skeleton + "_" + this.Tid + "_avatar";
    }

    protected string GetAvatarPath()
    {
        return "Assets/Model/characters/" + this.Skeleton + "_" + this.Tid + "/" + GetAvatarName() + ".asset";
    }

    private Dictionary<string, ChildAnimatorState> stateDicts = new Dictionary<string, ChildAnimatorState>();
    private Dictionary<string, AnimatorStateTransition> transDict = new Dictionary<string, AnimatorStateTransition>();
    private Dictionary<string, AnimatorControllerParameter> paramDict = new Dictionary<string, AnimatorControllerParameter>();

    public float TransitTime(string stateName)
    {
        if (stateName.Contains("idle") && !stateName.Contains("fight"))
            return 0.1f;
        return 0.05f;
    }

    public float TransitTime(AnimatorStateTransition transition)
    {
        var stateName = transition.name;

        if (stateName.Contains("idle") && !stateName.Contains("fight"))
            return 0.1f;

        var toState = transition.destinationState;
        if (toState.motion != null)
        {
            if (toState.motion.name.Contains("atk"))
                return 0.05f;
        }
        return 0.1f;
    }

    public void Setup(bool mainscene = false)
    {
        LogUtil.Debug("setup animator for " + this.GetControllerName());

        var controllerName = this.GetControllerName();
        var control = this.GetController(mainscene);

        this.Controller = control;
        Dictionary<string, bool> msStateHash = null;
       

        if (!this.Config.animators2.ContainsKey(controllerName))
        {
            LogUtil.Debug("animator config not found for " + controllerName);
            return;
        }

        this.Config.animators_ms.TryGetValue(controllerName, out msStateHash);

        var stateHash = this.Config.animators2[controllerName];
        var sm = stateMachine;

        if (mainscene)
        {
            if (msStateHash != null)
            {
                var stateHash2 = new Dictionary<string, AnimatorEntryConfig>(stateHash);
                foreach (var pair in stateHash)
                {
                    if (!msStateHash.ContainsKey(pair.Key))
                    {
                        stateHash2.Remove(pair.Key);
                    }
                }
                stateHash = stateHash2;
            }
            else
            {
                stateHash = new Dictionary<string, AnimatorEntryConfig>();
            }
        }

        foreach (var st in sm.states)
        {
            stateDicts[st.state.name] = st;
        }

        foreach (var param in Controller.parameters)
        {
            paramDict[param.name] = param;
        }

        foreach (var trans in sm.anyStateTransitions)
        {
            transDict[trans.name] = trans;
        }

        foreach (var pair in stateHash)
        {
            var s = pair.Value;
            var clipPath = this.GetClipPath(s.clip);
            var clipname = Path.GetFileNameWithoutExtension(clipPath);
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(this.GetClipPath(s.clip));
            AnimatorState state = null;
            if (stateDicts.ContainsKey(s.state))
            {
                var st = stateDicts[s.state];
                state = st.state;
            }
            else
            {
                state = sm.AddState(s.state);
                var trans = CreateAnyTransition(state, TransitTime(state.name));
                transDict[trans.name] = trans;
            }

            if (clip != null)
            {
                clip.name = clipname;
                state.motion = clip;
            }
            else
            {
                sm.RemoveState(state);
                LogUtil.Error(s.clip + " doesnt exist");
            }
        }

        var states = sm.states.Where(x => stateHash.ContainsKey(x.state.name)).ToArray();

        Func<ChildAnimatorState[], ChildAnimatorState[], bool> Indentitical = (list1, list2) =>
        {
            if (list1.Length != list2.Length)
                return false;
            return list1.Union(list2).Count() == list2.Length;
        };
        stateDicts.Clear();
        foreach (var st in states)
        {
            stateDicts[st.state.name] = st;
            if (!transDict.ContainsKey(st.state.name))
            {
                var trans = _CreateAnyTransition(st.state, TransitTime(st.state.name));
                transDict[trans.name] = trans;
            }
        }

        List<string> removed = new List<string>();


        foreach (var p in transDict)
        {
            var trans = p.Value;
            if (trans == null)
            {
                removed.Add(p.Key);
                continue;
            }

            if (!stateDicts.ContainsKey(p.Key))
            {
                sm.RemoveAnyStateTransition(trans);
                removed.Add(p.Key);
            }
        }

        foreach (var r in removed)
        {
            transDict.Remove(r);
        }


        removed.Clear();

        foreach (var p in paramDict)
        {
            var param = p.Value;
            if (param == null)
            {
                removed.Add(p.Key);
                continue;
            }

            if (!stateDicts.ContainsKey(p.Key) && param.type == AnimatorControllerParameterType.Trigger)
            {
                Controller.RemoveParameter(param);
                removed.Add(p.Key);
            }
            else
            {
                param.defaultBool = false;
            }
        }

        foreach (var r in removed)
        {
            paramDict.Remove(r);
        }

        sm.anyStateTransitions = transDict.Values.ToArray();

        sm.states = states;

        this.FixTransitions(mainscene);
        if (!mainscene)
            this.FixAnimationOnSkeletons();

        EditorUtility.SetDirty(this.Controller);
    }

    private ChildAnimatorState[] GetAttackStates(AnimatorStateMachine stateMachine = null)
    {
        var atk = "_atk";
        if (stateMachine == null)
        {
            stateMachine = this.stateMachine;
        }
        var states = stateMachine.states;
        var list = states.Where(x => x.state.motion != null && x.state.motion.name.Contains(atk)).ToArray();
        return list;
    }

    private ChildAnimatorState[] GetNonAttackStates()
    {
        var attackStates = GetAttackStates();
        var states = stateMachine.states;

        return states.Except(attackStates).ToArray();
    }

    private void FixAnimationOnSkeletons()
    {
        if (this.Animator == null)
            return;
        if (this.Controller == null)
            return;

        var path = GetAnimatorPath();
        ModelEditorHelper.fixOneController(path);
    }

    private void FixTransitions(bool mainsScene = false)
    {
        if (this.Animator == null)
            return;
        if (this.Controller == null)
            return;

        var states = stateMachine.states;
        var transitions = stateMachine.anyStateTransitions.ToList();
        foreach (var trans in transitions)
        {
            trans.duration = TransitTime(trans);
        }

        stateMachine.anyStateTransitions = transitions.ToArray();


        var attackStates = GetAttackStates();
        var nonAttackStates = states.Except(attackStates).ToList();
        nonAttackStates.Sort((x, y) =>
            {
                return x.state.name.CompareTo(y.state.name);
            });

        if (stateDicts.ContainsKey("run"))
        {
            var runState = stateDicts["run"];
            MakeLoop(runState);
        }

        if (stateDicts.ContainsKey("walk"))
        {
            var walk = stateDicts["walk"];
            MakeLoop(walk);
        }

        if (stateDicts.ContainsKey("idle_idle"))
        {
            var normalIdleState = stateDicts["idle_idle"];
            stateMachine.defaultState = normalIdleState.state;
        }
        else
        {
            if (stateDicts.Count > 0)
            {
                stateMachine.defaultState = stateDicts.ElementAt(0).Value.state;
            }
        }

        if (stateDicts.ContainsKey("idle_idle_1"))
        {
            var idleVariantState = stateDicts["idle_idle_1"];
            idleVariantState.state.transitions = new AnimatorStateTransition[0];
        }

        if (stateDicts.ContainsKey("idle_idle_2"))
        {
            var idleVariantState = stateDicts["idle_idle_2"];
            idleVariantState.state.transitions = new AnimatorStateTransition[0];
        }


        if (!mainsScene)
        {
            var list = new List<ChildAnimatorState>();

            var start = -60 * attackStates.Length / 2;

            for (var i = 0; i < attackStates.Length; i++)
            {
                var s = attackStates[i];
                s.position = new Vector3(300, start + i * 60, 0);
                list.Add(s);
            }


            start = -60 * nonAttackStates.Count / 2;

            for (var i = 0; i < nonAttackStates.Count; i++)
            {
                var s = nonAttackStates[i];
                s.position = new Vector3(-300, start + i * 60, 0);
                list.Add(s);
            }

            stateMachine.states = list.ToArray();
        }

    }

}

