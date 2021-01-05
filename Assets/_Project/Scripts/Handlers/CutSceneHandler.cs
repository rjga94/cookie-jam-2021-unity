using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Handlers
{
    public class CutSceneHandler : MonoBehaviour
    {
        [SerializeField, InlineEditor] private CutSceneSO cutSceneSO;

        private void Start() => CutSceneManager.Instance.StartCutScene(cutSceneSO);
    }
}