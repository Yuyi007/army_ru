//
// LuaFixedUpdateBehaviour.cs
//
// Author:
//       duwenjie
//

//
//
using System;
using UnityEngine;
using SLua;


namespace LBoot
{
    [CustomLuaClassAttribute]
    /// <summary>
    /// Camera related rendering callback, requires a camera component on the gameObject
    /// </summary>
    public class LuaCameraBehaviour : LuaBaseBehaviour
    {
        private static readonly string OnPostRenderString = "OnPostRender";
        private static readonly string OnPreCullString = "OnPreCull";
        private static readonly string OnPreRenderString = "OnPreRender";


        void OnPostRender()
        {
            NotifyLua(OnPostRenderString);
        }

        void OnPreCull()
        {
            NotifyLua(OnPreCullString);
        }

        void OnPreRender()
        {
            NotifyLua(OnPreRenderString);
        }

    }
}

