using UnityEngine;
using System;
using System.Collections;
using LBoot;

[ExecuteInEditMode]
public class FVBloomTextures : MonoBehaviour
{
    private RenderTexture sceneResult = null;
    private RenderTexture bloomResult = null;

    public RenderTexture SceneResult
    {
        get
        {
            return sceneResult;
        }
    }

    public RenderTexture BloomResult
    {
        get
        {
            return bloomResult;
        }
    }

    // Use this for initialization
    void Awake()
    {
        // Do not init textures here
        // Init it from FVBloomSelectiveStencil.OnEnabled()
        // Only allocate memory when needed, memory for a full screen buffer is expensive
    }

    public void InitTextures()
    {
        LogUtil.Debug("FVBloomTextures: InitTextures!!!!!!!!");
        // fail-safe examination
        if (sceneResult != null || bloomResult != null)
        {
            throw new Exception("FVBloomTextures: textures already inited!");
        }

        sceneResult = new RenderTexture(Screen.width, Screen.height, 24);
        bloomResult = new RenderTexture(Screen.width, Screen.height, 0);
    }

    public void OnDestroy()
    {
        // OnDestroy() will only be called for once active objects
        // Do not rely on this call to DestroyTextures()
        DestroyTextures();
    }

    public void DestroyTextures()
    {
        if (sceneResult != null)
        {
            sceneResult.Release();
            if (Application.isPlaying)
                Destroy(sceneResult);
            else
                DestroyImmediate(sceneResult);
            
            sceneResult = null;
        }

        if (bloomResult != null)
        {
            bloomResult.Release();
            if (Application.isPlaying)
                Destroy(bloomResult);
            else
                DestroyImmediate(bloomResult);
            bloomResult = null;
        }
    }

    public bool NeedRefreshTextures()
    {
        bool needRefresh = false;
        if (sceneResult == null && bloomResult == null)
        {
        }
        else if (sceneResult.width != Screen.width || sceneResult.height != Screen.height)
        {
            needRefresh = true;
        }
        return needRefresh;
    }

    public bool CheckTextures()
    {
        bool textureChanged = false;
        if (sceneResult == null && bloomResult == null)
        {
            InitTextures();
            textureChanged = true;
        }
        else if (sceneResult.width != Screen.width || sceneResult.height != Screen.height)
        {
            DestroyTextures();
            InitTextures();
            textureChanged = true;
        }
        return textureChanged;
    }

}
