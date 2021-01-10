using UnityEngine;

namespace Poucet.StateMachine.States
{
    public class PoucetJumpOut : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}