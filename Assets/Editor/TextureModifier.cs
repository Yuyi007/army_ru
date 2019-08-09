using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

class TextureModifier
{
    // Chooses a proper compression format.
    static TextureFormat CompressionFormat
    {
        get
        {
            switch (EditorUserBuildSettings.activeBuildTarget)
            {
                case BuildTarget.Android:
                    return TextureFormat.ETC_RGB4;
                case BuildTarget.iOS:
                    return TextureFormat.PVRTC_RGB4;
                default:
                    return TextureFormat.DXT1;
            }
        }
    }

    void OnPreprocessTexture()
    {
//        var importer = (assetImporter as TextureImporter);
//
//        importer.textureType = TextureImporterType.GUI;
//
//        if (assetPath.EndsWith (suffix)) {
//            importer.textureFormat = TextureImporterFormat.RGBA32;
//        }
    }

    static void CreateAlphaMaskForTexture()
    {
        var texture = Selection.activeObject as Texture2D;
        if (texture != null)
        {
            var path = AssetDatabase.GetAssetPath(texture);
            if (path.Contains("images"))
            {
                CreateAlphaMask(texture);
            }
        }
    }

    static void CreateAlphaMask(Texture2D texture)
    {
        var assetPath = AssetDatabase.GetAssetPath(texture);

        var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        textureImporter.isReadable = true;


        EditorUtility.CompressTexture(texture, TextureFormat.ARGB32, TextureCompressionQuality.Best);

        // Make a mask texture temporary in true color.
        var mask = new Texture2D(texture.width, texture.height, TextureFormat.RGB24, false);
        mask.wrapMode = TextureWrapMode.Clamp;

        // Convert the source image into a mask.
        var pixels = texture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            var a = pixels[i].a;
            pixels[i] = new Color(a, a, a);
        }
        mask.SetPixels(pixels);


        // Compress the mask in the proper compression format.
        var filename = Path.GetFileNameWithoutExtension(assetPath);

        // Replace the asset which already exists, or create a new asset.
        var maskPath = assetPath.Replace(filename + ".png", filename + "_mask.asset");
        var maskAsset = AssetDatabase.LoadAssetAtPath(maskPath, typeof(Texture2D)) as Texture2D;

        if (maskAsset == null)
        {
            AssetDatabase.CreateAsset(mask, maskPath);
        }
        else
        {
            EditorUtility.CopySerialized(mask, maskAsset);
        }


        var maskImporter = TextureImporter.GetAtPath(maskPath) as TextureImporter;

        if (maskImporter != null)
            maskImporter.textureFormat = TextureImporterFormat.AutomaticCompressed;

        TextureImporterFormat format;
        int max;
        textureImporter.GetPlatformTextureSettings("iPhone", out max, out format);
        textureImporter.SetPlatformTextureSettings("iPhone", max, TextureImporterFormat.PVRTC_RGB4, 50, false);

        textureImporter.GetPlatformTextureSettings("Android", out max, out format);
        textureImporter.SetPlatformTextureSettings("Android", max, TextureImporterFormat.ETC_RGB4, 50, false);
        textureImporter.isReadable = false;
    }
}