using UnityEngine;
using System.Collections;
using LBoot;

[ExecuteInEditMode]
public class LightmapSwitcher : MonoBehaviour, CtrlClassBase
{

    enum LightmapEnum
    {
        Unknown,
        Day,
        Night,
    };

	public LightmapParams[]	allParams;
    public Texture2D[] dayLightmaps;
    public Texture2D[] nightLightmaps;
    public bool useNightLightmaps = false;

    private LightmapEnum preUseNightLightmaps = LightmapEnum.Unknown;
    //-1: unknown, 0: day, 1: night
    private LightmapData[] dayLightMapDatas;

    public LightmapData[] DayLightMapDatas
    {
        get
        {
            return dayLightMapDatas;
        }
    }

    private LightmapData[] nightLightMapDatas;

    public LightmapData[] NightLightMapDatas
    {
        get
        {
            return nightLightMapDatas;
        }
    }

    // Use this for initialization
    void Start()
    {
		initData ();
    }

	public void initData()
	{
		if (dayLightmaps.Length > 0)
		{
			dayLightMapDatas = new LightmapData[dayLightmaps.Length];
			for (int i = 0; i < dayLightmaps.Length; ++i)
			{
				if (dayLightmaps[i] == null)
				{
					LogUtil.Error("dayLightmaps has null texture for gameobject: " + gameObject.name);
					dayLightMapDatas = null;
					break;
				}
				dayLightMapDatas[i] = new LightmapData();
				dayLightMapDatas[i].lightmapColor = dayLightmaps[i];
				dayLightMapDatas[i].lightmapDir = null;
			}
		}

		if (nightLightmaps.Length > 0)
		{
			nightLightMapDatas = new LightmapData[nightLightmaps.Length];
			for (int i = 0; i < nightLightmaps.Length; ++i)
			{
				if (nightLightmaps[i] == null)
				{
					LogUtil.Error("nightLightmaps has null texture for gameobject: " + gameObject.name);
					nightLightmaps = null;
					break;
				}
				nightLightMapDatas[i] = new LightmapData();
				nightLightMapDatas[i].lightmapColor = nightLightmaps[i];
				nightLightMapDatas[i].lightmapDir = null;
			}
		}
	}

    // Update is called once per frame
#if UNITY_EDITOR
    void Update()
    {
        if (!LBoot.LBootApp.Running)
            DoRefresh();
    }
#endif

    public void DoRefresh()
    {
        if (!useNightLightmaps && preUseNightLightmaps != LightmapEnum.Day)
        {
            if (dayLightMapDatas == null || dayLightMapDatas.Length <= 0)
                return;
            LightmapSettings.lightmaps = dayLightMapDatas;
            preUseNightLightmaps = LightmapEnum.Day;
			SetLightmapParams (0);
        }
        else if (useNightLightmaps && preUseNightLightmaps != LightmapEnum.Night)
        {
            if (nightLightMapDatas == null || nightLightMapDatas.Length <= 0)
                return;
            LightmapSettings.lightmaps = nightLightMapDatas;
            preUseNightLightmaps = LightmapEnum.Night;
			SetLightmapParams (1);
        }
    }

	void SetLightmapParams(int index)
	{	
		if (allParams == null) {
			return;
		}
		int len = allParams.Length;
		for (int i = 0; i < len; ++i) {
			allParams [i].ApplyData (index);
		}
	}

}
