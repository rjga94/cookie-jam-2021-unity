using Interfaces;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour, Interactable
    {
        [SerializeField, InlineEditor] private DialogSO dialogSO;
        
        public void OnInteract() => DialogManager.Instance.StartDialog(dialogSO);
    }
}