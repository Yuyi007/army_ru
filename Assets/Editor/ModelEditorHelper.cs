using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEditor.Animations;
using LBootEditor;
using CinemaDirector;
using LBoot;

public static class ModelEditorHelper
{
    [MenuItem("Tools/Model/Reimport All Models In Selected Folder")]
    private static void ReimportAllModelsInSelectedFolder()
    {
        string selectedPath = getSelectedAssetsFolder(Selection.activeObject);
        if (selectedPath == null)
        {
            return;
        }
        LogUtil.Debug("ReimportAllModelsInSelectedFolder: " + selectedPath);

        // some files have lower case ext name, so use get all files instead
        // string[] modelsPath = Directory.GetFiles(selectedPath, "*.fbx", SearchOption.AllDirectories);
        List<string> fbxPaths = new List<string>();
        string[] modelsPath = Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories);
        for (int i = 0; i < modelsPath.Length; ++i)
        {
            string mpath = modelsPath[i];
            if (!mpath.EndsWith(".fbx", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            // AssetDatabase.ImportAsset (mpath);
//			LogUtil.Debug("ReimportAllModelsInSelectedFolder find file: " + mpath);
            fbxPaths.Add(mpath);
        }

        for (int i = 0; i < fbxPaths.Count; ++i)
        {
            string mpath = fbxPaths[i];
//            AssetDatabase.ImportAsset(mpath);
            AssetDatabase.ImportAsset(mpath, ImportAssetOptions.DontDownloadFromCacheServer);
            var cancel = EditorUtility.DisplayCancelableProgressBar("Reimporting Models " + (i + 1).ToString() + "/" + fbxPaths.Count.ToString(),
                             "reimporting " + mpath,
                             (float)(i + 1) / fbxPaths.Count);
            if (cancel)
            {
                break;
            }
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Model/Reimport All Models In models/streets")]
    public static void ReimportAllModelsInModelsStreets()
    {
        string selectedPath = "Assets/Models/streets/";

        if (selectedPath == null)
        {
            return;
        }
        LogUtil.Debug("ReimportAllModelsInSelectedFolder: " + selectedPath);

        // some files have lower case ext name, so use get all files instead
        // string[] modelsPath = Directory.GetFiles(selectedPath, "*.fbx", SearchOption.AllDirectories);
        List<string> fbxPaths = Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories).Where(x => x.EndsWith(".fbx", StringComparison.OrdinalIgnoreCase)).ToList();
       
        for (int i = 0; i < fbxPaths.Count; ++i)
        {
            string mpath = fbxPaths[i];
            //            AssetDatabase.ImportAsset(mpath);
            AssetDatabase.ImportAsset(mpath, ImportAssetOptions.DontDownloadFromCacheServer);
            var cancel = EditorUtility.DisplayCancelableProgressBar("Reimporting Models " + (i + 1).ToString() + "/" + fbxPaths.Count.ToString(),
                "reimporting " + mpath,
                (float)(i + 1) / fbxPaths.Count);
            if (cancel)
            {
                break;
            }
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Model/Cleanup Components")]
    private static void CleanupModelComponents()
    {

        // some files have lower case ext name, so use get all files instead
        // string[] modelsPath = Directory.GetFiles(selectedPath, "*.fbx", SearchOption.AllDirectories);
        List<string> fbxPaths = new List<string>();
        string[] prefabPaths = Directory.GetFiles("Assets/Prefab/characters", "*.prefab", SearchOption.AllDirectories);
        for (int i = 0; i < prefabPaths.Length; ++i)
        {
            string mpath = prefabPaths[i];
            var cancel = EditorUtility.DisplayCancelableProgressBar("Fix Character " + (i + 1).ToString() + "/" + prefabPaths.Length.ToString(),
                             "fixing " + mpath,
                             (float)(i + 1) / prefabPaths.Length);
            if (cancel)
            {
                break;
            }

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(mpath);
            var go = GameObject.Instantiate(prefab);
            GameObject.DestroyImmediate(go.GetComponent<Rigidbody>());
            GameObject.DestroyImmediate(go.GetComponent<Game.LuaRecvHitBehaviour>());
            GameObject.DestroyImmediate(go.GetComponent<BoxCollider>());
            var recvCollider = go.transform.Find("RecvCollider");
            if (recvCollider != null)
            {
                GameObject.DestroyImmediate(recvCollider.GetComponent<BoxCollider>());
            }
            PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
            GameObject.DestroyImmediate(go);
            EditorUtility.SetDirty(prefab);
        }

        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
    }


    [MenuItem("Tools/Model/Bootstrap Model _&c")]
    private static void BootStrapModel()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.Bootstrap();
    }

    [MenuItem("Tools/Model/Backup Box Timeline _&b")]
    private static void BackupBoxTimeline()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.SetupAnimator();
        modify.SavePrefab();
        EditorCoroutine.Start(modify.BackupBoxTimeline());
    }

    [MenuItem("Tools/Model/Remove Box Timeline")]
    private static void RemoveBoxTimeline()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        EditorCoroutine.Start(modify.RemoveBoxTimeline());
    }

    [MenuItem("Tools/Model/Remove Wrong Box Timeline")]
    private static void RemoveWrongBoxTimeline()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        EditorCoroutine.Start(modify.RemoveWrongBoxTimeline());
    }

    [MenuItem("Tools/Model/Apply Box Timeline")]
    private static void ApplyBoxTimeline()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        EditorCoroutine.Start(modify.ApplyBoxTimeline());
    }

    [MenuItem("Tools/Model/Fix Animator")]
    private static void FixAnimator()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.SetupAnimator();
    }

    [MenuItem("Tools/Model/Create Default Parts")]
    private static void CreateDefaultParts()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.CreateDefaultParts();
    }

    [MenuItem("Tools/Model/Fix weapon scale")]
    private static void FixWeaponScale()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.FixWeaponScale();
    }

    [MenuItem("Tools/Model/Optimize animations")]
    private static void OptimizeAnimations()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.OptimizeAnimations();
    }

    [MenuItem("Tools/Model/Clear Transitions")]
    private static void ClearTransitions()
    {
        var modify = new ModifyModel(Selection.activeGameObject);
        modify.ClearTransitions();
    }

    [MenuItem("Tools/Model/Clear Controller Prefab")]
    private static void ClearControllerPrefab()
    {
        var files = Directory.GetFiles("Assets/Prefab/character_controllers", "*.prefab", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
            var go = GameObject.Instantiate(prefab);
            var animator = go.GetComponent<Animator>();
            animator.enabled = false;
            for (var i = go.transform.childCount - 1; i >= 0; i--)
            {
                var t = go.transform.GetChild(i);
                GameObject.DestroyImmediate(t.gameObject);
            }
            PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
            EditorUtility.SetDirty(prefab);
            GameObject.DestroyImmediate(go);
        }
    }

    private static string getSelectedAssetsFolder(UnityEngine.Object obj)
    {
        string path = "";
        if (obj == null)
        {
            return null;
        }
        path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
        if (path.Length > 0)
        {
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                return null;
            }
        }
        return null;
    }

    public static float TransitTime(string stateName)
    {
        if (stateName.Contains("idle") && !stateName.Contains("fight"))
            return 0.1f;
        return 0.05f;
    }

    public static float TransitTime(AnimatorStateTransition transition)
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

    [MenuItem("Tools/Model/Clear Animation Events")]
    public static void ClearAllAnimationEvents()
    {
        var files = Directory.GetFiles("Assets/Model/animations", "*.anim", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var anim = AssetDatabase.LoadAssetAtPath<AnimationClip>(file);
            if (anim.events.Length > 0)
            {
                anim.events = new AnimationEvent[0];
                EditorUtility.SetDirty(anim);
            }
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Model/Fix All Generic Animations (remove animation on skeleton)")]
    public static void FixAllGenericAnimatorControllers()
    {
        EditorCoroutine.Start(_FixAllGenericAnimatorControllers());
    }

	[MenuItem("Tools/Model/Fix Selected Generic Animator (remove animation on skeleton)")]
	public static void FixSelectedGenericAnimator()
	{
		var file = Selection.activeObject;
		var path = AssetDatabase.GetAssetPath(file);
		var config = LBootEditor.GameConfig.Get();
		var animatiors = config.animators2;
		var name = Path.GetFileNameWithoutExtension(path);
		var canceled = false;
		if (!animatiors.ContainsKey(name))
		{
			return;
		}
		fixOneController (path);
	}

	public static void fixOneController(string file)
	{
		var config = LBootEditor.GameConfig.Get();
		var animatiors = config.animators2;
		var name = Path.GetFileNameWithoutExtension(file);
		if (!animatiors.ContainsKey(name))
		{
			return;
		}
		LogUtil.Debug("Fixing controller " + name);
		var controller = AssetDatabase.LoadAssetAtPath<UnityEditor.Animations.AnimatorController>(file);

		var animList = animatiors[name];
		var skeleton = name.Split('_').First();
		var animFolder = "Assets/Model/animations/" + skeleton + "/";
		var dict = new Dictionary<string, string>();

		foreach (var pair in animList)
		{
			var stateConfig = pair.Value;
			var clipName = stateConfig.clip;
			var animPath = animFolder + stateConfig.clip + ".anim";
			var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(animPath);
			if (clip != null)
			{
				var skeletonBindings = GetSkeletonBindings(clip);
				foreach (var b in skeletonBindings)
				{
					AnimationUtility.SetEditorCurve(clip, b, null);
					EditorUtility.SetDirty(clip);
				}
			}
			else
			{
				LogUtil.Error("clip " + animPath + " for " + controller.name + " not found ");
			}
		}
	}

    public static IEnumerator _FixAllGenericAnimatorControllers()
    {
		var files = Directory.GetFiles("Assets/Animator/", "*.controller", SearchOption.TopDirectoryOnly).Where(x => !x.Contains("male")).ToArray();
        var config = LBootEditor.GameConfig.Get();
        var animatiors = config.animators2;

        int length = files.Length;
        int index = 0;
        bool canceled = false;
        foreach (var file in files)
        {
            ++index;
			fixOneController (file);
			if (!ShowProgress("FixAllGenericAnimatorControllers", string.Format("progress {0}/{1}, {2}", index, length, file), (float)index / length))
			{
				canceled = true;
				break;
			}
			yield return null;
        }
        HideProgress();
    }

    public static bool ShowProgress(string title, string desc, float progress)
    {
        return !EditorUtility.DisplayCancelableProgressBar(title, desc, progress);
    }

    public static void HideProgress()
    {
        EditorUtility.ClearProgressBar();
    }

    public static EditorCurveBinding[] GetSkeletonBindings(AnimationClip clip)
    {
        return AnimationUtility.GetCurveBindings(clip).Where(x => x.path == "skeleton").ToArray();
    }


    [MenuItem("Tools/Model/Fix Animator Controllers")]
    public static void FixAllControllers()
    {
        var files = Directory.GetFiles("Assets/Animator/", "*.controller", SearchOption.AllDirectories);
        var config = LBootEditor.GameConfig.Get();
        var animatiors = config.animators2;

        foreach (var file in files)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            if (!animatiors.ContainsKey(name))
            {
                continue;
            }
            LogUtil.Debug("Fixing controller " + name);
            var controller = AssetDatabase.LoadAssetAtPath<UnityEditor.Animations.AnimatorController>(file);

            var animList = animatiors[name];
            var skeleton = name.Split('_').First();
            var animFolder = "Assets/Model/animations/" + skeleton + "/";
            var dict = new Dictionary<string, string>();
            foreach (var pair in animList)
            {
                var stateConfig = pair.Value;
                var clipName = stateConfig.clip;
                dict[stateConfig.state] = animFolder + stateConfig.clip + ".anim";
            }

            var sm = controller.layers[0].stateMachine;
            var list = sm.states.ToList();
            var anyTransitions = sm.anyStateTransitions.ToList();
            var transDict = new Dictionary<string, AnimatorStateTransition>();

            foreach (var t in anyTransitions)
            {
                transDict[t.name] = t;
            }

            var states = sm.states;
            var dictStates = new Dictionary<string, AnimatorState>();
            var paramList = controller.parameters;

            foreach (var st in states)
            {
                dictStates[st.state.name] = st.state;
            }

            for (var i = anyTransitions.Count - 1; i >= 0; i--)
            {
                var trans = anyTransitions[i];
                if (!dictStates.ContainsKey(trans.name))
                {
                    LogUtil.Debug("remove transition " + trans.name);
                    sm.RemoveAnyStateTransition(trans);
                    anyTransitions.RemoveAt(i);
                }
                else if (transDict[trans.name] != trans)
                {
                    anyTransitions.RemoveAt(i);
                }
                else
                {
                    trans.duration = TransitTime(trans);
                }
            }

            foreach (var param in paramList)
            {
                if (!dictStates.ContainsKey(param.name) && param.type == AnimatorControllerParameterType.Trigger)
                {
                    LogUtil.Debug("remove parameter " + param.name);
                    controller.RemoveParameter(param);
                }
                else
                {
                    param.defaultBool = false;
                }
            }

            sm.anyStateTransitions = anyTransitions.ToArray();

            if (dictStates.ContainsKey("idle_idle"))
            {
                var defaultIdle = dictStates["idle_idle"];
                controller.layers[0].stateMachine.defaultState = defaultIdle;
            }


            foreach (var st in list)
            {
                if (st.state.motion == null)
                {
                    LogUtil.Debug(name + " state " + st.state.name + " is missing animation clip, fixing...");
                    if (!dict.ContainsKey(st.state.name))
                        continue;

                    var clipFile = dict[st.state.name];
                    var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(clipFile);
                    if (clip != null)
                    {
                        st.state.motion = clip;

                    }
                    else
                    {
                        LogUtil.Error("clip " + clipFile + " for " + controller.name + " state " + st.state.name + " not found ");
                    }
                }
                else
                {
                    // LogUtil.Debug("controller = " + controller + " state = " + st.state.name + " clip = " + AssetDatabase.GetAssetPath(st.state.motion));
                }
            }

            sm.states = list.ToArray();
            EditorUtility.SetDirty(controller);
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Model/Apply All Box Animations for animation clips")]
    public static void ApplyAllBoxAnimations()
    {
        EditorCoroutine.Start(_ApplyAllBoxAnimations());
    }

    [MenuItem("Tools/Model/Remove unused box clips")]
    public static void RemoveUnusedBoxClips()
    {
        var files = Directory.GetFiles("Assets/BoxAnimations/", "*.anim", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            var clipName = name.Replace("_box", "");
            var bone = clipName.Split('_').First();
            var clipPath = "Assets/Model/animations/" + bone + "/" + clipName + ".anim";
            if (!File.Exists(clipPath))
            {
                LogUtil.Debug(clipPath);
                AssetDatabase.DeleteAsset(file);
            }
        }
    }


    public static IEnumerator _ApplyAllBoxAnimations()
    {
        var boxClipFiles = Directory.GetFiles("Assets/BoxAnimations/", "*.anim", SearchOption.AllDirectories);
        var clipFiles = new List<string>();
        foreach (var boxClipFile in boxClipFiles)
        {
            var file = Path.GetFileNameWithoutExtension(boxClipFile);
            var list = file.Split('_').ToList();
            list.RemoveAt(list.Count - 1);
            var clipFile = String.Join("_", list.ToArray());
            var folder = list.First();
            var path = "Assets/Model/animations/" + folder + "/" + clipFile + ".anim";
            if (File.Exists(path))
                clipFiles.Add(path);
        }

        var index = 0;
        var length = clipFiles.Count;
        foreach (var file in clipFiles)
        {
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(file);
            if (!BoxEditorHelper.ShowProgress(string.Format("ApplyBoxTimeline {0}/{1}", index, length), index / length))
                break;

            BoxEditorHelper.ApplyBoxTimeline(clip);
            if (index % 5 == 0)
                yield return null;
            index++;
        }

        BoxEditorHelper.HideProgress();
        AssetDatabase.SaveAssets();
    }
}

