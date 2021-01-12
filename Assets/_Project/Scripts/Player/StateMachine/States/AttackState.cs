using System;
using UnityEngine;

namespace Player.States
{
    public class AttackState : StateMachineBehaviour
    {
        public static event Action onEnterAttackState, onExitAttackState;
        // private AudioSource _audioSource;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // _audioSource = animator.GetComponent<AudioSource>();
            // AudioManager.Instance.AudioInjectorSO.PlayerAttack.Play(_audioSource);
            
            onEnterAttackState?.Invoke();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            onExitAttackState?.Invoke();
        }
    }
}