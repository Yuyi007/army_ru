
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{

    public struct TextSegmentFlag
    {
        public int start;
        public int end;
    }

    public class LinkObject
    {
        public Action<string> action;
    }

    static public class UGUIText_Extend
    {
        // Format: [link_player=7777]Player Name[/link_player]
        static Dictionary<string, LinkObject> mLinkAction;

        public static Dictionary<string, LinkObject> linkAction
        {
            get
            {
                if(null == mLinkAction)
                {
                    mLinkAction = new Dictionary<string, LinkObject>();
                    mLinkAction.Add("url", new LinkObject() { action = ProcessURLLink, });
                    mLinkAction.Add("link_player", new LinkObject() { action = null, });
                    mLinkAction.Add("link_item", new LinkObject() { action = null, });
                }
                return mLinkAction;
            }
        }

        static List<string> mSegmentFlag;

        public static List<string> segmentFlag
        {
            get
            {
                if (null == mSegmentFlag)
                {
                    mSegmentFlag = new List<string>();
                    mSegmentFlag.Add("u");
                }
                return mSegmentFlag;
            }
        }


        static public int GetExactCharacterIndex(
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            VertexHelper verts,
#else
            IList<UIVertex> verts,
#endif
            Vector2 pos)
        {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            int vertCount = verts.currentVertCount;
#else
            int vertCount = verts.Count;
#endif
            int charCount = vertCount / 4 - 1;

            for (int i = 0; i < charCount; ++i)
            {
                int i0 = (i << 2);

                Vector3 leftTop = GetVertexHelperUIVertex(verts, i0);
                if (pos.x < leftTop.x) continue;
                if (pos.y > leftTop.y) continue;

                int i1 = i0 + 2;
                //can't expand to neighbour left-bottom position, because neighbour may <rich text> char, four vertices value on one position.
                //if (i0 + 7 < vertCount)
                //    i1 = i0 + 7;

                Vector3 rightBottom = GetVertexHelperUIVertex(verts, i1);
                //if (pos.x > rightBottom.x) continue;
                //if (pos.y < rightBottom.y) continue;

                bool tX = pos.x > rightBottom.x, tY = pos.y < rightBottom.y;

                if (tY) continue;

                if (!tX)
                    return i;

                int i2 = i1 + 2;
                if (i2 >= vertCount)
                    continue;

                //right-bottom to neighbour left-top area, fill font space click area.
                Vector3 neighbourLeftTop = GetVertexHelperUIVertex(verts, i2);
                if (pos.x > neighbourLeftTop.x) continue;
                if (pos.y > neighbourLeftTop.y) continue;

                return i;
            }
            return -1;
        }

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        static public Vector3 GetVertexHelperUIVertex(VertexHelper verts, int index)
        {
            UIVertex tempVert = new UIVertex();

            verts.PopulateUIVertex(ref tempVert, index);

            return tempVert.position;
        }
#else
        static public Vector3 GetVertexHelperUIVertex(IList<UIVertex> verts, int index)
        {
            return verts[index].position;
        }
#endif

        static public string PrintText(ref string originText, List<int> originIndex, List<TextSegmentFlag> underlineIndex)
        {
            StringBuilder sb = new StringBuilder();
            originIndex.Clear();
            underlineIndex.Clear();

            TextSegmentFlag temp = new TextSegmentFlag();

            bool start = false;
            bool lastFlag = start;

            for (int i = 0; i < originText.Length; ++i)
            {
                if(ParseSymbol(ref originText, ref i))
                {
                    --i;
                    continue;
                }
                //remove [u] [/u] and record each start & end index
                if (ParseSegmentFlag(ref originText, ref i, ref temp, ref start, ref sb))
                {
                    --i;
                    if (lastFlag != start)
                    {
                        lastFlag = start;
                        if (!start)
                            underlineIndex.Add(temp);
                    }
                    continue;
                }
                sb.Append(originText[i]);
                originIndex.Add(i);
            }

            return sb.ToString();
        }

        static public bool ParseSymbol(ref string text, ref int index)
        {
            int length = text.Length;

            if (index + 3 > length || text[index] != '[') return false;

            int startIndex = index + 1;
            int offset = 0;
            foreach (var itr in linkAction)
            {
                string flag = itr.Key;
                int flagLen = flag.Length;

                if (startIndex + flagLen + 1 > length - 1)
                    continue;

                //end (eg [/url])
                if ('/' == text[startIndex])
                {
                    if (0 == string.Compare(text, startIndex + 1, flag, 0, flagLen))
                    {
                        offset = startIndex + flagLen + 1;
                        if(']' == text[offset])
                        {
                            index = offset + 1;
                            return true;
                        }
                    }
                }

                //start(eg [url=xxx])
                if (0 != string.Compare(text, startIndex, flag, 0, flagLen))
                    continue;

                int infoStart = startIndex + flagLen + 1;
                int closingBracket = text.IndexOf(']', infoStart);

                if (closingBracket != -1)
                {
                    //string info = text.Substring(infoStart, closingBracket - infoStart);
                    //string format =
                    index = closingBracket + 1;

                    //if no space before link object text, add a ' '(space) char before link object text to avoid it interrupt by newline.
                    int beforeIndex = startIndex - 2;
                    if (beforeIndex >= 0 && ' ' != text[beforeIndex] && ' ' != text[index])
                        text = text.Insert(index, " ");

                    return true;
                }
                else
                {
                    index = text.Length;
                    return true;
                }
            }

            return false;
        }

        static public bool ParseSegmentFlag(ref string text, ref int index, ref TextSegmentFlag flagData, ref bool start, ref StringBuilder sb)
        {
            int length = text.Length;
            int end = length - 1;

            if (index + 3 > length || text[index] != '[') return false;

            string flag = "u";
            int startIndex = index + 1;
            int offset = 0, flagLen = flag.Length;

            if (startIndex + flagLen + 1 > end)
                return false;

            //end (eg: [/u])
            if ('/' == text[startIndex])
            {
                if (0 == string.Compare(text, startIndex + 1, flag, 0, flagLen))
                {
                    offset = startIndex + flagLen + 1;
                    if (']' == text[offset])
                    {
                        index = offset + 1;
                        if (start)
                        {
                            start = false;
                            flagData.end = sb.Length - 1;
                        }
                        return true;
                    }
                }
            }

            //start(eg: [u])
            if (0 != string.Compare(text, startIndex, flag, 0, flagLen))
                return false;

            bool isEndFlag = false;

            //end (eg: [/u])
            if ('/' == text[startIndex])
            {
                startIndex++;
                isEndFlag = true;
            }

            if (0 == string.Compare(text, startIndex, flag, 0, flagLen))
            {
                offset = startIndex + flagLen;
                if (']' == text[offset])
                {
                    index = offset + 1;
                    if (isEndFlag && start)
                    {
                        start = false;
                        flagData.end = sb.Length - 1;
                    }
                    else if (!isEndFlag && !start)
                    {
                        start = true;
                        flagData.start = sb.Length;
                    }
                    return true;
                }
            }

            return false;
        }

        static public void ProcessLinkObjectText(string originText, int originIndex)
        {

            if (originIndex >= originText.Length)
                return;

            foreach (var itr in linkAction)
            {
                string flagStr = string.Format("[{0}=", itr.Key);
                int linkStart = originText.LastIndexOf(flagStr, originIndex);

                if (-1 == linkStart)
                    continue;

                linkStart += flagStr.Length;
                int linkEnd = originText.IndexOf("]", linkStart);
                if (-1 == linkEnd)
                    continue;

                string flagEndStr = string.Format("[/{0}]", itr.Key);
                int linkObjectEnd = originText.IndexOf(flagEndStr, linkEnd);
                if(-1 == linkObjectEnd || originIndex <= linkObjectEnd)
                {
                    string info = originText.Substring(linkStart, linkEnd - linkStart);
                    if (null != itr.Value.action)
                        itr.Value.action(info);
                    break;
                }
            }
        }

        static public void ProcessURLLink(string url)
        {
            if (!string.IsNullOrEmpty(url))
                Application.OpenURL(url);
        }


    }

    public class UnderlineEdgeConfig
    {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
        VertexHelper toFill;
#else
        List<UIVertex> toFill;
        UICharInfo charInfo = new UICharInfo();
#endif
        int fillEnd;
        UIVertex[] temp;
        TextGenerator textGen;
        float offsetTop, offsetBottom;
        UIVertex tempVert = new UIVertex();

        public void init(
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            VertexHelper pToFill,
#else
            List<UIVertex> pToFill,
#endif
            UIVertex[] pTemp, TextGenerator pTextGen, float pOffsetTop, float pOffsetBottom)
        {
            toFill = pToFill;
#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            fillEnd = toFill.currentVertCount - 1;
#else
            fillEnd = toFill.Count - 1;
#endif
            temp = pTemp;
            textGen = pTextGen;
            offsetTop = pOffsetTop;
            offsetBottom = pOffsetBottom;
        }

        public bool setUnderLineStartPos(int startIdx, ref int startLineIdx, int lineIdx)
        {
            int tlPosIdx = startIdx * 4;
            if (tlPosIdx > fillEnd)
                return false;

            float startLeftX = UGUIText_Extend.GetVertexHelperUIVertex(toFill, tlPosIdx).x;
            temp[0].position.x = startLeftX;
            temp[3].position.x = startLeftX;

            startLineIdx = lineIdx - (textGen.lines[lineIdx].startCharIdx > startIdx ? 1 : 0);

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            float lineTopY = textGen.lines[startLineIdx].topY;
#else
            float lineTopY = textGen.characters[startIdx].cursorPos.y;
#endif
            temp[0].position.y = lineTopY + offsetTop;
            temp[3].position.y = lineTopY + offsetBottom;

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            toFill.PopulateUIVertex(ref tempVert, tlPosIdx + 3);
#else
            tempVert = toFill[tlPosIdx + 3];
#endif
            for (int j = 0; j < 4; j++)
            {
                temp[j].color = tempVert.color;
            }

            return true;
        }

        public bool setUnderLineEndPos(int endIdx)
        {
            int trPosIdx = endIdx * 4 + 1;
            if (trPosIdx > fillEnd)
                return false;

            float endRightX = UGUIText_Extend.GetVertexHelperUIVertex(toFill, trPosIdx).x;
            temp[1].position.x = endRightX;
            temp[2].position.x = endRightX;

            temp[1].position.y = temp[0].position.y;
            temp[2].position.y = temp[3].position.y;

#if UNITY_5_2 || UNITY_5_3_OR_NEWER || UNITY_5_4
            toFill.AddUIVertexQuad(temp);
#else
            toFill.AddRange(temp);
#endif

            return true;
        }


    }

}
