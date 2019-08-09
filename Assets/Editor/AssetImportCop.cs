using System.IO;
using UnityEditor;
using UnityEngine;
using LBoot;
using System.Collections.Generic;
using System.Linq;

// TODO compile to dll
public class AssetImportCop : AssetPostprocessor
{
    AssetRule FindRuleForAsset(string path, AssetImporter importer)
    {
        return SearchRecursive(path, importer);
    }

    private AssetRule SearchRecursive(string path, AssetImporter importer)
    {
        foreach (var findAsset in AssetDatabase.FindAssets("t:AssetRule", new[] {Path.GetDirectoryName(path)}))
        {
            var rulePath = AssetDatabase.GUIDToAssetPath(findAsset);
            var p = Path.GetDirectoryName(rulePath);
            if (p == Path.GetDirectoryName(path))
            {
                LogUtil.Debug("Found AssetRule for Asset Rule" + rulePath);
                var rule = AssetDatabase.LoadAssetAtPath<AssetRule>(rulePath);
                if (rule.IsMatch(importer))
                    return rule;
            }
        }
        //no match so go up a level
        path = Directory.GetParent(path).FullName;
        path = path.Replace('\\', '/');
        path = path.Remove(0, Application.dataPath.Length);
        path = path.Insert(0, "Assets");
        LogUtil.Debug("Searching: " + path);
        if (path != "Assets")
            return SearchRecursive(path, importer);

        //no matches
        return null;
    }


    private void OnPreprocessTexture()
    {
        var setting = LBootEditor.PipelineSettings.Load();
        if (setting != null && !setting.ImportPathWatches.Any(x => assetImporter.assetPath.Contains(x)))
            return;

        AssetRule rule = FindRuleForAsset(assetImporter.assetPath, assetImporter);

        if (rule == null)
        {
//            LogUtil.Debug("No asset rules found for asset");
            return;
        }

        LogUtil.Debug("Modifying Texture settings: " + assetImporter.assetPath);
        rule.ApplySettings(assetImporter);
    }

    private void OnPreprocessModel()
    {
        var setting = LBootEditor.PipelineSettings.Load();
        if (setting != null && !setting.ImportPathWatches.Any(x => assetImporter.assetPath.Contains(x)))
            return;

        AssetRule rule = FindRuleForAsset(assetImporter.assetPath, assetImporter);

        if (rule == null)
        {
//            LogUtil.Debug("No asset rules found for asset");
            return;
        }
        rule.ApplySettings(assetImporter);
    }
}
