//
// LuaVisibleBehaviour.cs
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
    /// <summary>
    /// Handles visiblity callbacks
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaVisibleBehaviour : LuaBaseBehaviour
    {
        private static readonly string OnBecameInvisibleString = "OnBecameInvisible";
        private static readonly string OnBecameVisibleString = "OnBecameVisible";

        void OnBecameInvisible()
        {
            NotifyLua(OnBecameInvisibleString);
        }

        void OnBecameVisible()
        {
            NotifyLua(OnBecameVisibleString);
        }

        // void OnRenderObject()
        // {
        //     NotifyLua("OnRenderObject");
        // }

        // void OnWillRenderObject()
        // {
        //     NotifyLua("OnWillRenderObject");
        // }

    }
}

