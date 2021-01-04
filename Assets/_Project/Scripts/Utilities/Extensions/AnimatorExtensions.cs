using System.Collections;
using UnityEngine;

namespace Utilities.Extensions
{
    public static class AnimatorExtensions
    {
        public static void SetTriggerForFrame(this Animator animator, MonoBehaviour monoBehaviour, int id)
        {
            SetTrigger(animator, monoBehaviour, id);
        }
        
        public static void SetTriggerForFrame(this Animator animator, MonoBehaviour monoBehaviour, string name)
        {
            var id = Animator.StringToHash(name);
            SetTrigger(animator, monoBehaviour, id);
        }

        private static void SetTrigger(Animator animator, MonoBehaviour monoBehaviour, int id)
        {
            animator.SetTrigger(id);
            monoBehaviour.StartCoroutine(ResetTrigger(animator, id));
        }

        private static IEnumerator ResetTrigger(Animator animator, int id)
        {
            yield return new WaitForEndOfFrame();
            animator.ResetTrigger(id);
        }
    }
}