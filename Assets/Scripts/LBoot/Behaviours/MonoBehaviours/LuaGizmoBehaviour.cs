//
// LuaGizmoBehaviour.cs
//
// Author:
//       duwenjie
//

//
using System;
using SLua;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class LuaGizmoBehaviour: LuaBaseBehaviour
    {
        private static readonly string OnDrawGizmosString = "OnDrawGizmos";

        void OnDrawGizmos()
        {
            NotifyLua(OnDrawGizmosString);
        }
    }
}

