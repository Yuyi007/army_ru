using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AssetRule))]
public class AssetRuleInspector : Editor
{

    private AssetRule orig;

    [MenuItem("Assets/Auditing/Create Asset Auditing Rule")]
    public static void CreateAssetRule()
    {
        var newRule = CreateInstance<AssetRule>();
        newRule.ApplyDefaults();

        string selectionpath = "Assets";
        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            selectionpath = AssetDatabase.GetAssetPath(obj);
            if (File.Exists(selectionpath))
            {
                selectionpath = Path.GetDirectoryName(selectionpath);
            }
            break;
        }

        string newRuleFileName = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(selectionpath, "New Asset Rule.asset"));
        newRuleFileName = newRuleFileName.Replace("\\", "/");
        AssetDatabase.CreateAsset(newRule, newRuleFileName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newRule;
        changed = true;
    }

    // TODO: Custom inspector for asset rules
    public override void OnInspectorGUI()
    {
        var t = (AssetRule)target;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Asset Rule Type");

        t.filter.type = (AssetFilterType)EditorGUILayout.EnumPopup(t.filter.type);


        EditorGUILayout.EndHorizontal();

        if (EditorGUI.EndChangeCheck())
        {
            changed = true;
        }

        t.filter.path = EditorGUILayout.TextField("Path Filter", t.filter.path);

        switch (t.filter.type)
        {
            case AssetFilterType.kAny:
                DrawTextureSettings(t);
                DrawMeshSettings(t);
                break;

            case AssetFilterType.kMesh:
                DrawMeshSettings(t);
                break;

            case AssetFilterType.kTexture:
                DrawTextureSettings(t);
                break;
        }


        if (changed)
        {
//            if (GUILayout.Button("Apply"))
//                Apply(t);
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
        }
    }

    private void Apply(AssetRule assetRule)
    {

        // get the directories that we do not want to apply changes to
        List<string> dontapply = new List<string>();
        var assetrulepath = AssetDatabase.GetAssetPath(assetRule).Replace(assetRule.name + ".asset", "").TrimEnd('/');
        string projPath = Application.dataPath;
        projPath = projPath.Remove(projPath.Length - 6);

        string[] directories = Directory.GetDirectories(Path.GetDirectoryName(projPath + AssetDatabase.GetAssetPath(assetRule)), "*", SearchOption.AllDirectories);
        foreach (var directory in directories)
        {
            var d = directory.Replace(Application.dataPath, "Assets");
            var appDirs = AssetDatabase.FindAssets("t:AssetRule", new[] { d });
            if (appDirs.Length != 0)
            {
                d = d.TrimEnd('/');
                d = d.Replace('\\', '/');
                dontapply.Add(d);
            }
        }


        List<string> finalAssetList = new List<string>();
        foreach (var findAsset in AssetDatabase.FindAssets("", new[] {assetrulepath}))
        {
            var asset = AssetDatabase.GUIDToAssetPath(findAsset);
            if (!File.Exists(asset))
                continue;
            if (dontapply.Contains(Path.GetDirectoryName(asset)))
                continue;
            if (!assetRule.IsMatch(AssetImporter.GetAtPath(asset)))
                continue;
            if (finalAssetList.Contains(asset))
                continue;
            if (asset == AssetDatabase.GetAssetPath(assetRule))
                continue;
            finalAssetList.Add(asset);
        }

        int i = 1;
        foreach (var asset in finalAssetList)
        {
            AssetImporter.GetAtPath(asset).SaveAndReimport();
            i++;
        }

        changed = false;

    }

    private void DrawMeshSettings(AssetRule assetRule)
    {
        GUILayout.Space(20);
        GUILayout.Label("MESH SETTINGS ");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Change Readable Settings");
        assetRule.settings.meshSettings.changeReadableSettings = EditorGUILayout.Toggle(assetRule.settings.meshSettings.changeReadableSettings);
        EditorGUILayout.EndHorizontal();

        if (assetRule.settings.meshSettings.changeReadableSettings)
        {
            // read write enabled
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Read/Write Enabled");
            assetRule.settings.meshSettings.readWriteEnabled = EditorGUILayout.Toggle(assetRule.settings.meshSettings.readWriteEnabled);
            EditorGUILayout.EndHorizontal();
        }

        // optimise mesh
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Optimise Mesh");
        assetRule.settings.meshSettings.optimiseMesh = EditorGUILayout.Toggle(assetRule.settings.meshSettings.optimiseMesh);
        EditorGUILayout.EndHorizontal();

        // optimise mesh
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Blend Shapes");
        assetRule.settings.meshSettings.ImportBlendShapes = EditorGUILayout.Toggle(assetRule.settings.meshSettings.ImportBlendShapes);
        EditorGUILayout.EndHorizontal();

        // optimise mesh
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Import Materials");
        assetRule.settings.meshSettings.importMaterials = EditorGUILayout.Toggle(assetRule.settings.meshSettings.importMaterials);
        EditorGUILayout.EndHorizontal();

        // optimise mesh
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Import Nomals");
        assetRule.settings.meshSettings.normalImportMode = (ModelImporterNormals)EditorGUILayout.EnumPopup(assetRule.settings.meshSettings.normalImportMode);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Animation Type");
        assetRule.settings.meshSettings.animationType = (ModelImporterAnimationType)EditorGUILayout.EnumPopup(assetRule.settings.meshSettings.animationType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mesh Compression");
        assetRule.settings.meshSettings.meshCompression = (ModelImporterMeshCompression)EditorGUILayout.EnumPopup(assetRule.settings.meshSettings.meshCompression);
        EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Import Tangents");
		assetRule.settings.meshSettings.importTangents = (ModelImporterTangents)EditorGUILayout.EnumPopup(assetRule.settings.meshSettings.importTangents);
		EditorGUILayout.EndHorizontal();
    }

    private int[] sizes = new[] { 32, 64, 128, 256, 512, 1024, 2048, 4096 };
    private string[] sizeStrings = new[] { "32", "64", "128", "256", "512", "1024", "2048", "4096" };
    private static bool changed = false;

    private void DrawTextureSettings(AssetRule assetRule)
    {
        GUILayout.Space(20);
        GUILayout.Label(" TEXTURE SETTINGS ");
        GUILayout.Space(20);

        GetValidPlatforms();
        // mip maps
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Generate Mip Maps");
        assetRule.settings.textureSettings.mipmapEnabled = EditorGUILayout.Toggle(assetRule.settings.textureSettings.mipmapEnabled);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Change readable settings");
        assetRule.settings.changeReadableSetting = EditorGUILayout.Toggle(assetRule.settings.changeReadableSetting);
        EditorGUILayout.EndHorizontal();

        //read write enabled
        if (assetRule.settings.changeReadableSetting)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Read/Write Enabled");
            assetRule.settings.textureSettings.readable = EditorGUILayout.Toggle(assetRule.settings.textureSettings.readable);
            EditorGUILayout.EndHorizontal();
        }

        //lightmap
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Lightmap");
        assetRule.settings.textureSettings.lightmap = EditorGUILayout.Toggle(assetRule.settings.textureSettings.lightmap);
        EditorGUILayout.EndHorizontal();

        // per platform settings
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Max Texture Size");
        assetRule.settings.textureSettings.maxTextureSize =
        EditorGUILayout.IntPopup(assetRule.settings.textureSettings.maxTextureSize, sizeStrings, sizes);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Change Texture Format");
        assetRule.settings.enableCompressSetting = EditorGUILayout.Toggle(assetRule.settings.enableCompressSetting);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Texture SpriteMode");
        var mode = (SpriteImportMode)EditorGUILayout.EnumPopup((SpriteImportMode)assetRule.settings.textureSettings.spriteMode);
        assetRule.settings.textureSettings.spriteMode = (int)mode;
        EditorGUILayout.EndHorizontal();

        // per platform settings
        if (assetRule.settings.enableCompressSetting)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Texture Format");
            assetRule.settings.textureSettings.textureFormat =
                (TextureImporterFormat)EditorGUILayout.EnumPopup(assetRule.settings.textureSettings.textureFormat);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Compression Quality");
            assetRule.settings.textureSettings.compressionQuality = (int)EditorGUILayout.Slider(assetRule.settings.textureSettings.compressionQuality, 0f, 100f);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Override iOS Format");
        assetRule.settings.overrideIos = EditorGUILayout.Toggle(assetRule.settings.overrideIos);
        EditorGUILayout.EndHorizontal();

        if (assetRule.settings.overrideIos)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("iOS Texture Format");
            assetRule.settings.iosTextureFormat =
                (TextureImporterFormat)EditorGUILayout.EnumPopup(assetRule.settings.iosTextureFormat);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Override Android Format");
        assetRule.settings.overrideAndroid = EditorGUILayout.Toggle(assetRule.settings.overrideAndroid);
        EditorGUILayout.EndHorizontal();

        if (assetRule.settings.overrideAndroid)
        {
//            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField("Alpha Split");
//            assetRule.settings.textureSettings.allowsAlphaSplit = EditorGUILayout.Toggle(assetRule.settings.textureSettings.allowsAlphaSplit);
//            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Android Texture Format");
            assetRule.settings.androidTextureFormat =
                (TextureImporterFormat)EditorGUILayout.EnumPopup(assetRule.settings.androidTextureFormat);
            EditorGUILayout.EndHorizontal();
        }
    }

    private void GetValidPlatforms()
    {

    }

    void OnEnable()
    {
        changed = false;
        orig = (AssetRule)target;
        Undo.RecordObject(target, "assetruleundo");
    }

    void OnDisable()
    {
        if (changed)
        {
            EditorUtility.SetDirty(target);
            if (EditorUtility.DisplayDialog("Unsaved Settings", "Unsaved AssetRule Changes", "Apply", "Revert"))
            {
                // Apply((AssetRule)target);
            }
            else
            {
                Undo.PerformUndo();
                //SerializedObject so = new SerializedObject(target);
                //so.SetIsDifferentCacheDirty();
                //so.Update();
            }

        }
        changed = false;


    }
}