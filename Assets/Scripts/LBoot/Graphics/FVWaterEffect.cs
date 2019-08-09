using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FVWaterEffect : MonoBehaviour
{
    private Renderer renderer = null;

    private bool updateMatsInEditorMode = false;

    void Start()
    {
        renderer = this.gameObject.GetComponent<Renderer>();
    }

    [SLua.DoNotToLua]
    public void UpdateWater(MaterialPropertyBlock pbBlock)
    {
        if (renderer == null)
            return;

        this.renderer.SetPropertyBlock(pbBlock);
    }

    void OnDestroy()
    {
        renderer = null;
    }
}
