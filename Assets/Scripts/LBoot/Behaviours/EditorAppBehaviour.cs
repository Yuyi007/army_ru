
using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LBoot
{
    public class EditorAppBehaviour : MonoBehaviour
    {
        void OnApplicationQuit()
        {
            #if UNITY_EDITOR
            // make sure only the main scene is in the build setting
            EditorBuildSettings.scenes = new EditorBuildSettingsScene[]
            {
                new EditorBuildSettingsScene("Assets/Scenes/EntryPoint.unity", true)
            };
            #endif
        }
    }
}

