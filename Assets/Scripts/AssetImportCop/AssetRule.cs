using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR

using System.IO;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

[System.Serializable]
public enum AssetFilterType
{
    kAny,
    kTexture,
    kMesh
}

[System.Serializable]
public class AssetRule : ScriptableObject
{
    public AssetFilter filter;
    public AssetRuleImportSettings settings;

#if UNITY_EDITOR

    public static AssetRule CreateAssetRule()
    {
        var assetRule = AssetRule.CreateInstance<AssetRule>();

        assetRule.ApplyDefaults();

        return assetRule;
    }

    public void ApplyDefaults()
    {
        filter.ApplyDefaults();
        settings.ApplyDefaults();
    }

    public bool IsMatch(AssetImporter importer)
    {
        return filter.IsMatch(importer);
    }

    public bool AreSettingsCorrect(AssetImporter importer)
    {
        return settings.AreSettingsCorrect(importer);
    }

    public void ApplySettings(AssetImporter importer)
    {
        settings.Apply(importer);
    }
#endif
}



[System.Serializable]
public struct AssetFilter
{
    public AssetFilterType type;
    public string path;

#if UNITY_EDITOR
    public bool IsMatch(AssetImporter importer)
    {
        if (importer == null)
            return false;

        AssetFilterType filterType = GetAssetFilterType(importer);
        return IsMatch(filterType, importer.assetPath);
    }

    public bool IsMatch(string path)
    {
        if (string.IsNullOrEmpty(this.path))
            return true;
        if (string.IsNullOrEmpty(path))
        {
            return string.IsNullOrEmpty(this.path);
        }

        if (path.Contains(this.path))
        {
            return true;
        }

        var filters = this.path.Replace(" ", "").Split(',');
        var negFilters = filters.Where(f => f.StartsWith("!"));
        var posFilters = filters.Except(negFilters);

        foreach (var filter in negFilters)
        {
            if (path.Contains(filter.Substring(1)))
                return false;
        }

        if (posFilters.Count() == 0)
            return true;

        foreach (var filter in posFilters)
        {
            if (path.Contains(filter))
                return true;
        }
//
//		string[] files = Directory.GetFiles(Application.dataPath, this.path);
//        string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories).Where(file =>
//            Regex.IsMatch(path, this.path)
//        );
//
//		if(files == null)
//			return false;
//
//		for(int i = 0; i < files.Length; i++)
//		{
//			if(fullPath.Equals(files[i]))
//				return true;
//		}

        return false;
    }

    public bool IsMatch(AssetFilterType type, string path)
    {
        return (this.type == AssetFilterType.kAny || type == this.type) &&
        IsMatch(path);
    }

    public static AssetFilterType GetAssetFilterType(AssetImporter importer)
    {
        if (importer is TextureImporter)
            return AssetFilterType.kTexture;
        else if (importer is ModelImporter)
            return AssetFilterType.kMesh;

        return AssetFilterType.kAny;
    }

    public void ApplyDefaults()
    {
        type = AssetFilterType.kAny;
        path = "";
    }
#endif
}


[System.Serializable]
public struct AssetRuleImportSettings
{
    public TextureImporterSettings textureSettings;
    public MeshImporterSettings meshSettings;
    public bool enableCompressSetting;
    public TextureImporterFormat iosTextureFormat;
    public TextureImporterFormat androidTextureFormat;
    public bool overrideAndroid;
    public bool overrideIos;
    public bool changeReadableSetting;

    public bool AreSettingsCorrect(AssetImporter importer)
    {
        if (importer is TextureImporter)
            return AreSettingsCorrectTexture((TextureImporter)importer);
        else if (importer is ModelImporter)
            return AreSettingsCorrectModel((ModelImporter)importer);

        return true;
    }

    bool AreSettingsCorrectTexture(TextureImporter importer)
    {
        TextureImporterSettings currentSettings = new TextureImporterSettings();
        importer.ReadTextureSettings(currentSettings);

        if (currentSettings.mipmapEnabled != this.textureSettings.mipmapEnabled)
            return false;
        if (currentSettings.readable != this.textureSettings.readable)
            return false;
        if (currentSettings.maxTextureSize > this.textureSettings.maxTextureSize)
            return false;
        if (currentSettings.lightmap != this.textureSettings.lightmap)
            return false;
        if (currentSettings.spriteMode != this.textureSettings.spriteMode)
            return false;

        if (this.enableCompressSetting)
        {
            if (currentSettings.textureFormat != this.textureSettings.textureFormat)
                return false;
            if (currentSettings.compressionQuality != this.textureSettings.compressionQuality)
                return false;
        }
        return true;

    }

    bool AreSettingsCorrectModel(ModelImporter importer)
    {
        var currentSettings = MeshImporterSettings.Extract(importer);
        return MeshImporterSettings.Equal(currentSettings, this.meshSettings);
    }

    public void Apply(AssetImporter importer)
    {
        if (importer is TextureImporter)
            ApplyTextureSettings((TextureImporter)importer);
        else if (importer is ModelImporter)
            ApplyMeshSettings((ModelImporter)importer);
    }

    void ApplyTextureSettings(TextureImporter importer)
    {
        bool dirty = false;
        TextureImporterSettings tis = new TextureImporterSettings();
        importer.ReadTextureSettings(tis);
        if (tis.mipmapEnabled != textureSettings.mipmapEnabled)
        {
            tis.mipmapEnabled = textureSettings.mipmapEnabled;
            dirty = true;
        }
        if (tis.readable != textureSettings.readable && this.changeReadableSetting)
        {
            tis.readable = textureSettings.readable;
            dirty = true;
        }
        if (tis.maxTextureSize > textureSettings.maxTextureSize)
        {
            tis.maxTextureSize = textureSettings.maxTextureSize;
            dirty = true;
        }

        if (tis.lightmap != textureSettings.lightmap)
        {
            tis.lightmap = textureSettings.lightmap;
            dirty = true;
        }

        if (tis.spriteMode != textureSettings.spriteMode)
        {
            tis.spriteMode = textureSettings.spriteMode;
            dirty = true;
        }

        if (tis.lightmap)
        {
            importer.textureType = TextureImporterType.Lightmap;
            string assetPath = importer.assetPath;
            if (assetPath.Contains("Lightmap") && assetPath.Contains(".exr"))
            {
                importer.textureType = TextureImporterType.Lightmap;
                importer.wrapMode = TextureWrapMode.Clamp;
            }
            if (assetPath.Contains("water_reflection_probe") && assetPath.Contains(".exr"))
            {
                importer.textureType = TextureImporterType.Cubemap;
                tis.cubemapConvolution = TextureImporterCubemapConvolution.None;
                tis.mipmapEnabled = false;
                tis.ApplyTextureType(TextureImporterType.Cubemap, false);
                importer.SetTextureSettings(tis);
            }
        }

        if (tis.spriteMode != 0)
            importer.textureType = TextureImporterType.Sprite;

        if (this.enableCompressSetting)
        {
            if (tis.textureFormat != textureSettings.textureFormat)
            {
                tis.textureFormat = textureSettings.textureFormat;
                dirty = true;
            }

            if (tis.compressionQuality != textureSettings.compressionQuality)
            {
                tis.compressionQuality = textureSettings.compressionQuality;
                dirty = true;
            }
        }

        // add settings as needed

        if (overrideIos)
        {
            int max;
            TextureImporterFormat format;
            importer.GetPlatformTextureSettings("iPhone", out max, out format);
            if (format != iosTextureFormat)
            {
                dirty = true;
            }
        }


        if (overrideAndroid)
        {
            int max;
            TextureImporterFormat format;
            int quality;
            importer.GetPlatformTextureSettings("Android", out max, out format);
            if (format != androidTextureFormat)
            {
                dirty = true;
            }


//            if (tis.allowsAlphaSplit != textureSettings.allowsAlphaSplit)
//            {
//                tis.allowsAlphaSplit = textureSettings.allowsAlphaSplit;
//                dirty = true;
//            }
        }

//        importer.SetAllowsAlphaSplitting(false);

        if (dirty)
        {
            Debug.Log("Modifying texture settings");
            importer.SetTextureSettings(tis);


            if (overrideIos)
            {
                importer.SetPlatformTextureSettings("iPhone", tis.maxTextureSize, iosTextureFormat, tis.compressionQuality, false);
            }
            if (overrideAndroid)
            {
                importer.SetPlatformTextureSettings("Android", tis.maxTextureSize, androidTextureFormat, tis.compressionQuality, true);
            }
//            importer.SaveAndReimport();
        }
        else
        {
            Debug.Log("Texture Import Settings are Ok");
        }
    }

    void ApplyMeshSettings(ModelImporter importer)
    {
        bool dirty = false;
        if (meshSettings.changeReadableSettings && importer.isReadable != meshSettings.readWriteEnabled)
        {
            importer.isReadable = meshSettings.readWriteEnabled;
            dirty = true;
        }

        if (importer.optimizeMesh != meshSettings.optimiseMesh)
        {
            importer.optimizeMesh = meshSettings.optimiseMesh;
            dirty = true;
        }

        if (importer.importBlendShapes != meshSettings.ImportBlendShapes)
        {
            importer.importBlendShapes = meshSettings.ImportBlendShapes;
            dirty = true;
        }

        if (importer.importNormals != meshSettings.normalImportMode)
        {
            importer.importNormals = meshSettings.normalImportMode;
            dirty = true;
        }

        if (importer.animationType != meshSettings.animationType)
        {
            importer.animationType = meshSettings.animationType;
            if (importer.animationType == ModelImporterAnimationType.None)
            {
                importer.importAnimation = false;
            }
            dirty = true;
        }

        if (importer.importMaterials != meshSettings.importMaterials)
        {
            importer.importMaterials = meshSettings.importMaterials;
            dirty = true;
        }

        if (importer.meshCompression != meshSettings.meshCompression)
        {
            importer.meshCompression = meshSettings.meshCompression;
            dirty = true;
        }

        if (importer.importTangents != meshSettings.importTangents)
        {
            importer.importTangents = meshSettings.importTangents;
            dirty = true;
        }

        // Add more settings in here that you might need

        if (dirty)
        {
            Debug.Log("Modifying Model Import Settings, An Import will now occur and the settings will be checked to be OK again during that import");
//            importer.SaveAndReimport();
        }
        else
        {
            Debug.Log("Model Import Settings OK");
        }
    }

    public void ApplyDefaults()
    {
        meshSettings.ApplyDefaults();
        ApplyTextureSettingDefaults();

    }

    private void ApplyTextureSettingDefaults()
    {
        textureSettings = new TextureImporterSettings();
        Debug.Log("texture setting defaults");
        textureSettings.maxTextureSize = 2048;
        textureSettings.mipmapEnabled = true;
        textureSettings.lightmap = false;
        textureSettings.textureFormat = TextureImporterFormat.AutomaticCompressed;
        textureSettings.compressionQuality = 50;
        textureSettings.spriteMode = 0;
        overrideAndroid = false;
        overrideIos = false;
        iosTextureFormat = TextureImporterFormat.AutomaticCompressed;
        androidTextureFormat = TextureImporterFormat.AutomaticCompressed;
//        textureSettings.allowsAlphaSplit = true;
        changeReadableSetting = true;

    }
}

#endif