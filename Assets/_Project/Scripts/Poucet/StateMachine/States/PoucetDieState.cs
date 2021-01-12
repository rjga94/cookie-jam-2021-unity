using UnityEngine;

namespace Poucet.StateMachine.States
{
    public class PoucetDieState : StateMachineBehaviour
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= .99f)
            {
                Destroy(animator.gameObject.transform.parent.gameObject);
                PoucetFightHandler.Instance.EndFight();
            }
        }
    }
}