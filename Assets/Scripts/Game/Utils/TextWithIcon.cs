using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using LBoot;
using SLua;

namespace UI.Sources
{
    [CustomLuaClassAttribute]
    public class TextWithIcon : Text
    {
        public float sizeDelta = -4;
        private List<Image> icons = new List<Image>();
        private List<Vector3> positions = new List<Vector3>();
        private List<string> matchValues = new List<string>();
        private List<string> paths = new List<string>();
        private List<string> names = new List<string>();
        private List<float> heights = new List<float>();
        private List<float> widths = new List<float>();
        private List<float> heightDeltas = new List<float>();
        private List<int> indexes = new List<int>();
        private float _fontHeight;
        private float _fontWidth;
        private GameObject root;

        
        private List<Image> _iconsPool = null;

        private List<Image> iconsPool
        {
            get
            {
                if (_iconsPool == null)
                {
                    _iconsPool = new List<Image>();
                }
                return _iconsPool;
            }
        }

        private int _iconIdx = 0;

        private bool dataDirty = false;

        protected string m_OriginText = "";
        protected string mLastPrintOriginText = "";
        //private bool justChecked = false;

        public string OriginText
        {
            get
            {
                return m_OriginText;
            }
            set
            {
                if (null == m_OriginText || !m_OriginText.Equals(value, StringComparison.Ordinal))
                {
                    m_OriginText = value;
                    SetPrintText();
                }
            }
        }

        protected override void OnDestroy()
        {
            if (this.icons != null)
            {
                this.icons.Clear();
            }

            if (this.heights != null)
            {
                this.heights.Clear();
            }

            if (this.widths != null)
            {
                this.widths.Clear();
            }

            if (this.heightDeltas != null)
            {
                this.heightDeltas.Clear();
            }

            if (this._iconsPool != null)
            {
                this._iconsPool.Clear();
            }

            if (this.indexes != null)
            {
                this.indexes.Clear();
            }

            if (this.names != null)
            {
                this.names.Clear();
            }

            if (this.positions != null)
            {
                this.positions.Clear();
            }

            if (this.matchValues != null)
            {
                this.matchValues.Clear();
            }

            if (this.paths != null)
            {
                this.paths.Clear();
            }

            this.matchValues = null;
            this.icons = null;
            this._iconsPool = null;
            this.heights = null;
            this.widths = null;
            this.indexes = null;
            this.names = null;
            this.positions = null;
            this.heightDeltas = null;
            this.root = null;
            this.paths = null;

            base.OnDestroy();
        }

        public string processedText
        {
            get { return base.text; }
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            base.OnPopulateMesh(vh);

            positions.Clear();

            int startVertexIndex;
            dataDirty = true;

            UIVertex vert0 = new UIVertex();
            UIVertex vert2 = new UIVertex();
            UIVertex vert3 = new UIVertex();
            int currentVertCount = vh.currentVertCount;

            for (var k = 0; k < indexes.Count; k++)
            {
                startVertexIndex = indexes[k] * 4 + 3;
                if (startVertexIndex >= currentVertCount)
                {
                    continue;
                }

                vh.PopulateUIVertex(ref vert0, startVertexIndex);
                vh.PopulateUIVertex(ref vert2, startVertexIndex - 2);
                vh.PopulateUIVertex(ref vert3, startVertexIndex - 3);

                _fontHeight = Vector3.Distance(vert3.position, vert0.position);
                _fontWidth = Vector3.Distance(vert3.position, vert2.position);

                float height = heights[k];
                float width = widths[k];
                float heightDelta = heightDeltas[k];
                // Debug.Log("x:"+ vert0.position.x);
                // Debug.Log("y:"+ vert0.position.y);
                // Debug.Log("z:"+ vert0.position.z);  
                // Debug.Log("width:"+ width);  
                // Debug.Log("heightDelta:"+ heightDelta); 
                //+heightDelta-1
                positions.Add(new Vector3(vert0.position.x + width / 2 , vert0.position.y + heightDelta, vert0.position.z));
            }
        }

        void Update()
        {
            CheckDirtyData();
        }

        private Sprite GetSprite(string name)
        {
            return BundleConfig.Get().GetSprite(name);
        }

        private Material GetMaterial(string name)
        {
            return BundleConfig.Get().GetMaterial(name);
        }

        //
        //
        private void ParseMatchString(string matchValue, ref string path, ref string name, ref float width, ref float height, ref float heightDelta)
        {
            var result = Regex.Match(matchValue, @"\<\s*sprite\s*\=\s*(.*?)\s*name\s*\=\s*(.*?)\s*width\s*\=\s*(.*?)\s*height\s*\=\s*(.*?)\s*heightDelta\s*\=\s*(.*?)\s*\/\>").Groups;
            int index = 0;
            foreach (var item in result)
            {
                if (index == 1)
                    path = item.ToString();
                else if (index == 2)
                    name = item.ToString();
                else if (index == 3)
                    width = System.Convert.ToSingle(item.ToString());
                else if (index == 4)
                    height = System.Convert.ToSingle(item.ToString());
                else if (index == 5)
                    heightDelta = System.Convert.ToSingle(item.ToString());
                index += 1;
            }
        }

        private void ClearIcons()
        {
            if (icons != null)
            {
                icons.Clear();
            }
            Transform t = this.transform.Find("iconroot");
            // LogUtil.Debug("-------- ClearIcons t:" + t);
            if (t)
            {
                GameObject.DestroyImmediate(t.gameObject);
            }
        }

        private void RecycleIcons()
        {
            if (icons != null)
            {
                for (var i = 0; i < icons.Count; i++)
                {
                    icons[i].gameObject.SetActive(false);
                    iconsPool.Add(icons[i]);
                }
                icons.Clear();
            }
        }

        private Image GetOneIcon()
        {
            var len = iconsPool.Count;
            if (len > 0)
            {
                var icon = iconsPool[0];
                iconsPool.RemoveAt(0);
                icon.gameObject.SetActive(true);
                return icon;
            }
            else
            {
                _iconIdx += 1;
                Transform rootTransform = getRootTransform();
                GameObject iconGo = new GameObject("icon" + _iconIdx);
                var iconTransform = iconGo.transform;
                iconTransform.SetParent(rootTransform);
                iconTransform.localScale = Vector3.one;

                iconGo.AddComponent<Image>();
                Image icon = iconGo.GetComponent<Image>();
                return icon;
            }
        }

        private Transform getRootTransform()
        {
            Transform t = this.transform.Find("iconroot");

            // LogUtil.Debug("-------- checkDirtyData t:" + t);

            Transform rootTransform;
            // GameObject root = GameObject.Find("iconroot");
            if (t == null)
            {
                // LogUtil.Debug("-------- checkDirtyData 1");
                rootTransform = new GameObject("iconroot").transform;
            }
            else
            {
                // LogUtil.Debug("-------- checkDirtyData 2");
                rootTransform = t;
                rootTransform.SetParent(transform);
                rootTransform.localScale = new Vector3(1, 1, 1);
                rootTransform.localPosition = new Vector3(0, 0, 0);
                rootTransform.localRotation = Quaternion.identity;
            }
            return rootTransform;
        }

        private void CheckDirtyData()
        {
            if (dataDirty)
            {
                // LogUtil.Debug("-------- checkDirtyData enter");
                RecycleIcons();
                Transform rootTransform = getRootTransform();
                // int index = 0;
                //LogUtil.Debug("-------- positions.Count:" + positions.Count);
                var posCount = positions.Count;
                for (var i = 0; i < posCount; i++)
                {
                    Image img = GetOneIcon(); //new GameObject("icon" + index);
                    GameObject icon = img.gameObject;
                    img.sprite = GetSprite(names[i]);
                    img.material = GetMaterial(names[i]);
                    img.rectTransform.sizeDelta = new Vector2(widths[i], heights[i]);
                    icons.Add(img);
                    // index += 1;
                }

                if (icons != null)
                {
                    var iconsCount = icons.Count;
                    for (var i = 0; i < iconsCount; i++)
                    {
                        var icon = icons[i];
                        icon.rectTransform.pivot = new Vector2(0.5f, 0.0f);
                        icon.rectTransform.anchoredPosition = positions[i];
                        var pos = icon.rectTransform.localPosition;
                        pos.z = 0;
                        icon.rectTransform.localPosition = pos;
                    }
                }

                dataDirty = false;
                //justChecked = true;
            }
        }

        private string GetSpace(int num)
        {
            string str = "";
            for (int i = 0; i < num; i++)
            {
                str = str + "   ";
            }
            return str;
        }

        [SLua.DoNotToLua]
        public void SetPrintText()
        {
            if (mLastPrintOriginText == OriginText)
                return;
            mLastPrintOriginText = OriginText;

            base.text = GetPrintText();
        }

        private string GetPrintText()
        {
            string text = "";
            GetSpriteInfos(OriginText, ref text);
            return text;
        }

        private void GetSpriteInfos(string originText, ref string processedTxt)
        {
            int diff = 0;
            this.paths.Clear();
            this.names.Clear();
            this.widths.Clear();
            this.heights.Clear();
            this.heightDeltas.Clear();
            var matches = Regex.Matches(originText, @"\<\s*sprite\s*(.*?)\s*\/\>");
            var length = matches.Count;
            for (var i = 0; i < length; i++)
            {
                var match = matches[i];
                string path = "";
                string name = "";
                float width = 20f;
                float height = 20f;
                float heightDelta = 0f;
                ParseMatchString(match.Value, ref path, ref name, ref width, ref height, ref heightDelta);
                this.paths.Add(path);
                this.names.Add(name);
                this.widths.Add(width);
                this.heights.Add(height);
                this.heightDeltas.Add(heightDelta);
            }
            processedTxt = Regex.Replace(originText, @"\<\s*sprite\s*(.*?)\s*\/\>", GetSpace(2));
            matches = Regex.Matches(processedTxt, @"(" + GetSpace(2) + ")");
            length = matches.Count;
            this.indexes.Clear();
            for (var i = 0; i < length; i++)
            {
                var match = matches[i];
                indexes.Add(match.Index);
            }
        }
    }
}

















