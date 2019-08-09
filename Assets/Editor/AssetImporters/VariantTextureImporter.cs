using System;
using UnityEditor;
using UnityEngine;


public class VariantTextureImporter : AssetPostprocessor
{

    void OnPreprocessTexture()
    {
        if (assetPath.Contains("Assets/Variants/character"))
        {
            var importer = assetImporter as TextureImporter;
            importer.maxTextureSize = 128;
            importer.mipmapEnabled = false;
            importer.textureFormat = TextureImporterFormat.AutomaticCompressed;
            importer.compressionQuality = 50;
//            importer.SetAllowsAlphaSplitting(true);
        }

    }


}

