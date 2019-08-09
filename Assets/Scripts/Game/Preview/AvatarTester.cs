using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

#if UNITY_EDITOR

using UnityEditor;



public class AvatarTester : MonoBehaviour
{
    public GameObject reference;
    public GameObject effect;
    public Vector2 size;
    private Vector2 scrollPosition;
    private Vector2 scrollPosition2;
    private Vector2 scroll2;

    private Transform[] myBones;
    private Transform skin;
    private Animator animator;
    private UnityEditor.Animations.AnimatorController controller;
    private AnimationClip[] clips;
    private AnimationClip sampledClip;
    private float time;
    private UnityEditor.Animations.AnimatorControllerLayer baseAnimLayer;
    private List<GameObject> clothes;
    private List<GameObject> roles;
    private string bonename = null;
    private Transform skeleton = null;
    private static string[] allParts = new string[]
    {
        "face",
        "head",
        "leg",
        "eyewear",
        "hair",
        "torso",
        "weapon",
        "phone"
    };

    private static string[] allRoles = new string[]
    {
        "daoshi001_rda001",
        "huyao001_rda021",
        "qipa001_rda031",
    };

    private bool isTracking = false;
    private Vector2 lastPoint = new Vector2();

    private Dictionary <string, List<GameObject>> clothesParts = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, bool> selectedParts = new Dictionary<string, bool>();


    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.controller = this.animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        this.clips = this.controller.animationClips;
        this.baseAnimLayer = this.controller.layers.ElementAt(0);
     
        this.skin = transform.Find("skin");
        this.skeleton = transform.Find("skeleton");
        this.myBones = this.skeleton.GetComponentsInChildren<Transform>(true);
        this.bonename = this.controller.name.Split('_')[0];

        if (effect != null)
        {
            effect.SetActive(false);
        }

        clothes = new List<GameObject>();


        var files = Directory.GetFiles("Assets/Prefab/clothes/", "*.prefab", SearchOption.AllDirectories);
        foreach (var f in files)
        {
            Debug.Log(f);
            if (f.Contains(this.bonename))
                clothes.Add(AssetDatabase.LoadAssetAtPath<GameObject>(f));
        }

        foreach (var part in allParts)
        {
            foreach (var cloth in clothes)
            {
                if (cloth.name.Contains(part))
                {
                    List<GameObject> list = null;
                    if (!clothesParts.TryGetValue(part, out list))
                    {
                        list = new List<GameObject>();
                        clothesParts[part] = list;
                    }

                    list.Add(cloth);
                }
            }

            this.selectedParts[part] = false;
        }

        this.transform.position = new Vector3(0f, 1.3f, 0f);
        this.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        this.transform.localScale = Vector3.one;
    }

    void ChangePart(GameObject o)
    {
        var container = GameObject.Instantiate(o);
        var partName = o.name.Split('_')[1];

        var part = container.transform.Find("skin/" + partName);
        var smr = part.GetComponent<SkinnedMeshRenderer>();
        var bones = new List<Transform>();
        foreach (var bone in smr.bones)
        {
            var b = this.FindBone(bone.name);
            if (b != null)
            {
                bones.Add(b);
            }
            else
            {
                Debug.LogError(string.Format(" {0} bone {1} not found on {2}", o.name, bone.name, this.gameObject.name ));
            }
        }

        var oldPart = transform.Find("skin/" + partName);


        var newPart = new GameObject(partName);
        newPart.transform.parent = this.skin;
        var newSmr = newPart.AddComponent<SkinnedMeshRenderer>();
        newSmr.sharedMaterials = smr.sharedMaterials;
        newSmr.sharedMesh = smr.sharedMesh;
        newSmr.bones = bones.ToArray();
        newPart.name = partName;
        var rootBone = FindBone(smr.rootBone.name);
        newSmr.rootBone = rootBone;

        GameObject.Destroy(oldPart.gameObject);
        GameObject.Destroy(container);
    }

    Transform FindBone(string bonename)
    {
        foreach (var bone in this.myBones)
        {
            if (bone.name == bonename)
            {
                return bone;
            }
        }
        return null;
    }

    void Update()
    {
        if (this.sampledClip != null)
        {
            this.time += Time.deltaTime;
            if (this.time > this.sampledClip.length)
            {
                this.time = 0;
            }
            UnityEditor.AnimationMode.SampleAnimationClip(this.gameObject, this.sampledClip, (float)this.time);
        }
        else
        {
            this.time = 0;
        }

        CheckRotation();
    }

    void CheckRotation()
    {
        //        bool rotting = false;
        //        Vector3 rot = new Vector3(0, 0, 0);
        if (Input.GetButtonDown("Fire1"))
        {
            var mouse = Input.mousePosition;
            var screenPos = new Vector2(mouse.x, mouse.y);
            lastPoint = screenPos;
            isTracking = true;

        }

        if (Input.GetButton("Fire1") && isTracking)
        {
            var mouse = Input.mousePosition;
            var screenPos = new Vector2(mouse.x, mouse.y);
            var delta = screenPos - lastPoint;
            OnRotate(delta);
            lastPoint = screenPos;
            isTracking = true;
        }

        if (Input.GetButtonUp("Fire1") && isTracking)
        {
            isTracking = false;
            lastPoint = Vector2.zero;
        }

    }

    void OnRotate(Vector2 delta)
    {
        var angle = this.transform.localEulerAngles;
        this.transform.localEulerAngles = new Vector3(0, angle.y - delta.x, 0);
    }



    /// <summary>
    /// Combine the SkinnedMeshRenderer
    /// </summary>
    private void Combine()
    {
        var allBones = transform.GetComponentsInChildren<Transform>(true);
        var combineInstances = new List<CombineInstance>();
        var materials = new List<Material>();
        var bones = new List<Transform>();
        var renderers = transform.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var smr in renderers)
        {
            materials.AddRange(smr.sharedMaterials);
            for (int sub = 0; sub < smr.sharedMesh.subMeshCount; ++sub)
            {
                var ci = new CombineInstance();
                ci.mesh = smr.sharedMesh;
                ci.subMeshIndex = sub;
                combineInstances.Add(ci);
                foreach (var bone in smr.bones)
                {
                    var b = Array.Find(allBones, t => t.name == bone.name);
                    if (b != null)
                        bones.Add(b);
                }
            }

            smr.enabled = false;
        }

        var r = gameObject.AddComponent<SkinnedMeshRenderer>();
        r.sharedMesh = new Mesh();
        r.sharedMesh.CombineMeshes(combineInstances.ToArray(), false, false);
        r.sharedMaterials = materials.ToArray();
        r.bones = bones.ToArray();
        r.receiveShadows = false;
        r.castShadows = false;
        r.updateWhenOffscreen = false;
    }


    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(size.x), GUILayout.Height(size.y));
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.Label("Animator States");
        if (baseAnimLayer == null)
        {
            baseAnimLayer = this.controller.layers.ElementAt(0);
        }
        var states = baseAnimLayer.stateMachine.states;
        Array.Sort(states, (x,y) => {
            return x.state.name.CompareTo(y.state.name);
        });
   
 
        for (int i = 0; i < states.Length; i++)
        {
            var state = states[i];
            if (GUILayout.Button(state.state.name, EditorStyles.miniButtonMid))
            {
                this.sampledClip = state.state.motion as AnimationClip;
                this.time = 0;
                this.animator.enabled = false;
            }
        }
        GUILayout.EndVertical();


        bool needDistroy = false;

        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.Label("Change Character");
        for (int i = 0; i < allRoles.Length; i++)
        {
            var roleName = allRoles[i];
            var assetPath = "Assets/Prefab/characters/" + roleName + ".prefab";

            if (GUILayout.Button(roleName, EditorStyles.miniButtonMid))
            {
                var prefabgo = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                var newRole = GameObject.Instantiate(prefabgo);
                AvatarTester newAT = newRole.AddComponent<AvatarTester>();
                needDistroy = true;
            }
        }

        GUILayout.Label("Preview Avatar");
        foreach (var pair in this.clothesParts)
        {
            var part = pair.Key;
            var list = pair.Value;

            this.selectedParts[part] = GUILayout.Toggle(this.selectedParts[part], part);
            if (this.selectedParts[part])
            {
                foreach (var c in list)
                {
                    if (GUILayout.Button(c.name, EditorStyles.miniButtonMid))
                    {
                        ChangePart(c);
                    }
                }
            }
        }

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();

        if (needDistroy)
        {
            Destroy(this.gameObject);
        }

    }
}
#endif
