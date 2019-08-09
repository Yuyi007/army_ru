using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using LBoot;

public class ModifyClothes
{
    private GameObject clothes;

    public GameObject Target
    {
        get
        {
            return clothes;
        }
    }

    private string part;

    public string Part
    {
        get
        {
            return part;
        }
    }

    private string skeleton;

    public string Skeleton
    {
        get
        {
            return skeleton;
        }
    }

    private string tid;

    public string Tid
    {
        get
        {
            return tid;
        }
    }

    public ModifyClothes()
    {
    }

    public ModifyClothes(GameObject go)
    {
        this.clothes = go;
        var arr = go.name.Split('_');
        this.skeleton = arr[0];
        this.part = arr[1];
        this.tid = arr[2];
    }

    public void CreatePrefab()
    {
        var skin = this.Target.transform.Find("skin");
        if (skin == null)
        {
            LogUtil.Error(this.Target.name + " has no skin");
            return;
        }

        List<string> parts = new List<string>();
        foreach (Transform t in skin)
        {
            parts.Add(t.name);
        }

        foreach (var partName in parts)
        {
            var part = GameObject.Instantiate(this.Target);
            var childCount = part.transform.childCount;
            for (var i = childCount - 1; i >= 0; i--)
            {
                var t = part.transform.GetChild(i);
                if (t.name != "skin" && t.name != "skeleton")
                {
                    GameObject.DestroyImmediate(t.gameObject);
                }
            }

            var comps = part.GetComponents<Component>();
            foreach (var comp in comps)
            {
                if (!(comp is Transform))
                {
                    GameObject.DestroyImmediate(comp);
                }
            }

            foreach (var name in parts)
            {
                if (name != partName)
                {
                    GameObject.DestroyImmediate(part.transform.Find("skin/" + name).gameObject);
                }
            }

            part.name = GetPartFileName(partName);
            var path = GetPartPrefabPath(partName);
            var dir = Path.GetDirectoryName(path);
            Directory.CreateDirectory(dir);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var renderer = part.GetComponentInChildren<SkinnedMeshRenderer>();

            renderer.receiveShadows = false;
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.motionVectors = false;
            renderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            renderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            renderer.skinnedMotionVectors = false;

            var meshPath = this.GetPartMeshPath(partName);
            var meshDir = Path.GetDirectoryName(meshPath);
            Directory.CreateDirectory(meshDir);
            var mesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
            if (mesh == null)
            {
                mesh = GameObject.Instantiate(renderer.sharedMesh);
                AssetDatabase.CreateAsset(mesh, meshPath);
            }

            mesh.Clear();
            EditorUtility.CopySerialized(renderer.sharedMesh, mesh);
          
            var meshName = Path.GetFileNameWithoutExtension(meshPath);
            mesh.name = meshName;
            mesh.uv2 = new Vector2[0];
            mesh.colors = new Color[0];
            mesh.tangents = new Vector4[0];

            if(mesh.subMeshCount > 1)
            {
                Debug.LogError("clothes " + part.name + " has more than 1 submesh");
            }
            // this merges all the submesh of the mesh into the first submesh
            mesh.SetTriangles(mesh.triangles, 0);

//            // clear triangles of other sub-meshes
//            for (var i = 1; i < mesh.subMeshCount; i++)
//                mesh.SetTriangles(new int[0], i);

            renderer.sharedMaterials = new Material[]{ renderer.sharedMaterial };

            EditorUtility.SetDirty(mesh);
            renderer.sharedMesh = mesh;

            if (prefab != null)
            {
                LogUtil.Debug("replacing prefab " + path);
                PrefabUtility.ReplacePrefab(part, prefab, ReplacePrefabOptions.ReplaceNameBased);
                EditorUtility.SetDirty(prefab);
            }
            else
            {
                LogUtil.Debug("creating prefab " + path);
                PrefabUtility.CreatePrefab(path, part, ReplacePrefabOptions.ConnectToPrefab);
            }

            GameObject.DestroyImmediate(part);
        }
    }


    private string GetPartPrefabPath(string part)
    {
        return "Assets/Prefab/clothes/" + part + "/" + GetPartFileName(part) + ".prefab";
    }

    private string GetPartMeshPath(string part)
    {
        return "Assets/Model/clothes/" + GetPartFileName(part) + "/mesh/" + GetPartFileName(part) + ".asset";
    }

    private string GetPartFileName(string part)
    {
        return this.Skeleton + "_" + part + "_" + this.Tid;
    }

}

