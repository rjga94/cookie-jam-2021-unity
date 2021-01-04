using UnityEngine;

namespace Player
{
    public static class AnimatorHelper
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public static void SetIsMoving(this Animator animator, bool value) => animator.SetBool(IsMoving, value);
    }
}