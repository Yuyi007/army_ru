using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using LBoot;
using SLua;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    [CustomLuaClassAttribute]
    public class FVRichText : Text,IPointerClickHandler
    {
        public float sizeDelta = -4;
        private List<Image> _icons = null;

        private List<Image> icons
        {
            get
            {
                if (_icons == null)
                {
                    _icons = new List<Image>();
                }
                return _icons;
            }
        }

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

        private List<Vector3> _positions = null;

        private List<Vector3> positions
        {
            get
            {
                if (_positions == null)
                {
                    _positions = new List<Vector3>();
                }

                return _positions;
            }
        }


        private List<string> _names = null;

        private List<string> names
        {
            get
            {
                if (_names == null)
                {
                    _names = new List<string>();
                }
                return _names;
            }
        }

        private List<float> _heights = new List<float>();

        private List<float> heights
        {
            get
            {
                if (_heights == null)
                {
                    _heights = new List<float>();
                }
                return _heights;
            }
        }

        private List<float> _widths = null;

        private List<float> widths
        {
            get
            {
                if (_widths == null)
                {
                    _widths = new List<float>();
                }
                return _widths;
            }
        }

        private List<float> _heightDeltas = null;

        private List<float> heightDeltas
        {
            get
            {
                if (_heightDeltas == null)
                {
                    _heightDeltas = new List<float>();
                }
                return _heightDeltas;
            }
        }

        private List<int> _indexes = null;

        private List<int> indexes
        {
            get
            {
                if (_indexes == null)
                {
                    _indexes = new List<int>();
                }
                return _indexes;
            }
        }

        private float _fontHeight;
        private float _fontWidth;
        private GameObject root;

        private bool dataDirty = false;

        //		protected string m_OriginText = "";
        protected string mLastPrintOriginText = "";


        protected GameObject mGo;
        protected RectTransform mTrans;
        private TextExtendTool txtTool;


        private string cacheStr;

        [SLua.DoNotToLua]
        public TextExtendTool TxtTool
        {
            get
            {
                if (txtTool == null)
                {
                    txtTool = new TextExtendTool();
                }

                return txtTool;
            }
        }



        [SLua.DoNotToLua]
        public GameObject cachedGameObject
        {
            get
            {
                if (mGo == null)
                    mGo = gameObject;
                return mGo;
            }
        }

        [SLua.DoNotToLua]
        public RectTransform cachedTransform
        {
            get
            {
                if (mTrans == null)
                    mTrans = transform as RectTransform;
                return mTrans;
            }
        }


        [TextArea(3, 10)][SerializeField] protected string m_OriginText = String.Empty;

        // text with flag
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
                    setPrintText();
                }
            }
        }


        protected List<int> mOriginIndexList = new List<int>();

        protected List<TextSegmentFlag> mUnderlineIndexList = new List<TextSegmentFlag>();




        [NonSerialized]
        // vertices pixel position per font.
		VertexHelper mVertexHelper = new VertexHelper();


        protected TextGenerator mCharTextGenerator;

        protected UnderlineEdgeConfig mUnderlineEdgeCfg;



        [SerializeField]
        [FormerlySerializedAs("linkObject")]
        public bool linkObject = true;



#if UNITY_EDITOR

        protected override void OnValidate()
        {
            base.OnValidate();
            setPrintText();
        }
#endif

        public void ClearLinkCallback(string linkType)
        {
            TxtTool.SetCallback(linkType, null);
        }

        public void SetLinkCallback(string linkType, Action<string> action)
        {
            TxtTool.SetCallback(linkType, action);
        }

        public void ClearLinkCallbacks()
        {
            if (null != txtTool)
            {
                txtTool.ClearCallbacks();
            }
        }

        protected override void OnDestroy()
        {
            if (this.txtTool != null)
            {
                this.txtTool.ClearAll();
            }

            if (this.mOriginIndexList != null)
            {
                this.mOriginIndexList.Clear();
            }

            if (this.mVertexHelper != null)
                this.mVertexHelper.Clear();

            if (this._icons != null)
            {
                this._icons.Clear();
            }

            if (this._heights != null)
            {
                this._heights.Clear();
            }

            if (this._widths != null)
            {
                this._widths.Clear();
            }

            if (this._heightDeltas != null)
            {
                this._heightDeltas.Clear();
            }

            if (this._iconsPool != null)
            {
                this._iconsPool.Clear();
            }

            if (this._indexes != null)
            {
                this._indexes.Clear();
            }

            if (this._names != null)
            {
                this._names.Clear();
            }

            if (this._positions != null)
            {
                this._positions.Clear();
            }

            if (this.mUnderlineIndexList != null)
            {
                this.mUnderlineIndexList.Clear();
            }

            this.mGo = null;
            this.mTrans = null;

            this._icons = null;
            this._iconsPool = null;
            this._heights = null;
            this._widths = null;
            this._indexes = null;
            this._names = null;
            this._positions = null;
            this._heightDeltas = null;
            this.root = null;
            this.mOriginIndexList = null;

            this.txtTool = null;

            this.mVertexHelper = null;
            this.mCharTextGenerator = null;
            this.mUnderlineEdgeCfg = null;

            base.OnDestroy();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!linkObject || OriginText.Length < 1)
                return;

            Vector2 localPos;
            bool ret = RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedTransform, eventData.position, eventData.pressEventCamera, out localPos);
            if (!ret)
                return;

            if (mVertexHelper.currentVertCount < 1)
                updateVBO();


            int textIndex = UGUIText_Extend.GetExactCharacterIndex(mVertexHelper, localPos);


            if (textIndex < 0)
                return;

            if (mOriginIndexList.Count <= textIndex)
                return;

            int originIndex = mOriginIndexList[textIndex];
            TxtTool.ProcessLinkObjectText(this.cacheStr, originIndex);

        }



        [SLua.DoNotToLua]
        public void setPrintText()
        {
            if (mLastPrintOriginText == OriginText)
                return;
            mLastPrintOriginText = OriginText;

            if (linkObject)
            {
                string _sprStr = m_OriginText;
                string _linkStr = TxtTool.PrintText(ref m_OriginText, mOriginIndexList, mUnderlineIndexList);

                GetPrintText(_linkStr);
                _sprStr = Regex.Replace(_sprStr, @"\<\s*sprite\s*(.*?)\s*\/\>", GetSpace(2));
                this.cacheStr = _sprStr;
                base.text = TxtTool.PrintText(ref _sprStr, mOriginIndexList, mUnderlineIndexList);
                mVertexHelper.Clear();
            }
            else
            {
                base.text = GetPrintText(this.OriginText);
            }

        }


        void updateVBO()
        {
            if (rectTransform != null && rectTransform.rect.width >= 0 && rectTransform.rect.height >= 0)
            {
                OnPopulateMesh(mVertexHelper);

            }
        }



        // at Unity version 4.6 - 5.1, don't write [u] out of <color=...> (eg. [u]<color=#00507C>Falcon[/u]</color>),
        // because underline calculate include rich text(like "<color") vertex and char info.

        void fillUnderline(VertexHelper toFill)
        {
            if (null == mCharTextGenerator)
                mCharTextGenerator = new TextGenerator(1);


            m_DisableFontTextureRebuiltCallback = true;

            Vector2 extents = rectTransform.rect.size;
            TextGenerationSettings settings = GetGenerationSettings(extents);
            mCharTextGenerator.Populate("_", settings);

            IList<UIVertex> verts = mCharTextGenerator.verts;
            if (verts.Count < 4)
                return;
            Vector2 topUV = (verts[0].uv0 + verts[1].uv0) / 2;
            Vector2 bottomUV = (verts[2].uv0 + verts[3].uv0) / 2;

            UIVertex[] temp = new UIVertex[4];
            for (int i = 0; i < 4; i++)
            {
                temp[i] = verts[i];
                if (i < 2)
                    temp[i].uv0 = topUV;
                else
                    temp[i].uv0 = bottomUV;
            }

            if (mCharTextGenerator.lineCount <= 0)
                return;

            float underLineTopY = mCharTextGenerator.lines[0].topY;

            float offsetTop = verts[0].position.y - underLineTopY;
            float offsetBottom = verts[3].position.y - underLineTopY;

            IList<UILineInfo> lines = cachedTextGenerator.lines;
            TextSegmentFlag segment;
            int segmentIdx = 0, segmentStartIdx = -1, segmentEndIdx = -1, endIdx = lines.Count - 1;
            bool start = false;

            if (null == mUnderlineEdgeCfg)
                mUnderlineEdgeCfg = new UnderlineEdgeConfig();

            mUnderlineEdgeCfg.init(toFill, temp, cachedTextGenerator, offsetTop, offsetBottom);

            for (int i = 0, max = lines.Count; i < max; ++i)
            {
                if (segmentIdx == mUnderlineIndexList.Count)
                    break;

                segment = mUnderlineIndexList[segmentIdx];
                if (!start && (lines[i].startCharIdx > segment.start || i == endIdx))
                {
                    if (!mUnderlineEdgeCfg.setUnderLineStartPos(segment.start, ref segmentStartIdx, i))
                        break;

                    start = true;
                }

                if (start && (lines[i].startCharIdx > segment.end || i == endIdx))
                {
                    segmentEndIdx = i - (lines[i].startCharIdx > segment.end ? 1 : 0);

                    if (segmentStartIdx == segmentEndIdx)
                    {
                        if (!mUnderlineEdgeCfg.setUnderLineEndPos(segment.end))
                            break;

                        segmentIdx++;
                        start = false;
                        --i;
                        continue;
                    }

                    //start -> start line end
                    int startLineEndCharIdx = lines[segmentStartIdx + 1].startCharIdx - 1;
                    if ('\n' == text[startLineEndCharIdx])
                        --startLineEndCharIdx;

                    if (!mUnderlineEdgeCfg.setUnderLineEndPos(startLineEndCharIdx))
                        break;

                    //for(line start + 1 --> line end - 1)
                    for (int k = segmentStartIdx + 1; k < segmentEndIdx; ++k)
                    {
                        int lineStartCharIdx = lines[k].startCharIdx;

                        //ignore line feed
                        if ('\n' == text[lineStartCharIdx])
                            continue;

                        if (!mUnderlineEdgeCfg.setUnderLineStartPos(lineStartCharIdx, ref k, k))
                            break;

                        int lineEndCharIdx = lines[k + 1].startCharIdx - 1;
                        if ('\n' == text[lineEndCharIdx])
                            --lineEndCharIdx;

                        if (!mUnderlineEdgeCfg.setUnderLineEndPos(lineEndCharIdx))
                            break;
                    }

                    //end line start -> end
                    int endLineStartCharIdx = lines[segmentEndIdx].startCharIdx;

                    if (!mUnderlineEdgeCfg.setUnderLineStartPos(endLineStartCharIdx, ref segmentEndIdx, segmentEndIdx))
                        break;

                    if (!mUnderlineEdgeCfg.setUnderLineEndPos(segment.end))
                        break;

                    segmentIdx++;
                    start = false;
                    --i;
                    continue;
                }
            }


            m_DisableFontTextureRebuiltCallback = false;

        }





        //--------------------------
        //private bool justChecked = false;



        public string processedText
        {
            get { return base.text; }
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {

            base.OnPopulateMesh(vh);
            //add underline vertex buffer
            fillUnderline(vh);

            positions.Clear();

            int startVertexIndex;
            dataDirty = true;

            UIVertex vert0 = new UIVertex();
            UIVertex vert2 = new UIVertex();
            UIVertex vert3 = new UIVertex();
            int currentVertCount = vh.currentVertCount;
            int count = indexes.Count;
            for (var k = 0; k < count; k++)
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
                positions.Add(new Vector3(vert0.position.x + width / 2, vert0.position.y + heightDelta, vert0.position.z));
            }
        }

        void Update()
        {
            CheckDirtyData();
        }

        private Sprite GetSprite(string name)
        {
            return LBoot.BundleConfig.Get().GetSprite(name);
        }

        private Material GetMaterial(string name)
        {
            return LBoot.BundleConfig.Get().GetMaterial(name);
        }

        //
        //
        private void ParseMatchString(string matchValue, ref string path, ref string name, ref float width, ref float height, ref float heightDelta)
        {
            var result = Regex.Match(matchValue, @"\<\s*sprite\s*\=\s*(.*?)\s*name\s*\=\s*(.*?)\s*width\s*\=\s*(.*?)\s*height\s*\=\s*(.*?)\s*heightDelta\s*\=\s*(.*?)\s*\/\>").Groups;
            var length = result.Count;
            for (var index = 0; index < length; index++)
            {
                var item = result[index].Value;

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
            }
        }

        private void ClearIcons()
        {
            if (_icons != null)
            {
                _icons.Clear();
            }

            Transform t = this.transform.Find("iconroot");
            // LogUtil.Debug("-------- ClearIcons t:" + t);
            if (t != null)
            {
                GameObject.DestroyImmediate(t.gameObject);
            }
        }

        private void RecycleIcons()
        {
            if (_icons != null)
            {
                for (var i = 0; i < _icons.Count; i++)
                {
                    _icons[i].gameObject.SetActive(false);
                    iconsPool.Add(_icons[i]);
                }
                _icons.Clear();
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
                    // var iconTransform = icon.transform;
                    // iconTransform.SetParent(rootTransform);
                    // iconTransform.localScale = Vector3.one;

                    // icon.AddComponent<Image>();
                    // Image img = icon.GetComponent<Image>();
                    img.sprite = GetSprite(names[i]);
                    img.material = GetMaterial(names[i]);
                    img.rectTransform.sizeDelta = new Vector2(widths[i], heights[i]);
                    icons.Add(img);

                    var iconRectTransform = img.rectTransform;
                    iconRectTransform.pivot = new Vector2(0.5f, 0.0f);
                    iconRectTransform.anchoredPosition = positions[i];
                    var pos = iconRectTransform.localPosition;
                    pos.z = 0;
                    iconRectTransform.localPosition = pos;

                    // index += 1;
                }

//                if (_icons != null)
//                {
//                    var iconsCount = icons.Count;
//                    for (var i = 0; i < iconsCount; i++)
//                    {
//                        var icon = icons[i];
//                        var iconRectTransform = icon.rectTransform;
//                        iconRectTransform.pivot = new Vector2(0.5f, 0.0f);
//                        iconRectTransform.anchoredPosition = positions[i];
//                        var pos = iconRectTransform.localPosition;
//                        pos.z = 0;
//                        iconRectTransform.localPosition = pos;
//                    }
//                }

                dataDirty = false;
                //justChecked = true;
            }
        }

        private string GetSpace(int num)
        {
            string str = "";
            for (int i = 0; i < num; i++)
            {
                str = str + "Ã";
            }
            return str;
        }

        //		[SLua.DoNotToLua]
        //		public void SetPrintText()
        //		{
        //			if (mLastPrintOriginText == OriginText)
        //				return;
        //			mLastPrintOriginText = OriginText;
        //
        //			base.text = GetPrintText();
        //		}

        private string GetPrintText(string txt)
        {
            string text = "";
            GetSpriteInfos(txt, ref text); //OriginText
            return text;
        }

        private void GetSpriteInfos(string originText, ref string processedTxt)
        {
            int diff = 0;
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

















