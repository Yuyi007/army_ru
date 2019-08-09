//
// ShowStatsBehaviour.cs
//
// Author:
//       duwenjie
//

//
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using SLua;
using System.Text;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class ShowStatsBehaviour : MonoBehaviour
    {
        public float f_UpdateInterval = 0.5F;
        
        private bool b_FpsUpdated = false;
        private float f_LastInterval;
        private int i_Frames = 0;
        private float f_Fps;

        private Rect rect = new Rect(0, 0, 400, 200);

        private bool b_ShowDetailed = false;
        private bool b_UpdateDetailed = false;
        private int i_Tris = 0;
        private int i_Verts = 0;
        private long i_MemUsage = 0;

        private string customStats = "";
        private Texture image;
        private Rect imageRect;
        private StringBuilder guiStringBuilder = new StringBuilder();

        void Start()
        {
            LogUtil.Debug("Start ShowStats");

            f_LastInterval = Time.realtimeSinceStartup;
            
            i_Frames = 0;

            DontDestroyOnLoad(this.gameObject);

            if (!Debug.isDebugBuild)
                this.enabled = false;
        }

        public Rect Rect
        {
            get
            {
                return rect;
            }
            set
            {
                rect = value;
            }
        }

        public bool ShowDetailed
        {
            get
            {
                return b_ShowDetailed;
            }
            set
            {
                b_ShowDetailed = value;
            }
        }

        public bool UpdateDetailed
        {
            get
            {
                return b_UpdateDetailed;
            }
            set
            {
                b_UpdateDetailed = value;
            }
        }

        public string CustomStats
        {
            get
            {
                return customStats;
            }
            set
            {
                customStats = value;
            }
        }

        public Texture Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public Rect ImageRect
        {
            get
            {
                return imageRect;
            }
            set
            {
                imageRect = value;
            }
        }

        public float Fps
        {
            get
            {
                return f_Fps;
            }
        }

        public int Tris
        {
            get
            {
                return i_Tris;
            }
        }

        public int Verts
        {
            get
            {
                return i_Verts;
            }
        }

        public long MemUsage
        {
            get
            {
                return i_MemUsage;
            }
        }

        void OnGUI()
        {
            if (b_FpsUpdated == false)
            {
                DrawGUI();
                return;
            }
            b_FpsUpdated = false;
            
            guiStringBuilder.Length = 0;
            guiStringBuilder.Capacity = 64;
            
            guiStringBuilder.Append("FPS:").AppendLine(f_Fps.ToString("f2"));

            if (b_ShowDetailed)
            {
                guiStringBuilder.Append("Resolution:").AppendLine("(" + Screen.width.ToString() + "," + Screen.height.ToString() + ")");
                guiStringBuilder.Append("i_Tris:").AppendLine(i_Tris.ToString());
                guiStringBuilder.Append("i_Verts:").AppendLine(i_Verts.ToString());
                guiStringBuilder.Append("mem:").AppendLine(i_MemUsage.ToString());
            }

            if (customStats != null && customStats.Length > 0)
            {
                guiStringBuilder.AppendLine(customStats);
            }

            DrawGUI();
        }

        void DrawGUI()
        {
            GUI.Label(rect, guiStringBuilder.ToString());

            if (image != null && imageRect != null)
            {
                GUI.DrawTexture(imageRect, image);
            }
        }

        void Update()
        {
            ++i_Frames;
            
            var now = Time.realtimeSinceStartup;
            if (now > f_LastInterval + f_UpdateInterval)
            {
                f_Fps = i_Frames / (now - f_LastInterval);
                f_LastInterval = now;
                b_FpsUpdated = true;
                i_Frames = 0;      

                if (b_UpdateDetailed)
                {
                    i_Tris = 0;
                    i_Verts = 0;
                    i_MemUsage = 0;

                    GameObject[] gameObjs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                    foreach (GameObject go in gameObjs)
                    {
                        SkinnedMeshRenderer smr = go.GetComponent<SkinnedMeshRenderer>();
                        if (smr)
                        {
                            i_Tris += smr.sharedMesh.triangles.Length / 3;
                            i_Verts += smr.sharedMesh.vertexCount;
                        }

                        MeshFilter mf = go.GetComponent<MeshFilter>();
                        if (mf)
                        {
                            if (mf.mesh.isReadable && mf.mesh.vertexCount > 0)
                            {
                                i_Tris += mf.mesh.triangles.Length / 3;
                                i_Verts += mf.mesh.vertexCount;
                            }
                        }

                        i_MemUsage += UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(go);
                    }
                }
            }
        }
    }
}
