using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class EnemyAttackState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("attack", this);
        }
    }
}