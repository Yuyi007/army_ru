using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LBootEditor;
using System;
using System.Text;
using LBoot;

public class EditorHelper
{
    private static void BatchFixImages()
    {

    }

    [MenuItem("uGUI/Remove empty UI Animation events")]
    private static void CheckUIAnimations()
    {
        var files = Directory.GetFiles("Assets/Animator/ui_animator/", "*.anim", SearchOption.AllDirectories).ToList();
        files.AddRange(Directory.GetFiles("Assets/images/uianim/animations/", "*.anim", SearchOption.AllDirectories));
        files.AddRange(Directory.GetFiles("Assets/Particles/effects/fx_anim/", "*.anim", SearchOption.AllDirectories));
        foreach (var file in files)
        {
            LogUtil.Debug(file);
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(file);
            var events = AnimationUtility.GetAnimationEvents(clip).ToList();
            for (var i = events.Count - 1; i >= 0; i--)
            {
                var evt = events[i];
                if (evt.functionName == null || evt.functionName == string.Empty)
                {
                    events.RemoveAt(i);
                }
            }
            AnimationUtility.SetAnimationEvents(clip, events.ToArray());
            EditorUtility.SetDirty(clip);
        }
        AssetDatabase.SaveAssets();
    }

#if UNITY_EDITOR_OSX
    [MenuItem("Tools/DesignHelper/Clean and Pull")]
    private static void CleanAndPull()
    {

        var proc = new System.Diagnostics.ProcessStartInfo();
        proc.UseShellExecute = true;
        proc.WorkingDirectory = Environment.GetEnvironmentVariable("KFC");
        proc.Arguments = "";
        proc.FileName = "manager_pull.sh";
        proc.ErrorDialog = true;
        proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        var p = System.Diagnostics.Process.Start(proc);
        p.WaitForExit();
        LogUtil.Debug("manager pull completed");

    }


    //    [MenuItem("Tools/DesignHelper/Build test xls")]
    private static void BuildTestXls()
    {
        var proc = new System.Diagnostics.ProcessStartInfo();
        proc.UseShellExecute = true;
        var dir = Environment.GetEnvironmentVariable("KFC");
        proc.WorkingDirectory = dir;
        proc.Arguments = "";
        proc.FileName = "build_test_xls.sh";
        proc.ErrorDialog = true;
        proc.UseShellExecute = true;
        var p = System.Diagnostics.Process.Start(proc);
        p.WaitForExit();
        LogUtil.Debug("build test xls completed");
    }
#endif

    [MenuItem("uGUI/Print image usage")]
    private static void PrintUIImageUsage()
    {
        var prefabs = Directory.GetFiles("Assets/prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();
        prefabs.AddRange(Directory.GetFiles("Assets/prefab/cutscenes/", "*.prefab", SearchOption.AllDirectories));

        var dict = new Dictionary<string, Dictionary<string, int>>();
        var dict2 = new Dictionary<string, List<string>>();
        foreach (var file in prefabs)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
            var images = prefab.GetComponentsInChildren<Image>(true);
            foreach (var image in images)
            {
                if (image.sprite)
                {
                    Dictionary<string, int> d = null;
                    if (!dict.TryGetValue(file, out d))
                    {
                        d = new Dictionary<string, int>();
                        dict[file] = d;
                    }
                    var tag = image.sprite.texture.name + " | " + image.sprite.name;
                    if (d.ContainsKey(tag))
                    {
                        d[tag] += 1;
                    }
                    else
                    {
                        d[tag] = 1;
                    }

                    List<string> list = null;
                    if (!dict2.TryGetValue(tag, out list))
                    {
                        list = new List<string>();
                        dict2[tag] = list;
                    }

                    if (!list.Contains(file))
                        list.Add(file);
                }
            }
        }

        var dict3 = new Dictionary<string, bool>();

        var imageFiles = Directory.GetFiles("Assets/images/ui/", "*.png", SearchOption.AllDirectories);
        foreach (var image in imageFiles)
        {
            var assets = AssetDatabase.LoadAllAssetsAtPath(image).ToList();
            foreach (var asset in assets)
            {
                var sprite = asset as Sprite;
                if (sprite != null)
                {
                    var tag = sprite.texture.name + " | " + sprite.name;
                    if (!dict2.ContainsKey(tag))
                    {
                        dict3[tag] = true;
                    }
                }
            }
        }

        var str = LitJson.JsonMapper.ToJson(dict3);
        LogUtil.Debug(str);

//        foreach (var file in depends)
//        {
//            builder.AppendLine(file);
//        }
//
//        LogUtil.Debug(builder.ToString());
    }

    [MenuItem("Tools/Find Missing Scripts")]
    private static void FindInSelection()
    {
        Transform[] go = Selection.transforms;
        int go_count = 0, components_count = 0, missing_count = 0;
        foreach (Transform g in go)
        {
            go_count++;
            Component[] components = g.GetComponentsInChildren<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                components_count++;
                if (components[i] == null)
                {
                    missing_count++;
                    string s = g.name;
                    Transform t = g.transform;
                    while (t.parent != null)
                    {
                        s = t.parent.name + "/" + s;
                        t = t.parent;
                    }
                    LogUtil.Debug("[Missing] " + s + " has an empty script attached in position: " + i + " " + g);
                }
            }
        }

        // LogUtil.Debug(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
    }

    [MenuItem("Tools/Disconnect Prefab")]
    private static void DisconnectPrefab()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            PrefabUtility.DisconnectPrefabInstance(go);
        }

        // LogUtil.Debug(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
    }

    [MenuItem("Tools/Fix Textfields")]
    private static void CorrectTextFields()
    {
        Font defaultFont = AssetDatabase.LoadAssetAtPath("Assets/fonts/cn/font_ui.ttf", typeof(Font)) as Font;
        Text[] texts = GameObject.FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if (text.font == null || text.font.name != "font_ui")
            {
                LogUtil.Debug("Correct the textfield " + text.name);
                text.font = defaultFont;
            }
        }
    }

    [MenuItem("Tools/Fix Textfields_all_ui")]
    private static void CorrectTextFieldsAllUI()
    {
        EditorCoroutine.Start(_CorrectTextFieldsAllUI());
    }

    private static IEnumerator _CorrectTextFieldsAllUI()
    {
        Font defaultFont = AssetDatabase.LoadAssetAtPath("Assets/fonts/cn/font_plain.ttf", typeof(Font)) as Font;
        var prefabs = Directory.GetFiles("Assets/prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();
        prefabs.AddRange(Directory.GetFiles("Assets/prefab/cutscenes", "*.prefab", SearchOption.AllDirectories));
        var mat = AssetDatabase.LoadAssetAtPath<Material>("Assets/Tools/Materials/sprite.mat");
        LogUtil.Error("mat = " + mat.ToString());

        for (int i = 0; i < prefabs.Count; ++i)
        {
            var prefab = prefabs[i];
            var changed = false;
            EditorUtility.DisplayProgressBar("fix text fields", "fixing " + prefab, (float)i / prefabs.Count);

            var p = AssetDatabase.LoadAssetAtPath<GameObject>(prefab);
            GameObject go = GameObject.Instantiate(p);
            var texts = go.GetComponentsInChildren<Text>(true);
            var canvases = go.GetComponentsInChildren<Canvas>(true);
            var images = go.GetComponentsInChildren<Image>(true);
            foreach (var text in texts)
            {
                if (text.font == null || (text.font.name != "font_ui" && text.font.name != "font_plain"))
                {
                    if (text.font != null)
                    {
                        LogUtil.Debug("Correct the textfield " + text.name + " font " + text.font.name);
                    }
                    else
                    {
                        LogUtil.Debug("Correct the textfield " + text.name + " font null");
                    }

                    text.font = defaultFont;
                    PrefabUtility.ReplacePrefab(go, p, ReplacePrefabOptions.ReplaceNameBased);

                    yield return null;
                }

//                if (text.material.name == "Default UI Material")
//                {
//                    text.material = mat;
//                    PrefabUtility.ReplacePrefab(go, p, ReplacePrefabOptions.ReplaceNameBased);
//                    yield return null;
//                }
            }
            foreach (var canvas in canvases)
            {
                if (canvas.pixelPerfect)
                {
                    LogUtil.Debug("Correct the pixelPerfect " + go.name);
                    canvas.pixelPerfect = false;
                    PrefabUtility.ReplacePrefab(go, p, ReplacePrefabOptions.ReplaceNameBased);
                    yield return null;
                }
                if (canvas.overridePixelPerfect)
                {
                    canvas.overridePixelPerfect = false;
                    PrefabUtility.ReplacePrefab(go, p, ReplacePrefabOptions.ReplaceNameBased);
                    yield return null;
                }
            }

//            foreach (var image in images)
//            {
//                LogUtil.Debug("image material is " + image.material.name);
//                if (image.material.name != "Default UI Material")
//                    continue;
//
//                if (image.material == mat)
//                    continue;
//
//                var mask = image.gameObject.GetComponent<Mask>();
//                if (mask == null)
//                {
//                    LogUtil.Debug("image material is null " + image.name + " " + image.material.ToString());
//                    image.material = mat;
//                    changed = true;
//
//                    yield return null;
//                }
//
//            }

            if (changed)
            {
                PrefabUtility.ReplacePrefab(go, p, ReplacePrefabOptions.ReplaceNameBased);
            }


            GameObject.DestroyImmediate(go);

        }

        AssetDatabase.SaveAssets();

        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Tools/Replace With Empty GameObject")]
    private static void MakeEmpty()
    {
        GameObject[] gos = Selection.gameObjects;

        foreach (GameObject go in gos)
        {
            var empty = new GameObject();
            empty.transform.SetParent(go.transform.parent);
            empty.name = go.name;
            empty.transform.localPosition = go.transform.localPosition;
            empty.transform.localRotation = go.transform.localRotation;
            empty.transform.localScale = go.transform.localScale;
            GameObject.DestroyImmediate(go);
        }
    }

    [MenuItem("Tools/Particles/Check Materials")]
    private static void CheckParticleMaterials()
    {
        var mats = Directory.GetFiles("Assets/Particles/effects", "*.mat", SearchOption.AllDirectories);
        StringBuilder error = new StringBuilder();
        foreach (var m in mats)
        {
            var mat = AssetDatabase.LoadAssetAtPath<Material>(m);
            if (mat.mainTexture == null && mat.shader.name != "Standard")
            {
                error.AppendLine(mat.name);
            }
        }

        if (error.Length > 0)
        {
            error.Insert(0, "Particle materials missing textures: \n");
            LogUtil.Error(error.ToString());
        }
    }

    //    [MenuItem("Tools/FixEffectMat")]
    private static void FixEfxMaterials()
    {
        var mats = Directory.GetFiles("Assets/Particles/effects", "*.mat", SearchOption.AllDirectories);
        foreach (var m in mats)
        {
            var mat = AssetDatabase.LoadAssetAtPath<Material>(m);
            if (mat.shader.name == "Particles/Additive" || mat.shader.name == "Mobile/Particles/Additive")
            {
                mat.shader = Shader.Find("Custom/Mobile/Particles/Additive");
            }

            if (mat.mainTexture == null)
            {
                LogUtil.Debug(mat.name);
            }
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Fix Prefabs")]
    private static void FixPrefabs()
    {
        EditorCoroutine.Start(_FixPrefabs());
    }

    private static IEnumerator _FixPrefabs()
    {
        var prefabs = Directory.GetFiles("Assets/Prefab/misc/", "*.prefab", SearchOption.AllDirectories);
        var total = prefabs.Length;
        var i = 0;
        foreach (var m in prefabs)
        {
            EditorUtility.DisplayProgressBar("fix prefab ", m, (float)i / total);

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(m);
            if (prefab != null)
            {
                EditorUtility.SetDirty(prefab);
                yield return null;
            }
            i++;
        }

        EditorUtility.ClearProgressBar();

        AssetDatabase.SaveAssets();
    }


    [MenuItem("Tools/Hide All Selected")]
    private static void HideAllSelected()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            go.SetActive(false);
        }

    }

    [MenuItem("Tools/Fix Anim names")]
    private static void FixAnimNames()
    {
        var files = Directory.GetFiles("Assets/Model/animations/male001/", "*.anim", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            AssetDatabase.MoveAsset(file, file.Replace("rad", "rda"));
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Show All Selected")]
    private static void ShowAllSelected()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            go.SetActive(true);
        }
    }

    [MenuItem("Tools/Scanners/Scan all scenes _&s")]
    private static void ScanAllScenes()
    {
        try
        {
            EditorScanners.ScanAllScenes();
        }
        catch (Exception e)
        {
            LogUtil.Error(e.ToString());
            EditorUtility.ClearProgressBar();
        }
    }

    [MenuItem("Tools/Scanners/Scan all characters _&s")]
    private static void ScanAllCharacters()
    {
        EditorScanners.ScanAllCharacters();
    }

    [MenuItem("Tools/Clean Empty Folder _&c")]
    private static void CleanEmptyFolder()
    {
        List<DirectoryInfo> list = new List<DirectoryInfo>();
        AltProg.CleanEmptyDir.Core.FillEmptyDirList(out list);
        AltProg.CleanEmptyDir.Core.DeleteAllEmptyDirAndMeta(ref list);
        LogUtil.Debug("Empty folders cleared");
    }

    [MenuItem("Tools/Check Effect Rotation And Scale _&c")]
    private static void CheckEffect()
    {
        EditorScanners.ScanAllEffect();
    }

    [MenuItem("Tools/Check Effect Particle Sim Space _&c")]
    private static void CheckParticleSimSpace()
    {
        EditorScanners.ScanAllEffectParticleSimSpace();
    }    

    [MenuItem("Play/PlayGame _%g")]
    public static void RunGame()
    {
        SetDevMode("");
        RunDevScene();
    }

    private static void SetDevMode(string mode)
    {
        string path = Application.dataPath + "/StreamingAssets/config.lua";

        if (! File.Exists(path))
        {
            LogUtil.Debug("SetDevMode: create config.lua");
            File.WriteAllText(path, "SCRIPT = 'debug'\nMODE = 'development'\n");
        }

        string content = File.ReadAllText(path);
        string regex = @".*DEV_MODE.*";
        string devMode = "DEV_MODE = '" + mode + "'";
        if (! Regex.IsMatch(content, regex))
        {
            LogUtil.Debug("SetDevMode: adding dev mode " + devMode);
            File.AppendAllText(path, devMode);
        }
        else
        {
            LogUtil.Debug("SetDevMode: changing dev mode " + devMode);
            File.WriteAllText(path, Regex.Replace(content, regex, devMode));
        }
    }

    private static void RunDevScene()
    {
        if (!EditorApplication.isPlaying)
        {
            Packager.AddAllScenes();
            PlayerPrefs.SetString("currentScene", EditorApplication.currentScene);
            EditorApplication.OpenScene("Assets/Scenes/EntryPoint.unity");
            EditorApplication.isPlaying = true;
        }
        else
        {
            EditorApplication.isPlaying = false;
            EditorCoroutine.Start(OpenScene(PlayerPrefs.GetString("currentScene")));
        }
    }

    public static IEnumerator OpenScene(string path)
    {
        yield return new WaitUntil(() => EditorApplication.isPlaying == false);
        EditorApplication.OpenScene(path);
    }

    [MenuItem("Tools/Add b_ prefix %&b")]
    public static void AddBPrefix()
    {
        var objects = Selection.transforms;
        foreach (var o in objects)
        {
            if (!o.name.StartsWith("b_"))
            {
                o.name = "b_" + ToCamelCase(o.name);
            }
        }
    }

    private static string ToCamelCase(string text)
    {
        return text.Substring(0, 1).ToLower() + text.Substring(1);
    }

    [MenuItem("Tools/Make same names _#c")]
    public static void MakeSameNames()
    {
        var objects = Selection.transforms;
        var first = objects[0];
        foreach (var o in objects)
        {
            o.name = first.name;
        }
    }

    [MenuItem("Tools/Make Name Sequences _#s")]
    public static void MakeNameSequence()
    {
        var objects = Selection.transforms;
        var first = objects[0];
        var pattern = @"(\w+)(\d+$)";
        var reg = new Regex(pattern);
        var match = reg.Match(first.name);
        var captures = match.Groups[1].Captures;
        var name = captures[0].Value;
        var startIndex = 1;

        if (match.Groups.Count > 2)
        {
            startIndex = int.Parse(match.Groups[2].Captures[0].Value);
//            LogUtil.Debug(index);
        }

        for (var i = 0; i < match.Groups.Count; i++)
        {
            var g = match.Groups[i];

            for (int j = 0; j < g.Captures.Count; j++)
            {
                LogUtil.Debug("group " + i + ": j=" + j + " " + g.Captures[j].Value);
            }
        }

//        LogUtil.Debug(name);

        for (var i = 0; i < objects.Length; i++)
        {
            var o = objects[i];
            o.name = name + (i + startIndex).ToString();
        }
    }

    [MenuItem("Tools/Add particle storable")]
    public static void AssignParticleStorable()
    {
        var objects = Selection.gameObjects;
        foreach (var o in objects)
        {
            LogUtil.Debug(o.name);
            if (o.GetComponent<Game.ParticleStorable>() == null)
            {
                o.AddComponent<Game.ParticleStorable>();
            }
        }
    }
        
//    [MenuItem("Tools/Optimize/Replace all mask to mask2D")]
    public static void ReplaceAllMask2Mask2D()
    {
        string[] guids = AssetDatabase.FindAssets(string.Format("t:GameObject"), new string[] {"Assets/Prefab/ui"});
        for (int i = 0; i < guids.Length; i++)
        {
            string prefab = AssetDatabase.GUIDToAssetPath(guids [i]);
            Debug.Log(prefab);
            GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(prefab);
            GameObject go = PrefabUtility.InstantiatePrefab(obj) as GameObject;

            UnityEngine.Object targetPrefab = PrefabUtility.GetPrefabParent(go);

            ScrollRect[] srs = go.transform.GetComponentsInChildren<ScrollRect>();

            for (int j = 0; j < srs.Length; j++)
            {
                ScrollRect sr = srs[j];
                GameObject o = sr.gameObject;
                Image img = o.GetComponent<Image>();
                img.sprite = null;
                img.color = new Color32(0, 0, 0, 0);

                Mask mask = o.GetComponent<Mask>();
                GameObject.DestroyImmediate(mask);

                o.AddComponent<RectMask2D>();
            }

            PrefabUtility.ReplacePrefab(go, targetPrefab, ReplacePrefabOptions.ConnectToPrefab);
            GameObject.DestroyImmediate(go);
        }

    }

    [MenuItem("Tools/Optimize/Get all prefabs with scrollview")]
    public static void GetAllPrefabsWithMaskScrollView()
    {
        List<string> lst = new List<string>();
        string[] guids = AssetDatabase.FindAssets(string.Format("t:GameObject"), new string[] {"Assets/Prefab/ui"});
        for (int i = 0; i < guids.Length; i++)
        {
            string prefab = AssetDatabase.GUIDToAssetPath(guids [i]);
            GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(prefab);
            GameObject go = PrefabUtility.InstantiatePrefab(obj) as GameObject;

            UnityEngine.Object targetPrefab = PrefabUtility.GetPrefabParent(go);

            ScrollRect[] srs = go.transform.GetComponentsInChildren<ScrollRect>();
            if (srs.Length != 0)
            {
                bool hasMask = false;
                for (int j = 0; j < srs.Length; j++)
                {
                    ScrollRect sr = srs [j];
                    GameObject o = sr.gameObject;
                    Mask mask = o.GetComponent<Mask>();
                    if (mask != null)
                    {
                        hasMask = true;
                        break;
                    }
                }

                if (hasMask)
                    lst.Add(prefab);
            }
            GameObject.DestroyImmediate(go);
        }

        foreach (string s in lst)
            Debug.Log(s);
    }

    //请先选中要修改的scrollview
    [MenuItem("Tools/Optimize/Replace current mask to mask2D")]
    public static void ReplaceCurrentMask2Mask2D()
    {
        GameObject go = Selection.activeGameObject;
        if (go == null)
            return;

        GameObject goRoot = PrefabUtility.FindRootGameObjectWithSameParentPrefab(go) as GameObject;
        if (goRoot == null)
            return;

        Debug.Log("rootPrefab = " + goRoot.name);

        ScrollRect sr = go.GetComponent<ScrollRect>();
        if (sr == null)
            return;

        Image img = go.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = null;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        }

        Mask mask = go.GetComponent<Mask>();
        GameObject.DestroyImmediate(mask);

        if(go.GetComponent<RectMask2D>() == null)
            go.AddComponent<RectMask2D>();
        
        UnityEngine.Object targetPrefab = PrefabUtility.GetPrefabParent(go);
        if (targetPrefab == null)
            return;

        PrefabUtility.ReplacePrefab(goRoot, targetPrefab, ReplacePrefabOptions.ConnectToPrefab | ReplacePrefabOptions.ReplaceNameBased);
        Debug.Log(goRoot.name + " 修改完成...");
    }

}