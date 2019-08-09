using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLua;

namespace Game
{
    [CustomLuaClassAttribute]
    public class UIRadar : Graphic
    {
        public Vector3[] pos = new Vector3[7];

        public void setVertices(int index, Vector3 vec)
        {
            pos[index] = vec;
        }

        public void apply()
        {
            SetVerticesDirty(); 
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            Color32 color32 = color;
            vh.Clear();
            // 这里我用5对GameObject的坐标来与该Image对象的五个顶点绑定起来
            // AddVert的最后一个参数是UV值

            vh.AddVert(pos[0], color32, new Vector2(0.5f, 0.5f));
            vh.AddVert(pos[1], color32, new Vector2(0.5f, 1f));
            vh.AddVert(pos[2], color32, new Vector2(1f, 1f));
            vh.AddVert(pos[3], color32, new Vector2(0f, 1f));
            vh.AddVert(pos[4], color32, new Vector2(0f, 0.5f));
            vh.AddVert(pos[5], color32, new Vector2 (0f, 0f));
            vh.AddVert(pos[6], color32, new Vector2(0f, 1f));

            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(0, 2, 3);
            vh.AddTriangle(0, 3, 4);
            vh.AddTriangle(0, 4, 5);
            vh.AddTriangle(0, 5, 6);
            vh.AddTriangle(0, 1, 6);
        }
    } 
}

