using Input;
using UnityEngine;

namespace Player.States
{
    public class DieState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputReader.Instance.EnableMenuInput();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= .99f) Destroy(animator.gameObject);
        }
    }
}