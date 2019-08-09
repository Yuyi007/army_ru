using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LBoot;
using System.Reflection;
using System.Linq;

[ExecuteInEditMode]
public class SetLightMapWithDynamicLightColor : MonoBehaviour, CtrlClassBase
{

    public GameObject watchGameObject = null;
    public bool gameObjectEnabled = true;
    public Color multColor = Color.white;
    [Range(0.0f, 8.0f)]
    public float colorIntensity = 1.0f;
    public bool maskEnabled = true;

    public bool maskIntensityCtrl = false;
    public float maskIntensity = 1.0f;

    public bool tiltFogEnabled = false;
    public float fogStart = 0;
    public float fogEnd = 500;
    public Color fogStartColor = Color.white;
    public Color fogEndColor = Color.white;

    public bool multLightColorEnabled = false;

    private double curTime = 0.0f;
    private double prevTime = 0.0f;
    private Renderer[] renderers;
    private Material[] materials;
    private bool updateMatsInEditorMode = false;
    private static MaterialPropertyBlock pbBlock;

    private static MaterialPropertyBlock PbBlock
    {
        get
        {
            if (pbBlock == null)
                pbBlock = new MaterialPropertyBlock();
            return pbBlock;
        }
    }

#if UNITY_EDITOR
    public float updateInterval = 0.05f;
#else
    public float                updateInterval = 1.0f;
#endif

    void OnDestroy()
    {
        this.materials = null;
        this.renderers = null;
    }

    // Use this for initialization
    void Start()
    {
        if (watchGameObject != null)
        {
            renderers = watchGameObject.GetComponentsInChildren<Renderer>(true);
        }
        else
        {
            renderers = new Renderer[0];
        }

        var mats = new List<Material>();
        var length1 = renderers.Length;

        for (var i = 0; i < length1; i++)
        {
            var renderer = renderers[i];
#if UNITY_EDITOR
#else
            renderer.SetPropertyBlock(null);
#endif
            var length = renderer.sharedMaterials.Length;
            var matList = renderer.sharedMaterials;

#if UNITY_EDITOR
            // the material files change during play mode in the
            // editor is not desirable
            if (Application.isPlaying)
            {
                matList = renderer.materials;
            }
#endif

            for (var j = 0; j < length; j++)
            {
                var m = matList[j];
                if (m != null)
                {
                    if (m.shader.name.Contains("LightmapUberShader"))
                        mats.Add(m);
                }
                else
                {
                    LogUtil.Error("gameobject has null materials " + renderer.gameObject.name);
                }
            }
        }

//        LogUtil.Warn("SetLightMapWithDynamicLightColor mats.length" + mats.Count);
        this.materials = mats.ToArray();
#if UNITY_EDITOR
        var settings = LBootEditor.PipelineSettings.Load();
        this.updateMatsInEditorMode = settings.CanRunScenePipeline();
#endif
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (watchGameObject == null)
            return;

        var selected = UnityEditor.Selection.activeGameObject;
        if (!LBoot.LBootApp.Running && (this.updateMatsInEditorMode) && (selected == this.gameObject || selected == transform.parent.gameObject))
        {
            double ct = UnityEditor.EditorApplication.timeSinceStartup;
            double deltaTime = ct - prevTime;
            curTime += deltaTime;
            prevTime = ct;
            if (curTime > updateInterval)
            {
                DoRefresh();
                curTime = 0.0f;
            }
        }
    }
#endif

    public void DoRefresh()
    {
        RefreshShaderLightColor(multColor, colorIntensity);
    }


    void RefreshShaderLightColor(Color color, float intensity)
    {
#if UNITY_EDITOR
        var pb = PbBlock;
        pb.SetColor("_LightColor", color);
        pb.SetFloat("_LightIntensity", intensity);

        if (maskEnabled)
        {
            if (maskIntensityCtrl)
            {
                pb.SetFloat("_MaskIntensity", maskIntensity);
            }
        }

        if (tiltFogEnabled)
        {
            pb.SetFloat("_tt_fogStart", fogStart);
            pb.SetFloat("_tt_fogEnd", fogEnd);
            pb.SetColor("_tt_fogStartColor", fogStartColor);
            pb.SetColor("_tt_fogEndColor", fogEndColor);
        }


        foreach (var r in renderers)
        {
            r.SetPropertyBlock(pb);
        }

        if (materials != null)
        {
            var length = materials.Length;
            for (int j = 0; j < length; j++)
            {
                var material = materials[j];
                if (maskEnabled)
                {
                    material.SetInt("_mt", 1);
                    material.EnableKeyword("FV_BRIGHT_MASK_TEX");
                }
                else
                {
                    material.SetInt("_mt", 0);
                    material.DisableKeyword("FV_BRIGHT_MASK_TEX");
                }

                if (tiltFogEnabled)
                {
                    material.SetInt("_tfe", 1);
                    material.EnableKeyword("FV_TILT_FOG");
                }
                else
                {
                    material.SetInt("_tfe", 0);
                    material.DisableKeyword("FV_TILT_FOG");
                }

                if (multLightColorEnabled)
                {
                    material.SetInt("_mlc", 1);
                    material.EnableKeyword("MULT_LIGHTCOLOR");
                }
                else
                {
                    material.SetInt("_mlc", 0);
                    material.DisableKeyword("MULT_LIGHTCOLOR");
                }
            }
        }
#else
        if (materials != null)
        {
            var length = materials.Length;
            for (int j = 0; j < length; j++)
            {
                var material = materials[j];
                material.SetColor("_LightColor", color);
                material.SetFloat("_LightIntensity", intensity);
                if (maskEnabled)
                {
                    material.SetInt("_mt", 1);
                    material.EnableKeyword("FV_BRIGHT_MASK_TEX");

                    if (maskIntensityCtrl)
                    {
                        material.SetFloat("_MaskIntensity", maskIntensity);
                    }
                }
                else
                {
                    material.SetInt("_mt", 0);
                    material.DisableKeyword("FV_BRIGHT_MASK_TEX");
                }

                if (tiltFogEnabled)
                {
                    material.SetInt("_tfe", 1);
                    material.EnableKeyword("FV_TILT_FOG");

                    material.SetFloat("_tt_fogStart", fogStart);
                    material.SetFloat("_tt_fogEnd", fogEnd);
                    material.SetColor("_tt_fogStartColor", fogStartColor);
                    material.SetColor("_tt_fogEndColor", fogEndColor);
                }
                else
                {
                    material.SetInt("_tfe", 0);
                    material.DisableKeyword("FV_TILT_FOG");
                }

                if (multLightColorEnabled)
                {
                    material.SetInt("_mlc", 1);
                    material.EnableKeyword("MULT_LIGHTCOLOR");
                }
                else
                {
                    material.SetInt("_mlc", 0);
                    material.DisableKeyword("MULT_LIGHTCOLOR");
                }
            }
        }
#endif

        if (watchGameObject != null)
        {
            watchGameObject.SetActive(gameObjectEnabled);
        }
    }
}
