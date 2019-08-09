using UnityEngine;
using System.Collections;

namespace CinemaDirector
{
    [CutsceneItemAttribute("Animator", "Set Animation Speed", CutsceneItemGenre.ActorItem, CutsceneItemGenre.MecanimItem)]
    public class SetAnimationSpeedEvent : CinemaActorEvent
    {
        public float animationSpeed = 1.0f;
        
        public override void Trigger(GameObject actor)
        {
            Animator animator = actor.GetComponent<Animator>();
            if (animator == null)
            {
                return;
            }
            
            animator.speed = animationSpeed;
        }
    }
}