using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmplifyBloom;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AmplifyBloomManager : MonoBehaviour
{

    AmplifyBloomEffect _amplifyBloomEffect;
    Camera _camera;


    void Awake()
    {
        //_camera = Camera.main;
        _camera = GetComponent<Camera>();
#if UNITY_EDITOR
        if (PlayerSettings.colorSpace == ColorSpace.Gamma)
        {
            Debug.LogWarning("Detected Gamma Color Space. For better visual results please switch to Linear Color Space by going to Player Settings > Other Settings > Rendering Path > Color Space > Linear.");
        }

#if UNITY_5_6_OR_NEWER
        if (!_camera.allowHDR)
#else
    			if ( !_camera.hdr )
#endif
        {
            Debug.LogWarning("Detected LDR on camera. For better visual results please switch to HDR by hitting the HDR toggle on the Camera component.");
        }
#endif
        _amplifyBloomEffect = GetComponent<AmplifyBloomEffect>();
    }


    public float Threshold
    {
        get
        {
            return _amplifyBloomEffect.OverallThreshold;
        }
        set
        {
            _amplifyBloomEffect.OverallThreshold = value;
        }
    }

    public bool BloomEnable
    {
        get
        {
            return _amplifyBloomEffect.enabled;
        }
        set
        {
            _amplifyBloomEffect.enabled = value;
        }
    }

    public bool Realistic
    {
        get
        {
            return (_amplifyBloomEffect.UpscaleQuality == UpscaleQualityEnum.Realistic) ? true : false;

        }
        set
        {
            _amplifyBloomEffect.UpscaleQuality = (value) ? UpscaleQualityEnum.Realistic : UpscaleQualityEnum.Natural;
        }
    }

    public bool HighPrecision
    {
        get
        {
            return _amplifyBloomEffect.HighPrecision;
        }
        set
        {
            _amplifyBloomEffect.HighPrecision = value;
        }
    }

    public bool LensDirt
    {
        get
        {
            return _amplifyBloomEffect.ApplyLensDirt;
        }

        set
        {
            _amplifyBloomEffect.ApplyLensDirt = value;
        }
    }

    public bool lensStarburst
    {
        get
        {
            return _amplifyBloomEffect.ApplyLensStardurst;
        }
        set
        {
            _amplifyBloomEffect.ApplyLensStardurst = value;
        }
    }

    public bool BokehFilter
    {
        get
        {
            return _amplifyBloomEffect.BokehFilterInstance.ApplyBokeh;
        }

        set
        {
            _amplifyBloomEffect.BokehFilterInstance.ApplyBokeh = value;
        }
    }

    public bool LensFlare
    {
        get
        {
            return _amplifyBloomEffect.LensFlareInstance.ApplyLensFlare;
        }
        set
        {
            _amplifyBloomEffect.LensFlareInstance.ApplyLensFlare = value;
        }
    }

    public bool LensGlare
    {
        get
        {
            return _amplifyBloomEffect.LensGlareInstance.ApplyLensGlare;

        }
        set
        {
            _amplifyBloomEffect.LensGlareInstance.ApplyLensGlare = value;
        }
    }


    public void OnOff()
    {
        _amplifyBloomEffect.enabled = !_amplifyBloomEffect.enabled;
    }
}
