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

public class ModifyBarrel : ModifyModel
{
    private ModifyPrefab modifyPrefab;
    private ModifyBarrelAnimator modifyAnimator;

    public ModifyBarrel(GameObject target)
    {
        this.target = target;
        this.modifyPrefab = new ModifyPrefab(this);

        this.animator = this.target.GetComponent<Animator>() ?? this.target.AddComponent<Animator>();
        this.controller = this.animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        this.tid = target.name;
        this.config = GameConfig.Get();
        this.tag = "Barrel";
        this.layer = "Barrel";

        this.modifyAnimator = new ModifyBarrelAnimator(this);
        this.modifyPrefab = new ModifyPrefab(this);
    }

    public override void Bootstrap(bool animatorOnly = false)
    {
        modifyAnimator.Setup();
        modifyPrefab.PrefabPath = "Assets/Prefab/barrels/" + Tid + ".prefab";
        modifyPrefab.Setup(false, false, false, false);
    }
}

