using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class EnemyAttackState : StateMachineBehaviour
    {
        [SerializeField] private GameObject attackColliderGO;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => attackColliderGO.SetActive(true);

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => attackColliderGO.SetActive(false);
    }
}