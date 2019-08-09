using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using LBootEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.VR;
using LBoot;

public class ModifyPrefab : ModifyBase
{
    private string prefabPath;

    public string PrefabPath
    {
        get
        {
            return prefabPath;
        }
        set
        {
            prefabPath = value;
        }
    }

    public ModifyPrefab(ModifyModel cm)
        : base(cm)
    {
    }

    public void Setup(bool stripMesh = true, bool stripAvatar = true, bool makeControllerHolder = true, bool combineMesh = true)
    {
        var template = GetTemplate();
        if (!Tid.Contains("npc999"))
            AddColliders(template);

        AddBehaviours(template);
        GameObject.DestroyImmediate(template);

        if (stripMesh)
            StripMesh();

        if (stripAvatar)
            StripAvatar();

        if (makeControllerHolder)
            MakeControllerHolder();

        FixRenderers();

        if (!cm.MainScene)
            CreateDefaultParts();

        if (combineMesh)
            CombineMesh();
        Save();
    }

    private void MakeControllerHolder()
    {
        var path = GetControllerHolderPath();

        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        if (prefab == null)
        {
            var go = GameObject.Instantiate(Target);
            var animator = go.GetComponent<Animator>();
            animator.avatar = null;
            animator.enabled = false;

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var comps = go.GetComponentsInChildren<Component>(true);
            for (var i = 0; i < comps.Length; i++)
            {
                var c = comps[i];
                if (c is Transform)
                    continue;
                if (c is Animator)
                    continue;
                GameObject.DestroyImmediate(c);
            }

            for (var i = go.transform.childCount - 1; i >= 0; i--)
            {
                var t = go.transform.GetChild(i);
                GameObject.DestroyImmediate(t.gameObject);
            }

            LogUtil.Debug("create prefab " + path);
            PrefabUtility.CreatePrefab(path, go, ReplacePrefabOptions.ConnectToPrefab);
            GameObject.DestroyImmediate(go);
        }
        else
        {
            LogUtil.Debug("replace prefab " + path);
            var animator = prefab.GetComponent<Animator>();
            var animator1 = this.Target.GetComponent<Animator>();
            animator.runtimeAnimatorController = animator1.runtimeAnimatorController;
            EditorUtility.SetDirty(prefab);
        }
    }

    private void FixRenderers()
    {
        var isNpc = !this.Tid.Contains("rda");


        var renderers = this.Target.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        foreach (var r in renderers)
        {
            if (cm.MainScene)
            {
                r.updateWhenOffscreen = false;
                if (isNpc)
                {
                    Debug.Log("npc update aabb:" + this.Tid);
                    var so = new SerializedObject(r);
                    var property = so.FindProperty("m_DirtyAABB");
                    property.boolValue = true;
                    property = so.FindProperty("m_AABB.m_Center");
                    property.vector3Value = Vector3.zero;

                    property = so.FindProperty("m_AABB.m_Extent");
                    property.vector3Value = Vector3.zero;

                    so.ApplyModifiedProperties();
                }
            }
            else
            {
                r.updateWhenOffscreen = false;
            }

            r.receiveShadows = false;
            r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            r.motionVectors = false;
            r.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            r.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            r.skinnedMotionVectors = false;

            if (Tid.Contains("npc999"))
            {
                r.quality = SkinQuality.Bone1;
            }
            else
            {
                r.quality = SkinQuality.Auto;
            }
        }
    }

    private GameObject GetTemplate()
    {
        var go = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Models/character_template_model.prefab");
        var template = GameObject.Instantiate(go);
        template.name = "template";
        return template;
    }

    public void AddColliders(GameObject template)
    {
        GameObject go = this.Target;
        BoxCollider bo = go.GetComponent<BoxCollider>();
        var transform = go.transform;

        if (!cm.MainScene)
        {
            for (int i = 1; i <= 10; i++)
            {
                var name = "AttackCollider_" + i;
                if (transform.Find(name) == null)
                {
                    var c = new GameObject(name);
                    c.transform.parent = transform;
                    c.layer = LayerMask.NameToLayer("AttackCollider");
                    var box = c.AddComponent<BoxCollider>();
                    box.isTrigger = false;

                    var bt = template.transform.Find(name).GetComponent<BoxCollider>();
                    box.center = bt.center;
                    box.size = bt.size;
                    c.tag = "AttackCollider";
                    box.enabled = false;
                }
            }

            if (transform.Find("RecvCollider") == null)
            {
                var c = new GameObject("RecvCollider");
                c.transform.parent = transform;
                c.layer = LayerMask.NameToLayer("RecvCollider");
                c.tag = "RecvCollider";
            }
        }
        else
        {
            for (int i = 1; i <= 10; i++)
            {
                var name = "AttackCollider_" + i;
                var box = transform.Find(name);
                if (box != null)
                    GameObject.DestroyImmediate(box.gameObject);
            }

            {

                var name = "RecvCollider";
                var box = transform.Find(name);
                if (box != null)
                    GameObject.DestroyImmediate(box.gameObject);
            }
        }

        go.layer = LayerMask.NameToLayer(cm.Layer);

        var skin = transform.Find("skin");
        if (skin != null)
        {
            skin.SetLayer(cm.Layer, true);
        }

        go.tag = cm.Tag;
    }

    public void AddBehaviours(GameObject template)
    {
        GameObject go = this.Target;
        Component test = go.GetComponent<Game.AnimCallbackBehaviours>() ?? go.AddComponent<Game.AnimCallbackBehaviours>();
//        if (!Tid.Contains("npc999"))
//        {
//            test = go.GetComponent<Game.LuaRecvHitBehaviour>() ?? go.AddComponent<Game.LuaRecvHitBehaviour>();
//        }

//        var animatorStorable = go.GetComponent<Game.AnimatorStorable>() ?? go.AddComponent<Game.AnimatorStorable>();
//        animatorStorable.Populate();

//        var rigidbody = go.GetComponent<Rigidbody>();
//        if (rigidbody == null)
//        {
//            rigidbody = go.AddComponent<Rigidbody>();
//        }

        if (this.Animator.isHuman)
            this.Animator.applyRootMotion = false;
        else
            this.Animator.applyRootMotion = true;

//        var rigidbodyTemplate = template.GetComponent<Rigidbody>();
//        rigidbody.useGravity = false;
//        rigidbody.interpolation = rigidbodyTemplate.interpolation;
//        rigidbody.freezeRotation = rigidbodyTemplate.freezeRotation;
//        rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
//        rigidbody.isKinematic = true;
    }

    public void StripAvatar()
    {
        var animator = this.Target.GetComponent<Animator>();

        if (animator == null)
            return;
        if (animator.avatar == null)
            return;

        var avatarPath = GetAvatarPath();
        var avatarAsset = AssetDatabase.LoadAssetAtPath<Avatar>(avatarPath);
        if (avatarAsset == null)
        {
            avatarAsset = GameObject.Instantiate(animator.avatar);
            AssetDatabase.CreateAsset(avatarAsset, avatarPath);
        }
        EditorUtility.CopySerialized(animator.avatar, avatarAsset);
        avatarAsset.name = Path.GetFileNameWithoutExtension(avatarPath);
        animator.avatar = avatarAsset;
        EditorUtility.SetDirty(avatarAsset);
    }

    public void StripMesh()
    {
        var isNpc = !this.Tid.Contains("rda");
        if (isNpc)
            return;

        var renderers = this.Target.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        foreach (var renderer in renderers)
        {
            var partName = renderer.name;
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
            mesh.colors = new Color[0];
            mesh.uv2 = new Vector2[0];
            mesh.tangents = new Vector4[0];
            renderer.sharedMesh = mesh;
            EditorUtility.SetDirty(mesh);
        }
    }

    public void CombineMesh()
    {
        if (this.Tid.Contains("rda"))
            return;

        var go = this.Target;
        var allBones = go.GetComponentsInChildren<Transform>(true);
        var skinRoot = go.transform.Find("skin");
        if (skinRoot == null)
            return;

        var combineInstances = new List<CombineInstance>();
        var materials = new List<Material>();
        var bones = new List<Transform>();
        var renderers = go.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        var meshClones = new List<Mesh>();

        for (var i = 0; i < renderers.Length; ++i)
        {
            var smr = renderers[i];
            var mat = smr.sharedMaterial;
            if (mat.name.EndsWith("weapon", StringComparison.OrdinalIgnoreCase))
            {
                if (mat.mainTexture == null)
                {
                    Debug.Log(Tid + " weapon has no texture, it is a dummy; skipping");
                    continue;
                }
            }

            materials.Add(smr.sharedMaterial);
            var sharedMesh = smr.sharedMesh;

//             materials.AddRange(smr.sharedMaterials);
            if (sharedMesh.subMeshCount > 1) 
                Debug.LogError(go.name + " renderer " + smr.name + " submeshcount=" + smr.sharedMesh.subMeshCount);

            if (sharedMesh.subMeshCount > 1 && smr.name != "cigarette")
            {
                var meshClone = GameObject.Instantiate(sharedMesh);
                meshClone.SetTriangles(meshClone.triangles, 0);
                meshClones.Add(meshClone);

                var ci = new CombineInstance();
                ci.mesh = meshClone;
                ci.subMeshIndex = 0;
                combineInstances.Add(ci);

                for (var j = 0; j < smr.bones.Length; ++j)
                {
                    var bone = smr.bones[j];
                    var b = Array.Find(allBones, t => t.name == bone.name);
                    if (b != null)
                        bones.Add(b);
                }
            }
            else
            {
                var ci = new CombineInstance();
                ci.mesh = smr.sharedMesh;
                ci.subMeshIndex = 0;
                combineInstances.Add(ci);
                for (var j = 0; j < smr.bones.Length; ++j)
                {
                    var bone = smr.bones[j];
                    var b = Array.Find(allBones, t => t.name == bone.name);
                    if (b != null)
                        bones.Add(b);
                }
            }

        }

        for (var i = 0; i < renderers.Length; ++i)
        {
            var smr = renderers[i];

            if (smr == null || ((UnityEngine.Object)smr) == null)
                continue;

            GameObject.DestroyImmediate(smr);
        }

        var r = go.GetComponent<SkinnedMeshRenderer>();
        if (r == null)
            r = go.AddComponent<SkinnedMeshRenderer>();
        if (r.sharedMesh != null)
        {
            GameObject.Destroy(r.sharedMesh);
        }

        r.sharedMesh = new Mesh();
        r.sharedMesh.CombineMeshes(combineInstances.ToArray(), false, false);
        r.sharedMaterials = materials.ToArray();
        r.bones = bones.ToArray();
        r.receiveShadows = false;
        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        r.updateWhenOffscreen = false;
        r.motionVectors = false;
        r.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        r.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        r.sharedMesh.colors = new Color[0];
        r.sharedMesh.uv2 = new Vector2[0];
        r.sharedMesh.tangents = new Vector4[0];
        r.skinnedMotionVectors = false;

        var hips = go.transform.Find("skeleton/Hips");
        if (hips != null)
        {
            r.rootBone = hips;
        }


        var meshPath = this.GetPartMeshPath(go.name);
        var meshDir = Path.GetDirectoryName(meshPath);
        Directory.CreateDirectory(meshDir);
        var mesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
        if (mesh == null)
        {
            mesh = GameObject.Instantiate(r.sharedMesh);
            AssetDatabase.CreateAsset(mesh, meshPath);
        }

        foreach(var meshClone in meshClones)
        {
            GameObject.DestroyImmediate(meshClone);
        }

        mesh.Clear();
        EditorUtility.CopySerialized(r.sharedMesh, mesh);
        var meshName = Path.GetFileNameWithoutExtension(meshPath);
        mesh.name = meshName;
        r.sharedMesh = mesh;
        r.quality = SkinQuality.Auto;
        EditorUtility.SetDirty(mesh);
    }

    public void CreateDefaultParts()
    {
        if (!this.Tid.Contains("rda"))
        {
            return;
        }

        var skin = this.Target.transform.Find("skin");

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

            if (prefab != null)
            {
                LogUtil.Debug("replacing prefab " + path);
//                DynamicBoneHelper.CopyDynamicBonesAndColliders(prefab, part);
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

    private static string[] exposedBones = new string[] { "Hips", "skeleton", "skin", "Head", "Righthand", "Lefthand" };

    public void Save()
    {
        var go = this.Target;

        this.Animator.enabled = true;
        if (Tid.Contains("npc999"))
        {
            if (this.Animator.isOptimizable)
            {
                //AnimatorUtility.OptimizeTransformHierarchy(go, new string[] { });
            }
        }

        if (cm.MainScene && this.Animator.isOptimizable)
        {
            AnimatorUtility.OptimizeTransformHierarchy(go, exposedBones);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
        }

        var prefabPath = GetPrefabPath();
        Directory.CreateDirectory(Path.GetDirectoryName(prefabPath));
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null)
        {
            LogUtil.Debug("create prefab " + prefabPath);
            PrefabUtility.CreatePrefab(prefabPath, go, ReplacePrefabOptions.ConnectToPrefab);
        }
        else
        {
            LogUtil.Debug("replace prefab " + prefabPath);
            PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
            EditorUtility.SetDirty(prefab);
        }

    }

    protected string GetPrefabPath()
    {
        if (prefabPath == null)
        {
            if (!cm.MainScene)
                return "Assets/Prefab/characters/" + Skeleton + "_" + Tid + ".prefab";
            else
                return "Assets/Prefab/characters_mainscene/" + Skeleton + "_" + Tid + "_ms.prefab";
        }
        else
        {
            return prefabPath;
        }
    }

    protected string GetControllerHolderPath()
    {

        return "Assets/Prefab/character_controllers/" + Skeleton + "_" + Tid + "_controller.prefab";
    }

    private string GetPartPrefabPath(string part)
    {
        return "Assets/Prefab/clothes/" + part + "/" + GetPartFileName(part) + ".prefab";
    }


    private string GetPartMeshPath(string part)
    {
        return "Assets/Model/characters/" + GetCharacterName() + "/mesh/" + GetPartFileName(part) + ".asset";
    }

    private string GetAvatarPath()
    {
        var name = GetCharacterName();
        return "Assets/Model/characters/" + name + "/" + name + "_avatar.asset";
    }

    private string GetCharacterName()
    {
        return  Skeleton + "_" + Tid;
    }

    private string GetPartFileName(string part)
    {
        if (part.Contains(this.Skeleton))
            return part;

        return this.Skeleton + "_" + part + "_" + this.Tid;
    }
}

