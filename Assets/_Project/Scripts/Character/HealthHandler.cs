using Interfaces;
using UnityEngine;

namespace Character
{
    public class HealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health;

        public float Health
        {
            get => health;
            private set => health = value;
        }

        private bool CanDie() => Health <= 0;

        private void DestroySelf() => Destroy(gameObject);

        public void OnTakeDamage(float amount)
        {
            Health -= amount;
            if (CanDie()) DestroySelf();
        }
    }
}