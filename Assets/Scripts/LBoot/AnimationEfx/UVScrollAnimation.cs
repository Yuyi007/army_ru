using UnityEngine;
using System.Collections;

public class UVScrollAnimation : MonoBehaviour
{

    public bool enableScrolling = false;
    public Vector2 scrollVelocity = Vector2.zero;

    private Renderer _renderer = null;
    private Material _material = null;

    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer != null)
        {
#if UNITY_EDITOR
            _material = _renderer.material;
#else
            _material = _renderer.sharedMaterial;
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_material == null || !enableScrolling)
        {
            return;
        }
        Vector2 toffset = _material.mainTextureOffset + scrollVelocity * Time.deltaTime;
        toffset.x -= Mathf.Floor(toffset.x);
        toffset.y -= Mathf.Floor(toffset.y);
        _material.mainTextureOffset = toffset;
    }

    void OnDestroy()
    {
        _renderer = null;
        _material = null;
    }
}
