using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CutScene
{
    public class CutSceneTrigger : MonoBehaviour
    {
        private bool _didPlayCutscene;
        
        [SerializeField] private bool startCutSceneOnAwake, canReplay;
        [SerializeField, InlineEditor] private CutSceneSO cutSceneSO;
        
        private void Start()
        {
            if (!startCutSceneOnAwake) return;
            if (!canReplay && _didPlayCutscene) return;
            CutSceneManager.Instance.StartCutScene(cutSceneSO);
            _didPlayCutscene = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!canReplay && _didPlayCutscene) return;
            CutSceneManager.Instance.StartCutScene(cutSceneSO);
            _didPlayCutscene = true;
        }
    }
}