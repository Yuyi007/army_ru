using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SLua;

namespace LBoot
{
    [AddComponentMenu("UI/Effects/Grayscale")]
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    [CustomLuaClassAttribute]
    public class Grayscale : BaseMeshEffect
    {
        [Range(0, 1)]
        public float fill;
        //public Color grayColor = Color.white;
        [Range(0, 1)]
        public float grayScale = 1.0f;


        [System.Serializable]
        [CustomLuaClassAttribute]
        public enum FillDirection
        {
            BottomTop,
            TopBottom,
            LeftRight,
            RightLeft,
        }

        public FillDirection fillDirection;
        private Image image;
        private Shader shader;

        // Use this for initialization
        protected override void Start()
        {
            image = GetComponent<Image>();
            shader = Shader.Find("UI/Grayscale");
            image.material = new Material(shader);
        }

        void Update()
        {
            image.material.SetFloat("_Fill", fill);
            image.material.SetFloat("_GrayScale", grayScale);
        }

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!this.IsActive())
            {
                return;
            }
            List<UIVertex> verts = new List<UIVertex>();
            vh.GetUIVertexStream(verts);

            float min = float.MaxValue;
            float max = float.MinValue;
            float len = 0;
            var vertsCount = verts.Count;
            for (int i = 0; i < vertsCount; i++)
            {
                switch (fillDirection)
                {
                    case FillDirection.BottomTop:
                    case FillDirection.TopBottom:
                        if (verts[i].position.y < min)
                            min = verts[i].position.y;
                        if (verts[i].position.y > max)
                            max = verts[i].position.y;
                        break;
                    case FillDirection.LeftRight:
                    case FillDirection.RightLeft:
                        if (verts[i].position.x < min)
                            min = verts[i].position.x;
                        if (verts[i].position.x > max)
                            max = verts[i].position.x;
                        break;
                }
            }
            len = max - min;
            if (len == 0)
                return;
            for (int i = 0; i < vertsCount; i++)
            {
                UIVertex uiVertex = verts[i];
                switch (fillDirection)
                {
                    case FillDirection.BottomTop:
                        uiVertex.uv1.y = (verts[i].position.y - min) / len;
                        break;
                    case FillDirection.TopBottom:
                        uiVertex.uv1.y = (max - verts[i].position.y) / len;
                        break;
                    case FillDirection.LeftRight:
                        uiVertex.uv1.y = (verts[i].position.x - min) / len;
                        break;
                    case FillDirection.RightLeft:
                        uiVertex.uv1.y = (max - verts[i].position.x) / len;
                        break;
                }
                verts[i] = uiVertex;
            }

            vh.Clear();
            vh.AddUIVertexTriangleStream(verts);
        }
    }
}