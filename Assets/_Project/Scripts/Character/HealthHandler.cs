using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class HealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health;
        public UnityEvent onTakeDamage, onDie;

        public float Health
        {
            get => health;
            private set => health = value;
        }

        private bool CanDie() => Health <= 0;

        public void OnTakeDamage(float amount)
        {
            Health -= amount;
            if (CanDie()) onDie?.Invoke();
            else onTakeDamage?.Invoke();
        }
    }
}