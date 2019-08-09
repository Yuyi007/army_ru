using System;
using UnityEngine;

public static class TransformExt
{
    public static Transform FindByName(this Transform transform, string childName)
    {
        var transforms = transform.GetComponentsInChildren<Transform>(true);
        var length = transforms.Length;
        for (var i = 0; i < length; i++)
        {
            var t = transforms[i];
            if (t.name == childName)
                return t;
        }

        return null;
    }

    public static Transform FirstChild(this Transform transform)
    {
        if (transform.childCount == 0)
            return null;
        return transform.GetChild(0);
    }

    public static void SetLayer(this Transform transform, int layer, bool recursive = false)
    {
        transform.gameObject.layer = layer;
        if (recursive)
        {
            var transList = transform.GetComponentsInChildren<Transform>(true);
            foreach (var trans in transList)
            {
                trans.gameObject.layer = layer;
            }
        }
    }

    public static void SetLayer(this Transform transform, string layerName, bool recursive = false)
    {
        transform.SetLayer(LayerMask.NameToLayer(layerName), recursive);
    }

    public static string FindPath(this Transform t)
    {
        var path = t.name;
        while (t != t.parent && t.parent != null)
        {
            t = t.parent;
            path = t.name + "/" + path;
        }

        return path;
    }

}

