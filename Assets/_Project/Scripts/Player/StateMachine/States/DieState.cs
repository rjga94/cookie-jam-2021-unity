using UnityEngine;

namespace Player.States
{
    public class DieState : StateMachineBehaviour
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= .99f) Destroy(animator.gameObject);
        }
    }
}