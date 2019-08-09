//
// LuaOnCollision.cs
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
    /// Handles collision callbacks
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaCollisionBehaviour : LuaBaseBehaviour
    {
        private static readonly string OnCollisionEnterString = "OnCollisionEnter";
        private static readonly string OnCollisionExitString = "OnCollisionExit";

        void OnCollisionEnter(Collision collision)
        {
            NotifyLua(OnCollisionEnterString, collision);
        }


        void OnCollisionExit(Collision collision)
        {
            NotifyLua(OnCollisionExitString, collision);
        }

    }
}

