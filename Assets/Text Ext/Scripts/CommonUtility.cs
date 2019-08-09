

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class CommonUtility
{

    public static GameObject findChildByName(GameObject go, string childname, bool includeInactive = true)
    {
        if (go == null)
            return null;
        Transform[] trans = go.transform.GetComponentsInChildren<Transform>(includeInactive);
        foreach (Transform t in trans)
        {
            if (t.name.CompareTo(childname) == 0)
            {
                return t.gameObject;
            }
        }

        return null;
    }

    public static GameObject loadObject(string path)
    {
        return Resources.Load<GameObject>(path);
    }

}
