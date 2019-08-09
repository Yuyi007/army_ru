//
// LuaTriggerBehaviour.cs
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
    /// Handles trigger callbacks
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaTriggerBehaviour : LuaBaseBehaviour
    {
        private static readonly string OnTriggerEnterString = "OnTriggerEnter";
        private static readonly string OnTriggerExitString = "OnTriggerExit";

        void OnTriggerEnter(Collider other)
        {
            NotifyLua(OnTriggerEnterString, other);
        }

        void OnTriggerExit(Collider other)
        {
            NotifyLua(OnTriggerExitString, other);
        }

        // void OnTriggerStay(Collider other)
        // {
        //     NotifyLua("OnTriggerStay", other);
        // }

        //        void OnTriggerEnter2D(Collider2D other)
        //        {
        //            NotifyLua("OnTriggerEnter2D", other);
        //        }

        //        void OnTriggerExit2D(Collider2D other)
        //        {
        //            NotifyLua("OnTriggerExit2D", other);
        //        }

        // void OnTriggerStay2D(Collider2D other)
        // {
        //     NotifyLua("OnTriggerStay2D", other);
        // }

    }
}

