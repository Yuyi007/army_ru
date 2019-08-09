using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace LBootEditor
{
    public class PipelineSettings : ScriptableObject, ISerializationCallbackReceiver
    {
        public string[] CharacterPipelineMachines;
        public string[] ScenePipelineMachines;
        public string[] ParticlePipelineMachines;
        public string[] ImportPathWatches;

#region ISerializationCallbackReceiver implementation

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            for (var i = 0; i < CharacterPipelineMachines.Length; i++)
            {
                CharacterPipelineMachines[i] = CharacterPipelineMachines[i].ToUpper();
            }

            for (var i = 0; i < ScenePipelineMachines.Length; i++)
            {
                ScenePipelineMachines[i] = ScenePipelineMachines[i].ToUpper();
            }

            for (var i = 0; i < ParticlePipelineMachines.Length; i++)
            {
                ParticlePipelineMachines[i] = ParticlePipelineMachines[i].ToUpper();
            }
        }

        public bool CanRunCharacterPipeline()
        {
            return CharacterPipelineMachines.Contains(System.Environment.MachineName.ToUpper());
        }

        public bool CanRunScenePipeline()
        {
            return ScenePipelineMachines.Contains(System.Environment.MachineName.ToUpper());
        }

        public bool CanRunParticlePipeline()
        {
            return ParticlePipelineMachines.Contains(System.Environment.MachineName.ToUpper());
        }

#endregion

#if UNITY_EDITOR
        public static PipelineSettings Load()
        {
            var path = "Assets/Editor/pipeline_settings.asset";
            if (File.Exists(path))
            {
                var settings = AssetDatabase.LoadAssetAtPath<PipelineSettings>(path);
                if (settings == null)
                {
                    AssetDatabase.ImportAsset(path);
                    settings = AssetDatabase.LoadAssetAtPath<PipelineSettings>(path);
                }

                return settings;
            }
            else
            {
                var settings = PipelineSettings.CreateInstance<PipelineSettings>();
                AssetDatabase.CreateAsset(settings, path);
                return settings;
            }
        }


        [MenuItem("Tools/Settings/Pipeline", false, 100)]
        public static void SelectSettings()
        {
            var settings = Load();
            Selection.activeObject = settings;
        }

#endif
    }

}

