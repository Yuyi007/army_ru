//
// LuaBehaviourBase.cs
//
// Author:
//       duwenjie
//

//

// #define PROFILE_FILE

using System;
using UnityEngine;
using SLua;

namespace LBoot
{
    /// <summary>
    /// Base class for defining engine callback behaviours
    /// It requires LuaBinderBehaviour to be on the same GameObject already
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaBaseBehaviour : MonoBehaviour
    {
        protected LuaBinderBehaviour binder;
        protected LuaTable _lua;
        
        public LuaTable Lua {
            get
            {
                if (_lua != null) return _lua;
                
                if (binder == null)
                {
                    binder = gameObject.GetComponent<LuaBinderBehaviour>();
                }

                if (binder != null) return binder.Lua;
                   
                return null;
            }
            // allow to set lua manually instead of getting it from binder
            set
            {
                _lua = value;
            }
        }

        virtual protected void Start()
        {
            binder = gameObject.GetComponent<LuaBinderBehaviour>();   
        }

        void OnDestroy()
        {
            this.binder = null;
            this._lua = null;
        }

        public virtual void ForceExit()
        {
            this.binder = null;
            this._lua = null;
        }

        protected void NotifyLua(string callback)
        {
#if PROFILE_FILE
            Profiler.BeginSample("NotifyLua." + callback);
#endif // PROFILE_FILE

            if (Lua != null)
            {
#if PROFILE_FILE
                Lua.State.OneLevelCall("__profile_lua_callback", Lua, callback);
#else
                Lua.OneLevelCall(callback, Lua);
#endif // PROFILE_FILE
            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }
        
        protected void NotifyLua(string callback, object arg1)
        {
#if PROFILE_FILE
            Profiler.BeginSample("NotifyLua." + callback);
#endif // PROFILE_FILE

            if (Lua != null)
            {
#if PROFILE_FILE
                Lua.State.OneLevelCall("__profile_lua_callback", Lua, callback, arg1);
#else
                Lua.OneLevelCall(callback, Lua, arg1);
#endif // PROFILE_FILE
            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }
    }
}

