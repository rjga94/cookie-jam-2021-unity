using System;
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
        public event UnityAction<bool> defendEvent;
        public event UnityAction pauseEvent;
        public event UnityAction interactEvent;
        public event UnityAction stepDialogEvent;
        public event UnityAction closeDialogEvent;

        private void OnEnable()
        {
            if (_applicationInput == null)
            {
                _applicationInput = new ApplicationInput();
                HookEvents();
            }

            EnableGameplayInput();
        }

        private void OnDisable() => _applicationInput.Disable();

        private void OnMovement(InputAction.CallbackContext context) => moveEvent?.Invoke(context.ReadValue<Vector2>());

        private void OnJump(InputAction.CallbackContext context) => jumpEvent?.Invoke();

        private void OnAttack(InputAction.CallbackContext context) => attackEvent?.Invoke();

        private void OnDefendStarted(InputAction.CallbackContext obj) => defendEvent?.Invoke(true);
        
        private void OnDefendCanceled(InputAction.CallbackContext obj) => defendEvent?.Invoke(false);

        private void OnPause(InputAction.CallbackContext obj) => pauseEvent?.Invoke();
        
        private void OnInteract(InputAction.CallbackContext obj) => interactEvent?.Invoke();
        
        private void OnStep(InputAction.CallbackContext obj) => stepDialogEvent?.Invoke();
        
        private void OnClose(InputAction.CallbackContext obj) => closeDialogEvent?.Invoke();

        private void HookEvents()
        {
            _applicationInput.Gameplay.Move.performed += OnMovement;
            _applicationInput.Gameplay.Jump.performed += OnJump;
            _applicationInput.Gameplay.Attack.performed += OnAttack;
            _applicationInput.Gameplay.Defend.started += OnDefendStarted;
            _applicationInput.Gameplay.Defend.canceled += OnDefendCanceled;
            _applicationInput.Gameplay.Pause.performed += OnPause;
            _applicationInput.Gameplay.Interact.performed += OnInteract;

            _applicationInput.Dialog.Step.performed += OnStep;
            _applicationInput.Dialog.Close.performed += OnClose;
        }

        private void UpdateActiveActionMap(ActionMap actionMap)
        {
            moveEvent?.Invoke(Vector2.zero);
            defendEvent?.Invoke(false);
            
            _applicationInput.Gameplay.Disable();
            _applicationInput.Dialog.Disable();

            switch (actionMap)
            {
                case ActionMap.Gameplay:
                    _applicationInput.Gameplay.Enable();
                    break;
                case ActionMap.Dialog:
                    _applicationInput.Dialog.Enable();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionMap), actionMap, null);
            }
        }
        
        public void EnableGameplayInput() => UpdateActiveActionMap(ActionMap.Gameplay);

        public void EnableDialogInput() => UpdateActiveActionMap(ActionMap.Dialog);
    }
}