using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FacialAnim : MonoBehaviour {

    public int eyeXCount = 4;
    public int eyeYCount = 4;

    public int mouthXCount = 4;
    public int mouthYCount = 4;

    public int leftEyeIndex = 0;
    public int rightEyeIndex = 0;
    public int mouthIndex = 0;

    public float eyeScale = 1.28f;
    public float mouthScale = 1.0f;

    private Material faceMat = null;

    private Vector4 EyeDstBottomLeftPos = new Vector4(0.13867f, 0.21875f, 0.5429688f, 0.21875f);
    private Vector4 EyeParams = new Vector4(0.32f, 0.32f, 0.25f, 0.25f);
    private Vector4 EyeSrcBottomLeftPos = Vector4.zero;

    private Vector4 MouthDstBottomLeftPos = new Vector4(0.375f, 0.5175781f, 0.5f, 0.5f);
    private Vector4 MouthParams = new Vector4(0.25f, 0.25f, 0.25f, 0.25f);
    private Vector4 MouthSrcBottomLeftPos = Vector4.zero;

	// Use this for initialization
	void Start () 
    {
        Transform faceTrans = this.transform.Find("Skin/Face");
        SkinnedMeshRenderer smr = faceTrans.GetComponent<SkinnedMeshRenderer>();
        faceMat = smr.material;

        RefreshStaticParam();
	}

    void RefreshParam() 
    {

    }

    void RefreshStaticParam()
    {
        float srcEyeScaleX = 1.0f / eyeXCount;
        float srcEyeScaleY = 1.0f / eyeYCount;
        EyeParams.Set(eyeScale*srcEyeScaleX, eyeScale*srcEyeScaleY, srcEyeScaleX, srcEyeScaleY);

        float srcMouthScaleX = 1.0f / mouthXCount;
        float srcMouthScaleY = 1.0f / mouthYCount;
        MouthParams.Set(mouthScale*srcMouthScaleX, mouthScale*srcMouthScaleY, srcMouthScaleX, srcMouthScaleY);
    }

    void RefreshFace()
    {
        // refresh eyes
        int leftEyeRow = leftEyeIndex / eyeXCount;
        int leftEyeCol = leftEyeIndex % eyeXCount;
        int rightEyeRow = rightEyeIndex / eyeXCount;
        int rightEyeCol = rightEyeIndex % eyeXCount;
        EyeSrcBottomLeftPos.Set(leftEyeRow*EyeParams.z, leftEyeCol*EyeParams.w, rightEyeRow*EyeParams.z, rightEyeCol*EyeParams.w);

        // refresh mouth
        int mouthRow = mouthIndex / mouthXCount;
        int mouthCol = mouthIndex % mouthXCount;
        MouthSrcBottomLeftPos.Set(mouthRow*MouthParams.z, mouthCol*MouthParams.w, 0, 0);

        // set shader params
        faceMat.SetVector("_EyeDstBLPos",   EyeDstBottomLeftPos);
        faceMat.SetVector("_EyeParam",      EyeParams);
        faceMat.SetVector("_EyeSrcBLPos",   EyeSrcBottomLeftPos);

        faceMat.SetVector("_MouthDstBLPos", MouthDstBottomLeftPos);
        faceMat.SetVector("_MouthParam",    MouthParams);
        faceMat.SetVector("_MouthSrcBLPos", MouthSrcBottomLeftPos);
    }
	
	// Update is called once per frame
	void Update () 
    {
        RefreshFace();
	}
}
