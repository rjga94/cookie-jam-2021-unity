using UnityEngine;
using UnityEngine.Animations;

namespace Player.States
{
    public class MoveState : StateMachineBehaviour
    {
        private PlayerController _controller;
        private Rigidbody2D _rigidbody2D;
        private PlayerStateDataSO _data;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _controller = animator.GetComponent<PlayerController>();
            _rigidbody2D = animator.GetComponent<Rigidbody2D>();
            _data = _controller.data;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _rigidbody2D.velocity = new Vector2(_controller.movementAxis.x * _data.movementSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }
}