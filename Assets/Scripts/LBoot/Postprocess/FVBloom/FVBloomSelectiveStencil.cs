using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using SLua;
using LBoot;

[RequireComponent(typeof(Camera))]
[CustomLuaClassAttribute, ExecuteInEditMode]
public class FVBloomSelectiveStencil : PostEffectsBase
{
    private RenderTexture bloomResult = null;
    private RenderTexture sceneResult = null;
    private Shader bloomShader = null;
    private Material bloomMaterial = null;

    private Shader clearShader = null;
    private Material clearMaterial = null;

    private Camera camera = null;
    private Camera sceneReceiverCam = null;
    private FVBloomTextures bloomTextures = null;

    private Material[] bloomSrcMaterials = null;
    private bool forceDisable = false;

    public enum Resolution
    {
        Low = 0,
        High = 1,
    }

    public enum BlurType
    {
        Standard = 0,
        Sgx = 1,
    }

    [Range(0.0f, 1.5f)]
    public float threshold = 0.25f;
    [Range(0.0f, 2.5f)]
    public float intensity = 0.75f;
    
    [Range(0.25f, 5.5f)]
    public float blurSize = 1.0f;
    
    Resolution resolution = Resolution.Low;
    [Range(1, 4)]
    public int blurIterations = 1;
    
    public BlurType blurType = BlurType.Standard;

    public bool IsEnabled()
    {
        return this.enabled && !this.forceDisable;
    }

    public void SetEnabled(bool val)
    {
        this.enabled = val && !this.forceDisable;
    }

    public bool IsForceDisabled()
    {
        return this.forceDisable;
    }

    public void SetForceDisable(bool val)
    {
        this.forceDisable = val;
        if (val)
        {
            SetEnabled(false);
        }
    }

    void Awake()
    {
        camera = this.transform.GetComponent<Camera>();

        bloomShader = Shader.Find("Hidden/FVFastBloom");
        clearShader = Shader.Find("Custom/BloomClearShader");

        RefreshMaterialReferences();
    }

    void Start()
    {
		
    }

    void Update()
    {
        if (bloomTextures != null && bloomTextures.NeedRefreshTextures())
        {
            sceneReceiverCam.targetTexture = null;
            CheckBloomParteners();
        }
    }

    public override bool CheckResources()
    {
        //LogUtil.Warn("before check resources: " + isSupported.ToString());

        CheckSupport(false);

        //LogUtil.Warn("after check resources: " + isSupported.ToString());
        
        bloomMaterial = CheckShaderAndCreateMaterial(bloomShader, bloomMaterial);

        //LogUtil.Warn("after check bloom material: " + isSupported.ToString());

        clearMaterial = CheckShaderAndCreateMaterial(clearShader, clearMaterial);

        //LogUtil.Warn("after check clear material: " + isSupported.ToString());

        if (!isSupported)
            ReportAutoDisable();
        return isSupported;
    }

    void OnEnable()
    {
        CheckBloomParteners();
        
        GL.Clear(true, false, Color.black);
        EnableBloomSelective();
        SetBloomMaterialsEnable(true);
        //LogUtil.Warn("bloom stencil enabled");
    }

    void OnDisable()
    {
        if (bloomMaterial)
            DestroyImmediate(bloomMaterial);

        if (clearMaterial)
            DestroyImmediate(clearMaterial);
        
        if (bloomTextures)
        {
            if (sceneReceiverCam)
            {
                sceneReceiverCam.targetTexture = null;
            }
            bloomTextures.DestroyTextures();
            this.bloomResult = null;
            this.sceneResult = null;
        }
        else
        {
            if (bloomResult != null || sceneResult != null)
            {
                // Indicate that bloomResult was improperly inited somewhere else
                LogUtil.Error("FVBloomSelectiveStencil: no bloomTextures but has bloomResult and sceneResult!");
            }
        }

        DisableBloomSelective();

        if (LBootApp.Running)
        {
            SetBloomMaterialsEnable(false);
        }

        //LogUtil.Warn("bloom stencil disabled");
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //LogUtil.Debug("before onrenderimage");
        if (CheckResources() == false || bloomResult == null || sceneResult == null)
        {
            Graphics.Blit(source, destination);
            return;
        }

        //LogUtil.Warn("do onrenderimage 1");

        // copy sceneResult to bloomResult
        Graphics.Blit(sceneResult, bloomResult);

        //LogUtil.Warn("do onrenderimage 2");

        // clear sceneResult based on stencil to keep glow pixels
        Graphics.Blit(bloomResult, sceneResult, clearMaterial);

        //LogUtil.Warn("do onrenderimage 3");

        // do glow 
        int divider = resolution == Resolution.Low ? 4 : 2;
        float widthMod = resolution == Resolution.Low ? 0.5f : 1.0f;

        //LogUtil.Warn("do onrenderimage 3.1");

        bloomMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod, 0.0f, threshold, intensity));

        //LogUtil.Warn("do onrenderimage 3.2");

        sceneResult.filterMode = FilterMode.Bilinear;

        //LogUtil.Warn("do onrenderimage 3.3");
        
        var rtW = sceneResult.width / divider;
        var rtH = sceneResult.height / divider;

        //LogUtil.Warn("do onrenderimage 3.4");
        
        // downsample
        RenderTexture rt = RenderTexture.GetTemporary(rtW, rtH, 0, sceneResult.format);

        //LogUtil.Warn("do onrenderimage 3.5");

        rt.filterMode = FilterMode.Bilinear;

        //LogUtil.Warn("do onrenderimage 3.6");

        Graphics.Blit(sceneResult, rt, bloomMaterial, 1);

        //LogUtil.Warn("do onrenderimage 4");

        var passOffs = blurType == BlurType.Standard ? 0 : 2;
        
        for (int i = 0; i < blurIterations; i++)
        {
            bloomMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod + (i * 1.0f), 0.0f, threshold, intensity));
            
            // vertical blur
            RenderTexture rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, sceneResult.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit(rt, rt2, bloomMaterial, 2 + passOffs);
            RenderTexture.ReleaseTemporary(rt);
            if (Application.isPlaying)
            {
                GameObject.Destroy(rt);
            }
            else
            {
                GameObject.DestroyImmediate(rt);
            }
            rt = rt2;
            
            // horizontal blur
            rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, sceneResult.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit(rt, rt2, bloomMaterial, 3 + passOffs);
            RenderTexture.ReleaseTemporary(rt);
            if (Application.isPlaying)
                GameObject.Destroy(rt);
            else
                GameObject.DestroyImmediate(rt);
            
            rt = rt2;
        }

        //LogUtil.Warn("do onrenderimage 5");

        // combine results
        //LogUtil.Warn("do onrenderimage 6");

        bloomMaterial.SetTexture("_Bloom", rt);

        //LogUtil.Warn("do onrenderimage 7");

        // HACK fix blit to destination with a material
        Graphics.Blit(bloomResult, destination, bloomMaterial, 0);

        //LogUtil.Warn("do onrenderimage 8");

        RenderTexture.ReleaseTemporary(rt);
        DestroyGo(rt);
        //LogUtil.Warn("do onrenderimage 9");
    }

    void DestroyGo(UnityEngine.Object o)
    {
        if (Application.isPlaying)
            GameObject.Destroy(o);
        else
            GameObject.DestroyImmediate(o);
    }

    /// <summary>
    /// check parteners
    /// </summary>
    
    void SetPartenersActive(bool active)
    {
        if (bloomTextures)
            bloomTextures.gameObject.SetActive(active);
        
        if (sceneReceiverCam)
            sceneReceiverCam.gameObject.SetActive(active);
    }

    void EnableBloomSelective()
    {    
        camera.cullingMask = 0;
        SetPartenersActive(true);
    }

    void DisableBloomSelective()
    {
        camera.cullingMask = ~(LayerMask.GetMask(new []
            {
                "3DUI"
            }));
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.clear;
        SetPartenersActive(false);
    }

    void OnDestroy()
    {
        OnDisable();
        var children = new List<GameObject>();
        foreach (Transform child in transform)
            children.Add(child.gameObject);

        if (Application.isPlaying)
            children.ForEach(child => Destroy(child));
        else
            children.ForEach(child => DestroyImmediate(child));

        SetBloomMaterialsEnable(false);
    }

    void CheckBloomParteners()
    {
        CheckBloomTextures();
        CheckSceneReceiver();
        
        sceneReceiverCam.targetTexture = bloomTextures.SceneResult;
        this.bloomResult = bloomTextures.BloomResult;
        this.sceneResult = bloomTextures.SceneResult;
    }

    FVBloomTextures CheckBloomTextures()
    {
        string name = "BloomTextures";
        Transform btgo = this.transform.Find(name);
        if (btgo == null)
        {
            GameObject ngo = new GameObject();
            ngo.name = name;
            ngo.transform.SetParent(this.transform, false);
            bloomTextures = ngo.AddComponent<FVBloomTextures>();
        }
        else
        {
            bloomTextures = btgo.GetComponent<FVBloomTextures>();
        }
        bloomTextures.CheckTextures();
        return bloomTextures;
    }

    Camera CheckSceneReceiver()
    {
        string name = "SceneReceiver";
        Transform srgo = this.transform.Find(name);
        if (srgo == null)
        {
            GameObject srt = new GameObject();
            srt.name = name;
            srt.transform.SetParent(this.transform, false);
            sceneReceiverCam = srt.AddComponent<Camera>();
        }
        else
        {
            sceneReceiverCam = srgo.GetComponent<Camera>();
        }
        
        sceneReceiverCam.CopyFrom(camera);
        sceneReceiverCam.cullingMask = ~(LayerMask.GetMask(new []
            {
                //neonLayerName,
                "3DUI"
            }));
        sceneReceiverCam.depth = -2;
        sceneReceiverCam.clearFlags = CameraClearFlags.SolidColor;
        sceneReceiverCam.backgroundColor = Color.clear;
        sceneReceiverCam.targetTexture = null;
        
        return sceneReceiverCam;
    }

    public void RefreshMaterialReferences()
    {
        Renderer[] allRenderers = GameObject.FindObjectsOfType<Renderer>();
        List<Material> lms = new List<Material>();
        foreach (Renderer r in allRenderers)
        {
            foreach (Material m in r.sharedMaterials)
            {
                if (m != null && m.shader &&
                    m.shader.name == "Shaders/LightmapUberShader-Glow")
                {
                    lms.Add(m);
                }
            }
        }
        bloomSrcMaterials = lms.ToArray();
    }

    void SetBloomMaterialsEnable(bool val)
    {
        if (bloomSrcMaterials == null)
            return;

        int op = (int)UnityEngine.Rendering.StencilOp.Keep;
        if (val)
        {
            op = (int)UnityEngine.Rendering.StencilOp.Replace;
        } 

        foreach (Material m in bloomSrcMaterials)
        {
            if (m == null)
                continue;
            m.SetInt("_SPassOp", op);
        }
    }
}
