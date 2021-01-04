using UnityEngine;
using Utilities.Extensions;

namespace Player
{
    public static class AnimatorHelper
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Attack = Animator.StringToHash("Attack");

        public static void SetIsMoving(this Animator animator, bool value) => animator.SetBool(IsMoving, value);
        public static void SetIsFalling(this Animator animator, bool value) => animator.SetBool(IsFalling, value);
        public static void SetIsAttacking(this Animator animator, bool value) => animator.SetBool(IsAttacking, value);
        public static void SetIsJumping(this Animator animator, bool value) => animator.SetBool(IsJumping, value);
        public static void TriggerJump(this Animator animator, MonoBehaviour monoBehaviour) => animator.SetTriggerForFrame(monoBehaviour, Jump);
        public static void TriggerAttack(this Animator animator, MonoBehaviour monoBehaviour) => animator.SetTriggerForFrame(monoBehaviour, Attack);
    }
}