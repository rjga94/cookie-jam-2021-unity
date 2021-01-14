using System;
using UnityEngine;
using UnityEngine.Animations;

namespace Poucet.StateMachine.States
{
    public class PoucetStomp : StateMachineBehaviour
    {
        public static event Action onEnterAttackState, onExitAttackState;
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            onEnterAttackState?.Invoke();
            animator.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            onExitAttackState?.Invoke();
        }
    }
}