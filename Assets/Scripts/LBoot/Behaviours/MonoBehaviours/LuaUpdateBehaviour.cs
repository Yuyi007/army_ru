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
    /// Update callback
    /// </summary>
    public class LuaUpdateBehaviour : LuaBaseBehaviour
    {
        void Update()
        {
            NotifyLua("Update");
        }
	
    }
}
