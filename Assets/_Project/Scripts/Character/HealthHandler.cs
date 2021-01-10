using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class HealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health;
        [SerializeField] private bool increaseHealthOverTime;
        public UnityEvent onTakeDamage, onDie;

        private Coroutine _coroutine;
        private float _maxHealth;
        
        public float Health
        {
            get => health;
            private set => health = value;
        }

        private void Awake()
        {
            _maxHealth = Health;
        }

        private void Start()
        {
            if (increaseHealthOverTime) _coroutine = StartCoroutine(IncreaseHealthOverTime());
        }

        private void OnDestroy()
        {
            StopCoroutine(IncreaseHealthOverTime());
            _coroutine = null;
        }

        private IEnumerator IncreaseHealthOverTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                if (Health < _maxHealth) Health += .1f;   
            }
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