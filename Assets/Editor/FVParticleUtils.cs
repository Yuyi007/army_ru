using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using LBoot;

public class FVParticleUtils
{
    private const int PARTICLE_LAYER = 21;
    // particle layer is Barrel

    [MenuItem("Tools/FVParticleTools/Make Particle Effect Tamplate")]
    private static void MakeParticleTemplate()
    {
        GameObject root = new GameObject();
        root.tag = "ParticleEffect";
        root.name = "New Particle System";

        GameObject go = new GameObject();
        go.name = "particles";
        go.transform.parent = root.transform;
        GameObject animRoot = new GameObject();
        animRoot.name = "particleAnimatorRoot";
        animRoot.transform.parent = go.transform;

        go = new GameObject();
        go.name = "others";
        go.transform.parent = root.transform;
        animRoot = new GameObject();
        animRoot.name = "animatorRoot";
        animRoot.transform.parent = go.transform;

        _DoBootstrapParticleSystem(root, true);
    }

    [MenuItem("Tools/FVParticleTools/Fix All Particle Effects in prefab")]
    public static void FixParticleSystemShaders()
    {
        string sPrefabPath = "Assets/Prefab/misc";
        string[] aParticleNames = Directory.GetFiles(sPrefabPath, "*.prefab");
        foreach (string v in aParticleNames)
        {
            //if (!v.Contains("eff_sff018"))
            //	continue;

            LogUtil.Debug("processing " + v);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(v);
            GameObject go = GameObject.Instantiate(prefab);
            _DoBootstrapParticleSystem(go, false);

            // save to prefab
            PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
            GameObject.DestroyImmediate(go);
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/FVParticleTools/Fix All Particle Effects Layers in prefab")]
    public static void FixParticleLayers()
    {
        LogUtil.Debug("Fixing particle layers...");
        string sPrefabPath = "Assets/Prefab/misc";
        string[] aParticleNames = Directory.GetFiles(sPrefabPath, "*.prefab");
        foreach (string v in aParticleNames)
        {
            LogUtil.Debug("processing layers of " + v);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(v);
            GameObject go = GameObject.Instantiate(prefab);
            go.SetLayer(PARTICLE_LAYER, true);

            // save to prefab
            PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
            GameObject.DestroyImmediate(go);
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/FVParticleTools/Bootstrap Selected Particle Effect")]
    private static void BootstrapParticleSystem()
    {
        GameObject psRoot = Selection.activeGameObject;
        if (psRoot.transform.parent != null)
        {
            EditorUtility.DisplayDialog("错误 ！", "请选择特效根节点！", "OK");
            return;
        }
        _DoBootstrapParticleSystem(psRoot, false);
    }

    // [MenuItem("Tools/FVParticleTools/Bootstrap Selected Particle Effect as Flippable")]
    private static void BootstrapParticleSystemFlippable()
    {
        GameObject psRoot = Selection.activeGameObject;
        if (psRoot.transform.parent != null)
        {
            EditorUtility.DisplayDialog("错误 ！", "请选择特效根节点！", "OK");
            return;
        }
        _DoBootstrapParticleSystem(psRoot, true);
    }

    [MenuItem("Tools/FVParticleTools/Batch Bootstrap Selected Particle Prefabs as Flippable")]
    private static void BootstrapParticleSystemFlippableAllSelected()
    {
        var list = Selection.gameObjects;
        foreach (var prefab in list)
        {

            if (prefab.transform.parent != null)
            {
//                EditorUtility.DisplayDialog("错误 ！", "请选择特效根节点！", "OK");
                continue;
            }
            var assetPath = AssetDatabase.GetAssetPath(prefab);
            if (assetPath == null)
                continue;

            if (!assetPath.Contains("Prefab/misc/")) {
               // EditorUtility.DisplayDialog("错误 ！", "请选择特Prefab/misc下的prefab", "OK");
                continue;
            }

            var psRoot = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            _DoBootstrapParticleSystem(psRoot, true);

            psRoot.SetLayer(PARTICLE_LAYER, true);
            // save to prefab
            PrefabUtility.ReplacePrefab(psRoot, prefab, ReplacePrefabOptions.ReplaceNameBased);
            GameObject.DestroyImmediate(psRoot);
        }
    }

    private static void _DoBootstrapParticleSystem(GameObject root, bool addScaleComp)
    {
        // check root gameobject must have FVParticleRoot
        FVParticleRoot fvpr = root.GetComponent<FVParticleRoot>();
        if (fvpr == null)
        {
            fvpr = (FVParticleRoot)root.AddComponent<FVParticleRoot>();
        }
        // check children of particles node, all must have FVParticleScalable
        Transform particleRootTrans = root.transform.Find("particles");
        if (particleRootTrans == null)
        {
            GameObject prgo = new GameObject();
            prgo.name = "particles";
            particleRootTrans = prgo.transform;

            List<Transform> larr = new List<Transform>();
            foreach (Transform child in root.transform)
            {
                larr.Add(child);
            }
            foreach (Transform child in larr)
            {
                child.parent = particleRootTrans;
            }
            particleRootTrans.transform.parent = root.transform;
        }

        /*
		if (root.tag != "ParticleEffect") {
      // rotate 90 degrees to fix rotation of particle
			foreach (Transform child in particleRootTrans.gameObject.transform) {
				Vector3 rot = child.transform.rotation.eulerAngles;
				rot.y += 90;
				child.transform.rotation = Quaternion.Euler(rot);
			}
			root.tag = "ParticleEffect";
		}
    */

        _AddParticleScalableComp(root, particleRootTrans.gameObject, addScaleComp);

        // 2017-6-7 lt: optimize by preset particles to Barrel layer
        // (setLayer recursively in lua is slow)
        root.SetLayer(PARTICLE_LAYER, true);
    }

    private static void _AddParticleScalableComp(GameObject psRoot, GameObject go, bool addScaleComp)
    {
        ParticleSystem ps = go.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            FVParticleScaling fvps = go.GetComponent<FVParticleScaling>();
            if (fvps == null && addScaleComp)
            {
                fvps = go.AddComponent<FVParticleScaling>();
            }

            if (fvps != null)
            {
                fvps.psRoot = psRoot;
                Renderer renderComp = go.GetComponent<Renderer>();


                if (renderComp != null &&
                renderComp.sharedMaterial != null &&
                renderComp.sharedMaterial.shader != null)
                {
                    var shader = renderComp.sharedMaterial.shader;
                    bool containsAdditive = shader.name.IndexOf("Additive", StringComparison.OrdinalIgnoreCase) >= 0;
                    bool containsAlpha = shader.name.IndexOf("Alpha", StringComparison.OrdinalIgnoreCase) >= 0;

                    if (containsAdditive)
                    {
                        renderComp.sharedMaterial.shader = Shader.Find("Custom/Mobile/Particles/AdditiveScalable");
                    }
                    else if (containsAlpha)
                    {
                        renderComp.sharedMaterial.shader = Shader.Find("Custom/Mobile/Particles/AlphaScalable");
                    }
                }
            }
        }
        foreach (Transform child in go.transform)
        {
            _AddParticleScalableComp(psRoot, child.gameObject, addScaleComp);
        }
    }
}

