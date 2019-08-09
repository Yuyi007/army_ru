using System;
using UnityEditor;
using UnityEngine;
using LBoot;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LBootEditor
{

    public class SaveProcessor : SaveAssetsProcessor
    {
        static string[] OnWillSaveAssets(string[] paths)
        {
            // var rules = AssetDatabase.FindAssets("t:AssetRule");
            // var rulePaths = rules.Select(x => Path.GetDirectoryName(AssetDatabase.GUIDToAssetPath(x)));
            // var setting = PipelineSettings.Load();
            // setting.ImportPathWatches = rulePaths.Distinct().ToArray();
            // EditorUtility.SetDirty(setting);

            if (EditorBuildSettings.scenes.Length > 1 && !Application.isPlaying)
            {
                EditorBuildSettings.scenes = new EditorBuildSettingsScene[]
                {
                    new EditorBuildSettingsScene("Assets/Scenes/EntryPoint.unity", true)
                };
            }
            else
            {
//                var names = paths.xJoin("\n");
//                LogUtil.Debug("saving:\n" + names);
            }

            var list = new List<string>();
            foreach(var s in paths) {
                if (s.EndsWith("AlphaMaskPoint.mat"))
                    continue;
                if (s.EndsWith("plane.mat"))
                    continue;
                if (s.EndsWith("HollowMask.mat"))
                    continue;

                list.Add(s);
//                Debug.Log("will save " + s);
            }

            return list.ToArray();
        }
    }
}

