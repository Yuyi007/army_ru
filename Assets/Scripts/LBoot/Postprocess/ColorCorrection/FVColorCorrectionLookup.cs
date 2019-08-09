
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LBoot;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/FV Color Correction (3D Lookup Texture)")]
    public class FVColorCorrectionLookup : PostEffectsBase
    {
        public Texture2D refTexture = null;
        public Shader shader;
        private Material material;

        private bool has3DTexture = false;
        // serialize this instead of having another 2d texture ref'ed
        static private Dictionary<string, Texture3D> converted3DLuts = new Dictionary<string, Texture3D>();
        private Texture3D converted3DLut = null;
        private bool usingLut3D = true;
        private Vector4 longScaleOffset = Vector4.zero;
#if UNITY_ANDROID
        private bool forceUseLut2D = true;
#else
        private bool forceUseLut2D = false;   
#endif

        public bool ForceUseLut2D
        {
            get
            {
                return forceUseLut2D;
            }
            set
            {
                forceUseLut2D = value;
            }
        }


        void Awake()
        {
            // LogUtil.Debug("FVColorCorrectionLookup Awake usingLut3D=" + usingLut3D);
            if (!refTexture)
                refTexture = Resources.Load("Texture/Neutral3D16b", typeof(Texture2D)) as Texture2D;

			checkShader ();
        }

		void checkShader()
		{
            // LogUtil.Debug("FVColorCorrectionLookup checkShader usingLut3D=" + usingLut3D);
			if (SystemInfo.supports3DTextures && !forceUseLut2D) {
				shader = Shader.Find("Hidden/ColorCorrection3DLut");
				usingLut3D = true;
			} else {
				shader = Shader.Find("Hidden/ColorCorrection2DLut");
				usingLut3D = false;
			}
		}

        public bool tryCheckResources(bool needCheckShader, bool forceCheckShader)
        {
            // LogUtil.Debug("FVColorCorrectionLookup CheckResources usingLut3D=" + usingLut3D);
            CheckSupport(false);

            material = CheckShaderAndCreateMaterial(shader, material);

            // in editor when we switch graphics emulation, we need to re-check
            // which shader should be used
            if (forceCheckShader || needCheckShader && !isSupported)
            {
                checkShader();
                material = CheckShaderAndCreateMaterial(shader, material);
            }

            if (!isSupported)
            {
                ReportAutoDisable();
            }
            else if (!has3DTexture && refTexture != null && usingLut3D)
            {
                Convert(refTexture);
            }
            
            return isSupported;       
        }

        public override bool CheckResources()
        {
#if UNITY_EDITOR
            return tryCheckResources(true, false);
#else
            return tryCheckResources(false, false);
#endif
        }

        void OnDisable()
        {
            if (material)
            {
                DestroyImmediate(material);
                material = null;
            }
        }

        void OnDestroy()
        {
        }

        public bool ValidDimensions(Texture2D tex2d)
        {
            if (!tex2d)
                return false;
            int h = tex2d.height;
            if (h != Mathf.FloorToInt(Mathf.Sqrt(tex2d.width)))
            {
                return false;
            }
            return true;
        }

        public Texture3D GetLutFromCache(string name)
        {
            Texture3D texture = null;
            converted3DLuts.TryGetValue(name, out texture);
            return texture;
        }

        public void Convert(Texture2D temp2DTex)
        {
            // conversion fun: the given 2D texture needs to be of the format
            //  w * h, wheras h is the 'depth' (or 3d dimension 'dim') and w = dim * dim
            if (has3DTexture)
                return;

            if (temp2DTex)
            {

                converted3DLut = GetLutFromCache(temp2DTex.name);

                if (converted3DLut == null)
                {
					
                    int dim = temp2DTex.width * temp2DTex.height;
                    dim = temp2DTex.height;

                    if (!ValidDimensions(temp2DTex))
                    {
                        LogUtil.Warn("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT.");
                        return;
                    }

                    var c = temp2DTex.GetPixels();
                    var newC = new Color[c.Length];

                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            for (int k = 0; k < dim; k++)
                            {
                                int j_ = dim - j - 1;
                                newC[i + (j * dim) + (k * dim * dim)] = c[k * dim + i + j_ * dim * dim];
                            }
                        }
                    }

                    converted3DLut = new Texture3D(dim, dim, dim, TextureFormat.ARGB32, false);
                    converted3DLut.SetPixels(newC);
                    converted3DLut.Apply();

                    converted3DLuts.Add(temp2DTex.name, converted3DLut);
                }

                has3DTexture = true;
            }
            else
            {
                // error, something went terribly wrong
                LogUtil.Error("Couldn't color correct with 3D LUT texture. Image Effect will be disabled.");
            }
        }

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            // LogUtil.Debug("FVColorCorrectionLookup OnRenderImage usingLut3D=" + usingLut3D);
			if (CheckResources() == false || (!SystemInfo.supports3DTextures || converted3DLut == null) && usingLut3D)
            {
                Graphics.Blit(source, destination);
                return;
            }

			if (usingLut3D) {
				int lutSize = converted3DLut.width;
				converted3DLut.wrapMode = TextureWrapMode.Clamp;
				material.SetFloat ("_Scale", (lutSize - 1) / (1.0f * lutSize));
				material.SetFloat ("_Offset", 1.0f / (2.0f * lutSize));
				material.SetTexture ("_ClutTex", converted3DLut);
			} else {
                if (refTexture == null) {
                    Graphics.Blit(source, destination);
                    return;
                }

				int lutSize = refTexture.height;
                int longSize = lutSize * lutSize;
				refTexture.wrapMode = TextureWrapMode.Clamp;
				material.SetTexture ("_ClutTex", refTexture);

                float invLutSize = 1.0f / lutSize;
                float lutSizeMunusOne = lutSize - 1;
                float halfOfInvLutSize = invLutSize * 0.5f;
                float halfOfInvLongSize = 1.0f / (2.0f * longSize);
                float lutScale = lutSizeMunusOne * invLutSize;

                material.SetFloat ("_LutSizeMinusOne", lutSizeMunusOne);
                material.SetFloat ("_InvLutSize", invLutSize);

				longScaleOffset.Set (
					lutScale, 
					lutScale,
					halfOfInvLongSize,
					halfOfInvLutSize
				);
				material.SetVector ("_LongScaleOffset", longScaleOffset);
			}

            Graphics.Blit(source, destination, material, QualitySettings.activeColorSpace == ColorSpace.Linear ? 1 : 0);
        }
    }

}


