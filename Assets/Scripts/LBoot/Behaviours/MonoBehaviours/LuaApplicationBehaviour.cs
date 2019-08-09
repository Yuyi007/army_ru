//
// LuaApplicationBehaviour.cs
//
// Author:
//       duwenjie
//

//
using System;
using SLua;
using UnityEngine;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class LuaApplicationBehaviour : LuaBaseBehaviour
    {
        void OnApplicationQuit()
        {
            NotifyLua("OnApplicationQuit");
        }

        void OnApplicationFocus()
        {
            NotifyLua("OnApplicationFocus");
        }

        void OnApplicationPause()
        {
            NotifyLua("OnApplicationPause");
        }

    }
}

