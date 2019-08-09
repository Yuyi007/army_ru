//
// LuaMouseBehaviour.cs
//
// Author:
//       duwenjie
//

//
using System;
using UnityEngine;
using SLua;

namespace LBoot
{
    [CustomLuaClassAttribute]
    /// <summary>
    /// Mouse related callbacks, requires a Collider on the gameObject
    /// </summary>
    public class LuaMouseBehaviour : LuaBaseBehaviour
    {
        void OnMouseDown()
        {
//            LogUtil.Debug("OnMouseDown");
            NotifyLua("OnMouseDown");
        }

        void OnMouseUp()
        {
            //LogUtil.Debug("OnMouseUp");
            NotifyLua("OnMouseUp");
        }

        void OnMouseDrag()
        {
            //LogUtil.Debug("OnMouseDrag");
            NotifyLua("OnMouseDrag");
        }

        void OnMouseEnter()
        {
            //LogUtil.Debug("OnMouseEnter");
            NotifyLua("OnMouseEnter");
        }

        void OnMouseOver()
        {
            //LogUtil.Debug("OnMouseOver");
            NotifyLua("OnMouseOver");
        }

        void OnMouseExit()
        {
            //LogUtil.Debug("OnMouseExit");
            NotifyLua("OnMouseExit");
        }

        void OnMouseUpAsButton()
        {
            //LogUtil.Debug("OnMouseUpAsButton");
            NotifyLua("OnMouseUpAsButton");
        }

    }
}

