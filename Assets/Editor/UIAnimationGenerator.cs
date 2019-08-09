using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEditor.Animations;


public class UIAnimationGenerator
{
    [MenuItem("uGUI/Create UI Animation")]
    public static void Create()
    {
        var image = Selection.activeObject;

        var path = AssetDatabase.GetAssetPath(image.GetInstanceID());
        var dir = Path.GetDirectoryName(path) + "/animations/";
        var sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(path).Cast<Sprite>().ToArray();

        var clipPath = dir + image.name + ".anim";
        var controllerPath = dir + image.name + "_controller.controller";
        var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
            
        if (clip == null)
        {
            clip = new AnimationClip();
            clip.name = image.name;
            AssetDatabase.CreateAsset(clip, clipPath);
        }

        var controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(controllerPath);
        if (controller == null)
        {
            controller = AnimatorController.CreateAnimatorControllerAtPathWithClip(controllerPath, clip);
        }

        var sm = controller.layers[0].stateMachine;
        var s = sm.states[0];
        s.state.name = "play";

        var setting = AnimationUtility.GetAnimationClipSettings(clip);
        setting.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(clip, setting);

        var binding = new EditorCurveBinding { type = typeof(Image), path = "", propertyName = "m_Sprite" };

        ObjectReferenceKeyframe[] frames = new ObjectReferenceKeyframe[sprites.Length];
        for (var i = 0; i < frames.Length; i++)
        {
            frames[i] = new ObjectReferenceKeyframe();
            frames[i].value = sprites[i];
            frames[i].time = i * 1.0f / 15;
        }

        clip.frameRate = 30;


        AnimationUtility.SetObjectReferenceCurve(clip, binding, frames);
        AssetDatabase.SaveAssets();
        Selection.objects = new Object[]{ controller, clip };

    }
}

