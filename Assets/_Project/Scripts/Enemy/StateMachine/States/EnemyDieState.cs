using Poucet;
using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class EnemyDieState : StateMachineBehaviour
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= .99f) Destroy(animator.gameObject);
        }
    }
}