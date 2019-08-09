using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LBoot;
using System.Reflection;
using System.Linq;

[ExecuteInEditMode]
public class WaterCtrl : MonoBehaviour, CtrlClassBase
{
    public GameObject watchGameObject = null;

    public Vector4 _texScale = new Vector4(0.05f, 0.05f, 0, 0);
    public Vector4 _texSpeed = new Vector4(0.01f, 0.01f, -0.01f, -0.01f);
    public Vector4 _normalScale = new Vector4(0.01f, 0.01f, 0.01f, 0.01f);
    private Vector4 _waterAdjustParams = new Vector4(0.5f, 0.6f, 0.1f, 0.1f);

    public Color _waterColor = Color.black;

    public float _texIntensity = 0.5f;
    public float _reflectionIntensity = 0.6f;
    public float _texDisturbIntensity = 0.1f;
    public float _reflectionDisturbIntensity = 0.1f;
    private Vector4 _texOffset = Vector4.zero;

    private FVWaterEffect[] allWaterSurfaces;
    private bool updateMatsInEditorMode = false;

    private static MaterialPropertyBlock pbBlock = null;

    public static MaterialPropertyBlock PbBlock
    {
        get
        {
            if (pbBlock == null)
                pbBlock = new MaterialPropertyBlock();
            
            return pbBlock;
        }
    }

    void OnDestroy()
    {
        watchGameObject = null;
        allWaterSurfaces = null;
    }

    void Start()
    {
        if (pbBlock == null)
            pbBlock = new MaterialPropertyBlock();
        
        if (watchGameObject == null)
            return;

        allWaterSurfaces = watchGameObject.GetComponentsInChildren<FVWaterEffect>(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (watchGameObject == null)
            return;

        _texOffset = _texOffset + _texSpeed * Time.deltaTime;

        _normalScale.x = Mathf.Max(_normalScale.x, 0.0001f);
        _normalScale.y = Mathf.Max(_normalScale.y, 0.0001f);

        float invNSX = 1.0f / _normalScale.x;
        float invNSY = 1.0f / _normalScale.y;

        _texOffset.x = Mathf.Repeat(_texOffset.x, invNSX);
        _texOffset.y = Mathf.Repeat(_texOffset.y, invNSX);
        _texOffset.z = Mathf.Repeat(_texOffset.z, invNSY);
        _texOffset.w = Mathf.Repeat(_texOffset.w, invNSY);

        _waterAdjustParams.x = _texIntensity;
        _waterAdjustParams.y = _reflectionIntensity;
        _waterAdjustParams.z = _texDisturbIntensity;
        _waterAdjustParams.w = _reflectionDisturbIntensity;

        var pb = PbBlock;

        pb.SetVector("_texScale", _texScale);
        pb.SetVector("_texOffset", _texOffset);
        pb.SetVector("_normalScale", _normalScale);
        pb.SetVector("_waterAdjustParams", _waterAdjustParams);
        pb.SetColor("_waterColor", _waterColor);

        foreach (var we in this.allWaterSurfaces)
        {
            we.UpdateWater(pb);
        }
    }

    public void DoRefresh()
    {
//		RefreshAllWaterSurfaces();
    }

    void RefreshAllWaterSurfaces()
    {
        if (allWaterSurfaces == null || allWaterSurfaces.Length <= 0)
            return;
		
//		for (int i = 0; i < allWaterSurfaces.Length; ++i) {
//			FVWaterEffect we = allWaterSurfaces [i];
//			we._texScale = _texScale;
//			we._texSpeed = _texSpeed;
//			we._normalScale = _normalScale;
//
//			we._waterColor = _waterColor;
//			we._texIntensity = _texIntensity;
//			we._reflectionIntensity = _reflectionIntensity;
//			we._texDisturbIntensity = _texDisturbIntensity;
//			we._reflectionDisturbIntensity = _reflectionDisturbIntensity;
//		}
    }
}
