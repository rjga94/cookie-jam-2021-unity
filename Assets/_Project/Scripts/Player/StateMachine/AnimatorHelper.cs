using UnityEngine;
using Utilities.Extensions;

namespace Player
{
    public static class AnimatorHelper
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        private static readonly int Jump = Animator.StringToHash("Jump");

        public static void SetIsMoving(this Animator animator, bool value) => animator.SetBool(IsMoving, value);
        public static void SetIsFalling(this Animator animator, bool value) => animator.SetBool(IsFalling, value);
        public static void TriggerJump(this Animator animator, MonoBehaviour monoBehaviour) => animator.SetTriggerForFrame(monoBehaviour, Jump);
    }
}