using System.Collections.Generic;
using Enemy.StateMachine.States;
using Interfaces;
using Player.States;
using Poucet.StateMachine.States;
using UnityEngine;

namespace Player
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private float attackPower;
        [SerializeField] private bool isEnemy;

        private List<int> _hitObjects;
        private bool _isInAttackState;

        private void OnEnable()
        {
            _hitObjects = new List<int>();
            if (isEnemy)
            {
                EnemyAttackState.onEnterAttackState += OnEnterAttackState;
                EnemyAttackState.onExitAttackState += OnExitAttackState;
                PoucetStomp.onEnterAttackState += OnEnterAttackState;
                PoucetStomp.onExitAttackState += OnExitAttackState;
            }
            else
            {
                AttackState.onEnterAttackState += OnEnterAttackState;
                AttackState.onExitAttackState += OnExitAttackState;
            }
        }

        private void OnDisable()
        {
            if (isEnemy)
            {
                EnemyAttackState.onEnterAttackState -= OnEnterAttackState;
                EnemyAttackState.onExitAttackState += OnExitAttackState; 
                PoucetStomp.onEnterAttackState -= OnEnterAttackState;
                PoucetStomp.onExitAttackState -= OnExitAttackState;
            }
            else
            {
                AttackState.onEnterAttackState -= OnEnterAttackState;
                AttackState.onExitAttackState -= OnExitAttackState;
            }
        }

        private void OnEnterAttackState()
        {
            _isInAttackState = true;
        }

        private void OnExitAttackState()
        {
            _isInAttackState = false;
            _hitObjects.Clear();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_isInAttackState) return;
            var damageable = other.GetComponent<IDamageable>();
            if (damageable == null || _hitObjects.Contains(other.GetInstanceID())) return;
            _hitObjects.Add(other.GetInstanceID());

            damageable.OnTakeDamage(attackPower);
        }
    }
}