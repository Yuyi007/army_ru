using UnityEngine;
using System.Collections;

public class TextureSheetAnimation : MonoBehaviour
{

    public int xCount;
    public int yCount;

    public int framePerSecond = 30;
    public int cycles = 1;

    private Vector2 texOffset;
    private Vector2 texScale;
    private float timePerFrame;
    private int preIndex = -1;
    private bool prePlaying;
    private ParticleSystem psComp = null;
    private int totalIndex = 0;
    private Renderer _renderer;
    private Material _material;

    // Use this for initialization
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    void RefreshParticleSystem()
    {
        if (psComp != null)
            return;
        psComp = GetComponent<ParticleSystem>();
        if (psComp == null)
        {
            psComp = GetComponentInChildren<ParticleSystem>();
        }
        ResetAnimation();
    }

    void OnEnable()
    {
        ResetAnimation();
    }

    void ResetAnimation()
    {
        if (xCount <= 0 || yCount <= 0 || framePerSecond == 0 || cycles == 0 || psComp == null)
            return;
        texScale = new Vector2(1.0f / xCount, 1.0f / yCount);
        texOffset = Vector2.zero;
        preIndex = -1;
        prePlaying = true;
        totalIndex = xCount * yCount;

        _material.mainTextureScale = texScale;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshParticleSystem();

        float particleTime = psComp.time;
        if (psComp.isPlaying && !prePlaying)
        {
            ResetAnimation();
        }
        prePlaying = psComp.isPlaying;

        if (xCount <= 0 || yCount <= 0 || framePerSecond == 0 || cycles == 0)
            return;

        timePerFrame = 1.0f / framePerSecond;

        float curTime = particleTime;
        int actualIndex = (int)Mathf.Floor(curTime / timePerFrame);
        int repeat = actualIndex / totalIndex;
        int index = actualIndex % totalIndex;

        if (preIndex == index || repeat >= cycles)
            return;

        /////////////////////////////////////
        // texture offset is like this
        //	(0,1)		(1,1)
        //
        //	(0,0)		(1,0)
        /////////////////////////////////////
        texOffset.x = (index % xCount) * texScale.x;
        texOffset.y = (yCount - 1 - index / xCount) * texScale.y;
        _material.mainTextureOffset = texOffset;
        preIndex = index;
    }
}
