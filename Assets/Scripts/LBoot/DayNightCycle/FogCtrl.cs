using UnityEngine;
using System.Collections;
using LBoot;

public class FogCtrl : MonoBehaviour, CtrlClassBase
{
    public class FogParams
    {
        public bool fogEnabled = false;
        public Color fogColor = Color.black;
        public float fogDensity = 0.01f;
        public float fogStartDistance = 0.0f;
        public float fogEndDistance = 300.0f;
        public FogMode fogMode = FogMode.Exponential;

        public void fetch()
        {
            fogEnabled = RenderSettings.fog;
            fogColor = RenderSettings.fogColor;
            fogDensity = RenderSettings.fogDensity;
            fogStartDistance = RenderSettings.fogStartDistance;
            fogEndDistance = RenderSettings.fogEndDistance;
            fogMode = RenderSettings.fogMode;
        }

        public void apply()
        {
            RenderSettings.fog = fogEnabled;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fogStartDistance = fogStartDistance;
            RenderSettings.fogEndDistance = fogEndDistance;
            RenderSettings.fogMode = fogMode;
        }
    };

    public bool fogEnabled = false;
    public FogMode fogMode = FogMode.Linear;
    public Color fogColor = Color.black;

    [Header("For Exponential Modes")]
    [Tooltip("Only For Exponential Modes")]
    public float fogDensity = 0.01f;

    [Header("For Linear Mode")]
    [Tooltip("Only For Linear Mode")]
    public float fogStartDistance = 0.0f;
    public float fogEndDistance = 300.0f;

    private FogParams preParam = new FogParams();
 
    // Update is called once per frame
    #if UNITY_EDITOR
    void Update()
    {
        if (!LBoot.LBootApp.Running)
            DoRefresh();
    }
    #endif

    void OnEnable()
    {
        preParam.fetch();
        RenderSettings.fog = fogEnabled;
    }

    void OnDisable()
    {
        preParam.apply();
        RenderSettings.fog = false;
    }

    public void DoRefresh()
    {
        RenderSettings.fog = fogEnabled;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogStartDistance = fogStartDistance;
        RenderSettings.fogEndDistance = fogEndDistance;
        RenderSettings.fogMode = fogMode;
    }

}