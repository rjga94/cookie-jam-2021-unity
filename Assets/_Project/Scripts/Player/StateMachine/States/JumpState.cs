using UnityEngine;

namespace Player.States
{
    public class JumpState : StateMachineBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private PlayerStateDataSO _data;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _rigidbody2D = animator.GetComponent<Rigidbody2D>();
            _data = animator.GetComponent<PlayerController>().data;
            
            _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, _data.jumpForce);
        }
    }
}