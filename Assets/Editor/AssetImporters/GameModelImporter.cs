using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LBoot;

public class GameModelImporter : AssetPostprocessor
{
    [MenuItem("Assets/Model/Process Model")]
    private static void ProcessModel()
    {
        var model = Selection.activeGameObject;
        var path = AssetDatabase.GetAssetPath(model);
        _ProcessModel(path);
    }


    private static void _ProcessModelWindows(string assetPath)
    {
        if (assetPath.Contains("Model/characters/") || assetPath.Contains("Model/clothes/") || assetPath.Contains("Model/clothes/"))
        {
            var settings = LBootEditor.PipelineSettings.Load();
            if (settings.CanRunCharacterPipeline())
            {
                _ProcessModel(assetPath);
            }
            else
            {
                LogUtil.Warn("Machine " + Environment.MachineName + " is not in character pipeline machines");
            }
        }
    }

    private static void _ProcessModel(string assetPath)
    {
        var importer = AssetImporter.GetAtPath(assetPath) as ModelImporter;
        importer.meshCompression = ModelImporterMeshCompression.Off;
        AssetDatabase.WriteImportSettingsIfDirty(assetPath);
        AssetDatabase.Refresh();

        var model = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        if (assetPath.Contains("Model/characters/"))
        {
            var folder = Path.GetDirectoryName(assetPath);
            if (folder.Contains("_"))
            {
                ProcessCharacter(model);
            }

        }
        else if (assetPath.Contains("Model/clothes/"))
        {
            ProcessClothes(model);

        }
        else if (assetPath.Contains("Model/barrels/"))
        {
            ProcessBarrel(model);
        }
    }

    void OnPostprocessModel(GameObject o)
    {
#if !UNITY_EDITOR_OSX
        var importer = this.assetImporter as ModelImporter;
        _ProcessModelWindows(importer.assetPath);
#endif
    }

    static void ProcessCharacter(GameObject model)
    {
        var go = GameObject.Instantiate(model);
        go.name = model.name;

        var modify = new ModifyModel(go);
        modify.Bootstrap();

        var modify2 = new ModifyModel(go, true);
        modify2.Bootstrap();

        GameObject.DestroyImmediate(go);
        AssetDatabase.SaveAssets();
    }

    static void ProcessClothes(GameObject model)
    {
        var go = GameObject.Instantiate(model);
        go.name = model.name;

        var modifier = new ModifyClothes(go);
        modifier.CreatePrefab();
        GameObject.DestroyImmediate(go);
        AssetDatabase.SaveAssets();
    }

    static void ProcessBarrel(GameObject model)
    {
        var go = GameObject.Instantiate(model);
        go.name = model.name;
        var modify = new ModifyBarrel(go);
        modify.Bootstrap();
        GameObject.DestroyImmediate(go);
        AssetDatabase.SaveAssets();
    }


    Material OnAssignMaterialModel(Material material, Renderer renderer)
    {
        var importer = this.assetImporter as  ModelImporter;

        if (importer.assetPath.Contains("Model/clothes/"))
        {
            return AssignMaterialBasedOnModel(material, renderer);
        }
        else if (importer.assetPath.Contains("Model/characters"))
        {
            return AssignMaterialBasedOnRenderer(material, renderer);
        }
        else if (importer.assetPath.Contains("Model/weapons/"))
        {
            return AssignMaterialBasedOnModel(material, renderer);
        }
        else if (importer.assetPath.Contains("Model/barrels/"))
        {
            return AssignMaterialBasedOnRenderer(material, renderer);
        }
        else
        {
            return null;
        }
    }

    private Material AssignMaterialBasedOnModel(Material material, Renderer renderer)
    {
        var importer = this.assetImporter as  ModelImporter;
        var name = Path.GetFileNameWithoutExtension(importer.assetPath);
        var dirPath = Path.GetDirectoryName(importer.assetPath);

        Directory.CreateDirectory(dirPath + "/Materials/");
        var matname = name;
        var matPath = dirPath + "/Materials/" + matname + ".mat";
        var texturePath = dirPath + "/texture/" + matname + ".tga";
        var texture = AssetDatabase.LoadAssetAtPath<Texture>(texturePath);
        var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
        if (mat != null)
        {
            mat.name = matname;
            FixMaterial(mat, texture);
            renderer.sharedMaterial = mat;
        }
        else
        {
            mat = new Material(Shader.Find("Shaders/TextureRampRimLight"));
            mat.name = matname;
            FixMaterial(mat, texture);
            renderer.sharedMaterial = mat;
            AssetDatabase.CreateAsset(mat, matPath);
        }
        return mat;
    }

    private Material AssignMaterialBasedOnRenderer(Material material, Renderer renderer)
    {
        var importer = this.assetImporter as  ModelImporter;
        var name = Path.GetFileNameWithoutExtension(importer.assetPath);
        var dirPath = Path.GetDirectoryName(importer.assetPath);

        Directory.CreateDirectory(dirPath + "/Materials/");
        var matname = name + "_" + renderer.name;
        var matPath = dirPath + "/Materials/" + matname + ".mat";
        var texturePath = dirPath + "/texture/" + matname + ".tga";
        var texture = AssetDatabase.LoadAssetAtPath<Texture>(texturePath);
        var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
        if (mat != null)
        {
            mat.name = matname;
            FixMaterial(mat, texture);
            renderer.sharedMaterial = mat;
        }
        else
        {
            mat = new Material(Shader.Find("Shaders/TextureRampRimLight"));
            mat.name = matname;
            FixMaterial(mat, texture);
            renderer.sharedMaterial = mat;
            AssetDatabase.CreateAsset(mat, matPath);
        }
        return mat;
    }

    void FixMaterial(Material material, Texture texture)
    {
        if (!material.shader.name.Contains("TextureRamp"))
        {
            material.shader = Shader.Find("Shaders/TextureRampRimLight");
        }

        if (texture != null)
        {
            material.mainTexture = texture;
        }

        // if (material.shader.name != "Shaders/TextureRampRimLightAdditive") {
        //     material.SetTexture("_RampTex", Resources.Load<Texture2D>("Texture/test_ramp"));
        //     material.SetColor("_ShadowColor", new Color(202f / 255f, 169f / 255f, 219f / 255f, 1));
        // }
    }
}

