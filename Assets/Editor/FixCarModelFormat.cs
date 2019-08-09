using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CarModelFromatFixer
{
    [MenuItem("Assets/FixMod/FixModelImport")]
    static void FixCarModelImportFormat()
    {
        string[] folders = { "Assets/Models" };

        string[] guids = AssetDatabase.FindAssets("t:Model", folders);
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter mi = ModelImporter.GetAtPath(path) as ModelImporter;
            if (mi == null)
                return;

            mi.isReadable = false;
            mi.optimizeMesh = true;

            mi.SaveAndReimport();
        }
    }
}
