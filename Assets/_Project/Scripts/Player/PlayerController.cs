﻿using Input;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private Interactable _interactable;
        
        [SerializeField, InlineEditor] public PlayerStateDataSO data;
        
        [HideInInspector] public Vector2 movementAxis;

        #region Lifecycle

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputReader.Instance.moveEvent += OnMovementInput;
            InputReader.Instance.jumpEvent += OnJumpInput;
            InputReader.Instance.attackEvent += OnAttackInput;
            InputReader.Instance.defendEvent += OnDefendInput;
            InputReader.Instance.interactEvent += OnInteractInput;
        }

        private void OnDisable()
        {
            InputReader.Instance.moveEvent -= OnMovementInput;
            InputReader.Instance.jumpEvent -= OnJumpInput;
            InputReader.Instance.attackEvent -= OnAttackInput;
            InputReader.Instance.defendEvent -= OnDefendInput;
            InputReader.Instance.interactEvent -= OnInteractInput;
        }

        #endregion

        private void Update()
        {
            _animator.SetIsFalling(_rigidbody2D.velocity.y < -0.05f);
        }

        #region Input events

        private void OnMovementInput(Vector2 value)
        {
            movementAxis = value;
            _animator.SetIsMoving(Mathf.Abs(movementAxis.x) != 0 || Mathf.Abs(movementAxis.y) != 0);
        }

        private void OnJumpInput() => _animator.TriggerJump(this);

        private void OnAttackInput() => _animator.TriggerAttack(this);

        private void OnDefendInput(bool IsKeyDown) => _animator.SetIsDefending(IsKeyDown);
        
        private void OnInteractInput()
        {
            if (!CanInteract()) return;
            _interactable?.OnInteract();
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D other) => _interactable = other.GetComponent<Interactable>();

        private void OnTriggerExit2D(Collider2D other)
        {
            var interactable = other.GetComponent<Interactable>();
            if (interactable != null && interactable == _interactable) _interactable = null;
        }

        private bool CanInteract() => _interactable != null;
    }
}