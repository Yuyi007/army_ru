using System;
using UnityEngine;

using System.Collections.Generic;
using System.Collections;
using LitJson;

namespace LBoot
{
    public class BundleConfig
    {
        private static BundleConfig instance;

        public static BundleConfig Get()
        {
            if (instance == null)
            {
#if UNITY_EDITOR || UNITY_IOS
                var text = LBoot.FileUtils.GetStringFromFile("bundles_ios.json");
#else
                var text = LBoot.FileUtils.GetStringFromFile("bundles_android.json");
#endif 
                instance = LitJson.JsonMapper.ToObject<BundleConfig>(text);
                instance.sprites = LitJson.JsonMapper.ToObject<Dictionary<string, string>>(LBoot.FileUtils.GetStringFromFile("sprites.json"));
            }
            return instance;
        }

        public static void Reset()
        {
            BundleConfig.instance = null;
        }

        public Sprite GetSprite(string spriteName)
        {
            string assetPath = null;
            sprites.TryGetValue(spriteName, out assetPath);
            if (assetPath == null)
                return null;

            assetPath = "assets/" + assetPath + ".asset";
            assetPath = assetPath.ToLower();
            SpriteAsset spriteAsset = null;
#if UNITY_EDITOR
            spriteAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<SpriteAsset>(assetPath);
#else

            string bundlePath = null;

            images.TryGetValue(assetPath, out bundlePath);

            if (bundlePath != null) {
                var assetBundle = BundleHelper.Load(bundlePath, -1);
                if (assetBundle != null) {
                spriteAsset = assetBundle.LoadAsset<SpriteAsset>(assetPath);
                }
            }
#endif
            if (spriteAsset != null)
            {
                
                return spriteAsset.GetSprite(spriteName);
            } 

            return null;
        }

        public Material GetMaterial(string spriteName)
        {
            string assetPath = null;
            sprites.TryGetValue(spriteName, out assetPath);
            if (assetPath == null)
                return null;
            
            assetPath = assetPath.Replace("Images", "Images_Mask");
            assetPath = "assets/" + assetPath + ".mat";
            assetPath = assetPath.ToLower();
            Material material = null;
#if UNITY_EDITOR
            material = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>(assetPath);
#else

            string bundlePath = null;

            materials.TryGetValue(assetPath, out bundlePath);

            if (bundlePath != null)
            {
                var assetBundle = BundleHelper.Load(bundlePath, -1);
                if (assetBundle != null)
                {
                    material = assetBundle.LoadAsset<Material>(assetPath);
                }
            }
#endif
           

            return material;
        }

        public Cubemap GetWaterCubemap(string cubemapPath)
        {
            string bundlePath = null;
            water_cubemaps.TryGetValue(cubemapPath, out bundlePath);
            Cubemap cubemap = null;
            if (bundlePath != null)
            {
                var assetBundle = BundleHelper.Load(bundlePath, -1);
                if (assetBundle != null)
                {
                    cubemap = assetBundle.LoadAsset<Cubemap>(cubemapPath);

                }
            }
            return cubemap;    
        }

        public Dictionary<string, string> sprites;
        public Dictionary<string, string> images;
        public Dictionary<string, string> materials;
        public Dictionary<string, string> water_cubemaps;

    }

}

