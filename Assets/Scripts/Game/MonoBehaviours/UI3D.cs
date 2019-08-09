using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SLua;

namespace Game
{
    [CustomLuaClassAttribute]
    public class UI3D : MonoBehaviour
    {
        [HideInInspector]
        [System.NonSerialized]
        public RenderTexture uiTexture = null;
        [HideInInspector]
        public Camera camera = null;
        [HideInInspector]
        public RawImage rawImg = null;
        [HideInInspector]
        public GameObject goScenery = null;

        [HideInInspector]
        public bool preview = false;

        #if UNITY_EDITOR
        [SLua.DoNotToLua]
        [System.NonSerialized]
        public GameObject previewModel;
        #endif

        public int width = 512;
        public int height = 512;

        public Vector3 modelRotation = new Vector3(0, 145, 0);
        public Vector3 modelPosition = new Vector3(10, -128, 550);
        public float modelScale = 120;

        private GameObject model;

        public void AddToScene(GameObject go)
        {
            go.transform.SetParent(goScenery.transform, false);
            go.transform.SetLayer("3DUI", true);
            model = go;
        }

        private void AdjustSize(out int w, out int h)
        {
            w = width;
            h = height;
            float fr = (float)Screen.width / (float)Screen.height;
            float fro = (float)width / (float)height;
            if (fr > fro)
            {
                h = (int)(height * (float)Screen.height / 640);
                w = (int)(width * (float)Screen.height / 640);
            }
            else
            {
                h = (int)(height * (float)Screen.width / 960.0f);
                w = (int)(width * (float)Screen.width / 960.0f);
            }
        }
#if UNITY_EDITOR
        private void Update()
        {
            if (IsGameRunning()) return;

            if (model != null)
            {
                model.transform.localPosition = modelPosition;
                model.transform.localScale = Vector3.one * modelScale;
                model.transform.eulerAngles = modelRotation;
            }
        }

        private void Start()
        {

            if (!IsGameRunning())
            {
                Preview();
            }
        }

        private bool IsGameRunning()
        {
            return LBoot.LBootApp.Running;
        }

        private void Preview()
        {
            if (this.uiTexture == null)
            {
                this.uiTexture = new RenderTexture(this.width, this.height, 16, RenderTextureFormat.ARGB32);
                this.rawImg.texture = this.uiTexture;
                this.rawImg.color = Color.white;
                this.camera.targetTexture = this.uiTexture;
                //				this.camera.renderingPath = 1;
                this.camera.nearClipPlane = 1;
                var rt = this.rawImg.GetComponent<RectTransform>();
                var rc = rt.rect;
                rt.rect.Set(rc.x, rc.y, this.width, this.height);
            }

            GameObject go = null;
            if (previewModel)
                go = GameObject.Instantiate(previewModel);
            else
                go = LBoot.BundleHelper.LoadAndCreate("Prefab/entity/test/whitecar", -1);
            go.transform.localPosition = modelPosition;
            go.transform.localScale = Vector3.one * modelScale;
            go.transform.eulerAngles = modelRotation;
            AddToScene(go);
        }
#endif
    }
}