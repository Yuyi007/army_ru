
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System;
using LBoot;
using System.Linq;
using System.Text.RegularExpressions;
using LitJson;
using System.Text;


public class ScanHelper
{
    public static void ScanGraph()
    {
        EditorScanners.ProcScallScene();
    }

    public static void ScanCharactors()
    {
        EditorScanners.ProcScanCharactor();
    }

    public static void Scan()
    {
        var args = Environment.GetCommandLineArgs();
        FI.ConfigPath = args[args.Length - 2];

        ScanGraph();
        ScanCharactors();
    }
}

public class EditorScanners
{
    public static void ProcScanCharactor()
    {
        ScanAllCharacters();
    }

    public static void ProcScallScene()
    {
        ScanAllScenes();
    }

    public static void ScanAllEffect()
    {
        var allEffects = Directory.GetFiles("Assets/Prefab/misc/", "*.prefab", SearchOption.AllDirectories).ToList();
        for (int i = 0; i < allEffects.Count; ++i)
        {
            var effect = allEffects[i];
            EditorUtility.DisplayProgressBar("Scan all effect", "scanning " + effect, (float)i / allEffects.Count);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(effect);
            var name = System.IO.Path.GetFileNameWithoutExtension(effect);
            var scanner = new EffectScanner();
            scanner.ScanPrefab(name, prefab);
        }
        EditorUtility.ClearProgressBar();
    }

    public static void ScanAllEffectParticleSimSpace()
    {
        var allEffects = Directory.GetFiles("Assets/Prefab/misc/", "*.prefab", SearchOption.AllDirectories).ToList();
        for (int i = 0; i < allEffects.Count; ++i)
        {
            var effect = allEffects[i];
            EditorUtility.DisplayProgressBar("Scan all effect", "scanning " + effect, (float)i / allEffects.Count);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(effect);
            var name = System.IO.Path.GetFileNameWithoutExtension(effect);
            var scanner = new EffectScanner();
            scanner.ScanParticleSimSpace(name, prefab);
        }
        EditorUtility.ClearProgressBar();
    }

    public static void ScanAllScenes()
    {
        var configName = "scenes.json";
        var filename = FI.ConfigPath + configName;

        var trancfgName = "transtriggers.json";
        var tranFileName = FI.ConfigPath + trancfgName;

        var npccfgName = "npctriggers.json";
        var npcFileName = FI.ConfigPath + npccfgName;

        var facilitycfgName = "facilitytriggers.json";
        var facilityFileName = FI.ConfigPath + facilitycfgName;

        var questcfgName = "questtriggers.json";
        var questFileName = FI.ConfigPath + questcfgName;

        var investigatecfgName = "investigatetriggers.json";
        var investigateFileName = FI.ConfigPath + investigatecfgName;

        var jsonWriter = new ScannerJsonWriter();
        var config = new SceneConfig();
        var cfgTran = new TranConfig();
        var cfgFacility = new FacilityConfig();
        var cfgNpc = new NpcConfig();
        var cfgQuest = new QuestAreaConfig();
        var cfgInvestigate = new InvestigateConfig();

        var allScenes = Directory.GetFiles("Assets/Scenes/game/streets", "*.unity", SearchOption.AllDirectories).ToList();
        for (int i = 0; i < allScenes.Count; ++i)
        {
            var scene = allScenes[i];
            EditorUtility.DisplayProgressBar("Scan all scenes", "scanning " + scene, (float)i / allScenes.Count);

            Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.OnDemand;
            var sceneName = Path.GetFileNameWithoutExtension(scene);
            var triggerSceneFile = "Assets/Scenes/city_triggers/" + sceneName + "_trigger.unity";

            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scene, UnityEditor.SceneManagement.OpenSceneMode.Single);
            if (File.Exists(triggerSceneFile))
            {
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(triggerSceneFile, UnityEditor.SceneManagement.OpenSceneMode.Additive);
            }

            Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.OnDemand;

            var curScene = EditorApplication.currentScene;
            if (curScene != null && curScene != "")
            {
                sceneName = System.IO.Path.GetFileNameWithoutExtension(curScene);
                var street = new SceneConfig.Street(sceneName);
                var ttan = new TranConfig.Trigger(sceneName);
                var tnpc = new NpcConfig.Trigger(sceneName);
                var tfacility = new FacilityConfig.Trigger(sceneName);
                var tquest = new QuestAreaConfig.Trigger(sceneName);
                var tinvestigate = new InvestigateConfig.Trigger(sceneName);

                var scanner = new SceneScanner(street, ttan, tfacility, tnpc, tquest, tinvestigate);
                scanner.ScanCurrentScene(sceneName);
                config.AddStreet(street);
                cfgTran.AddTrigger(ttan);
                cfgNpc.AddTrigger(tnpc);
                cfgFacility.AddTrigger(tfacility);
                cfgQuest.AddTrigger(tquest);
                cfgInvestigate.AddTrigger(tinvestigate);

                LogUtil.Debug("Scene " + curScene + " scan success");
            }
            else
            {
                LogUtil.Debug("You need to select a scene before scan");
            }

        }
        jsonWriter.OutputToFile(filename, config.ToJson());
        jsonWriter.OutputToFile(tranFileName, cfgTran.ToJson());
        jsonWriter.OutputToFile(facilityFileName, cfgFacility.ToJson());
        jsonWriter.OutputToFile(npcFileName, cfgNpc.ToJson());
        jsonWriter.OutputToFile(questFileName, cfgQuest.ToJson());
        jsonWriter.OutputToFile(investigateFileName, cfgInvestigate.ToJson());


        LogUtil.Debug("Scene " + filename + " successfully generated in game-config folder");
        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
    }

    public static void ScanAllCharacters()
    {
        var configName = "skill_anims.json";
        var configFilename = FI.ConfigPath + configName;

        var jsonWriter = new CharacterJsonWriter();
        jsonWriter.WriteObjectStart();

        UnityEditor.SceneManagement.EditorSceneManager.NewScene(
            UnityEditor.SceneManagement.NewSceneSetup.EmptyScene, UnityEditor.SceneManagement.NewSceneMode.Single);

        var all = Directory.GetFiles("Assets/Prefab/characters", "*.prefab", SearchOption.AllDirectories).ToList();
        for (int i = 0; i < all.Count; ++i)
        {
            var filename = all[i];
            EditorUtility.DisplayProgressBar("Scan all characters", "scanning " + filename, (float)i / all.Count);

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(filename);
            var name = System.IO.Path.GetFileNameWithoutExtension(filename);

            if (name.EndsWith("_model"))
            {
                name = name.Substring(0, name.Length - "_model".Length);
            }

            var scanner = new CharacterScanner(jsonWriter);
            scanner.ScanPrefab(name, prefab);

            LogUtil.Debug("Prefab " + filename + " scan success");
        }
        ;

        jsonWriter.WriteObjectEnd();
        jsonWriter.OutputToFile(configFilename);

        LogUtil.Debug("Config " + configFilename + " successfully scanned and generated in game-config folder");
        EditorUtility.ClearProgressBar();
    }
}
