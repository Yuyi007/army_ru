
//
using System;
using UnityEngine;
using SLua;

namespace LBoot
{
    /// <summary>
    /// Handles proj atk stay callbacks
    /// </summary>
    [CustomLuaClassAttribute]
    public class LuaProjStayAtkBehaviour : LuaBaseBehaviour
    {
        // void OnTriggerStay2D(Collider2D collider)
        // {
        //     if (collider.CompareTag("RecvCollider"))
        //     {
        //         if (transform.CompareTag("DetectCollider"))
        //         {
        //             NotifyLua("OnDetectStay", collider);
        //         }
        //         else if(transform.CompareTag("ProjAttackCollider"))
        //         {
        //             NotifyLua("OnAttackStay", collider);
        //         }
        //     }
        // }

		private bool isDetect = false;

        void Start()
        {
			int detectColliderLayer = LayerMask.NameToLayer ("DetectCollider");
			isDetect = (gameObject.layer == detectColliderLayer);
        }

        void OnTriggerStay(Collider collider)
        {
			if (isDetect)
            {
                NotifyLua("OnDetectStay", collider);
            }
            else
            {
                NotifyLua("OnAttackStay", collider);
            }
        }
    }
}