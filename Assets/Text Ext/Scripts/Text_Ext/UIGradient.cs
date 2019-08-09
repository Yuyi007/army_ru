
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/UIGradient")]

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
public class UIGradient : BaseMeshEffect
#else
public class UIGradient : BaseVertexEffect
#endif
{
    [SerializeField]
    private Color32 topColor = Color.white;
    [SerializeField]
    private Color32 bottomColor = Color.black;

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
    [NonSerialized]
    private static Mesh s_TransferMesh;
#endif

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
    public override void ModifyMesh(Mesh mesh)
#else
    public override void ModifyVertices(List<UIVertex> vertexList)
#endif
    {
        if (!IsActive())
        {
            return;
        }

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        Vector3[] vertexList = mesh.vertices;
        int count = mesh.vertexCount;
#else
        int count = vertexList.Count;
#endif
        if (count > 0)
        {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            float bottomY = vertexList[0].y;
            float topY = vertexList[0].y;
#else
            float bottomY = vertexList[0].position.y;
            float topY = vertexList[0].position.y;
#endif

            //has a problem: if use at multiple line text, the gradient will effect from top line to bottom line, not font at one line.
            for (int i = 1; i < count; i++)
            {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
                float y = vertexList[i].y;
#else
                float y = vertexList[i].position.y;
#endif
                if (y > topY)
                {
                    topY = y;
                }
                else if (y < bottomY)
                {
                    bottomY = y;
                }
            }

            float uiElementHeight = topY - bottomY;

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            List<Color32> colors = new List<Color32>();
            for (int i = 0; i < count; i++)
            {
                colors.Add(Color32.Lerp(bottomColor, topColor, (vertexList[i].y - bottomY) / uiElementHeight));
            }
            mesh.SetColors(colors);
#else
            for (int i = 0; i < count; i++) {
				UIVertex uiVertex = vertexList[i];
				uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
				vertexList[i] = uiVertex;
			}
#endif
        }
    }

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
    public override void ModifyMesh(VertexHelper vh)
    {
        if (null == s_TransferMesh)
            s_TransferMesh = new Mesh();

        vh.FillMesh(s_TransferMesh);
        ModifyMesh(s_TransferMesh);
        VertexHelper temp = new VertexHelper(s_TransferMesh);

        int count = temp.currentVertCount;
        UIVertex tep = new UIVertex();
        for (int i = 0; i < count; ++i)
        {
            temp.PopulateUIVertex(ref tep, i);
            vh.SetUIVertex(tep, i);
        }
    }
#endif
}