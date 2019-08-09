using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CinemaDirector;
using SLua;

[CustomLuaClassAttribute, Serializable]
public class CutsceneCast : MonoBehaviour
{
    [SerializeField]
    private Cutscene cutscene = null;

    [SerializeField]
    private Rigidbody[]  allRigidBodies = null;

    [SerializeField]
    private ActorTrackGroup[]  allAtgs = null;

    [SerializeField]
    private UnityEngine.UI.Text[]  allTexts = null;

    [SerializeField]
    private UnityEngine.Camera[]  allCams = null;

    [SerializeField]
    private GameObject[]  allBillboards = null;

    [SerializeField]
    private GameObject[]  allActors = null;


    public Cutscene Cutscene
    {
        get
        {
            return this.cutscene;
        }
        set
        {
            this.cutscene = value;
        }
    }

    public Rigidbody[] AllRigidBodies
    {
        get
        {
            return this.allRigidBodies;
        }
    }

    public ActorTrackGroup[] AllAtgs
    {
        get
        {
            return this.allAtgs;
        }
    }

    public UnityEngine.UI.Text[] AllTexts
    {
        get
        {
            return this.allTexts;
        }
    }

    public UnityEngine.Camera[] AllCams
    {
        get
        {
            return this.allCams;
        }
    }

    public GameObject[] AllBillboards
    {
        get
        {
            return this.allBillboards;
        }
    }

    public GameObject[] AllActors
    {
        get
        {
            return this.allActors;
        }
    }
    
    public void RefreshData()
    {
        allRigidBodies = this.gameObject.GetComponentsInChildren<Rigidbody>(true);
        allAtgs = this.gameObject.GetComponentsInChildren<ActorTrackGroup>(true);
        allTexts = this.gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(true);
        allCams = this.gameObject.GetComponentsInChildren<UnityEngine.Camera>(true);

        allBillboards = CutsceneCast.getAllBillboards(this.gameObject);

        Transform actorRoot = this.transform.Find("Actors");
        allActors = new GameObject[actorRoot.childCount];
        for (int i = 0; i < actorRoot.childCount; ++i)
        {
            allActors[i] = actorRoot.GetChild(i).gameObject;
        }
    }

    public static GameObject[] getAllBillboards(GameObject root)
    {
        List<GameObject> abb = new List<GameObject>();
        Transform[] allTrans = root.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in allTrans)
        {
            if (t.tag == "3DUICutscene")
            {
                abb.Add(t.gameObject);
            }
        }
        return abb.ToArray();
    }

    private void OnDestroy()
    {
        this.allCams = null;
        this.allAtgs = null;
        this.allActors = null;
        this.allBillboards = null;
        this.allTexts = null;
        this.allRigidBodies = null;
        this.cutscene = null;
    }
}
