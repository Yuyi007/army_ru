using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using LBoot;

public class FVMaterialUtils
{
    [MenuItem("Tools/Fix All Lightmap Shaders")]
    private static void FixAllLightmapShaders()
    {
        string sMatPath = "Assets/Models/streets";
        string[] aMatNames = Directory.GetFiles(sMatPath, "*.mat", SearchOption.AllDirectories);

        foreach (string v in aMatNames)
        {
            //if (!v.Contains("zg_dalou005"))
            //	continue;

            Material mat = AssetDatabase.LoadAssetAtPath<Material>(v);
            if (mat != null && mat.shader != null)
            {
                LogUtil.Debug("processing " + v + ", shader = " + mat.shader.name);
                FixMaterial(null, mat);
            }
        }

        GameObject[] allObjs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in allObjs)
        {
            Renderer[] renderComps = go.GetComponentsInChildren<Renderer>();
            foreach (Renderer rd in renderComps)
            {
                foreach (Material mat in rd.sharedMaterials)
                {
                    FixMaterial(rd, mat);
                }
            }
        }
		
        AssetDatabase.SaveAssets();
    }

    private static void FixMaterial(Renderer rd, Material mat)
    {
        if (mat == null || mat.shader == null)
        {
            return;
        }
        string orgShaderName = mat.shader.name;

        if (!orgShaderName.Contains("LightmapUber"))
        {
            return;
        }

        /*
        bool isMasked = orgShaderName.Contains("Masked");
        bool isCullOut = orgShaderName.Contains("CullOut");
        bool isTransparent = orgShaderName.Contains("Transparent");
        bool isMultColor = orgShaderName.Contains("ColorMult");
        bool isNoLightmap = orgShaderName.Contains("NoLightmap");

        if (isTransparent)
        {
            mat.shader = Shader.Find("Shaders/LightmapUberShaderTransparent");
        }
        else
        {
            mat.shader = Shader.Find("Shaders/LightmapUberShader");
        }

        if (isNoLightmap)
        {
            isMultColor = true;
            if (rd && rd.gameObject && rd.gameObject.isStatic)
            {
                isNoLightmap = false;
                isMultColor = false;
            }
        }
        */

        LogUtil.Debug("processing " + mat.name + ", shader = " + orgShaderName);
        mat.DisableKeyword("MASK_TEX");

        /*
        setShaderSwitch(mat, "FV_BRIGHT_MASK_TEX", "_mt", isMasked);
        setShaderSwitch(mat, "ENABLE_LIGHTMAP", "_elm", !isNoLightmap);
        setShaderSwitch(mat, "MULT_LIGHTCOLOR", "_mlc", isMultColor);
        setShaderSwitch(mat, "CULL_OUT", "_co", isCullOut);
        */
    }

    private static void setShaderSwitch(Material mat, string name, string vname, bool enabled)
    {
        if (enabled)
        {
            mat.EnableKeyword(name);
            mat.SetInt(vname, 1);
        }
        else
        {
            mat.DisableKeyword(name);
            mat.SetInt(vname, 0);
        }
    }
}

