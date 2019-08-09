using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using LBoot;

public class Static3DModelImporter : AssetPostprocessor
{

    void OnPreprocessModel()
    {
        var importer = this.assetImporter as ModelImporter;
        // if (importer.assetPath.Contains("Models/streets/"))
        // {
        //     importer.animationType = ModelImporterAnimationType.None;
        // }

        if (importer.assetPath.Contains("Model/fx/"))
        {
            importer.animationType = ModelImporterAnimationType.None;
        }

    }

    void OnPostprocessModel(GameObject o)
    {
        // var importer = this.assetImporter as ModelImporter;
        // if (importer.assetPath.Contains("Models/streets/"))
        // {
        //     var renderers = o.GetComponentsInChildren<MeshRenderer>(true);
        //     var meshFilters = o.GetComponentsInChildren<MeshFilter>(true);
        //     foreach (var r in renderers)
        //     {

        //         var bc = r.gameObject.GetComponent<Collider>();
        //         if (bc != null)
        //         {
        //             GameObject.DestroyImmediate(bc);
        //         }
        //     }

        //     var importerReadable = false;
        //     // foreach (var meshFilter in meshFilters)
        //     // {
        //     //     if (meshFilter.sharedMesh != null && meshFilter.sharedMesh.vertexCount < 900)
        //     //     {
        //     //         importerReadable = true;
        //     //         break;
        //     //     }
        //     // }

        //     if (importer.isReadable != importerReadable)
        //     {
        //         importer.isReadable = importerReadable;
        //         EditorUtility.SetDirty(o);
        //     }
        // }

        // if (importer.assetPath.Contains("Model/fx/"))
        // {
        //     var renderers = o.GetComponentsInChildren<Renderer>();
        //     foreach (var r in renderers)
        //     {
        //         r.receiveShadows = false;
        //         r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        //     }
        // }
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        var path = assetPath;
        // automatically setting the texture to the material its supposed to be on for
        // particles
        if (path.Contains("Assets/Particles/effects") && path.EndsWith(".tga", StringComparison.OrdinalIgnoreCase))
        {
            var imageName = Path.GetFileNameWithoutExtension(path);
            var dir = Path.GetDirectoryName(path);
            var matPath = "Assets/Particles/effects/fx_Materials/";
            var mats = Directory.GetFiles(matPath, imageName + "*.mat", SearchOption.AllDirectories);
            foreach (var matFile in mats)
            {
                var mat = AssetDatabase.LoadAssetAtPath<Material>(matFile);

                if (mat != null && mat.mainTexture == null)
                {
                    var text2 = AssetDatabase.LoadAssetAtPath<Texture>(path);
                    if (text2 != null)
                    {
                        mat.SetTexture("_MainTex", text2);
                        mat.mainTexture = text2;
                        EditorUtility.SetDirty(mat);
                        LogUtil.Debug("Fixing Texture: " + matFile);
                    }
                }
            }
        }
    }

}

