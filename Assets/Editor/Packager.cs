using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System;
using LBoot;
using System.Linq;
using LitJson;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class Packager
{
    [MenuItem("Assets/Make Assetbundles/IOS")]
    static void MakeBundlesIOS()
    {
        FI.TargetPlatform = "ios";
        MakeBundles();
    }


    [MenuItem("Assets/Make Assetbundles/Android")]
    static void MakeBundlesAndroid()
    {
        FI.TargetPlatform = "android";
        MakeBundles();
    }

    [MenuItem("Assets/Make Assetbundles/OSX")]
    static void MakeBundlesOSX()
    {
        FI.TargetPlatform = "osx";
        MakeBundles();
    }


    [MenuItem("Assets/Make Assetbundles/All")]
    static void MakeBundlesAll()
    {
        MakeBundlesIOS();
        MakeBundlesAndroid();
        MakeBundlesOSX();
    }

    [MenuItem("Assets/Copy AssetBundles")]
    static void CopyAssetsToProject()
    {
		FI.TargetPlatform = "android";
		FI.copyToProject();

        FI.TargetPlatform = "ios";
        FI.copyToProject();
    }

    public static void MakeBundles()
    {
        MakeBundlesWithPath(FI.BuildPath, FI.TargetPlatform);
        CopyAssetsToProject();
    }

    public static bool MakeBundlesCmdWithBootsrap()
    {
        return MakeBundlesCmd();
    }


    public static bool MakeBundlesCmd()
    {
        try
        {
            var args = Environment.GetCommandLineArgs();
            var buildPath = args[args.Length - 3];
            var targetPlatform = args[args.Length - 2];
            MakeBundlesWithPath(buildPath, targetPlatform);
            return true;
        }
        catch (Exception e)
        {
            LogUtil.Error(e.ToString());
            return false;
        }
    }

    public static bool MakeEmpty()
    {
        // Just for recompilation of scripts on jenkins, do nothing
        return true;
    }

    [MenuItem("Assets/ClearAssetBundleScene")]
    public static void ClearAssetBundleScene()
    {
        var files = Directory.GetFiles("Assets/Scenes/test/", "*.unity", SearchOption.AllDirectories).ToList();
        foreach (var file in files)
        {
            var ip = GetImporter(file);
            ip.assetBundleName = null;
        }
    }

    private static string GetBundleName(string file)
    {
        var path = String.Join("/", file.Split('/').ToList().Skip(1).ToArray());
        var folder = Path.GetDirectoryName(path);
        var name = Path.GetFileNameWithoutExtension(path);
        var bundle = folder + "/" + name;
        return bundle;
    }

    private static string GetFolderPath(string file)
    {
        var path = file;
        var folder = Path.GetDirectoryName(path);
        return folder;
    }

	private static string GetDirLastFolder(string dir)
	{
		var path = dir.Split ('/').ToList ().ToArray();
		return path[path.Length-1];
	}

    private static void AssignFolderBundle(string dir)
    {
        if (!Directory.Exists(dir))
            return;

        var files = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
        foreach (var folder in files)
        {
            var folderAsset = GetImporter(folder);
            folderAsset.assetBundleName = GetBundleName(folder) + FI.AssetBundleExtension;
        }
    }

    private static void AssignImageAssetsBundles(string dir)
    {
        if (!Directory.Exists(dir))
            return;
	
		foreach (var file  in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
        {
			if (file.EndsWith(".DS_Store"))
				continue;
			if (file.EndsWith(".meta"))
                continue;
			if (file.EndsWith(".tpsheet"))
                continue;
			var ip = GetImporter(file);
            if (ip != null)
				ip.assetBundleName = GetBundleName(file) + FI.AssetBundleExtension;
        }
    }

    private static void AssignFolderNameAsBundle(string dir, string bundleName = null)
    {
        if (bundleName == null)
            bundleName = GetBundleName(dir) + FI.AssetBundleExtension;

        if (bundleName == "null")
            bundleName = null;

        var fi = GetImporter(dir);
        fi.assetBundleName = bundleName;
    }

    private static void AssignBundleWithoutFBX(string dir)
    {
        var files = Directory.GetFiles(dir, "*.tga", SearchOption.AllDirectories).ToList();
        files.AddRange(Directory.GetFiles(dir, "*.mat", SearchOption.AllDirectories));
        files.AddRange(Directory.GetFiles(dir, "*.asset", SearchOption.AllDirectories));

        foreach (var f in files)
        {
            if (f.EndsWith(".meta") || f.EndsWith(".DS_Store"))
                continue;
            var m = GetImporter(f);
            if (m != null)
            {
				//string path = String.Join("/", f.Split('/').ToList().Skip(1).ToArray());
				m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }
    }

    private static void AssignMatBundle(string dir)
    {
        var dirs = Directory.GetDirectories(dir);
        foreach (var d in dirs)
        {
            AssignBundleWithoutFBX(d);
        }
    }


    [MenuItem("Assets/Clear effect bundles")]
    public static void ClearEffectBundles()
    {
        var files = Directory.GetFiles("Assets/Particles/effects/", "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var ip = GetImporter(file);
            if (ip != null)
            {
                ip.assetBundleName = null;
            }
        }
    }


    private static void ClearFolderBundle(string dir)
    {
        var files = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
        foreach (var folder in files)
        {
            var subFiles = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            foreach (var f in subFiles)
            {
                if (f.EndsWith(".meta"))
                    continue;
				if (f.EndsWith(".DS_Store"))
					continue;
                var m = GetImporter(f);
                if (m != null)
                {
                    m.assetBundleName = null;
                }
            }
        }
    }


    private static void AssignModelMatBundle(string dir)
    {
        var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Where(x => x.EndsWith("*.fbx", StringComparison.OrdinalIgnoreCase));
        foreach (var file in files)
        {
            var filename = Path.GetFileNameWithoutExtension(file);
            var folder = GetFolderPath(file);
            var mats = Directory.GetFiles(folder, "*.mat", SearchOption.AllDirectories);
            foreach (var f in mats)
            {
                var f1 = Path.GetFileNameWithoutExtension(f);
                if (f1 == filename)
                {
                    var m = GetImporter(f);
                    if (m != null)
                    {
                        m.assetBundleName = GetBundleName(file) + FI.AssetBundleExtension;
                    }
                }
            }

            var textures = Directory.GetFiles(folder, "*.tga", SearchOption.AllDirectories);
            foreach (var f in textures)
            {
                var f1 = Path.GetFileNameWithoutExtension(f);
                if (f1 == filename)
                {
                    var m = GetImporter(f);
                    if (m != null)
                    {
                        m.assetBundleName = GetBundleName(file) + FI.AssetBundleExtension;
                    }
                }
            }

            textures = Directory.GetFiles(folder, "*.png", SearchOption.AllDirectories);
            foreach (var f in textures)
            {
                var f1 = Path.GetFileNameWithoutExtension(f);
                if (f1 == filename)
                {
                    var m = GetImporter(f);
                    if (m != null)
                    {
                        m.assetBundleName = GetBundleName(file) + FI.AssetBundleExtension;
                    }
                }
            }
        }
    }


    public static void BootstrapCombatParticles()
    {
        FVParticleUtils.FixParticleSystemShaders();
    }

    public static void BootstrapSpriteAssets()
    {
        CreateSpriteAssets();
    }


    [MenuItem("Assets/Fix Effect Textures")]
    public static void FixEffectTextures()
    {
        var files = Directory.GetFiles("Assets/Particles/effects/", "*.png", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var importer = GetImporter(file) as TextureImporter;
            if (importer.textureFormat != TextureImporterFormat.AutomaticCompressed)
            {
                importer.textureFormat = TextureImporterFormat.AutomaticCompressed;
                AssetDatabase.SaveAssets();
                AssetDatabase.ImportAsset(file);
            }
        }
    }

    [MenuItem("Assets/FindPhysicComponents")]
    public static void FindPhysicComponents()
    {
        List<string> names = new List<string>();
        GameObject[] gos = Selection.gameObjects;
        foreach(GameObject go in gos){
            Debug.Log("============Find BoxCollider =============");
            BoxCollider [] bs = go.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider b in bs){
                names.Add(b.gameObject.name);
                Debug.Log(b.gameObject.name);
            }

            Debug.Log("============Find MeshCollider =============");
            MeshCollider[] ms = go.GetComponentsInChildren<MeshCollider>();
            foreach (MeshCollider b in ms)
            {
                names.Add(b.gameObject.name);
                Debug.Log(b.gameObject.name);
            }

            Debug.Log("============Find Rigidbody =============");
            Rigidbody[] rs = go.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody b in rs)
            {
                names.Add(b.gameObject.name);
                Debug.Log(b.gameObject.name);
            }

            Debug.Log("============Find SphereCollider =============");
            SphereCollider[] ss = go.GetComponentsInChildren<SphereCollider>();
            foreach (SphereCollider b in ss)
            {
                names.Add(b.gameObject.name);
                Debug.Log(b.gameObject.name);
            }

            Debug.Log("============Find TerrainCollider =============");
            TerrainCollider[] ts = go.GetComponentsInChildren<TerrainCollider>();
            foreach (TerrainCollider b in ts)
            {
                names.Add(b.gameObject.name);
                Debug.Log(b.gameObject.name);
            }
            Debug.Log("============End =============");
        }
    }

    public static string[] FindEffectDependencies()
    {
        var files = Directory.GetFiles("Assets/Prefab/", "*.prefab", SearchOption.AllDirectories).ToList();
        files.AddRange(Directory.GetFiles("Assets/Scenes/game/streets/", "*.unity", SearchOption.AllDirectories));


        files = files.Select(x => x.Replace("\\", "/")).ToList();

        var depends = AssetDatabase.GetDependencies(files.ToArray());
        depends = depends.Select(x => x.Replace("\\", "/")).ToArray();
        var list = new List<string>();
        foreach (var file in depends)
        {
            if (file.Contains("Assets/Particles/effects"))
            {
                list.Add(file);
            }
        }
        return list.ToArray();
    }


    public static string[] FindSceneDependencies()
    {
        var files = Directory.GetFiles("Assets/Scenes/game/", "*.unity", SearchOption.AllDirectories).ToList();

        files = files.Select(x => x.Replace("\\", "/")).ToList();

        var depends = AssetDatabase.GetDependencies(files.ToArray());
        depends = depends.Select(x => x.Replace("\\", "/")).ToArray();
        var list = new List<string>();
        foreach (var file in depends)
        {
            if (file.Contains("Assets/Models/Scenes/"))
            {
                list.Add(file);
            }
        }
        return list.ToArray();
    }

    [MenuItem("Tools/Find unused scene assets")]
    public static void FindUnusedSceneAssets()
    {
        var files = Directory.GetFiles("Assets/Models/Scenes/", "*.*", SearchOption.AllDirectories);
        files = files.Select(x => x.Replace("\\", "/")).ToArray();
        var depends = FindSceneDependencies();
        var list = new List<string>();
        foreach (var file in files)
        {
            if (file.EndsWith(".meta"))
                continue;

            if (file.EndsWith(".DS_Store"))
                continue;


            if (!depends.Contains(file))
            {
                list.Add(file);
            }
        }

        File.WriteAllText("UnusedSceneAssets.txt", "unused scene asset files (total " + list.Count.ToString() + ")\n" + string.Join("\n", list.ToArray()));
    }

    [MenuItem("Tools/Find unused effect assets")]
    public static void FindUnusedEffectAssets()
    {
        var files = Directory.GetFiles("Assets/Particles/effects/", "*.*", SearchOption.AllDirectories);
        files = files.Select(x => x.Replace("\\", "/")).ToArray();
        var depends = FindEffectDependencies();
        var list = new List<string>();
        foreach (var file in files)
        {
            if (file.EndsWith(".meta"))
                continue;

            if (file.EndsWith(".DS_Store"))
                continue;


            if (!depends.Contains(file))
            {
                list.Add(file);
            }
        }

        LogUtil.Debug("unused effect asset files (total " + list.Count.ToString() + ")\n" + string.Join("\n", list.ToArray()));
    }

    public static void CreateSpriteAssets()
    {
        LBootEditor.AssetHelper.CreateSpriteAssets();
    }

    private static void SetBundleName(AssetImporter importer, string assetbundleName)
    {
        if (importer == null)
            return;

        if (importer.assetPath.Contains("ImportSetting"))
            importer.assetBundleName = null;
        else
            importer.assetBundleName = assetbundleName;
    }

    [MenuItem("Assets/Assign Model Entity")]
    private static void AssignEntityModelBundle()
    {
        string dir = "Assets/Models/Entity";

        var tds = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
        foreach (var td in tds)
        {
            var stds = Directory.GetDirectories(td, "*", SearchOption.TopDirectoryOnly);
            foreach (var std in stds)
            {
                AssignBundleByFolder(std);
            }
        }

        //水贴
        // dir = "Assets/Paint";
        // var subFolders = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
        // foreach (var folder in subFolders)
        // {
        //     AssignBundleByFile(folder);
        // }
    }

    private static void AssignBundleByFile(string folder)
    {
        var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
        foreach (var f in files)
        {
            string lf = f.ToLower();
            string name = GetBundleName(lf);
            if (f.EndsWith(".meta") || f.EndsWith(".DS_Store"))
                continue;
            var m = GetImporter(f);
            if (m != null)
            {
                m.assetBundleName = name + FI.AssetBundleExtension;
            }
        } 
    }

    private static void AssignBundleByFolder(string folder)
    {
        var name = GetBundleName(folder);
        var allFiles = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
        foreach (var f in allFiles)
        {
            if (f.EndsWith(".meta") || f.EndsWith(".DS_Store"))
                continue;

            var m = GetImporter(f);
            if (m != null)
            {
                m.assetBundleName = name + FI.AssetBundleExtension;
            }
        }
    }
    [MenuItem("Tools/Assets/Assign SceneModelBundle")]
	private static void AssignSceneModelBundle ()
	{
		string dir = "Assets/Models/Scenes";
        var subScenes = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);

        foreach (var sceneDir in subScenes)
        {
            string sceneName = Path.GetDirectoryName(sceneDir);
            var folders = Directory.GetDirectories(sceneDir, "*", SearchOption.TopDirectoryOnly);
            foreach (var folder in folders)
            {
                string lfolder = folder.ToLower();
                Debug.Log(lfolder);
                //use top folder name as bundle name
                if (lfolder.EndsWith("ani") ||
                    lfolder.EndsWith("brush") ||
                    lfolder.EndsWith("shader") ||
                    lfolder.EndsWith("prefab"))
                {
                    AssignBundleByFolder(folder);
                }
                //use sub folder name as bundle name
                else if (lfolder.EndsWith("materials") ||
                        lfolder.EndsWith("mod") ||
                        lfolder.EndsWith("texture"))
                {
                    var _subDirs = Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly);
                    foreach (var _folder in _subDirs)
                    {
                        AssignBundleByFolder(_folder);
                    }
                }
            }
        }

		//var files = Directory.GetFiles (dir, "*.FBX", SearchOption.AllDirectories);
		//foreach (var file in files) 
		//{
		//	//fbx
		//	var pi = GetImporter (file);
		//	string folder = GetFolderPath (file);
		//	string name = GetBundleName (folder);
		//	SetBundleName (pi, name + FI.AssetBundleExtension);

		//	//assign bundle with folder
		//	var subDirs = Directory.GetDirectories (folder, "*", SearchOption.AllDirectories);
		//	foreach(var subDir in subDirs)
		//	{
		//		var matFiles = Directory.GetFiles(subDir, "*.tga", SearchOption.AllDirectories).ToList();
		//		matFiles.AddRange(Directory.GetFiles(subDir, "*.mat", SearchOption.AllDirectories));
		//		matFiles.AddRange(Directory.GetFiles(subDir, "*.asset", SearchOption.AllDirectories));
		//		matFiles.AddRange(Directory.GetFiles(subDir, "*.bmp", SearchOption.AllDirectories));
		//		matFiles.AddRange(Directory.GetFiles(subDir, "*.png", SearchOption.AllDirectories));
		//		string subName = GetBundleName(file);
		//		foreach (var f in matFiles)
		//		{
		//			if (f.EndsWith(".meta"))
		//				continue;
		//			var m = GetImporter(f);
		//			if (m != null)
		//			{
		//				m.assetBundleName = subName + FI.AssetBundleExtension;
		//			}
		//		}
		//	}
		//}
	}

    [MenuItem("Assets/Assign Bundles")]
    public static void AssignAssetBundles()
    {
        ClearAssetBundleScene();
        IEnumerable<string> files = null;
		AssignImageAssetsBundles("Assets/Images");
		AssignImageAssetsBundles("Assets/Images_Mask");

		AssignEntityModelBundle ();
		// AssignSceneModelBundle ();
	

		//prefabs
        var prefabFiles = Directory.GetFiles ("Assets/Prefab", "*.prefab", SearchOption.AllDirectories);
        foreach (var prefab in prefabFiles) 
		{
            var m = GetImporter(prefab);
            if (m != null)
            {
                var bundleName = GetBundleName(prefab);
                m.assetBundleName = bundleName + FI.AssetBundleExtension;
            }
		}
    
        var ip = GetImporter("Assets/Animator");
        ip.assetBundleName = null;

		//animators
		var subFolders = new List<string>();
		subFolders.Add ("Assets/Animator/ui_animator");
		subFolders.Add ("Assets/Animator/entity_animator");
		foreach (var folder in subFolders)
		{
			var dirs = Directory.GetDirectories (folder, "*", SearchOption.TopDirectoryOnly);
			foreach (var dir in dirs) 
			{
				AssignFolderNameAsBundle (dir);
				var ctrlerFiles = Directory.GetFiles (dir, "*.controller", SearchOption.AllDirectories).ToList ();
				foreach (var ctrler in ctrlerFiles) 
				{
					var m = GetImporter (ctrler);
					if (m != null) 
					{
						var bundleName = GetBundleName (dir);
						Debug.Log ("Gen animator file:"+ctrler+" bundleName:"+bundleName);
						SetBundleName (m,  bundleName+ FI.AssetBundleExtension);
					}
				}

				var animFiles = Directory.GetFiles (dir, "*.anim", SearchOption.AllDirectories).ToList ();
				foreach (var anim in animFiles) 
				{
					var m = GetImporter (anim);
					if (m != null) 
					{
						var bundleName = GetBundleName (dir);
						Debug.Log ("Gen animator file:"+anim+" bundleName:"+bundleName);
						SetBundleName (m, bundleName + FI.AssetBundleExtension);
					}
				}
			}
		}

        // game scenes
        files = Directory.GetFiles("Assets/Scenes/game/", "*.unity", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var sceneFile = GetImporter(file);
            var name = Path.GetFileNameWithoutExtension(file);
            SetBundleName(sceneFile, GetBundleName(file) + FI.AssetBundleExtension);
        }

		//game scenes extra (light map / reflection )
		var subDirs = Directory.GetDirectories ("Assets/Scenes/game/", "*", SearchOption.TopDirectoryOnly);
		foreach (var dir in subDirs) 
		{
			foreach (var file  in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
			{
				if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
					continue;
				if (file.EndsWith("LightingData.asset"))
					continue;
				var m = GetImporter(file);
				if ( m != null)
					m.assetBundleName = GetBundleName(dir)+ "_extra" + FI.AssetBundleExtension;
			}
		}

		// sounds 
		subDirs = Directory.GetDirectories ("Assets/Sounds", "*", SearchOption.TopDirectoryOnly);
		foreach (var dir in subDirs) 
		{
			var bundleName = GetBundleName (dir);
	
			var sounds = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
				.Where(x => x.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".wav", StringComparison.OrdinalIgnoreCase));
			foreach (var sound in sounds) 
			{
				var m = GetImporter(sound) as AudioImporter;
				if (m != null)
				{
					m.assetBundleName = bundleName + FI.AssetBundleExtension;
				}
			}
		}

        //particles
        subDirs = Directory.GetDirectories("Assets/Particles", "*", SearchOption.TopDirectoryOnly);
        foreach (var dir in subDirs)
        {
            foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
                    continue;
                var m = GetImporter(file);
                if (m != null)
                    m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }

        //T4M
        subDirs = Directory.GetDirectories("Assets/T4MOBJ", "*", SearchOption.TopDirectoryOnly);
        foreach (var dir in subDirs)
        {
            foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
                    continue;
                var m = GetImporter(file);
                if (m != null)
                    m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }

        //AssignFolderNameAsBundle("Assets/Fonts/cn");
        subDirs = Directory.GetDirectories("Assets/Fonts", "*", SearchOption.TopDirectoryOnly);
        foreach (var dir in subDirs)
        {
            foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
                    continue;
                var m = GetImporter(file);
                if (m != null)
                    m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }

        //common shaders
        subDirs = Directory.GetDirectories("Assets/Shaders", "*", SearchOption.TopDirectoryOnly);
        foreach (var dir in subDirs)
        {
            foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
                    continue;
                var m = GetImporter(file);
                if (m != null)
                    m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }

        //ui resources
        subDirs = Directory.GetDirectories("Assets/UIRes", "*", SearchOption.TopDirectoryOnly);
        foreach (var dir in subDirs)
        {
            foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".meta") || file.EndsWith(".DS_Store"))
                    continue;
                var m = GetImporter(file);
                if (m != null)
                    m.assetBundleName = GetBundleName(dir) + FI.AssetBundleExtension;
            }
        }

        AssetDatabase.SaveAssets();
    }
    
    [MenuItem("Assets/Assign Bundles TWO")]
    public static void MakeBundlesWithPathTWO()
    {
        
        string toPath = "/Users/linjianfu/ddz/lart/AssetBundles/android/";
        string targetPlatform = "android";
        var target = BuildTarget.iOS;

        if (targetPlatform == "android")
        {
            target = BuildTarget.Android;
        }
        else if (targetPlatform == "osx")
        {
            target = BuildTarget.StandaloneOSX;
        }

        // Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.OnDemand;
        AssignAssetBundles();
        //      ClearAssetBundleScene();

        Directory.CreateDirectory (toPath);

        AssetBundleManifest manifest = null;

        // this has to be false or some color information
        // on the mesh will be lost
        PlayerSettings.stripUnusedMeshComponents = false;

        if (target == BuildTarget.Android)
        {
            Debug.Log ("Build to dir111:"+toPath);
            manifest = BuildPipeline.BuildAssetBundles(toPath,
                BuildAssetBundleOptions.StrictMode |
                BuildAssetBundleOptions.DeterministicAssetBundle |
                BuildAssetBundleOptions.ChunkBasedCompression,
                // BuildAssetBundleOptions.UncompressedAssetBundle,// |
                // BuildAssetBundleOptions.ForceRebuildAssetBundle,
                target);
        }
        else
        {
            Debug.Log ("Build to dir222:"+toPath);
            manifest = BuildPipeline.BuildAssetBundles(toPath,
                BuildAssetBundleOptions.StrictMode |
                BuildAssetBundleOptions.DeterministicAssetBundle |
                BuildAssetBundleOptions.ChunkBasedCompression,
                target);
        }

        BundleEncoder.Init(LBootApp.BUNDLE_KEY, LBootApp.BUNDLE_IV);
        // foreach (string bundleFile in Directory.GetFiles(toPath,
        //     "*" + LBootApp.DEFAULT_BUNDLE_EXTENSION, SearchOption.AllDirectories))
        // {
        //     EncodeBundleFile(bundleFile);
        // }

        File.Delete(toPath + FI.ManifestFile);
        File.Copy(toPath + targetPlatform, toPath + FI.ManifestFile);
        // EncodeBundleFile(toPath + FI.ManifestFile);

        // WriteBundleHashFile(toPath, targetPlatform);
    }

    public static void MakeBundlesWithPath(string toPath, string targetPlatform)
    {

        var target = BuildTarget.iOS;

        if (targetPlatform == "android")
        {
            target = BuildTarget.Android;
        }
        else if (targetPlatform == "osx")
        {
            target = BuildTarget.StandaloneOSX;
        }

        // Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.OnDemand;
        AssignAssetBundles();
        //      ClearAssetBundleScene();

		Directory.CreateDirectory (toPath);

        AssetBundleManifest manifest = null;

        // this has to be false or some color information
        // on the mesh will be lost
        PlayerSettings.stripUnusedMeshComponents = false;

        if (target == BuildTarget.Android)
        {
			Debug.Log ("Build to dir111:"+toPath);
            manifest = BuildPipeline.BuildAssetBundles(toPath,
                BuildAssetBundleOptions.StrictMode |
                BuildAssetBundleOptions.DeterministicAssetBundle |
                BuildAssetBundleOptions.ChunkBasedCompression,
                // BuildAssetBundleOptions.UncompressedAssetBundle,// |
                // BuildAssetBundleOptions.ForceRebuildAssetBundle,
                target);
        }
        else
        {
            Debug.Log ("Build to dir222:"+toPath);
            manifest = BuildPipeline.BuildAssetBundles(toPath,
                BuildAssetBundleOptions.StrictMode |
                BuildAssetBundleOptions.DeterministicAssetBundle |
                BuildAssetBundleOptions.ChunkBasedCompression,
                target);
        }

        BundleEncoder.Init(LBootApp.BUNDLE_KEY, LBootApp.BUNDLE_IV);
        // foreach (string bundleFile in Directory.GetFiles(toPath,
        //     "*" + LBootApp.DEFAULT_BUNDLE_EXTENSION, SearchOption.AllDirectories))
        // {
        //     EncodeBundleFile(bundleFile);
        // }

        File.Delete(toPath + FI.ManifestFile);
        File.Copy(toPath + targetPlatform, toPath + FI.ManifestFile);
        // EncodeBundleFile(toPath + FI.ManifestFile);

        // WriteBundleHashFile(toPath, targetPlatform);
    }

    // Unity AssetBundle building is not stable
    // Let's write our own hashes for asset bundle updates
    static void WriteBundleHashFile(string toPath, string targetPlatform)
    {
        var filename = toPath + "/" + targetPlatform + "_hashes.json";
        LogUtil.Debug("WriteBundleHashFile: hash filename=" + filename);

        var writer = new ScannerJsonWriter();
        writer.WriteObjectStart();

        var manifestFile = toPath + "/" + targetPlatform;
        var manifestBundle = BundleEncoder.CreateBundleFromFile(manifestFile);
        var manifest = manifestBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        LogUtil.Debug("WriteBundleHashFile: manifestFile=" + manifestFile);

        var dependants = new Dictionary<string, List<string>>();
        foreach (var file in manifest.GetAllAssetBundles())
        {
            string[] dependencies = manifest.GetAllDependencies(file);
            foreach (var depend in dependencies)
            {
                if (!dependants.ContainsKey(depend))
                {
                    dependants[depend] = new List<string>();
                }
                dependants[depend].Add(file);
            }
        }

        foreach (var file in manifest.GetAllAssetBundles())
        {
            writer.WritePropertyName(file);
            writer.WriteObjectStart();

            writer.WritePropertyName("hash");
            writer.Write(ComputeBundleAssetHash(toPath, targetPlatform, file));

            writer.WritePropertyName("depends");
            writer.WriteArrayStart();
            string[] dependencies = manifest.GetAllDependencies(file);
            foreach (var depend in dependencies)
            {
                writer.Write(depend);
            }
            writer.WriteArrayEnd();

            writer.WritePropertyName("dependants");
            writer.WriteArrayStart();
            List<string> files = null;
            if (dependants.TryGetValue(file, out files))
            {
                foreach (var dependant in files)
                {
                    writer.Write(dependant);
                }
            }
            else
            {
                LogUtil.Debug("WriteBundleHashFile: file " + file + " has no dependants!");
            }
            writer.WriteArrayEnd();

            writer.WriteObjectEnd();
        }

        writer.WriteObjectEnd();
        writer.OutputToFile(filename);
    }

    static char[] trimChars = new char [] { '\'', '\"', '\n', '\r', ' ' };

    // Here we concatenate each assets' md5, and do a md5 on the concatenated string
    static string ComputeBundleAssetHash(string toPath, string targetPlatform, string bundleFile)
    {
        var manifestFile = toPath + "/" + bundleFile + ".manifest";
        LogUtil.Debug("ComputeBundleAssetHash: manifestFile=" + manifestFile);

        System.IO.StreamReader file = new System.IO.StreamReader(manifestFile);
        var line = "";
        string state = "start";
        StringBuilder hashBuilder = new StringBuilder();
        var assetsBytes = new List<byte>();

        while ((line = file.ReadLine()) != null)
        {
            if (state == "start" && line.StartsWith("Assets:"))
            {
                state = "scan";
            }
            else if (state == "scan" && line.StartsWith("- "))
            {
                var asset = line.Substring(2, line.Length - 2).Trim(trimChars);
                LogUtil.Debug("ComputeBundleAssetHash: bundleFile=" + bundleFile + " asset=" + asset);
                if (File.Exists(asset))
                {
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(asset))
                        {
                            assetsBytes.AddRange(md5.ComputeHash(stream));
                        }
                    }
                }
                else
                {
                    LogUtil.Error("ComputeBundleAssetHash: file not exists " + asset);
                }
            }
            else if (state == "scan" && line.StartsWith("Dependencies:"))
            {
                state = "finish";
                break;
            }
        }

        using (var md5 = MD5.Create())
        {
            var hash = Encoding.ASCII.GetString(md5.ComputeHash(assetsBytes.ToArray()));
            return hash;
        }
    }

    static AssetImporter GetImporter(string path)
    {
        var importer = AssetImporter.GetAtPath(path);
        if (importer == null)
        {
            Debug.Log("asset importer missing: " + path + ", reimporting.");
            AssetDatabase.ImportAsset(path);
            importer = AssetImporter.GetAtPath(path);
        }

        return importer;
    }

    static void EncodeBundleFile(string bundleFile)
    {
        LogUtil.Debug("Encoding bundle file: " + bundleFile);
        if (BundleEncoder.GetEncodingOfFile(bundleFile) == BundleEncoder.Encoding.Unknown)
        {
            BundleEncoder.EncodeOverwriteBundleFile(bundleFile);
        }
        else
        {
            LogUtil.Debug("This bundle file is already encoded: " + bundleFile);
        }
    }

    static void WriteEditorScene(string sceneName)
    {
        string fileName = "Assets/Template/SceneName.tmp";
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            lock (fs)
            {
                if (!fs.CanWrite)
                {
                    throw new System.Security.SecurityException("fileName=" + fileName + "is read only!");
                }
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(sceneName);
                sw.Dispose();
                sw.Close();
            }
        }
    }

    [MenuItem("Assets/Build Project/IOS-Debug")]
    public static void BuildIOSPlayer()
    {
        _BuildIOSPlayer(iOSSdkVersion.DeviceSDK);
    }

    [MenuItem("Assets/Build Project/IOS-production")]
    public static void BuildIOSPlayerProduction()
    {
        _BuildIOSPlayer(iOSSdkVersion.DeviceSDK, false);
    }

    [MenuItem("Assets/Build Project/IOS-simulator")]
    static void BuildIOSPlayerSimulator()
    {
        _BuildIOSPlayer(iOSSdkVersion.SimulatorSDK);
    }

    static void _BuildIOSPlayer(iOSSdkVersion version, bool devMode = true)
    {
        var scenes = GetBuildPlayerScenes(devMode);

        // pack asset bundles into data.zip
        FI.TargetPlatform = "ios";
        // PackFiles();

        // create necessary folders for building project
        Directory.CreateDirectory("proj.ios/Data/Raw");
        Directory.CreateDirectory("proj.ios/Libraries");
        // build the xcode project

        // PlayerSettings.iOS.targetResolution = iOSTargetResolution.Native;
        PlayerSettings.iOS.sdkVersion = version;
        if (!devMode)
            PlayerSettings.iOS.scriptCallOptimization = ScriptCallOptimizationLevel.FastButNoExceptions;
        else
            PlayerSettings.iOS.scriptCallOptimization = ScriptCallOptimizationLevel.SlowAndSafe;

        PlayerSettings.enableCrashReportAPI = false;

        PlayerSettings.stripEngineCode = false;
        PlayerSettings.gpuSkinning = true;
		PlayerSettings.SetMobileMTRendering (BuildTargetGroup.iOS, true);
        PlayerSettings.graphicsJobs = false;
        PlayerSettings.accelerometerFrequency = 0;
        PlayerSettings.stripUnusedMeshComponents = false;
        // ios doesnt support antiAliasing
        QualitySettings.antiAliasing = 0;
        QualitySettings.pixelLightCount = 1;

        PlayerSettings.iOS.appleEnableAutomaticSigning = false;
        // PlayerSettings.iOS.applicationDisplayName = "荣耀飞车";
        // PlayerSettings.iOS.appleDeveloperTeamID = "T7DS86KKR2";
        
        if (devMode)
            BuildPipeline.BuildPlayer(scenes, "proj.ios", BuildTarget.iOS, BuildOptions.AcceptExternalModificationsToPlayer | BuildOptions.Development);
        else
            BuildPipeline.BuildPlayer(scenes, "proj.ios", BuildTarget.iOS, BuildOptions.AcceptExternalModificationsToPlayer);

        //bundle files are copied in package.sh
        //CopyAssetsToProject();
    }

    [MenuItem("Assets/Build Project/Android-debug")]
    static void BuildAndroidPlayer()
    {
        _BuildAndroidPlayer(true);
    }

    [MenuItem("Assets/Build Project/Android-production")]
    static void BuildAndroidPlayerProduction()
    {
        _BuildAndroidPlayer(false);
    }


    static void _BuildAndroidPlayer(bool devMode = true)
    {
        var scenes = GetBuildPlayerScenes(devMode);

        FI.TargetPlatform = "android";

        PlayerSettings.stripEngineCode = false;
        PlayerSettings.accelerometerFrequency = 0;
        PlayerSettings.Android.splashScreenScale = AndroidSplashScreenScale.ScaleToFill;
        PlayerSettings.gpuSkinning = false;
        PlayerSettings.Android.disableDepthAndStencilBuffers = false;
		PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, true);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetMobileMTRendering (BuildTargetGroup.iOS, true);

        QualitySettings.pixelLightCount = 1;

        // EditorPrefs.SetString("AndroidSdkRoot", Environment.GetEnvironmentVariable("ANDROID_HOME"));
        // EditorPrefs.SetString("JdkPath", Environment.GetEnvironmentVariable("JAVA_HOME"));
        // if (Application.dataPath.Contains("jobs/workspace/")) {
            // on jenkins:
            EditorPrefs.SetString("AndroidSdkRoot", "/projects/SDK");
            EditorPrefs.SetString("AndroidNdkRoot", "/projects/android-ndk-r13b");
            EditorPrefs.SetString("JdkPath", "/Library/Java/JavaVirtualMachines/jdk1.8.0_162.jdk/Contents/Home");
        // }

        EditorUserBuildSettings.exportAsGoogleAndroidProject = true;
        
        Debug.Log(">>>>>>BuildAndroidPlayer111" + devMode);
        if (devMode) {
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.allowDebugging = true;
            EditorUserBuildSettings.connectProfiler = true;
            Debug.Log(">>>>>>BuildAndroidPlayer222");
            EditorUserBuildSettings.androidETC2Fallback = AndroidETC2Fallback.Quality32Bit;
            BuildPipeline.BuildPlayer(scenes,
                "proj.android/proj_debug",
                BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer |
                    BuildOptions.Development |
                    BuildOptions.AllowDebugging |
                    BuildOptions.ConnectWithProfiler);
        } else {
            EditorUserBuildSettings.development = false;
            EditorUserBuildSettings.allowDebugging = false;
            EditorUserBuildSettings.connectProfiler = false;
            EditorUserBuildSettings.androidETC2Fallback = AndroidETC2Fallback.Quality32Bit;
            BuildPipeline.BuildPlayer(scenes,
                "proj.android/proj_product",
                BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer|
                BuildOptions.CompressWithLz4);
        }

        // bundles are copied in package_apk.sh
        // FI.copyToProject();
    }

    public static string [] GetBuildPlayerScenes(bool devMode)
    {
        if (devMode) {
            return new string[] {
                "Assets/Scenes/EntryPoint.unity",
                // "Assets/Scenes/game/debug.unity",
            };
        } else {
            return new string[] {
                "Assets/Scenes/EntryPoint.unity",
            };
        }
    }

    public static BuildTarget GetTargetPlatform()
    {
        var target = BuildTarget.iOS;
        if (FI.TargetPlatform == "ios")
        {
            target = BuildTarget.iOS;
        }

        if (FI.TargetPlatform == "android")
        {
            target = BuildTarget.Android;
        }

        if (FI.TargetPlatform == "osx")
        {
            target = BuildTarget.StandaloneOSXIntel64;
        }

        return target;
    }

    [MenuItem("Tools/Cache/Clean")]
    public static void CleanCache()
    {
        if (Caching.ClearCache())
        {
            LogUtil.Warn("Successfully cleaned all caches.");
        }
        else
        {
            LogUtil.Warn("Cache was in use.");
        }
    }

    [MenuItem("Assets/Add All Scenes")]
    public static void AddAllScenes()
    {
        var allScenes = Directory.GetFiles("Assets/Scenes/game/", "*.unity", SearchOption.AllDirectories).ToList();
        var newScenes = new List<EditorBuildSettingsScene>();
        allScenes.ForEach(x =>
            {
                LogUtil.Debug(x);
                newScenes.Add(new EditorBuildSettingsScene(x, true));
            });
        EditorBuildSettings.scenes = newScenes.ToArray();
    }



    public static void BuildLightMap()
    {
        //        Lightmapping.BakeMultipleScenes(

    }



    //[MenuItem("Assets/Assign UI Font")]
    //public static void AssignUIFont()
    //{
    //    Font font = Resources.GetBuiltinResource(typeof(Font), "msyh.ttf") as Font;
    //    Debug.Log(font);
    //    var uiPrefabs = Directory.GetFiles("Assets/prefab/ui", "*.prefab", SearchOption.AllDirectories).ToList();
    //    foreach (var prefab in uiPrefabs)
    //    {
    //        Debug.Log(prefab);
    //        GameObject tgo = AssetDatabase.LoadAssetAtPath(prefab, typeof(GameObject)) as GameObject;
    //        GameObject pgo = PrefabUtility.InstantiatePrefab(tgo) as GameObject;
    //        Text[] ts = pgo.GetComponentsInChildren<Text>();

    //        foreach (Text t in ts)
    //        {
    //            t.font = font;
    //        }
    //        //MonoBehaviour.DestroyImmediate(pgo);
    //        break;
    //    }
    //    AssetDatabase.SaveAssets();
    //}
}