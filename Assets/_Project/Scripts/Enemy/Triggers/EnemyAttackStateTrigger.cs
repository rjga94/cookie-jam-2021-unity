using Enemy.StateMachine;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttackStateTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_controller == null || _controller.animator == null) return;
            _controller.animator.SetIsPlayerInAttackRange(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_controller == null || _controller.animator == null) return;
            _controller.animator.SetIsPlayerInAttackRange(false);
        }
    }
}