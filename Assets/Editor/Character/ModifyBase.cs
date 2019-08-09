using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using LBootEditor;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class ModifyBase
{
    protected ModifyModel cm;

    public GameObject Target
    {
        get { return cm.Target; }
    }

    public Animator Animator
    {
        get { return cm.Animator; }
    }

    public AnimatorController Controller
    {
        get { return cm.Controller; }
        set
        {
            cm.Controller = value;
            this.Animator.runtimeAnimatorController = value;
        }
    }

    public string Tid
    {
        get { return cm.Tid; }
    }

    public string Skeleton
    {
        get { return cm.Skeleton; }
    }

    public GameConfig Config
    {
        get { return cm.Config; }
    }

    public AnimationClip[] Clips
    {
        get { return Controller.animationClips; }
    }

    public ModifyBase(ModifyModel cm)
    {
        this.cm = cm;
    }
}

