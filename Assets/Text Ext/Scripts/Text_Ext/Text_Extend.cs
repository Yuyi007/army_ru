using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    /// <summary>
    /// Labels are graphics that display text.
    /// </summary>


    [AddComponentMenu("UI/Text_Extend")]
    public class Text_Extend : Text, IPointerClickHandler
    {
        protected GameObject mGo;
        protected RectTransform mTrans;
        private TextExtendTool txtTool;

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

        // true text that print in UI.
        public string processedText
        {
            get { return base.text; }
        }

        protected List<int> mOriginIndexList = new List<int>();

        protected List<TextSegmentFlag> mUnderlineIndexList = new List<TextSegmentFlag>();


#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        [NonSerialized]
        // vertices pixel position per font.
        VertexHelper mVertexHelper = new VertexHelper();
#else
        // vertices pixel position per font.
        List<UIVertex> vbo = new List<UIVertex>();
#endif

        protected TextGenerator mCharTextGenerator;

        protected UnderlineEdgeConfig mUnderlineEdgeCfg;

        string mLastPrintOriginText;

        [SerializeField]
        [FormerlySerializedAs("linkObject")]
        public bool linkObject = true;



#if UNITY_EDITOR

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        protected override void OnValidate()
        {
            base.OnValidate();
            setPrintText();
        }
#else
        protected override void UpdateGeometry()
        {
            setPrintText();
            base.UpdateGeometry();
        }
#endif

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

        [SLua.DoNotToLua]
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!linkObject || OriginText.Length < 1)
                return;

            Vector2 localPos;
            bool ret = RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedTransform, eventData.position, eventData.pressEventCamera, out localPos);
            if (!ret)
                return;

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            if (mVertexHelper.currentVertCount < 1)
#else
            if (vbo.Count < 1)
#endif
                updateVBO();


#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            int textIndex = UGUIText_Extend.GetExactCharacterIndex(mVertexHelper, localPos);
#else
            int textIndex = UGUIText_Extend.GetExactCharacterIndex(vbo, localPos);
#endif

            if (textIndex < 0)
                return;

            if (mOriginIndexList.Count <= textIndex)
                return;

            int originIndex = mOriginIndexList[textIndex];
            TxtTool.ProcessLinkObjectText(OriginText, originIndex);

        }

        [SLua.DoNotToLua]
        public void setPrintText()
        {
            if (mLastPrintOriginText == OriginText)
                return;
            mLastPrintOriginText = OriginText;

            if (linkObject)
            {

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
                base.text = TxtTool.PrintText(ref m_OriginText, mOriginIndexList, mUnderlineIndexList);
                mVertexHelper.Clear();
#else
                base.m_Text = UGUIText_Extend.PrintText(ref m_OriginText, mOriginIndexList, mUnderlineIndexList);
                vbo.Clear();
#endif
                //updateVBO();
            }
            else
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
                base.text = this.OriginText;
#else
                base.m_Text = this.OriginText;
#endif
        }

        void updateVBO()
        {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            //mVertexHelper.Clear();
#else
            //vbo.Clear();
#endif

            if (rectTransform != null && rectTransform.rect.width >= 0 && rectTransform.rect.height >= 0)
            {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
                OnPopulateMesh(mVertexHelper);
#else
                OnFillVBO(vbo);
#endif
            }
        }

        // at Unity version 4.6 - 5.1, don't write [u] out of <color=...> (eg. [u]<color=#00507C>Falcon[/u]</color>),
        // because underline calculate include rich text(like "<color") vertex and char info.
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        void fillUnderline(VertexHelper toFill)
#else
        void fillUnderline(List<UIVertex> toFill)
#endif
        {
            if (null == mCharTextGenerator)
                mCharTextGenerator = new TextGenerator(1);

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            m_DisableFontTextureRebuiltCallback = true;
#else
#endif
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

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            float underLineTopY = mCharTextGenerator.lines[0].topY;
#else
            float underLineTopY = mCharTextGenerator.characters[0].cursorPos.y;
#endif
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

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            m_DisableFontTextureRebuiltCallback = false;
#else
#endif
        }

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            base.OnPopulateMesh(toFill);

            //add underline vertex buffer
            fillUnderline(toFill);
        }
#else
        protected override void OnFillVBO(List<UIVertex> toFill)
        {
            base.OnFillVBO(toFill);

            //add underline vertex buffer
            fillUnderline(toFill);
        }
#endif

    }
}
