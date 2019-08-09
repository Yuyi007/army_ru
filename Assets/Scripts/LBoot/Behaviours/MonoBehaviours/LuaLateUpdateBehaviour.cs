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
    /// LateUpdate callback
    /// </summary>
    public class LuaLateUpdateBehaviour : LuaBaseBehaviour
    {
        void LateUpdate()
        {
            NotifyLua("LateUpdate");
        }
    }
}

