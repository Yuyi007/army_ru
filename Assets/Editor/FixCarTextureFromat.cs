using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CarTextureFromatFixer {

    /// <summary>
    /// Fixs the car selection material.
    /// </summary>
    [MenuItem("Assets/FixImgs/FixCarSelectionMats")]
    static void FixCarSelectionMaterial()
    {
        string[] folders = { "Assets/Models" }; 
        string[] guids = AssetDatabase.FindAssets("t:Material", folders);
        foreach(string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
           
            if (mat == null) continue;

            Shader shader = mat.shader;
            if (shader.name == "GameCar/CarSelection") 
            {
                FixCarMaterialSelectionMainTex(mat);
                FixCarMaterialSelectionMetalTex(mat);
                FixCarMaterialSelectionNormal(mat);
                Debug.Log("Fixed:" + path);
            }
        }
    }

    static void FixCarMaterialSelectionNormal(Material mat)
    {
        Texture tex = mat.GetTexture("_NormalTex");
        string path = AssetDatabase.GetAssetPath(tex);
        Debug.Log("Begin " + mat.name + " Normal texture:" + path);

        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Default;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = false;
        ti.alphaSource = TextureImporterAlphaSource.None;
        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 1024;
        setIos.format = TextureImporterFormat.PVRTC_RGB4;
        setIos.textureCompression = TextureImporterCompression.CompressedHQ;
        setIos.compressionQuality = 80;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 1024;
        setAnd.format = TextureImporterFormat.ETC_RGB4;
        setAnd.textureCompression = TextureImporterCompression.CompressedHQ;
        setAnd.compressionQuality = 80;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    static void FixCarMaterialSelectionMetalTex(Material mat)
    {
        Texture tex = mat.GetTexture("_MetallicTex");
        string path = AssetDatabase.GetAssetPath(tex);
        Debug.Log("Begin " + mat.name + " Metallic texture:" + path);

        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Default;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = false;
        ti.alphaSource = TextureImporterAlphaSource.None;
        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 512;
        setIos.format = TextureImporterFormat.Alpha8;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell; 
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 512;
        setAnd.format = TextureImporterFormat.Alpha8;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    static void FixCarMaterialSelectionMainTex(Material mat)
    {
        Texture tex = mat.GetTexture("_MainTex");
        string path = AssetDatabase.GetAssetPath(tex);
        Debug.Log("Begin "+ mat.name +" MainTex:" + path);

        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;
        
        ti.textureType = TextureImporterType.Default;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.mipmapEnabled = false; //Disable mip map
        ti.isReadable = false;
        ti.alphaSource = TextureImporterAlphaSource.FromInput; //Alpha channel used as manual smoothness
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 1024;
        setIos.format = TextureImporterFormat.PVRTC_RGBA4;
        setIos.textureCompression = TextureImporterCompression.CompressedHQ;
        setIos.compressionQuality = 80;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell; //Mitchell is better than bilinear
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 1024;
        setAnd.format = TextureImporterFormat.ETC2_RGBA8Crunched;
        setAnd.textureCompression = TextureImporterCompression.CompressedHQ;
        setAnd.compressionQuality = 80;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();

    }

    /// <summary>
    /// Fixs the car combat material.
    /// </summary>
    [MenuItem("Assets/FixImgs/FixCarCombatMats")]
    static void FixCarCombatMaterial()
    {
        string[] folders = { "Assets/Models" };
        string[] guids = AssetDatabase.FindAssets("t:Material", folders);
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat == null) continue;

            Shader shader = mat.shader;
            if (shader.name == "GameCar/CarCombat")
            {
                FixCarMaterialCombatMainTex(mat);
                FixCarMaterialCombatMetalTex(mat);
                Debug.Log("Fixed:" + path);
            }
        }
    }

    static void FixCarMaterialCombatMainTex(Material mat)
    {
        Texture tex = mat.GetTexture("_MainTex");
        string path = AssetDatabase.GetAssetPath(tex);
        Debug.Log("Begin " + mat.name + " MainTex:" + path);

        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Default;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.mipmapEnabled = false; //Disable mip map
        ti.isReadable = false;
        ti.alphaSource = TextureImporterAlphaSource.FromInput; //Alpha channel used as manual smoothness
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 256;
        setIos.format = TextureImporterFormat.PVRTC_RGBA4;
        setIos.textureCompression = TextureImporterCompression.Compressed;
        setIos.compressionQuality = 60;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Bilinear; 
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 256;
        setAnd.format = TextureImporterFormat.ETC2_RGBA8Crunched;
        setAnd.textureCompression = TextureImporterCompression.Compressed;
        setAnd.compressionQuality = 60;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Bilinear;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    static void FixCarMaterialCombatMetalTex(Material mat)
    {
        Texture tex = mat.GetTexture("_MetallicTex");
        string path = AssetDatabase.GetAssetPath(tex);
        Debug.Log("Begin " + mat.name + " Metallic texture:" + path);

        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Default;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = false;
        ti.alphaSource = TextureImporterAlphaSource.None;
        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 128;
        setIos.format = TextureImporterFormat.Alpha8;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Bilinear;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 128;
        setAnd.format = TextureImporterFormat.Alpha8;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Bilinear;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    /// <summary>
    /// Fixs the sprite sheets.
    /// </summary>
    [MenuItem("Assets/FixImgs/FixAllSpriteSheets")]
    static void FixSpriteSheets()
    {
        string[] folders = { "Assets/Images" };
        string[] guids = AssetDatabase.FindAssets("t:texture2D", folders);
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Debug.Log(path);
            if(path.Contains("ui/9symbol"))
            {
                Fix9SymbolSheets(path);
                continue;
            }

            if(path.Contains("ui/bgs"))
            {
                FixBackgroundSheets(path);
                continue;
            }

            if (path.Contains("ui/icon"))
            {
                FixIconSheets(path);
                continue;
            }

            if (path.Contains("ui/pic"))
            {
                FixPictureSheets(path);
                continue;
            }
        }
    }

    [MenuItem("Assets/FixImgs/FixBgSheets")]
    static void FixBgsSheets()
    {
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            if (path.Contains("ui/bgs"))
            {
                FixBackgroundSheets(path); 
            }
        }
    }

    [MenuItem("Assets/FixImgs/Fix9SymbolSheets")]
    static void Fix9SymbolSheets()
    {
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            if (path.Contains("ui/9symbol"))
            {
                Fix9SymbolSheets(path);
            }
        }
    }

    [MenuItem("Assets/FixImgs/FixIconSheets")]
    static void FixIconSheets()
    {
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            if (path.Contains("ui/icon"))
            {
                FixIconSheets(path);
            }
        }
    }

    [MenuItem("Assets/FixImgs/FixPicSheets")]
    static void FixPicSheets()
    {
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            if (path.Contains("ui/pic"))
            {
                FixPictureSheets(path);
            }
        }
    }


    static void Fix9SymbolSheets(string path)
    {
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Sprite;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.alphaSource = TextureImporterAlphaSource.FromInput;

        ti.spriteImportMode = SpriteImportMode.Multiple;
        ti.spritePixelsPerUnit = 100;
        ti.alphaIsTransparency = true;

        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 2048;
        setIos.format = TextureImporterFormat.RGBA32;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 2048;
        setAnd.format = TextureImporterFormat.RGBA32;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    static void FixBackgroundSheets(string path)
    {
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Sprite;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.alphaSource = TextureImporterAlphaSource.None;

        ti.spriteImportMode = SpriteImportMode.Multiple;
        ti.spritePixelsPerUnit = 100;
        ti.alphaIsTransparency = false;

        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 2048;
        setIos.format = TextureImporterFormat.PVRTC_RGB4;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setIos.textureCompression = TextureImporterCompression.Compressed;
        setIos.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 2048;
        setAnd.format = TextureImporterFormat.ETC2_RGB4;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setAnd.textureCompression = TextureImporterCompression.Compressed;
        setAnd.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

    static void FixIconSheets(string path)
    {
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Sprite;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.alphaSource = TextureImporterAlphaSource.FromInput;

        ti.spriteImportMode = SpriteImportMode.Multiple;
        ti.spritePixelsPerUnit = 100;
        ti.alphaIsTransparency = true;

        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 1024;
        setIos.format = TextureImporterFormat.PVRTC_RGBA4;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setIos.textureCompression = TextureImporterCompression.Compressed;
        setIos.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 1024;
        setAnd.format = TextureImporterFormat.ETC2_RGBA8;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setAnd.textureCompression = TextureImporterCompression.Compressed;
        setAnd.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setAnd);
        try{
            ti.SaveAndReimport();
        }catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    static void FixPictureSheets(string path)
    {
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null)
            return;

        ti.textureType = TextureImporterType.Sprite;
        ti.textureShape = TextureImporterShape.Texture2D;
        ti.sRGBTexture = true;
        ti.alphaSource = TextureImporterAlphaSource.FromInput;

        ti.spriteImportMode = SpriteImportMode.Multiple;
        ti.spritePixelsPerUnit = 100;
        ti.alphaIsTransparency = true;

        ti.mipmapEnabled = false;
        ti.isReadable = false;
        ti.wrapMode = TextureWrapMode.Repeat;
        ti.filterMode = FilterMode.Bilinear;

        TextureImporterPlatformSettings setIos = ti.GetPlatformTextureSettings("iPhone");
        setIos.overridden = true;
        setIos.maxTextureSize = 2048;
        setIos.format = TextureImporterFormat.PVRTC_RGB4;
        setIos.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setIos.textureCompression = TextureImporterCompression.Compressed;
        setIos.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setIos);

        TextureImporterPlatformSettings setAnd = ti.GetPlatformTextureSettings("Android");
        setAnd.overridden = true;
        setAnd.maxTextureSize = 2048;
        setAnd.format = TextureImporterFormat.ETC2_RGB4;
        setAnd.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        setAnd.textureCompression = TextureImporterCompression.Compressed;
        setAnd.compressionQuality = 70;
        ti.SetPlatformTextureSettings(setAnd);

        ti.SaveAndReimport();
    }

}
