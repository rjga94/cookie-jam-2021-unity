using Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private const float _groundCheckDistance = 0.1f;
        
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private int _groundLayerMask;
        
        [SerializeField, InlineEditor] public PlayerStateDataSO data;
        
        [HideInInspector] public Vector2 movementAxis;

        #region Lifecycle

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _groundLayerMask = LayerMask.GetMask("Ground");
        }

        private void OnEnable()
        {
            InputReader.Instance.moveEvent += OnMovementInput;
            InputReader.Instance.jumpEvent += OnJumpInput;
            InputReader.Instance.attackEvent += OnAttackInput;
        }

        private void OnDisable()
        {
            InputReader.Instance.moveEvent -= OnMovementInput;
            InputReader.Instance.jumpEvent -= OnJumpInput;
            InputReader.Instance.attackEvent -= OnAttackInput;
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

        #endregion
    }
}