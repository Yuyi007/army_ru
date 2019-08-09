//
// LuaAwakeBehaviour.cs
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
    public class LuaAwakeBehaviour : LuaBaseBehaviour
    {
        void Awake ()
        {
            NotifyLua("Awake", this.Lua);
        }
        
    }
}

