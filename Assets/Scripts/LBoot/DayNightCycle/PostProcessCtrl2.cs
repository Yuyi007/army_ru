using UnityEngine;
using System.Collections;
using LBoot;

[ExecuteInEditMode]
public class PostProcessCtrl2 : MonoBehaviour, CtrlClassBase
{
    public Camera watchCam = null;

#if UNITY_EDITOR
    public float updateInterval = 0.05f;
#else
	public float updateInterval = 1.0f;
#endif
	
    //////////////////////////////////////////////////////////////////////
    /// Day or Night
    public string time = "day";

    //////////////////////////////////////////////////////////////////////
    /// Color Correction Curves Ctrl
    [Header("Color Correction Curves Ctrl")]
    public bool ccColorCorrectionEnable = false;
    [Range(0.0f, 5.0f)]
    public float ccSaturation = 1.0f;
    public AnimationCurve ccRedChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    public AnimationCurve ccGreenChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    public AnimationCurve ccBlueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    //////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////////////////////////////
    /// Bloom and Glare Ctrl
    [Header("Bloom and Glare Ctrl")]
    public bool bgBloomAndGlareEnable = false;
    public float bgIntensity = 1.0f;
    [Range(-0.05f, 4.0f)]
    public float bgThreshold = 1.0f;
    public Color bgRGBThreshold = Color.white;
    [Range(1, 4)]
    public int bgBlurIterations = 2;
    [Range(0.1f, 10.0f)]
    public float bgSampleDistance = 1.0f;
    public float bgLensFlareIntensity = 0.0f;
    [Range(0.0f, 4.0f)]
    public float bgLensFlareThreshold = 1.0f;
    public float bgLensFlareStretchWidth = 1.0f;
    public float bgLensFlareRotation = 1.0f;
    public float bgSaturation = 1.0f;
    public Color bgTintColor = new Color(49, 49, 165, 191);
    //////////////////////////////////////////////////////////////////////

    private double curTime = 0.0f;
    private double prevTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        var camera = this.gameObject.GetComponent<Camera>();
        if (camera != null)
        {
            watchCam = camera;
        }
    }

    void OnDestroy()
    {
        this.watchCam = null;
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (watchCam == null)
        {
            return;
        }

        if (LBootApp.Running) return;
        double ct = UnityEditor.EditorApplication.timeSinceStartup;
        double deltaTime = ct - prevTime;
        curTime += deltaTime;
        prevTime = ct;
        if (curTime > updateInterval)
        {
            RefreshPostProcessParams();
            curTime = 0.0f;
        }
    }
#endif

    public void DoRefresh()
    {
        if (watchCam == null)
        {
            return;
        }
        RefreshPostProcessParams();
    }

    void RefreshPostProcessParams()
    {
        // RefreshColorCorrection();
        // RefreshBloom();
    }

    void RefreshColorCorrection()
    {
        var ccc = watchCam.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();
        if (ccc)
        {
            ccc.enabled = ccColorCorrectionEnable;
            if (true) // (ccc.enabled)
            {
                ccc.saturation = ccSaturation;
                ccc.redChannel = ccRedChannel;
                ccc.greenChannel = ccGreenChannel;
                ccc.blueChannel = ccBlueChannel;
            }
        }
    }

    void RefreshBloom()
    {
        var bloom = watchCam.GetComponent<UnityStandardAssets.ImageEffects.Bloom>();
        if (bloom)
        {
            bloom.enabled = bgBloomAndGlareEnable;
            if (true) // (bloom.enabled)
            {
                bloom.bloomIntensity = bgIntensity;
                bloom.bloomThreshold = bgThreshold;
                bloom.bloomThresholdColor = bgRGBThreshold;
                bloom.bloomBlurIterations = bgBlurIterations;
                bloom.sepBlurSpread = bgSampleDistance;
                bloom.hollyStretchWidth = bgLensFlareStretchWidth;
                bloom.lensflareIntensity = bgLensFlareIntensity;
                bloom.lensflareThreshold = bgLensFlareThreshold;
                bloom.flareRotation = bgLensFlareRotation;
                bloom.lensFlareSaturation = bgSaturation;
                bloom.flareColorA = bgTintColor;
            }
        }
    }

}
