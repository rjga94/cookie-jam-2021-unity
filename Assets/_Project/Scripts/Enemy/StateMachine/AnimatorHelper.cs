using UnityEngine;

namespace Enemy.StateMachine
{
    public static class AnimatorHelper
    {
        private static readonly int IsPlayerInRange = Animator.StringToHash("IsPlayerInRange");
        private static readonly int IsPlayerInAttackRange = Animator.StringToHash("IsPlayerInAttackRange");
        private static readonly int IsAtStartPosition = Animator.StringToHash("IsAtStartPosition");
        
        public static void SetIsPlayerInRange(this Animator animator, bool value) => animator.SetBool(IsPlayerInRange, value);
        public static void SetIsPlayerInAttackRange(this Animator animator, bool value) => animator.SetBool(IsPlayerInAttackRange, value);
        public static void SetIsAtStartPosition(this Animator animator, bool value) => animator.SetBool(IsAtStartPosition, value);
    }
}