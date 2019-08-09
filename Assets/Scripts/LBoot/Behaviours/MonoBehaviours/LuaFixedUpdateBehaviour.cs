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
    /// FixedUpdate callback
    /// </summary>
    public class LuaFixedUpdateBehaviour : LuaBaseBehaviour
    {
		private float lastLuaFixedUpdateTime = 0;
		private float luaFixedUpdateInterval = (float)(1.0 / LBootApp.TARGET_FRAME_RATE);

        void FixedUpdate()
        {
			// 2015/09/18 lt: 
			// This does not work because vector lerp goes with the original interval
			// Causes character movement to slow down
			/* 
			var interval = Time.fixedTime - lastLuaFixedUpdateTime;
			if (interval >= luaFixedUpdateInterval) 
			{
				NotifyLua("FixedUpdate");
				lastLuaFixedUpdateTime = Time.fixedTime;
			}
			*/

			NotifyLua("FixedUpdate");
        }

		public float LuaFixedUpdateInterval {
			get {
				return luaFixedUpdateInterval;
			}
			set {
				luaFixedUpdateInterval = value;
			}
		}
    }
}

