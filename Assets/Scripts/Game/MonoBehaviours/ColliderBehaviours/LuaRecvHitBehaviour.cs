
//
using System;
using UnityEngine;
using SLua;
using LBoot;

namespace Game
{
    [CustomLuaClassAttribute]
    public class LuaRecvHitBehaviour : LuaBaseBehaviour
    {
        // void OnTriggerEnter2D(Collider2D collider)
        // {
        //     if (collider.CompareTag("AttackCollider") ||
        //     collider.CompareTag("DetectCollider") ||
        //     collider.CompareTag("ProjAttackCollider"))
        //     {
        //         NotifyLua("OnBeingAttacked", collider);
        //     }
        // }

        private int attackColliderLayer = 0;
        private int detectColliderLayer = 0;

        void Start()
        {
			attackColliderLayer = LayerMask.NameToLayer ("AttackCollider");
			detectColliderLayer = LayerMask.NameToLayer ("DetectCollider");
        }

        void OnTriggerEnter(Collider collider)
        {
			int colliderLayer = collider.gameObject.layer;
			if (colliderLayer == attackColliderLayer ||
			    colliderLayer == detectColliderLayer) {
				NotifyLua ("OnBeingAttacked", collider);
			}
        }
    }
}