//
// LuaCutsceneEventBehaviour.cs
//
// Author:
//       duwenjie
//
//
// #define PROFILE_FILE

using System;
using UnityEngine;
using SLua;
using CinemaDirector;

namespace LBoot
{
    /// <summary>
    /// Handles collision callbacks
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaCutsceneEventBehaviour : LuaBaseBehaviour
    {
        override protected void Start()
        {
            base.Start();
            RefreshCutsceneHandlers();
        }

        private void CutsceneFinished(object sender, CutsceneEventArgs e)
        {
            NotifyLua("CutsceneFinished");
        }

        private void CutscenePaused(object sender, CutsceneEventArgs e)
        {
            NotifyLua("CutscenePaused");
        }

        public void RefreshCutsceneHandlers()
        {
#if PROFILE_FILE
            Profiler.BeginSample("LuaCutsceneEventBehaviour.RefreshCutsceneHandlers");
#endif
            CutsceneCast cc = this.gameObject.GetComponent<CutsceneCast>();
            if (cc == null)
                return;
            Cutscene cs = cc.Cutscene;
            if (cs == null)
                return;

            cs.CutsceneFinished += new CutsceneHandler(CutsceneFinished);
            cs.CutscenePaused += new CutsceneHandler(CutscenePaused);

#if PROFILE_FILE
            Profiler.EndSample();
#endif
        }
    }

}