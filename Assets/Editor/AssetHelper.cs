using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LBoot;
using UnityEngine.UI;
using System.Text;

namespace LBootEditor
{
    public class AssetHelper
    {

        public static void CreateFontAsset()
        {

        }

        class Texture2DInfo
        {
            public Texture2D texture;
            public string path;
        }

        public static EditorCurveBinding[] GetObjectBindings(AnimationClip clip)
        {
            return AnimationUtility.GetObjectReferenceCurveBindings(clip).Where(x =>
                {
                    return x.type == typeof(Image);
                }
            ).ToArray();
        }

        [MenuItem("Tools/Assets/Print Standard Shader Materials", false, 100)]
        public static void FindStandardShaderMaterials()
        {
//            AssetDatabase.getas
//            var files = Directory.GetFiles("Assets/Models/", "*.mat", SearchOption.AllDirectories);
            var guids = AssetDatabase.FindAssets("t:Material", new string[] { "Assets/Models/streets" });
            var sb = new StringBuilder();
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mat = AssetDatabase.LoadAssetAtPath<Material>(path);
                if (mat.shader.name.Contains("Standard"))
                {
                    sb.AppendLine(path);
                }
            }

            Debug.Log(sb.ToString());
            File.WriteAllText("scene_textures/all_materials_using_standard_shaders.txt", sb.ToString());
        }

        [MenuItem("Tools/Assets/Fix all Animation textures", false, 100)]
        public static void FixAnimationsWithSymbols()
        {
            var animations = Directory.GetFiles("Assets/Animator/ui_animator", "*.anim", SearchOption.AllDirectories).ToList();
            animations.AddRange(Directory.GetFiles("Assets/images/uianim", "*.anim", SearchOption.AllDirectories));

            var symbolSprites = AssetDatabase.LoadAssetAtPath<SpriteAsset>("Assets/images/ui/symbol.asset");
            foreach (var file in animations)
            {
                var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(file);
                var bindings = GetObjectBindings(clip);
                foreach (var b in bindings)
                {
                    LogUtil.Debug("file " + b.type.ToString());
                    ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(clip, b);
                    for (var i = 0; i < keyframes.Length; i++)
                    {
                        var frame = keyframes[i];
                        if (frame.value is Sprite)
                        {
                            LogUtil.Debug(frame.value.name);
                            var sprite = symbolSprites.GetSprite(frame.value.name);
                            if (sprite != null)
                            {
                                frame.value = sprite;
                                LogUtil.Debug("fixing animation " + file);

                                keyframes[i] = frame;
                            }
                        }
                    }
                    AnimationUtility.SetObjectReferenceCurve(clip, b, keyframes);
                }
                EditorUtility.SetDirty(clip);


            }
            AssetDatabase.SaveAssets();
        }

        private static void _FixAllUITexturesWithSymbol(SpriteAsset spriteAsset)
        {
            var iconSprites = spriteAsset;
            var prefabs = Directory.GetFiles("Assets/Prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();
            //prefabs.AddRange(Directory.GetFiles("Assets/Prefab/cutscenes/", "*.prefab", SearchOption.AllDirectories));

            foreach (var file in prefabs)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
                var images = prefab.GetComponentsInChildren<Image>(true);
                var buttons = prefab.GetComponentsInChildren<Button>(true);
                if (images.Length == 0 && buttons.Length == 0)
                    continue;

                foreach (var image in images)
                {
                    if (image.sprite == null)
                        continue;

                    var name = image.sprite.name;
                    var sprite = iconSprites.GetSprite(name);

                    if (sprite != null)
                    {
                        image.sprite = sprite;
                        EditorUtility.SetDirty(prefab);
                    }
                }


                //                LogUtil.Debug(file);
                EditorUtility.SetDirty(prefab);
            }



            AssetDatabase.SaveAssets();
        }

        [MenuItem("Tools/Assets/Fix all symbol textures", false, 100)]
        public static void FixAllUITexturesWithSymbol()
        {
            var iconSprites = AssetDatabase.LoadAssetAtPath<SpriteAsset>("Assets/images/ui/gem.asset");
            _FixAllUITexturesWithSymbol(iconSprites);

            // iconSprites = AssetDatabase.LoadAssetAtPath<SpriteAsset>("Assets/images/ui/btn2.asset");
            // _FixAllUITexturesWithSymbol(iconSprites);

//            iconSprites = AssetDatabase.LoadAssetAtPath<SpriteAsset>("Assets/images/ui/debri.asset");
//            _FixAllUITexturesWithSymbol(iconSprites);
        }

        [MenuItem("Tools/Assets/Fix all missing image", false, 100)]
        public static void FixAllMissingImage()
        {
            var prefabs = Directory.GetFiles("Assets/Prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();
            //prefabs.AddRange(Directory.GetFiles("Assets/Prefab/cutscenes/", "*.prefab", SearchOption.AllDirectories));
            var sprites = UnityEditor.AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/images/icons/empty.png").Cast<Sprite>().ToList();
            Sprite empty = null;
            foreach (var s in sprites)
            {
                empty = s;
                break;
            }
            foreach (var file in prefabs)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
                var images = prefab.GetComponentsInChildren<Image>(true);

//                var textureMeshPros = prefab.GetComponentsInChildren<TMPro.TMP_Text>(true);

                foreach (var image in images)
                {
                    SerializedObject so = new SerializedObject(image);
                    SerializedProperty property = so.FindProperty("m_Sprite");
                    if (property.propertyType == SerializedPropertyType.ObjectReference)
                    {
                        if (property.objectReferenceValue == null
                            && property.objectReferenceInstanceIDValue != 0)
                        {
                            ShowError("image", prefab, image.GetType().Name, ObjectNames.NicifyVariableName(property.name));
                            image.sprite = empty;
                            EditorUtility.SetDirty(prefab);
                        }
                    }
                }

//                foreach (var p in textureMeshPros)
//                {
//                    GameObject.DestroyImmediate(p);
//                    EditorUtility.SetDirty(prefab);
//                }

            }



            AssetDatabase.SaveAssets();
        }

        private static Material GetTextureAlphaMaterial(Texture2D texture, String texturePath = null)
        {
            if (texturePath == null)
                texturePath = AssetDatabase.GetAssetPath(texture);

            string maskPath = texturePath.Replace("Images", "Images_mask");
            var filename = Path.GetFileNameWithoutExtension(texturePath);
            maskPath = maskPath.Replace(filename, filename + "_Mask");

            var mask = AssetDatabase.LoadAssetAtPath<Texture2D>(maskPath);
            if (mask != null)
            {
                Debug.Log("maskpath = " + maskPath);
                var matPath = texturePath.Replace("Images", "Images_Mask");
                matPath = matPath.Replace(".png", ".mat");
                var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
                if (mat == null)
                {
                    mat = new Material(Shader.Find("SpriteWithMask"));
                    mat.SetTexture("_AlphaTex", mask);
                    AssetDatabase.CreateAsset(mat, matPath);
                }

                return mat;

                // image.material = mat;
                // EditorUtility.SetDirty(prefab);
            }

            return null;
        }

        [MenuItem("Tools/Assets/Fix all images with alpha mask", false, 100)]
        public static void FixAllImagesWithMask()
        {
            var prefabs = Directory.GetFiles("Assets/Prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();
            //prefabs.AddRange(Directory.GetFiles("Assets/Prefab/cutscenes/", "*.prefab", SearchOption.AllDirectories));

            foreach (var file in prefabs)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
                var images = prefab.GetComponentsInChildren<Image>(true);

                foreach (var image in images)
                {
                    var sprite = image.sprite;
                    Texture2D texture = null;
                    string texturePath = null;

                    if (sprite != null)
                    {
                        texture = sprite.texture;
                        texturePath = AssetDatabase.GetAssetPath(texture);
                    }
                    else
                    {
                        continue;
                    }

                    if (texturePath == null)
                        continue;

                    if (!texturePath.Contains("images/"))
                        continue;

                    if (texturePath.Contains("empty.png"))
                        continue;

                    //var filename = Path.GetFileNameWithoutExtension(texturePath);
                    var mat = GetTextureAlphaMaterial(texture, texturePath);

                    if (mat != null)
                    {
                        image.material = mat;
                        EditorUtility.SetDirty(prefab);
                    }
                    else
                    {
                        if (image.material != null)
                        {
                            Debug.Log("name = " + image.material.shader.name);
                            if (image.material.shader.name == "SpriteWithMask")
                            {
                                image.material = null;
                                EditorUtility.SetDirty(prefab);
                            }
                        }
                    }
                }
            }

            AssetDatabase.SaveAssets();
        }


        [MenuItem("Tools/Assets/Show Missing Object References in scene", false, 50)]
        public static void FindMissingReferencesInCurrentScene()
        {
            var objects = GetSceneObjects();
            FindMissingReferences(Path.GetFileNameWithoutExtension(EditorApplication.currentScene), objects);
        }


        [MenuItem("Tools/Assets/Show Missing Object References in assets", false, 52)]
        public static void MissingComponentAssets()
        {
            var obj = Selection.activeObject;
            var objs = new List<GameObject>();

            if (obj is GameObject)
            {
                objs.Add(obj as GameObject);
            }
            else
            {
                var path = AssetDatabase.GetAssetPath(obj);
                var files = Directory.GetFiles(path + "/", "*.prefab", SearchOption.AllDirectories);
                foreach (var o in files)
                {
                    Debug.Log(o);
                    objs.Add(AssetDatabase.LoadAssetAtPath<GameObject>(o));
                }
                Debug.Log(objs.Count());
            }

            FindMissingReferences("Project", objs.ToArray(), true);
        }

        private static void FindMissingReferences(string context, GameObject[] objects, bool deep = false)
        {
            foreach (var go in objects)
            {

                var components = go.GetComponents<Component>();
                Transform[] transforms = new Transform[] { go.transform };
                if (deep)
                {
                    transforms = go.GetComponentsInChildren<Transform>(true);
                }

                foreach (var t in transforms)
                {
//                    var serializedObject = new SerializedObject(t.gameObject);
                    var comps = t.gameObject.GetComponents<Component>();
//                    var shouldSave = false;
//                    // Find the component list property
//                    var prop = serializedObject.FindProperty("m_Component");
//
//                    // Iterate over all components
//                    for (int j = comps.Length - 1; j >= 0; j--)
//                    {
//                        // Check if the ref is null
//                        if (comps[j] == null)
//                        {
//                            // If so, remove from the serialized component array
//                            prop.DeleteArrayElementAtIndex(j);
//                            shouldSave = true;
//                        }
//                    }
//
//                    if (shouldSave)
//                        serializedObject.ApplyModifiedProperties();


                    foreach (var c in comps)
                    {
                        if (!c)
                        {

//                            var name = "";
                            Debug.LogError("Missing Component in GO: " + FullPath(go) + " child=" + t.name, go);
                            continue;
                        }

                        SerializedObject so = new SerializedObject(c);
                        var sp = so.GetIterator();

                        while (sp.NextVisible(true))
                        {
                            if (sp.propertyType == SerializedPropertyType.ObjectReference)
                            {
                                if (sp.objectReferenceValue == null
                                    && sp.objectReferenceInstanceIDValue != 0)
                                {
                                    ShowError(context, go, c.GetType().Name, c.name, ObjectNames.NicifyVariableName(sp.name));
                                }
                            }
                        }
                    }

                }


//                EditorUtility.SetDirty(go);
            }

//            EditorApplication.SaveAssets();

        }

        private static GameObject[] GetSceneObjects()
        {
            return GameObject.FindObjectsOfType<GameObject>()
                    .Where(go => string.IsNullOrEmpty(AssetDatabase.GetAssetPath(go))
                && go.hideFlags == HideFlags.None).ToArray();
        }

        private const string err = "Missing Ref in: [{3}]{0}. Component: {1}, Property: {2}, Child: {4}";

        private static void ShowError(string context, GameObject go, string c, string childName, string property)
        {
            Debug.LogError(string.Format(err, FullPath(go), c, property, context, childName), go);
        }

        private static void ShowError(string context, GameObject go, string c, string property)
        {
            Debug.LogError(string.Format(err, FullPath(go), c, property, context, ""), go);
        }

        private static string FullPath(GameObject go)
        {
            return go.transform.parent == null
                    ? go.name
                        : FullPath(go.transform.parent.gameObject) + "/" + go.name;
        }


        //        [MenuItem("Tools/Assets/Fix ScreenSpace", false, 100)]
        public static void FixScreenSpace()
        {
            var prefabs = Directory.GetFiles("Assets/Prefab/ui/", "*.prefab", SearchOption.AllDirectories).ToList();

            foreach (var file in prefabs)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
                var canvas = prefab.GetComponent<Canvas>();
                if (canvas != null)
                {
                    if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                    {
                        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                        EditorUtility.SetDirty(prefab);
                    }
                }

            }



            AssetDatabase.SaveAssets();
        }



        //[MenuItem("Tools/Assets/Remove Cutscene AnimatorStorable", false, 100)]
        public static void RemoveCutsceneAnimatorStorable()
        {
            var prefabs = Directory.GetFiles("Assets/Prefab/cutscenes/", "*.prefab", SearchOption.AllDirectories).ToList();

            foreach (var file in prefabs)
            {
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
                var list = prefab.GetComponentsInChildren<Game.AnimatorStorable>(true);
                if (list.Length == 0)
                    continue;

                var go = GameObject.Instantiate(prefab);
                list = go.GetComponentsInChildren<Game.AnimatorStorable>(true);

                var save = false;
                for (var i = list.Length - 1; i >= 0; i--)
                {
                    GameObject.DestroyImmediate(list[i]);
                    save = true;
                }

                if (save)
                {
                    PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
                    EditorUtility.SetDirty(prefab);
                }

                GameObject.DestroyImmediate(go);
            }

            AssetDatabase.SaveAssets();
        }

        [MenuItem("Tools/Assets/Print all textures", false, 100)]
        public static void PrintTextures()
        {
            string[] guids = AssetDatabase.FindAssets("t:texture2D");
            List<Texture2DInfo> list = new List<Texture2DInfo>();

            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                Texture2D t = (Texture2D)AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D));
                if (t != null)
                {
                    var info = new Texture2DInfo();
                    info.texture = t;
                    info.path = path;
                    list.Add(info);
                }
            }

            List<Texture2DInfo> sorted = list.OrderBy(o => (-o.texture.width * o.texture.height)).ToList();
            foreach (Texture2DInfo info in sorted)
            {
                var t = info.texture;
                LogUtil.Debug("path=" + info.path + " size=" + t.width + "x" + t.height + " mipmaps=" + t.mipmapCount + " format=" + t.format);
            }
        }

        [MenuItem("Tools/Assets/Create sprite Assets for images", false, 100)]
        public static void CreateSpriteAssets()
        {
			var textures = Directory.GetFiles("Assets/images/ui/", "*.png", SearchOption.AllDirectories).ToList();
//            textures.AddRange(Directory.GetFiles("Assets/images/uianim/", "*.png", SearchOption.AllDirectories));

            foreach (var f in textures)
            {
                var dir = Path.GetDirectoryName(f);
                var image = AssetDatabase.LoadAssetAtPath<Texture2D>(f);
                if (image == null)
                {
                    AssetDatabase.ImportAsset(f);
                }

                var mat = GetTextureAlphaMaterial(image);
                var sprites = UnityEditor.AssetDatabase.LoadAllAssetRepresentationsAtPath(f).Cast<Sprite>().ToList();

                Debug.Log(f);

                var path = dir + "/" + image.name + ".asset";
                var spriteAsset = AssetDatabase.LoadAssetAtPath<SpriteAsset>(path);
                var created = false;

                if (spriteAsset == null)
                {
                    spriteAsset = LBoot.SpriteAsset.Create();
                    created = true;
                }

                spriteAsset.Fill(sprites.ToArray());

                if (created)
                {
                    AssetDatabase.CreateAsset(spriteAsset, path);
                }

                EditorUtility.SetDirty(spriteAsset);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.SaveAssets();
        }
       
        [MenuItem("Tools/Assets/read sprite Assets for images", false, 100)]
        public static void ReadSpriteAsset()
        {
            var assets = Directory.GetFiles("Assets/images/icons/", "*.asset", SearchOption.AllDirectories).ToList();

            foreach (var f in assets)
            {
                var dir = Path.GetDirectoryName(f);
                var spriteAsset = AssetDatabase.LoadAssetAtPath<LBoot.SpriteAsset>(f);
                LogUtil.Debug(spriteAsset.name);
                spriteAsset.Dump();

            }
        }

        [MenuItem("Tools/Assets/Count Textures for scenes", false, 100)]
        public static void CountTextures()
        {
            var scenes = Directory.GetFiles("Assets/Scenes/game/streets", "cit*.unity", SearchOption.TopDirectoryOnly);
            var str = new StringBuilder();
            foreach (var path in scenes)
            {
                var name = Path.GetFileNameWithoutExtension(path);
                var depends = AssetDatabase.GetDependencies(path);
                Dictionary<String,bool> textures = new Dictionary<String, bool>();
                Dictionary<int, float> sizes = new Dictionary<int, float>
                {
                    { 512, 1f },
                    { 1024, 4f },
                    { 256, 0.25f },
                    { 128, 0.125f },
                    { 2048, 16f },
                    { 64, 0.125f / 4 },
                    { 32, 0.125f / 16 },
                };

                float count = 0f;

                foreach (var depend in depends)
                {
                    if (depend.StartsWith("Assets/Models/") && depend.EndsWith(".TGA", StringComparison.OrdinalIgnoreCase))
                    {

                        textures[depend] = true;
                        var texture = AssetDatabase.LoadAssetAtPath<Texture>(depend);
                        if (sizes.ContainsKey(texture.width))
                            count += sizes[texture.width];
                        else
                        {
                        }
//                            Debug.LogError(depend + " size " + texture.width.ToString() + " not valid");
                    }
                }

                str.AppendLine(name + " 512x512 Texture Count:" + count);
                var list = textures.Keys.ToArray();
                Array.Sort(list);
                File.WriteAllLines("scene_textures/" + name + "_textures.txt", list);

            }

            Debug.Log(str.ToString());
        }

        [MenuItem("Tools/Assets/Check LightmapUberShader Keyword Usage", false, 100)]
        public static void CheckShaderKeywordUsage()
        {
            Dictionary<string, Dictionary<string, int> > res = new Dictionary<string, Dictionary<string, int> >();

            string sPattern = "LightmapUber";
            string sPrefabPath = "Assets/";
            string[] aMatNames = Directory.GetFiles(sPrefabPath, "*.mat", SearchOption.AllDirectories);
            foreach (string matName in aMatNames)
            {
                Material mat = AssetDatabase.LoadAssetAtPath(matName, typeof(Material)) as Material;
                if (mat == null || !mat.shader.name.Contains(sPattern))
                {
                    continue;
                }
                string shaderName = mat.shader.name;

                Dictionary<string, int> sdata = null;
                if (res.ContainsKey(shaderName))
                {
                    sdata = res[shaderName];
                }
                else
                {
                    sdata = new Dictionary<string, int>();
                    res.Add(shaderName, sdata);
                }

                foreach (string sk in mat.shaderKeywords)
                {
                    if (mat.IsKeywordEnabled(sk))
                    {
                        if (sdata.ContainsKey(sk))
                        {
                            sdata[sk] += 1;
                        }
                        else
                        {
                            sdata.Add(sk, 1);
                        }
                    }
                }
            }

            string sRes = "";
            foreach (KeyValuePair<string, Dictionary<string, int> > entry in res)
            {
                sRes = sRes + entry.Key + ":\n";
                foreach (KeyValuePair<string, int> ddata in entry.Value)
                {
                    sRes = sRes + "     name:" + ddata.Key + ", count:" + ddata.Value.ToString() + "\n";
                }
            }

            Debug.Log(sRes);
        }

    }
}

