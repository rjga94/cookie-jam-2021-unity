using UnityEngine;

namespace Poucet.StateMachine.States
{
    public class PoucetDieState : StateMachineBehaviour
    {
        [SerializeField] private PoucetFightHandler _fightHandler;
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= .99f)
            {
                _fightHandler.EndFight();
                Destroy(animator.gameObject.gameObject);
            }
        }
    }
}