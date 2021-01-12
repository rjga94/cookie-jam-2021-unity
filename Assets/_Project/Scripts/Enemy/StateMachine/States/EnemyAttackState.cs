using System;
using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class EnemyAttackState : StateMachineBehaviour
    {
        public static event Action onEnterAttackState, onExitAttackState;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            onEnterAttackState?.Invoke();

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            onExitAttackState?.Invoke();
    }
}