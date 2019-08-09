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
    /// Animator callback
    /// </summary>
    public class LuaAnimatorBehaviour : LuaBaseBehaviour
	{
		void OnAnimatorMove()
		{
			NotifyLua("OnAnimatorMove");
		}

		// void OnAnimatorIK(int layerIndex)
		// {
		// 	NotifyLua("OnAnimatorIK", layerIndex);
		// }
	}
}
