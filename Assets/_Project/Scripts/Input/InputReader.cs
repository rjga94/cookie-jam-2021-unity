using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Utilities;

namespace Input
{
    public class InputReader : SingletonScriptableObject<InputReader>
    {
        private ApplicationInput _applicationInput;
        
        public event UnityAction<Vector2> moveEvent;
        public event UnityAction jumpEvent;
        public event UnityAction attackEvent;
        public event UnityAction defendEvent;
        public event UnityAction pauseEvent;

        private void OnEnable()
        {
            if (_applicationInput == null)
            {
                _applicationInput = new ApplicationInput();
                HookGameplayEvents();
            }
            
            _applicationInput.Gameplay.Enable();
        }

        private void OnDisable() => _applicationInput.Disable();

        private void OnMovement(InputAction.CallbackContext context) => moveEvent?.Invoke(context.ReadValue<Vector2>());

        private void OnJump(InputAction.CallbackContext context) => jumpEvent?.Invoke();

        private void OnAttack(InputAction.CallbackContext context) => attackEvent?.Invoke();

        private void OnDefend(InputAction.CallbackContext obj) => defendEvent?.Invoke();

        private void OnPause(InputAction.CallbackContext obj) => pauseEvent?.Invoke();

        private void HookGameplayEvents()
        {
            _applicationInput.Gameplay.Move.performed += OnMovement;
            _applicationInput.Gameplay.Jump.performed += OnJump;
            _applicationInput.Gameplay.Attack.performed += OnAttack;
            _applicationInput.Gameplay.Defend.performed += OnDefend;
            _applicationInput.Gameplay.Pause.performed += OnPause;
        }
    }
}