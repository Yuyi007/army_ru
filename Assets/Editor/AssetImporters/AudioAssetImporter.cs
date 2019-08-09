using System;
using UnityEditor;
using UnityEngine;
using LBoot;

public class AudioAssetImporter : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        var importer = this.assetImporter as AudioImporter;
        // importer.ClearSampleSettingOverride("Standalone");
        // importer.ClearSampleSettingOverride("iOS");
        // importer.ClearSampleSettingOverride("Android");

        var defaultSettings = importer.defaultSampleSettings;
        var androidSettings = importer.GetOverrideSampleSettings("Android");
        
        var useStreaming = true;
        // if (importer.assetPath.Contains("sounds/efx/"))
        // {
        //     useStreaming = false;
        // }
        if (useStreaming) 
        {
            androidSettings.loadType = AudioClipLoadType.Streaming;
        }
        else 
        {
            androidSettings.loadType = AudioClipLoadType.CompressedInMemory;
        }
        defaultSettings.loadType = AudioClipLoadType.CompressedInMemory;

        importer.defaultSampleSettings = defaultSettings;
        // importer.SetOverrideSampleSettings("Android", androidSettings);
        // importer.forceToMono = false;
        // importer.loadInBackground = true;
        // importer.preloadAudioData = true;
        
        importer.ClearSampleSettingOverride("Android");
    }

    void OnPostProcessAudio(AudioClip clip) 
    {

    }
}

