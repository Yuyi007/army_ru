using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CinemaDirector;
using LBoot;

public class FVBloomPostProcessor : AssetModificationProcessor
{
    
    public static string[] OnWillSaveAssets(string[] paths)
    {   
        //ProcessFVBloom();
        return paths;
    }
    
    public static void ProcessFVBloom()
    {
		FVBloomSelectiveStencil[] fvbs = GameObject.FindObjectsOfType<FVBloomSelectiveStencil>();
		foreach (FVBloomSelectiveStencil fvb in fvbs) {
			LogUtil.Error ("processing fvbloom for " + fvb.gameObject.name);
			fvb.RefreshMaterialReferences();
		}
    }
}
