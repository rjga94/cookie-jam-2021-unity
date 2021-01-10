using UnityEngine;

namespace Enemy.StateMachine.States
{
    public class EnemyMoveState : StateMachineBehaviour
    {
        private EnemyController _controller;
        private EnemyStateDataSO _data;
        private Rigidbody2D _rigidbody2D;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _controller = animator.GetComponentInParent<EnemyController>();
            _data = _controller.data;
            _rigidbody2D = animator.GetComponentInParent<Rigidbody2D>();
        }
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var movementAxisX = 0;
            if (_rigidbody2D.position.x > _controller.playerPosition.x) movementAxisX = -1;
            else if (_rigidbody2D.position.x < _controller.playerPosition.x) movementAxisX = 1;

            _rigidbody2D.velocity = new Vector2(movementAxisX * _data.moveSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
        }
    }
}