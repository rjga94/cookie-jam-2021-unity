using Managers;
using UnityEngine;

namespace Player.States
{
    public class AttackState : StateMachineBehaviour
    {
        // private AudioSource _audioSource;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // _audioSource = animator.GetComponent<AudioSource>();
            // AudioManager.Instance.AudioInjectorSO.PlayerAttack.Play(_audioSource);
        }
    }
}