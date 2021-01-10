using UnityEngine;
using Utilities.Extensions;

namespace Enemy.StateMachine
{
    public static class AnimatorHelper
    {
        private static readonly int IsPlayerInRange = Animator.StringToHash("IsPlayerInRange");
        private static readonly int IsPlayerInAttackRange = Animator.StringToHash("IsPlayerInAttackRange");
        private static readonly int IsAtStartPosition = Animator.StringToHash("IsAtStartPosition");
        private static readonly int Hurt = Animator.StringToHash("Hurt");
        private static readonly int Die = Animator.StringToHash("Die");
        
        public static void SetIsPlayerInRange(this Animator animator, bool value) => animator.SetBool(IsPlayerInRange, value);
        public static void SetIsPlayerInAttackRange(this Animator animator, bool value) => animator.SetBool(IsPlayerInAttackRange, value);
        public static void SetIsAtStartPosition(this Animator animator, bool value) => animator.SetBool(IsAtStartPosition, value);
        
        public static void TriggerHurt(this Animator animator, MonoBehaviour monoBehaviour) => animator.SetTriggerForFrame(monoBehaviour, Hurt);
        public static void TriggerDie(this Animator animator, MonoBehaviour monoBehaviour) => animator.SetTriggerForFrame(monoBehaviour, Die);
    }
}