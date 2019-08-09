using System;
using UnityEngine;

//using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using LitJson;

namespace LBootEditor
{

    public class GameConfig
    {
        private static GameConfig instance;

        public static GameConfig Get()
        {
#if UNITY_EDITOR_OSX
            if (instance == null)
            {
#endif
                var text = LBoot.FileUtils.GetStringFromStreamingAssets("config.json");
                var animClips = LBoot.FileUtils.GetStringFromStreamingAssets("animClips.json");
                instance = LitJson.JsonMapper.ToObject<GameConfig>(text);
                instance.animClips = LitJson.JsonMapper.ToObject <Dictionary<string, double>>(animClips);
#if UNITY_EDITOR_OSX
            }
#endif
            return instance;
        }

        public Dictionary<string, Dictionary<string, AnimatorEntryConfig>> animators2;
        public Dictionary<string, Dictionary<string, bool>> animators_ms;

        public CommonConfig common;
        public Dictionary<string, double> animClips;

        public float getClipLength(string controllerName, string stateName)
        {
            Dictionary<string, AnimatorEntryConfig> config;
            string clipName = null;
            if (this.animators2.TryGetValue(controllerName, out config))
            {
                AnimatorEntryConfig value;
                if (config.TryGetValue(stateName, out value))
                {
                    clipName = value.clip;
                }
            }

            if (clipName != null)
            {
                double length = 0;
                animClips.TryGetValue(clipName, out length);
                return (float)length;
            }
            return 0f;
        }
    }


    public class ModelMountConfig
    {
        public string tid;
        public string skeleton;
        public List<MountConfig> mounts;
    }

    public class MountConfig
    {
        public string bone;
        public string assetId;
        public bool hide;
    }

    public class AnimatorEntryConfig
    {
        public string bone_id;
        public string res_id;
        public string state;
        public string clip;
    }

    public class CommonConfig
    {
        public double main_camera_y;
        public double main_camera_z;
        public double main_camera_high_y;
        public double main_camera_high_z;
        public double main_camera_max_y;
        public double main_camera_min_y;
        public double main_camera_rotate_speed;
        public double main_camera_sensitivity;
        public double main_camera_speed_horizon;
        public double main_camera_speed_vertical;
        public double main_camera_min_dist;
    }
}

