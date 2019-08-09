using UnityEngine;
using System.Collections;

public class LEDAnimation : MonoBehaviour
{
	
    public int xCount;
    public int yCount;

    public int framePerSecond = 30;
    public Material material;

    private Vector2 texOffset;
    private Vector2 texScale;
    private float timePerFrame;
    private int preIndex = -1;
    private int totalIndex = 0;
    private float curTime;

    void Start()
    {
        var renderer = GetComponent<Renderer>();
        if (Application.isEditor)
            this.material = renderer.material;
        else
            this.material = renderer.sharedMaterial;
    }

    void OnEnable()
    {
        ResetAnimation();
    }

    void ResetAnimation()
    {
        if (xCount <= 0 || yCount <= 0 || framePerSecond == 0)
            return;
        texScale = new Vector2(1.0f / xCount, 1.0f / yCount);
        texOffset = Vector2.zero;
        preIndex = -1;
        totalIndex = xCount * yCount;
        curTime = 0;

        if (material == null)
            return; 
        material.mainTextureScale = texScale;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (material == null || xCount <= 0 || yCount <= 0 || framePerSecond == 0)
            return;

        timePerFrame = 1.0f / framePerSecond;

        curTime += Time.deltaTime;
        int actualIndex = (int)Mathf.Floor(curTime / timePerFrame);
        //int repeat = actualIndex / totalIndex;
        int index = actualIndex % totalIndex;

        if (preIndex == index)
            return;

        /////////////////////////////////////
        // texture offset is like this
        //	(0,1)		(1,1)
        //
        //	(0,0)		(1,0)
        /////////////////////////////////////
        texOffset.x = (index % xCount) * texScale.x;
        texOffset.y = (yCount - 1 - index / xCount) * texScale.y;
        material.mainTextureOffset = texOffset;
        preIndex = index;
    }
}
