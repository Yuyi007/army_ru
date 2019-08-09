using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityStandardAssets.ImageEffects;
using LBoot;

public class SceneEditorHelper
{
    /// <summary>
    /// Creates the gameobject with the given path
    /// </summary>
    /// <param name="path">Path.</param>
    public static GameObject CreateGameObject(string path)
    {

        var list = path.Split('/').ToList();
        list.RemoveAll(x => x == string.Empty);
        var gameObjects = new List<GameObject>();
        var p = "";
        for (var i = 0; i < list.Count; i++)
        {
            var name = list[i];
            GameObject parent = null;
            if (i > 0)
                parent = gameObjects[i - 1];

            p = p + "/" + list[i];
            var go = GameObject.Find(p);
            if (go == null)
            {
                go = new GameObject(name);
                if (parent != null)
                    go.transform.SetParent(parent.transform, false);
                else
                    go.transform.SetParent(null, false);
            }

            gameObjects.Add(go);
        }

        return gameObjects.Last();
    }


    public static T CreateGameObject<T>(string path) where T: Component
    {
        var go = CreateGameObject(path);
        var comp = go.GetComponent<T>();
        if (comp == null)
        {
            comp = go.AddComponent<T>();
        }
        return comp;
    }

    [MenuItem("Tools/Scene/Find all renderers using standard shader")]
    public static void FindAllRenderersUsingStandardShaders()
    {
        var go = GameObject.Find("scenery");
        var renderers = go.GetComponentsInChildren<MeshRenderer>(true);
        var sb = new StringBuilder();
        sb.AppendLine("renderers using standard shader:");
        foreach (var render in renderers)
        {
            if (render.sharedMaterials == null)
            {
                Debug.Log(render.name + " has no materials");
                continue;
            }
            if (render.sharedMaterials.Any(x => x == null || x.shader == null || x.shader.name.Contains("Standard")))
            {
                sb.AppendLine(render.name);
            }
        }
        Debug.Log(sb.ToString());
    }

    [MenuItem("Tools/Resize model textures")]
    public static void ChangeTexture()
    {
        var files = Directory.GetFiles("Assets/Models/streets", "*.tga", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            LogUtil.Debug("change texture size " + file);
            var texture = AssetDatabase.LoadAssetAtPath<Texture>(file);
            var importer = AssetImporter.GetAtPath(file) as TextureImporter;
            importer.maxTextureSize = 256;
        }

        AssetDatabase.SaveAssets();
//        AssetDatabase.ImportAsset("Assets/Models/streets/", ImportAssetOptions.ImportRecursive);
    }

    

    [MenuItem("Tools/Scene/Delete Empty Animators")]
    public static void DeleteEmptyAnimators()
    {
        var animators = GameObject.FindObjectsOfType<Animator>();
        foreach (var a in animators)
        {
            if (a.runtimeAnimatorController == null)
            {
                GameObject.DestroyImmediate(a);
            }
        }
        EditorApplication.MarkSceneDirty();
        EditorApplication.SaveScene();
    }

    [MenuItem("Tools/Scene/Fix Renderers shadow setting")]
    public static void FixShadowSetting()
    {
        var renderers = GameObject.FindObjectsOfType<Renderer>();
        foreach (var a in renderers)
        {
            StaticEditorFlags flag = GameObjectUtility.GetStaticEditorFlags(a.gameObject);
            if ((flag & StaticEditorFlags.LightmapStatic) == 0)
            {
                a.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                a.receiveShadows = false;
            }
            else
            {
                a.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                a.receiveShadows = true;
            }
        }

        EditorApplication.MarkSceneDirty();
        EditorApplication.SaveScene();
    }

    [MenuItem("Tools/Scene/Optimize All Scenes")]
    public static void OptimizeAllScenes()
    {
        var allScenes = Directory.GetFiles("Assets/Scenes/game/streets", "*.unity", SearchOption.AllDirectories).ToList();

        for (int i = 0; i < allScenes.Count; ++i)
        {
            var scene = allScenes[i];
            EditorUtility.DisplayProgressBar("Optimize all scenes", "optimizing " + scene, (float)i / allScenes.Count);
            LogUtil.Debug("Optimizing scene " + scene + "...");

            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scene, UnityEditor.SceneManagement.OpenSceneMode.Single);
            OptimizeScene();
        }

        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Tools/Scene/Optimize Scene")]
    public static void OptimizeScene()
    {
        OptimizeBloomTextures();
        OptimizeStaticBatching();
        OptimizeDefaultMaterialsForBoundaries();
    }

    [MenuItem("Tools/Scene/Optimize Default Material for Boundaries")]
    public static void OptimizeDefaultMaterialsForBoundaries()
    {
        var cubeMesh = AssetDatabase.LoadAssetAtPath<Mesh>("Assets/Models/Prefab/cube.asset");
        foreach (var render in BoundaryRenderers())
        {
            render.sharedMaterial = Resources.Load<Material>("Material/plane");
            render.receiveShadows = false;
            render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            render.motionVectors = false;
            render.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            render.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            var meshFilter = render.GetComponent<MeshFilter>();
            meshFilter.sharedMesh = cubeMesh;
        }
    }

    // Bloom Textures must be examined on the scene,
    // If they have render textures assigned in editor mode,
    // render textures will be generated automatically during scene loading in game!
    public static void OptimizeBloomTextures()
    {
        var camera = GameObject.Find("scenery/mainCamera");
        if (camera == null)
        {
            LogUtil.Error("Scene has no main camera!");
            return;
        }

        var stencil = camera.GetComponent<FVBloomSelectiveStencil>();
        var bloom = camera.GetComponent<Bloom>();
        var bloomOpt = camera.GetComponent<BloomOptimized>();
        var colorCorrection = camera.GetComponent<ColorCorrectionCurves>();
        var colorCorrectionLookup = camera.GetComponent<FVColorCorrectionLookup>();
        var antialiasing = camera.GetComponent<Antialiasing>();
        var fxaa = camera.GetComponent<FXAA>();
        var smaa = camera.GetComponent<Smaa.SMAA>();
        var bloomTextures = camera.transform.Find("BloomTextures");
        var sceneReceiver = camera.transform.Find("SceneReceiver");

        if (stencil != null)
        {
            LogUtil.Debug("FVBloomSelectiveStencil component found, removing textures...");
            stencil.enabled = false;
            // GameObject.DestroyImmediate(stencil);
        }

        if (bloom != null)
        {
            LogUtil.Debug("Bloom component found, disabling...");
            bloom.enabled = false;
        }

        if (bloomOpt != null)
        {
            LogUtil.Debug("BloomOptimized component found, disabling...");
            bloomOpt.enabled = false;
        }

        if (colorCorrection != null)
        {
            LogUtil.Debug("ColorCorrectionCurves component found, disabling...");
            colorCorrection.enabled = false;
        }

        if (colorCorrectionLookup != null)
        {
            LogUtil.Debug("colorCorrectionLookup component found, disabling...");
            colorCorrectionLookup.enabled = false;
        }

        if (antialiasing != null)
        {
            LogUtil.Debug("Antialiasing component found, disabling...");
            antialiasing.enabled = false;
        }

        if (fxaa != null)
        {
            LogUtil.Debug("FXAA component found, disabling...");
            fxaa.enabled = false;
        }

        if (smaa != null)
        {
            LogUtil.Debug("SMAA component found, disabling...");
            smaa.enabled = false;
        }

        if (bloomTextures != null)
        {
            LogUtil.Debug("BloomTextures game object found, removing textures...");
            bloomTextures.gameObject.SetActive(false);
            // GameObject.DestroyImmediate(bloomTextures.gameObject);
        }

        if (sceneReceiver != null)
        {
            LogUtil.Debug("SceneReceiver game object found, removing textures...");
            sceneReceiver.gameObject.SetActive(false);
            // GameObject.DestroyImmediate(sceneReceiver.gameObject);
            sceneReceiver.gameObject.GetComponent<Camera>().targetTexture = null;
        }
    }

    // Static batching will combine meshes, leading to more memory usage.
    // For those model cannot be effectively batched, unset their static batching flag.
    public static void OptimizeStaticBatching()
    {
        var models = GameObject.Find("scenery/models");
        if (models == null)
        {
            LogUtil.Debug("Scene has no models!");
            return;
        }

        var renderers = models.GetComponentsInChildren<Renderer>();
        Dictionary<string, int> materialsLookup = new Dictionary<string, int>();
        int isStatic = 0;
        int notStatic = 0;
        int noMeshFilter = 0;
        foreach (var renderer in renderers)
        {
            var keyBuilder = new StringBuilder();
            foreach (var mat in renderer.sharedMaterials)
            {
                if (mat != null)
                    keyBuilder.Append(mat.GetInstanceID());
            }

            var key = keyBuilder.ToString();
            int count = -1;
            if (materialsLookup.TryGetValue(key, out count))
            {
                materialsLookup[key] = count + 1;
            }
            else
            {
                materialsLookup[key] = 1;
            }
        }

        List<GameObject> staticGOs = new List<GameObject>();
        StaticBatchRoot sbr = models.GetComponent<StaticBatchRoot>();
        if (sbr == null)
        {
            sbr = models.AddComponent<StaticBatchRoot>();
        }

        var scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        var isCombat = true;
        if (scene.name.Contains("cit") || scene.name.Contains("ind"))
            isCombat = false;

        foreach (var renderer in renderers)
        {
            renderer.motionVectors = false;
            renderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            renderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;

            var keyBuilder = new StringBuilder();
            foreach (var mat in renderer.sharedMaterials)
            {
                if (mat != null)
                    keyBuilder.Append(mat.GetInstanceID());
            }

            var go = renderer.gameObject;
            var flags = GameObjectUtility.GetStaticEditorFlags(go);
            var meshFilter = go.GetComponent<MeshFilter>();
            var mesh = meshFilter.sharedMesh;

            var key = keyBuilder.ToString();
            int count = -1;
            if (materialsLookup.TryGetValue(key, out count) && count > 3 && mesh != null && mesh.vertexCount < 900)
            {
                // model importer must set to be readable for the StaticBatchingUtility.Combine to work
                var prefab = PrefabUtility.GetPrefabParent(go);
                if (prefab != null)
                {
//                    var path = AssetDatabase.GetAssetPath(prefab);
//                    Debug.Log("path= " + path, prefab);
//                    var importer = AssetImporter.GetAtPath(path) as ModelImporter;
//                    if (importer != null)
//                    {
//                        importer.isReadable = true;
//                        AssetDatabase.WriteImportSettingsIfDirty(path);
//                    }
                }

                MeshFilter mf = go.GetComponent<MeshFilter>();
                if (mf != null)
                {
                    if (!isCombat)
                        staticGOs.Add(go);
                }
                else
                {
                    noMeshFilter++;
                }

                if (!isCombat)
                    flags &= ~StaticEditorFlags.BatchingStatic;
                else
                    flags |= StaticEditorFlags.BatchingStatic;
                
                isStatic++;
            }
            else
            {
                if (!isCombat)
                    flags &= ~StaticEditorFlags.BatchingStatic;
                else
                    flags |= StaticEditorFlags.BatchingStatic;
                notStatic++;
            }
            GameObjectUtility.SetStaticEditorFlags(go, flags);
        }


        LogUtil.Debug("OptimizeStaticBatching: materials combinations=" + materialsLookup.Count);
        LogUtil.Debug("OptimizeStaticBatching: static=" + isStatic + " other=" + notStatic);
        LogUtil.Debug("OptimizeStaticBatching: no mesh filter =" + noMeshFilter);

        sbr.staticGameObjects = staticGOs.ToArray();

        EditorApplication.MarkSceneDirty();
        EditorApplication.SaveScene();
    }

    public static bool StripCamera(GameObject go)
    {
        var transforms = go.GetComponentsInChildren<Transform>(true);
        var changed = false;
        foreach (var t in transforms)
        {
            if (t.GetComponent<Camera>() != null)
            {
                changed = true;
                GameObject.DestroyImmediate(t.GetComponent<Camera>());
            }
        }
        return changed;
    }

    [MenuItem("Tools/Scene/Strip city trigger cameras")]
    public static void StripCamerasInTriggers()
    {
        var list = Directory.GetFiles("Assets/Prefab/city_triggers/", "*.prefab");
        foreach (var file in list)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
            var go = GameObject.Instantiate(prefab);
            var changed = StripCamera(go);
            if (changed)
            {
                PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
                EditorUtility.SetDirty(prefab);
            }

            GameObject.DestroyImmediate(go);
        }

        AssetDatabase.SaveAssets();

    }

    [MenuItem("Tools/Scene/Basic/Bake Navmesh")]
    public static void BakeNavMesh()
    {
        UndoCarveScene();
        CarveScene();
        var renderers = GameObject.Find("models").GetComponentsInChildren<Renderer>();
        foreach (var render in renderers)
        {
            GameObject.DestroyImmediate(render.gameObject.GetComponent<UnityEngine.AI.NavMeshObstacle>());
            var bounds = render.bounds;
            var flags = GameObjectUtility.GetStaticEditorFlags(render.gameObject);
            if (!EditorApplication.currentScene.Contains("ind") && bounds.center.y > 0.5)
            {
                flags &= ~StaticEditorFlags.NavigationStatic;
            }
            else
            {
                flags |= StaticEditorFlags.NavigationStatic;
            }
            GameObjectUtility.SetStaticEditorFlags(render.gameObject, flags);
        }

        var malus = Malus();
        foreach (var malu in malus)
        {
            var flags = GameObjectUtility.GetStaticEditorFlags(malu);
            flags |= StaticEditorFlags.NavigationStatic;
            GameObjectUtility.SetStaticEditorFlags(malu, flags);
        }

        var tianqiao = Tianqiao();
        foreach (var o in tianqiao)
        {
            var flags = GameObjectUtility.GetStaticEditorFlags(o);
            flags |= StaticEditorFlags.NavigationStatic;
            GameObjectUtility.SetStaticEditorFlags(o, flags);
        }

        var settingsObject = new SerializedObject(UnityEditor.AI.NavMeshBuilder.navMeshSettingsObject);
        var agentSlope = settingsObject.FindProperty("m_BuildSettings.agentSlope");
        var agentClimb = settingsObject.FindProperty("m_BuildSettings.agentClimb");
        agentSlope.floatValue = 45f;
        agentClimb.floatValue = 0.3f;

        settingsObject.ApplyModifiedProperties();
        settingsObject.Update();
//
//        var iter = settingsObject.GetIterator();
//        do
//        {
////            LogUtil.Debug("member:  " + iter.displayName);
//            LogUtil.Debug("member:  " + iter.name);
//            LogUtil.Debug("value:  " + iter.floatValue);
//        } while (iter.Next(true));

        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }

    [MenuItem("Tools/Scene/Basic/Bake Occlusion culling")]
    public static void BakeOcclusion()
    {
        var area = CreateGameObject<OcclusionArea>("Occlusion Area");

        var renderers = GameObject.Find("models").GetComponentsInChildren<Renderer>();
        var bounds = new Bounds();
        var occludeeOnlyCount = 0;
        foreach (var renderer in renderers)
        {
            var boundSize = renderer.bounds.size;
            var isOnlyOccludee = false;
            isOnlyOccludee = isOnlyOccludee || boundSize.x < 5f && boundSize.y < 5f && boundSize.z < 5f;
            isOnlyOccludee = isOnlyOccludee || boundSize.x < 1 || boundSize.z < 1;

            if (isOnlyOccludee)
            {
                var flag = GameObjectUtility.GetStaticEditorFlags(renderer.gameObject);
                flag &= ~StaticEditorFlags.OccluderStatic;
                GameObjectUtility.SetStaticEditorFlags(renderer.gameObject, flag);
                occludeeOnlyCount++;
            }
            else
            {

            }
            bounds.Encapsulate(renderer.bounds);
        }

        var size = bounds.size;
        Debug.Log("Occludee only count=" + occludeeOnlyCount.ToString());

        size.Scale(new Vector3(1.2f, 1, 1.2f));
        area.size = size;
        area.transform.position = bounds.center;
        area.center = Vector3.zero;
        StaticOcclusionCulling.smallestOccluder = 8f;
        StaticOcclusionCulling.smallestHole = 0.25f;
        StaticOcclusionCulling.backfaceThreshold = 80f;
        StaticOcclusionCulling.Compute();
    }

    public static bool ValidCityScene(string sceneName)
    {
        return sceneName.Contains("Assets/Scenes/game/streets") && !sceneName.Contains("trs");
    }

    public static bool ValidCampaignScene(string sceneName)
    {
        return sceneName.Contains("Assets/Scenes/game/streets") && sceneName.Contains("trs");
    }

    [MenuItem("Tools/Scene/Bootstrap")]
    public static void Bootstrap()
    {
        BakeNavMesh();
        BakeOcclusion();
        DeleteEmptyAnimators();
        OptimizeScene();
        EditorApplication.MarkSceneDirty();
        AssetDatabase.SaveAssets();
        AssetDatabase.SaveAssets();
    }

    public static IEnumerable<BoxCollider> SceneBoxes()
    {
        var models = GameObject.Find("scenery/models");
        var boxes = models.GetComponentsInChildren<BoxCollider>(true).ToList();
        models = GameObject.Find("scenery/cehuayong");
        if (models != null)
        {
            boxes.AddRange(models.GetComponentsInChildren<BoxCollider>(true));
        }
        return boxes;
    }

    public static IEnumerable<Renderer> SceneRenderers()
    {
        var models = GameObject.Find("scenery/models");
        var renderers = models.GetComponentsInChildren<Renderer>(true).ToList();
        return renderers;
    }

    public static IEnumerable<Renderer> BoundaryRenderers()
    {
        var models = GameObject.Find("scenery/fightBoundary");
        var renderers = models.GetComponentsInChildren<Renderer>(true).ToList();
        return renderers;
    }


    public static IEnumerable<GameObject> Dianxiangans()
    {
        var models = GameObject.Find("scenery/models");
        var list = new List<GameObject>();
        var trans = models.GetComponentsInChildren<Transform>(true);

        foreach (Transform t in trans)
        {
            if (t.name.Contains("dianxiangan") || t.name.Contains(("ludeng")))
            {
                list.Add(t.gameObject);
            }
        }
        return list;
    }

    public static IEnumerable<GameObject> Malus()
    {
        var models = GameObject.Find("scenery/models");
        var list = new List<GameObject>();
        foreach (Transform t in models.GetComponentsInChildren<Transform>())
        {
            if (t.name.Contains("malu") || t.parent.name.Contains("malu"))
            {
                list.Add(t.gameObject);
            }
        }
        return list;
    }

    public static IEnumerable<GameObject> Tianqiao()
    {
        var models = GameObject.Find("scenery/models");
        var list = new List<GameObject>();
        foreach (Transform t in models.GetComponentsInChildren<Transform>())
        {
            if (t.name.Contains("tianqiao") || t.parent.name.Contains("tianqiao"))
            {
                list.Add(t.gameObject);
            }
        }
        return list;
    }

    private static int LayerObstacle
    {
        get
        {
            return LayerMask.NameToLayer("Obstacles");
        }
    }

    private static int LayerLodObstacle
    {
        get
        {
            return LayerMask.NameToLayer("LodObstacle");
        }
    }

    private static int LayerLodObstacle120
    {
        get
        {
            return LayerMask.NameToLayer("LodObstacle120");
        }
    }


    private static int LayerCameraObstacle
    {
        get
        {
            return LayerMask.NameToLayer("CameraObstacle");
        }
    }


    private static bool ValidCityTriggerScene()
    {
        var curScene = EditorApplication.currentScene;
        return curScene.Contains("Assets/Scenes/city_triggers/");
    }

    private static bool ValidInstanceTriggerScene()
    {
        var curScene = EditorApplication.currentScene;
        return curScene.Contains("Assets/Scenes/instances/");
    }

    private static void FixSequenceName(string name, string rootName, string rootParentPath)
    {
        var root = CreateGameObject(rootParentPath + "/" + rootName);
        var count = root.transform.childCount;
        for (var i = 0; i < root.transform.childCount; i++)
        {
            var n = name + (i + 1).ToString();
            var t = root.transform.GetChild(i);
            t.name = n;
        }
    }

    private static GameObject CreateBoxObject(string name,
                                              string rootName,
                                              Vector3 defaultSize,
                                              string rootParentPath = "levelRoot",
                                              string layer = "AreaTrigger",
                                              GameObject gameObject = null,
                                              bool isTrigger = true, bool scale = false, string tag = null)
    {
        var go = gameObject;

        if (go == null)
            go = new GameObject(name);

        var rootParent = CreateGameObject(rootParentPath);
        var root = CreateGameObject(rootParentPath + "/" + rootName);
        var bo = go.GetComponent<BoxCollider>();

        if (bo == null)
            bo = go.AddComponent<BoxCollider>();

        if (scale)
        {
            bo.transform.localScale = defaultSize;
        }
        else
        {
            bo.size = defaultSize;
        }

        bo.isTrigger = isTrigger;
        go.layer = LayerMask.NameToLayer(layer);

        Selection.activeGameObject = go;
        var count = root.transform.childCount;

        go.name = name + (count + 1).ToString();
        go.transform.SetParent(root.transform, false);
        if (tag != null)
        {
            go.tag = tag;
        }

        return go;
    }

    private static int ObstacleLayers
    {
        get
        {
            return LayerMask.NameToLayer("Obstacles") | LayerMask.NameToLayer("LodObstacle") | LayerMask.NameToLayer("CameraObstacle");
        }
    }

    private static void UndoCarveScene()
    {
        var boundary = GameObject.Find("scenery/fightBoundary/Walls");
        foreach (Transform t in boundary.transform)
        {
            removeNavObstacle(t.gameObject);
        }

        var grounds = GameObject.Find("scenery/fightBoundary/Grounds");
        foreach (Transform t in grounds.transform)
        {

            removeNavObstacle(t.gameObject);
        }

        var boxes = SceneBoxes();
        foreach (var box in boxes)
        {
            removeNavObstacle(box.gameObject);
        }

        var objtacle = GameObject.Find("scenery/fightBoundary/Obstacles");
        foreach (Transform t in objtacle.transform)
        {
            removeNavObstacle(t.gameObject);
        }
    }

    private static void CarveScene()
    {
//        var boundary = GameObject.Find("scenery/fightBoundary/Walls");
//        foreach (Transform t in boundary.transform)
//        {
//            addColliderAsObstacle(t);
//        }
//
//        var grounds = GameObject.Find("scenery/fightBoundary/Grounds");
//        foreach (Transform t in grounds.transform)
//        {
//
//            removeNavObstacle(t.gameObject);
//        }
//
//        var boxes = SceneBoxes();
//        foreach (var box in boxes)
//        {
//            if ((box.gameObject.layer & ObstacleLayers) > 0)
//            {
//                var center = box.bounds.center;
////                if (center.y > 0.5f)
////                {
//                addColliderAsObstacle(box.transform);
////                }
////                else
////                {
////                    removeNavObstacle(box.gameObject);
////                }
//            }
//            else
//            {
//
//                removeNavObstacle(box.gameObject);
//            }
//        }
        var obstacle = GameObject.Find("scenery/fightBoundary/Obstacles");
        foreach (Transform t in obstacle.transform)
        {
            addColliderAsObstacle(t);
        }
    }

    private static void CarveCampaignScene()
    {
        var boundary = GameObject.Find("scenery/fightBoundary/Walls");
        foreach (Transform t in boundary.transform)
        {
            addColliderAsObstacle(t, true);
        }

        var grounds = GameObject.Find("scenery/fightBoundary/Grounds");
        foreach (Transform t in grounds.transform)
        {

            removeNavObstacle(t.gameObject);
        }

        var boxes = SceneBoxes();
        foreach (var box in boxes)
        {
            if ((box.gameObject.layer & ObstacleLayers) > 0)
            {
                var center = box.bounds.center;
                if (center.y > 0.5f)
                {
                    addColliderAsObstacle(box.transform, true);
                }
                else
                {
                    removeNavObstacle(box.gameObject);
                }
            }
            else
            {

                removeNavObstacle(box.gameObject);
            }
        }
    }
    private static void removeNavObstacle(GameObject go)
    {
        var obs = go.GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (!obs)
            return;
        GameObject.DestroyImmediate(obs);
    }

    private static void removeObstacleFromColider(Transform t)
    {
        var obs = t.gameObject.GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (!obs)
            return;

        GameObject.DestroyImmediate(obs);
    }

    private static void addColliderAsObstacle(Transform t, bool enableBox = false)
    {
        var box = t.gameObject.GetComponent<BoxCollider>();
        if (!box)
            return;

        var size = box.size;
        var ob = t.gameObject.GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (ob == null)
        {
            ob = t.gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            ob.size = size;
        }

        if (ob.size.x < size.x || ob.size.y < size.y || ob.size.z < size.z)
        {
            ob.size = size;
        }

        ob.shape = UnityEngine.AI.NavMeshObstacleShape.Box;
        ob.carving = true;
        ob.enabled = true;

        box.enabled = enableBox;
    }

    private static void VisitGameObjectRecursive(GameObject go, Action<GameObject> aFunc)
    {
        if (go == null)
            return;

        aFunc(go);

        foreach (Transform child in go.transform)
        {
            VisitGameObjectRecursive(child.gameObject, aFunc);
        }
    }
}