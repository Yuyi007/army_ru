using UnityEngine;
using System.Collections;
using System;
using SLua;

namespace Game{

[ExecuteInEditMode]
[AddComponentMenu ("Component/Image Effects/Blur/RadialBlur/RadialBlur")]
[CustomLuaClassAttribute]
public class RadialBlur : MonoBehaviour {
	#region Variables
	public Shader RadialBlurShader = null;
	private Material RadialBlurMaterial = null;
	// private RenderTextureFormat rtFormat = RenderTextureFormat.Default;

	[Range(0.0f, 1.0f)]
	public float SampleDist = 0.17f;

	[Range(1.0f, 5.0f)]
	public float SampleStrength = 2.09f;


	#endregion
	

void Start () {
		FindShaders ();
		CheckSupport ();
		CreateMaterials ();
	}

	void FindShaders () {
		if (!RadialBlurShader) {
            RadialBlurShader = Shader.Find("Component/Image Effects/Blur/RadialBlur/Shader/RadialBlur");
		}
	}

	void CreateMaterials() {
		if(!RadialBlurMaterial){
			RadialBlurMaterial = new Material(RadialBlurShader);
			RadialBlurMaterial.hideFlags = HideFlags.HideAndDontSave;	
		}
	}

	bool Supported(){
		return (SystemInfo.supportsImageEffects && SystemInfo.supportsRenderTextures && RadialBlurShader.isSupported);
		// return true;
	}


	bool CheckSupport() {
		if(!Supported()) {
			enabled = false;
			return false;
		}
		// rtFormat = SystemInfo.SupportsRenderTextureFormat (RenderTextureFormat.RGB565) ? RenderTextureFormat.RGB565 : RenderTextureFormat.Default;
		return true;
	}


	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{	
		#if UNITY_EDITOR
			FindShaders ();
			CheckSupport ();
			CreateMaterials ();	
		#endif

		if(SampleDist != 0 && SampleStrength != 0){
             
            int scale = 8;
            if (sourceTexture.width <= 320)
            {
                scale = 1;
            } else if (sourceTexture.width <= 640)
            {
                scale = 2;
            } else if (sourceTexture.width <= 1280)
            {
                scale = 4;
            } else if (sourceTexture.width <= 1920)
            {
                scale = 8;
            } else
            {
                scale = 8;
            }
            int rtW = sourceTexture.width/scale;
            int rtH = sourceTexture.height/scale;


	        RadialBlurMaterial.SetFloat ("_SampleDist", SampleDist);
	        RadialBlurMaterial.SetFloat ("_SampleStrength", SampleStrength);	


	        RenderTexture rtTempA = RenderTexture.GetTemporary (rtW, rtH, 0,RenderTextureFormat.Default);
            rtTempA.filterMode = FilterMode.Bilinear;

            Graphics.Blit (sourceTexture, rtTempA);

            RenderTexture rtTempB = RenderTexture.GetTemporary (rtW, rtH, 0,RenderTextureFormat.Default);
            rtTempB.filterMode = FilterMode.Bilinear;
            // RadialBlurMaterial.SetTexture ("_MainTex", rtTempA);
            Graphics.Blit (rtTempA, rtTempB, RadialBlurMaterial,0);

            RadialBlurMaterial.SetTexture ("_BlurTex", rtTempB);
       		Graphics.Blit (sourceTexture, destTexture, RadialBlurMaterial,1);

            RenderTexture.ReleaseTemporary(rtTempA);
            RenderTexture.ReleaseTemporary(rtTempB);
 
		}

		else{
			Graphics.Blit(sourceTexture, destTexture);
			
		}
		
		
	}
	
	 public void OnDisable () {
        if (RadialBlurMaterial)
            DestroyImmediate (RadialBlurMaterial);
            // RadialBlurMaterial = null;
    }
}

}
