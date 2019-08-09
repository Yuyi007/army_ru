using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using SLua;
using LBoot;

[RequireComponent(typeof(Camera))]
[CustomLuaClassAttribute, ExecuteInEditMode]
public class GhostCamera : PostEffectsBase
{
    public Texture2D scanlineTex = null;
    public Texture2D lomoMaskTex = null;

    public Shader compShader = null;
	public Material compMaterial = null;
	public float lineNum;

	private Camera cam = null;

    void Awake()
    {
		cam = this.gameObject.GetComponent<Camera> ();
		compShader = Shader.Find("Hidden/FVGhostCamera");
		scanlineTex = Resources.Load("Texture/scan_line", typeof(Texture2D)) as Texture2D;
		lomoMaskTex = Resources.Load("Texture/lomo_mask", typeof(Texture2D)) as Texture2D;
		lineNum = 70f;
    }

	public override bool CheckResources()
	{
		//LogUtil.Warn("before check resources: " + isSupported.ToString());

		CheckSupport(false);

		//LogUtil.Warn("after check resources: " + isSupported.ToString());

		compMaterial = CheckShaderAndCreateMaterial(compShader, compMaterial);

		//LogUtil.Warn("after check bloom material: " + isSupported.ToString());

		if (!isSupported)
			ReportAutoDisable();
		return isSupported;
	}

	public void OnDestroy()
	{
		// OnDestroy() will only be called for once active objects
		// Do not rely on this call to DestroyTextures()
		// DestroyTexture(cam.targetTexture);
	}

	public void DestroyTexture(RenderTexture rt)
	{
		if (rt != null) 
		{
			rt.Release();
			if (Application.isPlaying)
				Destroy(rt);
			else
				DestroyImmediate(rt);
		}
	}

	void Update()
	{
		// checkRenderTexture ();
	}

	int getWidth()
	{
		return (int)(Screen.width * 0.5f);
	}

	int getHeight()
	{
		return (int)(Screen.height* 0.5f);
	}

	public RenderTexture getRenderTexture()
	{
		return cam.targetTexture;
	}

	void checkRenderTexture()
	{
		int tw = getWidth();
		int th = getHeight();

		RenderTexture rt = cam.targetTexture;
		if (rt == null || rt.width != tw || rt.height != th) {
			DestroyTexture (rt);
			rt = new RenderTexture(tw, th, 24);
			cam.targetTexture = rt;
		}
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (CheckResources() == false)
		{
			Graphics.Blit(source, destination);
			return;
		}

		int tw = getWidth();
		int th = getHeight();

		Vector4 uvScale = new Vector4((float)tw / scanlineTex.width, lineNum, (float)tw / th, 0);
		float width = tw;
		float height = th;
		if (width > height) {
			uvScale.z = width / height;
			uvScale.w = 1;
		} else {
			uvScale.z = 1;
			uvScale.w = height / width;
		}

		scanlineTex.wrapMode = TextureWrapMode.Repeat;
		lomoMaskTex.wrapMode = TextureWrapMode.Clamp;
		compMaterial.SetTexture ("_ScanLineTex", scanlineTex);
		compMaterial.SetTexture ("_LomoTex", lomoMaskTex);
		compMaterial.SetVector ("_ScanLine_UVScale", uvScale);
		Graphics.Blit(source, destination, compMaterial, 0);
	}
}