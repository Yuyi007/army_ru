using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LitJson;
using System.IO;
using LBootEditor;
using UnityEditor.Animations;

public class ModifyModel
{
    protected GameObject target;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    protected string layer;

    public string Layer
    {
        get { return layer; }
        set { layer = value; }
    }

    protected string tag;

    public string Tag
    {
        get { return tag; }
        set { tag = value; }
    }


    protected Animator animator;

    public Animator Animator
    {
        get { return animator; }
        set { animator = value; }
    }

    protected string tid;

    public string Tid
    {
        get { return tid; }
    }

    protected string skeleton;

    public string Skeleton
    {
        get { return skeleton; }
    }

    protected AnimatorController controller;

    public AnimatorController Controller
    {
        get { return controller; }
        set { controller = value; }
    }

    protected GameConfig config;

    public GameConfig Config
    {
        get { return config; }
        set { config = value; }
    }

    private ModifyBox modifyBox;
    private ModifyAnimator modifyAnimator;
    private ModifyPrefab modifyPrefab;
    private ModifyAnimation modifyAnimation;

    private bool mainScene = false;

    public bool MainScene
    {
        get
        {
            return mainScene;
        }
    }

    public ModifyModel()
    {
    }

    public ModifyModel(GameObject fighter, bool mainScene = false)
    {
        this.target = fighter;

        if (this.target == null)
        {
            throw new Exception("No fighter selected");
        }

        this.mainScene = mainScene;
        this.animator = this.target.GetComponent<Animator>();

        if (this.animator == null)
        {
            this.animator = this.target.AddComponent<Animator>();
        }
            
        this.controller = this.animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

        var names = this.target.name.Split('_');

        this.tid = names[1];
        this.skeleton = names[0];
        this.config = GameConfig.Get();

        this.modifyBox = new ModifyBox(this);
        this.modifyAnimator = new ModifyAnimator(this);
        this.modifyPrefab = new ModifyPrefab(this);
        this.modifyAnimation = new ModifyAnimation(this);
        this.tag = "Fighter";
        this.layer = "Player";
    }

    public virtual void Bootstrap(bool animatorOnly = false)
    {
        if (animatorOnly)
        {
            SetupAnimator();
        }
        else
        {
            SetupAnimator();
            SetupPrefab();
        }
    }

    public void SetupAnimator()
    {
        modifyAnimator.Setup(this.mainScene);
    }

    public void SetupPrefab()
    {
        if (!this.mainScene)
        {
            modifyPrefab.Setup();
        }
        else
        {
            modifyPrefab.Setup(false, false, false, false);
        }
    }

    public IEnumerator BackupBoxTimeline()
    {
        return modifyBox.BackupBoxTimeline();
    }

    public IEnumerator RemoveBoxTimeline()
    {
        return modifyBox.RemoveBoxTimeline();
    }

    public IEnumerator RemoveWrongBoxTimeline()
    {
        return modifyBox.RemoveWrongBoxTimeline();
    }

    public IEnumerator ApplyBoxTimeline()
    {
        return modifyBox.ApplyBoxTimeline();
    }

    public void SavePrefab()
    {
        modifyPrefab.Save();
    }

    public Transform FindByName(string name)
    {
        var transforms = this.Target.GetComponentsInChildren<Transform>(true);
        return transforms.First(x => x.name == name);
    }

    public void FixWeaponScale()
    {
        modifyAnimation.FixWeaponScale();
    }

    public void OptimizeAnimations()
    {
        modifyAnimation.OptimizeAnimations();
    }

    public void CreateDefaultParts()
    {
        modifyPrefab.CreateDefaultParts();
    }

    public void ClearTransitions()
    {
        modifyAnimator.ClearTransitions();
    }

}

