using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SLua;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class StaticBatchRoot : MonoBehaviour
    {
        public GameObject[] staticGameObjects = null;
        private GameObject staticRootGo = null;

#if UNITY_EDITOR_OSX
        void Start()
        {
            if (!LBoot.LBootApp.Running)
                doCombineStaticBatch();
        }
#endif

        private IEnumerator CombineCoroutine()
        {
            for (var i = 0; i < staticGameObjects.Length; i++)
            {
                var g = staticGameObjects[i];
                if (g != null)
                {
                    var meshFilter = g.GetComponent<MeshFilter>();
                    var meshRenderer = g.GetComponent<MeshRenderer>();
                    if (meshRenderer != null && meshFilter != null && meshFilter.sharedMesh != null)
                    {
                        meshRenderer.receiveShadows = false;
                        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        g.transform.SetParent(staticRootGo.transform, true);
                    }
                    if (i % 10 == 0)
                        yield return null;
                }
            }

            StaticBatchingUtility.Combine(staticRootGo);
        }

        void OnDestroy()
        {
            staticGameObjects = null;
            staticRootGo = null;
        }

        public void doCombineStaticBatch()
        {
            if (staticGameObjects == null || staticGameObjects.Length <= 0)
                return;

            if (staticRootGo != null)
                return;

            this.staticRootGo = new GameObject("StaticRoot");

            staticRootGo.transform.SetParent(this.transform);
            StartCoroutine(CombineCoroutine());
        }
    }
}
