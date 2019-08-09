using UnityEngine;
using System.Collections;
using LBoot;

[ExecuteInEditMode]
public class GameObjectCtrl : MonoBehaviour, CtrlClassBase
{

    public GameObject[] ctrlObjects;
    public bool enabled;

    // Update is called once per frame
    #if UNITY_EDITOR
    void Update()
    {
        if (!LBootApp.Running)
            DoRefresh();
    }
    #endif

    public void DoRefresh()
    {
        foreach (var go in ctrlObjects)
        {
            if (go != null)
            {
                go.SetActive(enabled);
            }
        }
    }
}
