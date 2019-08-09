
//
using System;
using UnityEngine;
using SLua;
using LBoot;

namespace Game
{
    /// <summary>
    /// Base class for defining engine callback behaviours
    /// It requires LuaBinderBehaviour to be on the same GameObject already, 
    /// or set a lua table manually
    /// </summary>
    [CustomLuaClassAttribute]
    public class AnimCallbackBehaviours : LuaBaseBehaviour
    {

        // Use this for initialization
        void OnAnimStart(string animName)
        {
            NotifyLua("OnAnimStart", animName);
        }
    	
        // Update is called once per frame
        void OnAnimFinish(string animName)
        {
            NotifyLua("OnAnimFinish", animName);
        }

        void OnAnimEvent(string param)
        {
            NotifyLua("OnAnimEvent", param);
        }

    }
}