using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CinemaDirector;
using LBoot;

public class CutscenePostProcessor : AssetModificationProcessor
{

    //    public static string[] OnWillSaveAssets(string[] paths)
    //    {
    //        // Get the name of the scene to save.
    //        string scenePath = string.Empty;
    //        string sceneName = string.Empty;
    //
    //        foreach (string path in paths)
    //        {
    //            if (path.Contains(".unity"))
    //            {
    //                scenePath = Path.GetDirectoryName(path);
    //                sceneName = Path.GetFileNameWithoutExtension(path);
    //            }
    //        }
    //
    //        if (sceneName.Length == 0)
    //        {
    //            return paths;
    //        }
    //
    //        //ProcessCutscene(sceneName);
    //
    //        return paths;
    //    }


    public static void ProcessCSGO(GameObject go)
    {
        string sceneName = go.name;
		CutsceneCast cc = go.GetComponentInChildren<CutsceneCast>();
		Cutscene cs = go.GetComponentInChildren<Cutscene>();
        _DoProcessCS(cc, cs, sceneName);
    }

    public static void ProcessCutscene(string sceneName)
    {
        CutsceneCast cc = GameObject.FindObjectOfType<CutsceneCast>();
        Cutscene cs = GameObject.FindObjectOfType<Cutscene>();
        _DoProcessCS(cc, cs, sceneName);
    }

    private static void _DoProcessCS(CutsceneCast cc, Cutscene cs, string sceneName)
    {
        GameObject root = null;
        if (cc == null)
        {
            if (cs == null)
            {
                return;
            }
            if (cs.gameObject.transform.parent == null)
            {
                root = new GameObject();
                root.name = "CutsceneAnchor";

                cs.gameObject.transform.parent = root.transform;

                GameObject actors = new GameObject();
                actors.name = "Actors";
                actors.transform.parent = root.transform;

                GameObject cameras = new GameObject();
                cameras.name = "Cameras";
                cameras.transform.parent = root.transform;

                var prefabc = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/cutscenes/Canvas.prefab");
                var pgo = GameObject.Instantiate(prefabc);
                pgo.name = "Canvas";
                pgo.transform.parent = root.transform;

                var prefabes = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/cutscenes/EventSystem.prefab");
                var pgoes = GameObject.Instantiate(prefabes);
                pgoes.name = "EventSystem";
            }
            else
            {
                root = cs.gameObject.transform.parent.gameObject;
            }
            cc = root.AddComponent<CutsceneCast>();
        }

		cs.Stop ();

        if (root == null)
        {
            root = cs.gameObject.transform.parent.gameObject;
        }

        RemoveGuiTextureForTransitionComp<ColorTransition>(root);
        RemoveGuiTextureForTransitionComp<FadeFromBlack>(root);
        RemoveGuiTextureForTransitionComp<FadeFromWhite>(root);
        RemoveGuiTextureForTransitionComp<FadeToBlack>(root);
        RemoveGuiTextureForTransitionComp<FadeToWhite>(root);

        if (sceneName != null && root.name != sceneName)
        {
            root.name = sceneName;
        }

        cc.RefreshData();
        cc.Cutscene = cs;

        RefreshCutscenePrefabActors(root);

        // remove all audio listeners
        RemoveAllComponents<AudioListener>(root);
        RemoveAllComponents<MeshCollider>(root);

        if (sceneName != null)
        {
            UpdatePrefab(root, sceneName);
        }
    }


    public static void FixNestedPrefabs()
    {
        CutsceneCast cc = GameObject.FindObjectOfType<CutsceneCast>();
        Cutscene[] css = GameObject.FindObjectsOfType<Cutscene>();
		_DoFixNextedPrefabs (cc, css);
	}

	private static void _DoFixNextedPrefabs(CutsceneCast cc, Cutscene[] css)
	{
		GameObject root = null;

		if (cc == null)
		{
			return;
		}

		foreach (var cs in css) {
			root = cs.gameObject.transform.parent.gameObject;
			RefreshCutscenePrefabActors (root);
			ReplaceCutscenePrefabActors (root);
		}
	}

	public static void FixNextedPrefabsByGO(GameObject go)
	{
		CutsceneCast cc = go.GetComponentInChildren<CutsceneCast>();
		Cutscene[] css = go.GetComponentsInChildren<Cutscene>(true);
		_DoFixNextedPrefabs (cc, css);
	}

    private static void RefreshCutscenePrefabActors(GameObject root)
    {
        Transform actorRoot = root.transform.Find("Actors");
        if (actorRoot == null)
            return;

        foreach (Transform ta in actorRoot)
        {
            CutscenePrefabActor pba = ta.gameObject.GetComponent<CutscenePrefabActor>();
            if (pba == null)
            {
                pba = ta.gameObject.AddComponent<CutscenePrefabActor>();
            }
            pba.CheckPrefab();
        }
    }

    private static void ReplaceCutscenePrefabActors(GameObject root)
    {
        Transform actorRoot = root.transform.Find("Actors");
        if (actorRoot == null)
            return;
        
        var prefabActors = actorRoot.GetComponentsInChildren<CutscenePrefabActor>(true);

        // set all the actors back parented to the actor root
        foreach (var pba in prefabActors)
        {
            pba.transform.SetParent(actorRoot);
        }

        foreach (var pba in prefabActors)
        {
            pba.RefreshPrefab();
        }
    }

    private static void RemoveAllComponents<TClass>(GameObject root) where TClass : UnityEngine.Object
    {
        TClass[] als = root.GetComponentsInChildren<TClass>(true);
        foreach (TClass al in als)
        {
            UnityEngine.Object.DestroyImmediate(al);
        }
    }

    private static void UpdatePrefab(GameObject root, string sceneName)
    {
        string path = "Assets/Prefab/cutscenes/" + sceneName + ".prefab";
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        
        if (prefab != null)
        {
            LogUtil.Debug("replacing prefab " + path);
            PrefabUtility.ReplacePrefab(root, PrefabUtility.GetPrefabParent(root), ReplacePrefabOptions.ConnectToPrefab);
        }
        else
        {
            LogUtil.Debug("creating prefab " + path);
            PrefabUtility.CreatePrefab(path, root, ReplacePrefabOptions.ConnectToPrefab);
        }
        AssetDatabase.Refresh();
    }

    private static void RemoveGuiTextureForTransitionComp<TransitionClass>(GameObject root) where TransitionClass : MonoBehaviour
    {
        TransitionClass[] tcs = root.GetComponentsInChildren<TransitionClass>();
        foreach (TransitionClass tc in tcs)
        {
            GUITexture gtx = tc.gameObject.GetComponent<GUITexture>();
            if (gtx != null)
            {
                UnityEngine.Object.DestroyImmediate(gtx);
            }
        }
    }

}
