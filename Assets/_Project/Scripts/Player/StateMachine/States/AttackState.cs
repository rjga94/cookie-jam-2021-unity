using Managers;
using UnityEngine;

namespace Player.States
{
    public class AttackState : StateMachineBehaviour
    {
        [SerializeField] private GameObject attackColliderGO;
        // private AudioSource _audioSource;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // _audioSource = animator.GetComponent<AudioSource>();
            // AudioManager.Instance.AudioInjectorSO.PlayerAttack.Play(_audioSource);
            
            attackColliderGO.SetActive(true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            attackColliderGO.SetActive(false);
        }
    }
}