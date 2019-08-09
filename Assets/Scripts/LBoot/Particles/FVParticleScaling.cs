using UnityEngine;
using System.Collections;
using SLua;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class FVParticleScaling : MonoBehaviour
    {
        public GameObject psRoot = null;

        private FVParticleRoot fvpr = null;
        private Renderer rendererComp = null;
        private Material material = null;
        private ParticleSystem ps = null;

        private static Shader additiveScalableShader = null;
        private static Shader alphaScalableShader = null;

        private bool isWorldSpace = false;
        private Vector3 lastPosition = Vector3.zero;
        private Vector2 orgTexScale = Vector2.one;
        private Vector2 curTexScale = Vector2.one;
        private Vector2 orgTexOffset = Vector2.zero;
        private ParticleSystem.MinMaxCurve pxc = new ParticleSystem.MinMaxCurve(0);
        private ParticleSystem.MinMaxCurve nxc = new ParticleSystem.MinMaxCurve(0);
        private Vector3 orgPositionOffset = Vector3.zero;
        private MaterialPropertyBlock propertyBlock = null;
        private Vector4 originMainTexSt = Vector4.zero;
        private static MaterialPropertyBlock staticPropertyBlockTexST = null;

        public static void Clear()
        {
            additiveScalableShader = null;
            alphaScalableShader = null;
        }

        [SLua.DoNotToLua]
        public void Init(FVParticleRoot fvpRoot)
        {
//            if (additiveScalableShader == null)
//            {
//                additiveScalableShader = Shader.Find("Custom/Mobile/Particles/AdditiveScalable");
//            }
//
//            if (alphaScalableShader == null)
//            {
//                alphaScalableShader = Shader.Find("Custom/Mobile/Particles/AlphaScalable");
//            }

            fvpr = fvpRoot;

//            if (psRoot == null)
//            {
//                fvpr = GetComponentInParent<FVParticleRoot>();
//                if (fvpr != null)
//                    psRoot = fvpr.gameObject;
//            }
//            else
//            {
//                fvpr = psRoot.GetComponent<FVParticleRoot>();
//            }

            rendererComp = GetComponent<UnityEngine.Renderer>();

            if (material == null && rendererComp != null)
            {
// #if UNITY_EDITOR
//                 // avoid changing the original material in editor
//                 material = rendererComp.material;
// #else
                material = rendererComp.sharedMaterial;
// #endif
//                if (material != null && !material.shader.name.EndsWith("Scalable"))
//                {
//                    var shader = additiveScalableShader;
//                    if (material.shader.name.Contains("Alpha"))
//                    {
//                        shader = alphaScalableShader;
//                    }
//
//                    material.shader = shader;
//                }
            }

            ps = this.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                isWorldSpace = (ps.simulationSpace == ParticleSystemSimulationSpace.World);
                saveOriginalParameter();
            }

            if (fvpr != null)
            {
                orgPositionOffset = this.transform.position - fvpr.transform.position;
                if (!isWorldSpace)
                {
                    propertyBlock = fvpr.PropertyBlock;
                }
                else
                {
                    if (staticPropertyBlockTexST == null)
                    {
                        staticPropertyBlockTexST = new MaterialPropertyBlock();
                    }
                    propertyBlock = staticPropertyBlockTexST;
                }
            }
            lastPosition = this.transform.position;
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            if (!LBoot.LBootApp.Running)
                CorrectMaterial();
        }

        [SLua.DoNotToLua]
        public void Reset()
        {
            if (!LBoot.LBootApp.Running)
                CorrectMaterial();
        }


        void CorrectMaterial()
        {
            Shader additiveShader = null;
            Shader alphaShader = null;



            rendererComp = GetComponent<Renderer>();

            if (rendererComp != null)
            {
                material = rendererComp.sharedMaterial;
                if (material != null && !material.shader.name.EndsWith("Scalable"))
                {
                    additiveShader = Shader.Find("Custom/Mobile/Particles/AdditiveScalable");
                    alphaShader = Shader.Find("Custom/Mobile/Particles/AlphaScalable");

                    var shader = additiveShader;
                    if (material.shader.name.Contains("Alpha"))
                    {
                        shader = alphaShader;
                    }

                    material.shader = shader;
                }
            }
        }

#endif
        [SLua.DoNotToLua]
        public void RefreshPositionAndScale()
        {
            if (!isWorldSpace)
            {
                handleLocalSpace();
            }
            else
            {
                handleWorldSpace();
            }
        }

        public void OnEnable()
        {
            RefreshPositionAndScale();
        }


        [SLua.DoNotToLua]
        public void handleWorldSpace()
        {
            if (fvpr == null || rendererComp == null || propertyBlock  == null)
                return;

            Vector3 curPosition = this.transform.position;
            float xDiff = curPosition.x - lastPosition.x;
            applyParameter(xDiff);


            this.transform.position = fvpr.transform.position + Vector3.Scale(orgPositionOffset, fvpr.Scale);
            lastPosition = curPosition;
        }

        [SLua.DoNotToLua]
        public void handleLocalSpace()
        {
            if (rendererComp == null || propertyBlock == null)
                return;

            rendererComp.SetPropertyBlock(propertyBlock);
        }


        [SLua.DoNotToLua]
        private void saveOriginalParameter()
        {
            if (!isWorldSpace)
            {
                return;
            }

            if (ps.velocityOverLifetime.enabled)
            {
                if (ps.velocityOverLifetime.x.mode == ParticleSystemCurveMode.Constant)
                {
                    pxc = new ParticleSystem.MinMaxCurve(ps.velocityOverLifetime.x.constantMax);
                    nxc = new ParticleSystem.MinMaxCurve(-ps.velocityOverLifetime.x.constantMax);
                }
            }

            if (material != null)
            {
                orgTexScale = material.mainTextureScale;
                orgTexOffset = material.mainTextureOffset;
            }
        }

        void OnDestroy()
        {
            this.fvpr = null;
            this.rendererComp = null;
            this.propertyBlock = null;
            this.psRoot = null;
            this.ps = null;
            this.material = null;
        }

        [SLua.DoNotToLua]
        private void applyParameter(float xDiff)
        {
            if (!isWorldSpace)
            {
                return;
            }

            var velocityOverLifetime = ps.velocityOverLifetime;

            if (velocityOverLifetime.enabled)
            {
                if (velocityOverLifetime.x.mode == ParticleSystemCurveMode.Constant)
                {
                    var vel = velocityOverLifetime;
                    if (xDiff > 0)
                    {
                        vel.x = pxc;
                    }
                    else if (xDiff < 0)
                    {
                        vel.x = nxc;
                    }
                }
            }

            curTexScale = orgTexScale;
            if (xDiff > 0)
            {
                originMainTexSt.Set(curTexScale.x, curTexScale.y, orgTexOffset.x, orgTexOffset.y);
                propertyBlock.SetVector("_MainTex_ST", originMainTexSt);
                rendererComp.SetPropertyBlock(propertyBlock);
            }
            else if (xDiff < 0)
            {
                curTexScale.x = -curTexScale.x;
                originMainTexSt.Set(curTexScale.x, curTexScale.y, orgTexOffset.x, orgTexOffset.y);
                propertyBlock.SetVector("_MainTex_ST", originMainTexSt);
                rendererComp.SetPropertyBlock(propertyBlock);
            }


        }
    }
}
