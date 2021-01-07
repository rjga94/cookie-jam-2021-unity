using Enemy.StateMachine;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveStateTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _controller.playerTransform = other.gameObject.transform;
            _controller.animator.SetIsPlayerInRange(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _controller.animator.SetIsPlayerInRange(false);
            _controller.playerTransform = null;
        }
    }
}