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

public class ModifyAnimation : ModifyBase
{
    public ModifyAnimation(ModifyModel cm)
        : base(cm)
    {
    }

    public void FixWeaponScale()
    {
        var noneWeapon = new string[]
        {
            "male001_rda001_atk001",
            "male001_rda001_atk002",
            "male001_rda001_atk003",
            "male001_rda001_atk004",
            "male001_rda001_atk005",
            "male001_rda001_atk006",
            "male001_rda001_atk010",
            "male001_rda001_atk011",
            "male001_rda001_atk012",
            "male001_rda001_atk013",
            "male001_rda001_atk014",
            "male001_rda001_atk015",
            "male001_rda001_bas001",
            "male001_rda001_bas002",
            "male001_rda001_bas003",
            "male001_rda001_bas004",
            "male001_rda001_bas006",
            "male001_rda001_bas007",
            "male001_rda001_bas008",
            "male001_rda001_bas009",
            "male001_rda001_bas011",
            "male001_rda001_bas013",
            "male001_rda001_bas014",
            "male001_rda001_bas015",
            "male001_rda001_bas016",
            "male001_rda001_hit001",
            "male001_rda001_hit002",
            "male001_rda001_hit003",
            "male001_rda001_hit004",
            "male001_rda001_hit005",
            "male001_rda001_hit006",
            "male001_rda001_hit007",
            "male001_rda001_hit008",
            "male001_rda001_hit009",
            "male001_rda001_chongfengtui",
            "male001_rda001_hit_land",
            "male001_rda001_jumpback",
            "male001_rda001_runstop",
            "male001_rda001_saotangtui",
            "male001_rda001_shenglongquan",

        };

        var clips = this.Clips;
        var zeroScaleClips = Array.FindAll(clips, (x) => noneWeapon.Any(c => x.name.Contains(c)));
        foreach (var c in zeroScaleClips)
        {
            FixClipScale(c);
        }

        var weaponClips = Array.FindAll(clips, (x) => !noneWeapon.Any(c => x.name.Contains(c)));
        foreach (var c in weaponClips)
        {
            ShowWeaponClip(c);
        }

        cm.SavePrefab();
        AssetDatabase.SaveAssets();
    }

    private void ShowWeaponClip(AnimationClip clip)
    {
        var path = "skeleton/Hips/Spine/Spine01/Leftshoulder/Leftarm/Leftforearm/Lefthand/Lwp";
        var b = new EditorCurveBinding { path = path, propertyName = "m_IsActive", type = typeof(GameObject) };
        var c = new AnimationCurve(new Keyframe(0, 1));
        AnimationUtility.SetEditorCurve(clip, b, c);

        path = "skeleton/Hips/Spine/Spine01/Rightshoulder/Rightarm/Rightforearm/Righthand/Rwp";

        b = new EditorCurveBinding { path = path, propertyName = "m_IsActive", type = typeof(GameObject) };
        c = new AnimationCurve(new Keyframe(0, 1));
        AnimationUtility.SetEditorCurve(clip, b, c);
    }

    private void FixClipScale(AnimationClip clip)
    {
        var path = "skeleton/Hips/Spine/Spine01/Leftshoulder/Leftarm/Leftforearm/Lefthand/Lwp";
        string[] propertyNames = new string[] {
            "m_LocalScale.x",
            "m_LocalScale.y",
            "m_LocalScale.z",
        };

        var bindings = AnimationUtility.GetCurveBindings(clip);

        foreach (var p in propertyNames) {
            var binding = new EditorCurveBinding { path = path, propertyName = p, type = typeof(Transform) };
            var curve = new AnimationCurve(new Keyframe(0, 0));
            AnimationUtility.SetEditorCurve(clip, binding, curve);
        }

        var b = new EditorCurveBinding { path = path, propertyName = "m_IsActive", type = typeof(GameObject) };
        var c = new AnimationCurve(new Keyframe(0, 1));
        AnimationUtility.SetEditorCurve(clip, b, c);

        path = "skeleton/Hips/Spine/Spine01/Rightshoulder/Rightarm/Rightforearm/Righthand/Rwp";

        foreach (var p in propertyNames) {
            var binding = new EditorCurveBinding { path = path, propertyName = p, type = typeof(Transform) };
            var curve = new AnimationCurve(new Keyframe(0, 0));
            AnimationUtility.SetEditorCurve(clip, binding, curve);
        }
//
        b = new EditorCurveBinding { path = path, propertyName = "m_IsActive", type = typeof(GameObject) };
        c = new AnimationCurve(new Keyframe(0, 1));
        AnimationUtility.SetEditorCurve(clip, b, c);

    }

    public void OptimizeAnimations()
    {
        var clips = this.Clips;
        foreach (var c in clips)
        {
            OptimizeClip(c);
        }

        cm.SavePrefab();
        AssetDatabase.SaveAssets();
    }

    public void OptimizeClip(AnimationClip clip)
    {
        LogUtil.Debug("OptimizeClip: clip=" + clip.name);
        foreach (var binding in AnimationUtility.GetCurveBindings(clip))
        {
            if (binding.propertyName.Contains("m_LocalScale") &&
                (! binding.path.EndsWith("Lwp")) && 
                (! binding.path.EndsWith("Rwp")) && 
                (! binding.path.EndsWith("Rp")) && 
                (! binding.path.EndsWith("ciga")) && 
                (! binding.path.EndsWith("Leftweapon")) && 
                (! binding.path.EndsWith("Rightweapon"))) 
            {
                RemoveScaleCurve(clip, binding);
            }
        }
    }

    public void RemoveScaleCurve(AnimationClip clip, EditorCurveBinding binding)
    {
        AnimationCurve curve = AnimationUtility.GetEditorCurve(clip, binding);
        Keyframe [] keys = curve.keys;
        var canRemoveScale = true;
        if (canRemoveScale) 
        {
            LogUtil.Debug("remove scale curves: path=" + binding.path 
                + " propertyName=" + binding.propertyName
                + " value=" + keys[0].value);
            AnimationUtility.SetEditorCurve(clip, binding, null);
        }
    }

}

