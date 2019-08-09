//
// LuaBinder.cs
//
// Author:
//       duwenjie
//

//
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
// #define PROFILE_FILE
// #define PROFILE_GO_NAME

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SLua;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LBoot
{
    [CustomLuaClassAttribute]
    public class LuaBinderBehaviour : MonoBehaviour
    {
        protected LuaTable lua;
        protected GameObject node;
		protected bool pooled = false;
        // protected BindableNode[] bindableNodes;
        protected bool executeDestroyCallbacks = true;

        public LuaTable Lua {
            get {
                return lua;
            }
        }

		public bool Pooled{
			get {
				return pooled;
			}
			set {
				pooled = value;
			}
		}

        public bool ExecuteDestroyCallbacks {
            get {
                return executeDestroyCallbacks;
            }
            set {
                executeDestroyCallbacks = value;
            }
        }

        internal LuaBridge luaBridge {
            get {
                return LBootApp.luaBridge;
            }
        }

        /**
         * Bind lua table
         */
        public void Bind(LuaTable table)
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.Bind " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.Bind");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

            lua = table;
            lua.setOneLevelField("gameObject", this.gameObject);
            lua.setOneLevelField("transform", this.transform);
            BindNodes();
            BindDone();

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        /**
         * Create a gameobject with the specified bundleName
         */
        [SLua.DoNotToLua]
        public static LuaBinderBehaviour Create(string bundleName, int ttl, LuaTable lua)
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            Profiler.BeginSample("LuaBinderBehaviour.Create " + bundleName + " ttl=" + ttl);
#else
            Profiler.BeginSample("LuaBinderBehaviour.Create");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

            var go = BundleHelper.LoadAndCreate(bundleName, ttl);
            var binder = go.AddComponent<LuaBinderBehaviour>();
            binder.Bind(lua);

#if PROFILE_FILE
            Profiler.EndSample();
#endif
            return binder;
        }

        /**
         * Bind the nodes in the instantiated component
         */
        protected void BindNodes()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.BindNodes " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.BindNodes");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

            if (lua.getOneLevelField("__bind_nodes") != null) {
                // if (bindableNodes == null) {
                //     bindableNodes = Array.FindAll(transform.GetComponentsInChildren<Transform>(true), x => x.name.StartsWith("b_"));
                // }
#if PROFILE_FILE
                lua.State.OneLevelCall("__profile_lua_callback", lua, "__bind_nodes");
#else
                lua.OneLevelCall("__bind_nodes", lua);
#endif // PROFILE_FILE
            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        /**
         * Done the binding
         */
        void BindDone()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.BindDone " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.BindDone");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

            this.node = this.gameObject;

#if PROFILE_FILE
            lua.State.OneLevelCall("__profile_lua_callback", lua, "__binded");
#else
            lua.OneLevelCall("__binded", lua);
#endif // PROFILE_FILE

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        /**
         * Custome clean up when gameobject is destroyed.
         */
        void CleanUp()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.CleanUp " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.CleanUp");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

            if (lua != null) {
#if PROFILE_FILE
                lua.State.OneLevelCall("__profile_lua_callback", lua, "cleanup");
#else
                lua.OneLevelCall("cleanup", lua);
#endif // PROFILE_FILE
            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        /**
         * Start update in lua
         */
        [SLua.DoNotToLua]
        public void StartUpdate()
        {
            // Debug.Log("$$ UpdateCoroutine started");
            // StartCoroutine("UpdateCoroutine");
        }

        /**
         * Stop update in lua
         */

        [SLua.DoNotToLua]
        public void StopUpdate()
        {
            // Debug.Log("$$ UpdateCoroutine stopped");
            // StopCoroutine("UpdateCoroutine");
        }

        [SLua.DoNotToLua]
        public bool IsBinded()
        {
            return lua != null && node != null;
        }

        /**
         * Object life cycle ended
         */
        void OnDestroy()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.OnDestroy " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.OnDestroy");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

			if (executeDestroyCallbacks && !pooled) {
                CleanUp();
                Exit();
            }

            this.lua = null;
            this.node = null;
            // this.bindableNodes = null;

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        /**
         * exit lua table
         */
        protected void Exit()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.Exit " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.Exit");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE

			if (lua != null && !pooled) {
#if PROFILE_FILE
                lua.State.OneLevelCall("__profile_lua_callback", lua, "exit");
                lua.State.OneLevelCall("__profile_lua_callback", lua, "onDestroy");
#else
                lua.OneLevelCall("exit", lua);
                lua.OneLevelCall("onDestroy", lua);
#endif // PROFILE_FILE
            }

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        public void ForceExit()
        {
#if PROFILE_FILE
#if PROFILE_GO_NAME
            var name = "unknown-gameobject";
            if (this.gameObject != null) {
                name = this.gameObject.name;
            }
            Profiler.BeginSample("LuaBinderBehaviour.ForceExit " + name);
#else
            Profiler.BeginSample("LuaBinderBehaviour.ForceExit");
#endif // PROFILE_GO_NAME
#endif // PROFILE_FILE
            // if (LBootApp.Running)
            // {
                CleanUp();
                Exit();
            // }

            this.lua = null;
            this.node = null;

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }

        public void DetachBinding()
        {
            this.lua = null;
            this.node = null;
        }
    }
}
