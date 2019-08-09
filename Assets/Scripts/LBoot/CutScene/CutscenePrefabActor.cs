using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CinemaDirector;
using SLua;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomLuaClassAttribute, Serializable]
public class CutscenePrefabActor : MonoBehaviour
{
    public string prefabPath = null;

#if UNITY_EDITOR

    void Awake()
    {
        CheckPrefab();
    }

    [SLua.DoNotToLua]
    public void CheckPrefab()
    {
        CutsceneCast cc = this.gameObject.GetComponentInParent<CutsceneCast>();
        if (cc == null)
            return;

        var ccPrefabObj = PrefabUtility.GetPrefabParent(cc.gameObject);
        var prefabObj = PrefabUtility.GetPrefabParent(this.gameObject);
        if (prefabObj != null && ccPrefabObj != null)
        {
            var pp = AssetDatabase.GetAssetPath(prefabObj);
            var ccpp = AssetDatabase.GetAssetPath(ccPrefabObj);
            if (pp != ccpp)
            {
                prefabPath = pp;
            }
        }
    }


    [SLua.DoNotToLua]
    public void RefreshPrefab()
    {
        if (prefabPath == null || prefabPath == "")
            return;

        var prefabc = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        Debug.Log("before check refresh prefab " + prefabPath.ToString());

        if (prefabc == null)
        {
            Debug.Log("prefabc is null " + prefabPath.ToString());

            string path = CommonUtils.findPrefabPath(prefabPath);
            if (path != null)
            {
                prefabPath = path;
                prefabc = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }
            if (prefabc == null)
                return;
        }

        if (prefabc.GetComponentInChildren<CutsceneCast>(true) != null)
        {
            Debug.LogError("CutscenePrefabActor.RefreshPrefab: Error prefabPath=" + prefabPath);
            return;
        }

        Debug.Log("do refresh prefab " + prefabPath.ToString());

        var pgo = PrefabUtility.InstantiatePrefab(prefabc) as GameObject;
        pgo.name = this.gameObject.name;

        pgo = PrefabUtility.ConnectGameObjectToPrefab(pgo, prefabc);
        pgo.name = this.gameObject.name;
        pgo.transform.SetParent(this.transform.parent, false);
        pgo.transform.localPosition = this.transform.localPosition;
        pgo.transform.localRotation = this.transform.localRotation;
        pgo.transform.localScale = this.transform.localScale;

        CutscenePrefabActor cpa = pgo.GetComponent<CutscenePrefabActor>();
        if (cpa == null)
        {
            cpa = pgo.AddComponent<CutscenePrefabActor>();
        }
        cpa.CheckPrefab();

        CutsceneCast cc = this.gameObject.GetComponentInParent<CutsceneCast>();
        if (cc == null)
            return;

        // move all billboards
        GameObject[] allBillboards = CutsceneCast.getAllBillboards(this.gameObject);
        foreach (GameObject bb in allBillboards)
        {
            bb.transform.SetParent(pgo.transform, false);
        }

        // re-target all enable-disable gameobjects global
        EnableGameObjectGlobal[] allEGOGs = cc.transform.GetComponentsInChildren<EnableGameObjectGlobal>();
        for (int i = 0; i < allEGOGs.Length; i++)
        {
            var tc = allEGOGs[i];
            if (tc.target == this.gameObject)
            {
                tc.target = pgo.gameObject;
            }
        }

        DisableGameObjectGlobal[] allDGOGs = cc.transform.GetComponentsInChildren<DisableGameObjectGlobal>();
        for (int i = 0; i < allDGOGs.Length; i++)
        {
            var tc = allDGOGs[i];
            if (tc.target == this.gameObject)
            {
                tc.target = pgo.gameObject;
            }
        }

        TransformLookAtAction[] allTLAAs = cc.transform.GetComponentsInChildren<TransformLookAtAction>();
        for (int i = 0; i < allTLAAs.Length; i++)
        {
            var tc = allTLAAs[i];
            if (tc.LookAtTarget == this.gameObject)
            {
                tc.LookAtTarget = pgo.gameObject;
            }
        }


        SetTransformEvent[] allSTFs = cc.transform.GetComponentsInChildren<SetTransformEvent>();
        for (int i = 0; i < allSTFs.Length; i++)
        {
            var tc = allSTFs[i];
            if (tc.Transform == null)
            {
                continue;
            }

            if (tc.Transform == this.gameObject.transform)
            {
                tc.Transform = pgo.transform;
            }
            else if (tc.Transform.IsChildOf(this.gameObject.transform))
            {
                tc.Transform = pgo.transform.FindByName(tc.Transform.name);
            }
        }


        SetParent[] allSPs = cc.transform.GetComponentsInChildren<SetParent>();
        for (int i = 0; i < allSPs.Length; i++)
        {
            var tc = allSPs[i];
            if (tc.parent == null)
                continue;

            if (tc.parent == this.gameObject)
            {
                tc.parent = pgo;
            }
            else if (tc.parent.transform.IsChildOf(this.gameObject.transform))
            {
                var ttrans = pgo.transform.FindByName(tc.parent.name);
                if (ttrans != null)
                    tc.parent = pgo.transform.FindByName(tc.parent.name).gameObject;
                else
                    Debug.LogError(tc.parent.name + " not found on " + pgo.name);
            }
        }

        // re-target all actor groups
        foreach (ActorTrackGroup atg in cc.AllAtgs)
        {
            if (atg.Actor == this.transform)
            {
                atg.Actor = pgo.transform;
            }
        }

        var prefabActors = this.gameObject.GetComponentsInChildren<CutscenePrefabActor>(true);
        foreach (var actor in prefabActors)
        {
            if (actor.gameObject == this.gameObject)
                continue;
            if (this.gameObject.transform.parent.name != "Actors")
                continue;

            actor.transform.SetParent(this.gameObject.transform.parent);
        }

        pgo.gameObject.SetActive(this.gameObject.activeSelf);

        GameObject.DestroyImmediate(this.gameObject);
    }

#endif
}
