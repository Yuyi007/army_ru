

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class HideSelf : MonoBehaviour
{
    protected GameObject mGo;
    protected RectTransform mTrans;

    public GameObject cachedGameObject { get { if (mGo == null) mGo = gameObject; return mGo; } }

    public RectTransform cachedTransform { get { if (mTrans == null) mTrans = transform as RectTransform; return mTrans; } }

    public Animator hideSelfAnim;

    public void onHide()
    {
        hideSelfAnim.Play("Box_Hide");
    }

    public void hide()
    {
        cachedGameObject.SetActive(false);
    }

}
