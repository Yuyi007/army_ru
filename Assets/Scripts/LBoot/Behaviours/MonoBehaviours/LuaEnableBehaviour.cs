//
// LuaEnableBehaviour.cs
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
    public class LuaEnableBehaviour : LuaBaseBehaviour
    {
        void OnEnable()
        {
            NotifyLua("OnEnable");
        }

        void OnDisable()
        {
            NotifyLua("OnDisable");
        }
    }
}

