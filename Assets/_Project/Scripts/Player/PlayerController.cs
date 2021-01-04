using Input;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        
        [SerializeField] public PlayerStateDataSO data;
        
        [HideInInspector] public Vector2 movementAxis;

        #region Lifecycle

        private void Awake() => _animator = GetComponent<Animator>();

        private void OnEnable() => InputReader.Instance.moveEvent += OnMovementInput;

        private void OnDisable() => InputReader.Instance.moveEvent -= OnMovementInput;

        #endregion

        private void OnMovementInput(Vector2 value)
        {
            movementAxis = value;
            _animator.SetIsMoving(Mathf.Abs(movementAxis.x) != 0 || Mathf.Abs(movementAxis.y) != 0);
        }
    }
}