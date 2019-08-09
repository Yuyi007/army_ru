

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class LinkTest : MonoBehaviour
{

    protected GameObject mGo;
    protected RectTransform mTrans;

    public GameObject cachedGameObject { get { if (mGo == null) mGo = gameObject; return mGo; } }

    public RectTransform cachedTransform { get { if (mTrans == null) mTrans = transform as RectTransform; return mTrans; } }

    void Start()
    {
        Dictionary<string, LinkObject> linkAct = UGUIText_Extend.linkAction;

        string linkPlayerStr = "link_me";
        linkAct[linkPlayerStr].action = (info) => { Debug.Log("Click link_player: " + info); };
        linkAct[linkPlayerStr].action += onClickPlayer;

        string linkItemStr = "link_item";
        linkAct[linkItemStr].action = (info) => { Debug.Log("Click link_item: " + info); };
        linkAct[linkItemStr].action += onClickItem;
    }

    void onClickPlayer(string info)
    {
        if ("1971" == info)
        {
            GameObject uiObj = CommonUtility.findChildByName(cachedGameObject, "UI_Elon_Musk");
            if (null == uiObj)
                return;

            uiObj.SetActive(true);
        }

    }

    void onClickItem(string info)
    {
        string uiName = "";
        switch (info)
        {
            case "1": uiName = "hypertext";
                break;
            case "2": uiName = "underline";
                break;
            case "3": uiName = "gradient";
                break;
            case "4": uiName = "font manage";
                break;
            case "5": uiName = "Generate Unity image font";
                break;
            case "9": uiName = "UI_Falcon_9";
                break;
        }
        if (!string.IsNullOrEmpty(uiName))
        {
            GameObject uiObj = CommonUtility.findChildByName(cachedGameObject, uiName);
            if (null == uiObj)
                return;

            uiObj.SetActive(true);
        }
    }

}
