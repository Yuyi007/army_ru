using System;
using UnityEditor;
using UnityEngine;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class BoxEditorHelper
{
    public static AnimationClip[] GetAllClips(string skeleton)
    {
        var path = "Assets/Model/animations/" + skeleton + "/";
        var files = Directory.GetFiles(path, "*.anim", SearchOption.AllDirectories);
        var list = new List<AnimationClip>();
        foreach (var file in files)
        {
            list.Add(AssetDatabase.LoadAssetAtPath<AnimationClip>(file));
        }

        return list.ToArray();
    }

    public static EditorCurveBinding[] GetBoxBindings(AnimationClip clip)
    {
        return AnimationUtility.GetCurveBindings(clip).Where(x => x.path.Contains("AttackCollider_")).ToArray();
    }

    private static bool Invalid(EditorCurveBinding x)
    {
        if (!x.path.Contains("AttackCollider_") && !x.path.Contains("ReceivCollider_") && x.type == typeof(BoxCollider))
            return true;

        if (x.path == "skeleton" || x.path == "skin")
            return true;

        if (x.path == "skeleton/Hips" && x.type == typeof(GameObject))
            return true;

        if (x.path.Contains("AttackCollider_") && x.type != typeof(Transform) && x.type != typeof(GameObject) && x.type != typeof(BoxCollider))
            return true;

        return false;
    }

    public static EditorCurveBinding[] GetWrongBoxBindings(AnimationClip clip)
    {
        return AnimationUtility.GetCurveBindings(clip).Where(x =>
            {
                return Invalid(x);
            }
        ).ToArray();
    }

    private static string GetBoxClipPath(string clipname)
    {
        return "Assets/BoxAnimations/" + clipname + "_box.anim";
    }

    public static IEnumerator ApplyBoxTimeline(string skeleton, AnimationClip[] clips = null)
    {
        if (clips == null)
            clips = GetAllClips(skeleton);

        var length = clips.Length;

        float index = 0;

        foreach (var clip in clips)
        {
            index++;
            _ApplyBoxTimeline(clip);
            if (!ShowProgress(string.Format("ApplyBoxTimeline {0}/{1}", index, length), index / length))
                break;

            yield return null;
        }

        HideProgress();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Model/Selection/apply box time line")]
    public static void ApplyBoxTimelineForSelected()
    {
        var clip = Selection.activeObject as AnimationClip;
        if (clip != null)
        {
            _ApplyBoxTimeline(clip);
            AssetDatabase.SaveAssets();
        }
    }

    private static void _ApplyBoxTimeline(AnimationClip clip)
    {
        var boxClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(GetBoxClipPath(clip.name));
        if (boxClip == null)
            return;

        var clipLength = clip.length;
        var boxClipLength = boxClip.length;
        var oldBindings = GetBoxBindings(clip);

        foreach (var b in oldBindings)
        {
            AnimationUtility.SetEditorCurve(clip, b, null);
        }

        var bindings = AnimationUtility.GetCurveBindings(boxClip);
        foreach (var b in bindings)
        {
            Debug.Log(b.propertyName + " path=" + b.path);
            var c = AnimationUtility.GetEditorCurve(boxClip, b);
            var keys = c.keys.ToList();

            for (var i = keys.Count - 1; i >= 0; i--)
            {
                var key = keys[i];
                if (key.time > clipLength)
                {
                    Debug.Log(string.Format("key time={0} original clip length={1}", key.time, clipLength));
                    var keyFrame = new Keyframe(clipLength, key.value);
                    keys[i] = keyFrame;
                }
            }

            var curve = new AnimationCurve(keys.ToArray());   
            AnimationUtility.SetEditorCurve(clip, b, curve);
            EditorUtility.SetDirty(clip);
        }
      
    }

    public static void ApplyBoxTimeline(AnimationClip clip)
    {
        _ApplyBoxTimeline(clip);
    }

    public static IEnumerator RemoveBoxTimeline(string skeleton, AnimationClip[] clips = null)
    {
        if (clips == null)
        {
            clips = GetAllClips(skeleton);
        }

        var length = clips.Length;
        float index = 0;

        foreach (var clip in clips)
        {
            index++;
            var bindings = GetBoxBindings(clip);
            foreach (var b in bindings)
            {
                AnimationUtility.SetEditorCurve(clip, b, null);
                EditorUtility.SetDirty(clip);
                yield return null;
            }

            if (!ShowProgress(string.Format("RemoveBoxTimeline {0}/{1}", index, length), index / length))
                break;
            
            yield return null;
        }

        HideProgress();
    }

    public static IEnumerator RemoveWrongBoxTimeline(string skeleton, AnimationClip[] clips = null)
    {
        if (clips == null)
        {
            clips = GetAllClips(skeleton);
        }

        var length = clips.Length;
        float index = 0;

        Debug.Log("RemoveWrongBoxTimeline " + skeleton + " length: " + clips.Length.ToString());

        foreach (var clip in clips)
        {
            index++;
            var bindings = GetWrongBoxBindings(clip);
            foreach (var b in bindings)
            {
                AnimationUtility.SetEditorCurve(clip, b, null);
                EditorUtility.SetDirty(clip);
                yield return null;
            }

            if (!ShowProgress(string.Format("RemoveWrongBoxTimeline {0}/{1}", index, length), index / length))
                break;
            
            yield return null;
        }

        HideProgress();
    }



    public static IEnumerator BackupBoxTimeline(string skeleton, AnimationClip[] clips = null)
    {
        if (clips == null)
            clips = GetAllClips(skeleton);

        var length = clips.Length;
        float index = 0;

        foreach (AnimationClip clip in clips)
        {
            index++;
            var path = GetBoxClipPath(clip.name);
            var c = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            var existed = true;

            if (c == null)
            {
                existed = false;
                c = new AnimationClip();
            }

            var boxBindingsOld = GetBoxBindings(c);

            c.frameRate = clip.frameRate;
            var boxBindings = GetBoxBindings(clip);
            var clipLength = clip.length;

            if (boxBindings.Length > 0)
            {
                foreach (var b in boxBindingsOld)
                {
                    AnimationUtility.SetEditorCurve(c, b, null);
                }
            }

            foreach (var b in boxBindings)
            {
                var curve = AnimationUtility.GetEditorCurve(clip, b);
                if (curve != null)
                {
                    var curveChanged = false;
                    if (b.propertyName == "m_Enabled" && curve.length > 0)
                    {
                        var last = curve[curve.length - 1];
                        if (last.time < clipLength && last.value == 0)
                        {
                            var keys = curve.keys.ToList();
                            var key = new Keyframe(clipLength, 0);
                            keys.Add(key);
                            curve = new AnimationCurve(keys.ToArray());
                            curveChanged = true;
                        }
                    }
                    if (curveChanged)
                        AnimationUtility.SetEditorCurve(clip, b, curve);
                    
                    AnimationUtility.SetEditorCurve(c, b, curve);

                    yield return null;
                }
            }

            if (AnimationUtility.GetAllCurves(c).Length > 0)
            {
                if (!existed)
                {
                    AssetDatabase.CreateAsset(c, path);
                }
                else
                {
                    EditorUtility.SetDirty(c);

                }
            }

            if (!ShowProgress(string.Format("BackupBoxTimeline {0}/{1}", index, length), index / length))
                break;

            yield return null;
        }

        HideProgress();

        AssetDatabase.SaveAssets();
    }

    public static bool ShowProgress(string desc, float progress)
    {
        return !EditorUtility.DisplayCancelableProgressBar("BoxModifier", desc, progress);
    }

    public static void HideProgress()
    {
        EditorUtility.ClearProgressBar();
    }



}

