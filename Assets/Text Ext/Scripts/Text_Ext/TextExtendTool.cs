
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class TextExtendTool
    {
        // Format: [link_player=7777]Player Name[/link_player]
        Dictionary<string, LinkObject> mLinkAction;

        public Dictionary<string, LinkObject> linkAction
        {
            get
            {
                if (null == mLinkAction)
                {
                    mLinkAction = new Dictionary<string, LinkObject>();
                    mLinkAction.Add("url", new LinkObject() { action = ProcessURLLink, });
                    mLinkAction.Add("link_player", new LinkObject() { action = null, });
                    mLinkAction.Add("link_item", new LinkObject() { action = null, });
                    mLinkAction.Add("link_audio", new LinkObject() { action = null, });
                }
                return mLinkAction;
            }
        }

        public void ClearAll()
        {
            ClearCallbacks();

            if (mLinkAction != null)
            {
                mLinkAction.Clear();
            }

            mLinkAction = null;
        }

        public void ClearCallbacks()
        {
            if (mLinkAction != null)
            {
                foreach (var pair in mLinkAction)
                {
                    pair.Value.action = null;
                }
            }
        }

        public void SetCallback(string linkType, Action<string> action)
        {
            if (linkAction.ContainsKey(linkType))
            {
                linkAction[linkType].action = action;
            }
            else
            {
                linkAction.Add(linkType, new LinkObject() { action = action });
            }
        }

        public string PrintText(ref string originText, List<int> originIndex, List<TextSegmentFlag> underlineIndex)
        {
            StringBuilder sb = new StringBuilder();
            originIndex.Clear();
            underlineIndex.Clear();

            TextSegmentFlag temp = new TextSegmentFlag();

            bool start = false;
            bool lastFlag = start;

            for (int i = 0; i < originText.Length; ++i)
            {
                if (ParseSymbol(ref originText, ref i))
                {
                    --i;
                    continue;
                }
                //remove [u] [/u] and record each start & end index
                if (UGUIText_Extend.ParseSegmentFlag(ref originText, ref i, ref temp, ref start, ref sb))
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

        public bool ParseSymbol(ref string text, ref int index)
        {
            int length = text.Length;

            if (index + 3 > length || text[index] != '[')
                return false;

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
                        if (']' == text[offset])
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

       
        public void ProcessLinkObjectText(string originText, int originIndex)
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
                if (-1 == linkObjectEnd || originIndex <= linkObjectEnd)
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

   

}
