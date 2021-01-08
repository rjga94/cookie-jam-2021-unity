using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private float attackPower;

        private List<int> _hitObjects;

        private void OnEnable() => _hitObjects = new List<int>();
        private void OnDisable() => _hitObjects = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D", this);

            var damageable = other.GetComponent<IDamageable>();
            if (damageable == null || _hitObjects.Contains(other.GetInstanceID())) return;
            _hitObjects.Add(other.GetInstanceID());
            
            Debug.Log($"damaged other with amount {attackPower}", this);
            damageable.OnTakeDamage(attackPower);
        }
    }
}