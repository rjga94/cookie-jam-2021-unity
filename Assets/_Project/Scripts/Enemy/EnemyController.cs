using System;
using System.Collections;
using Enemy.StateMachine;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {

        public Vector2 startPosition { get; private set; }
        
        [HideInInspector] public Animator animator;
        [HideInInspector, CanBeNull] public Transform playerTransform;
        [SerializeField, InlineEditor] public EnemyStateDataSO data;
        [HideInInspector] public Vector2 playerPosition;
        
        #region Lifecycle

        private void Awake()
        {
            startPosition = gameObject.transform.position;
            animator = GetComponent<Animator>();
        }

        #endregion

        private void Update()
        {
            animator.SetIsAtStartPosition(Mathf.Abs(gameObject.transform.position.x - startPosition.x) < 0.1f);
            if (playerTransform != null) playerPosition = playerTransform.position;
        }

        public IEnumerator TriggerJumpOut()
        {
            yield return new WaitForSeconds(5f);
            animator.TriggerJumpOut(this);
        }

        public void OnTakeDamage() => animator.TriggerHurt(this);

        public void OnDie() => animator.TriggerDie(this);
    }
}