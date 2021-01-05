using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Handlers
{
    public class CutSceneHandler : MonoBehaviour
    {
        [SerializeField] private GameScene nextScene;
        [SerializeField, InlineEditor] private CutSceneSO cutSceneSO;

        private CutSceneManager _cutSceneManager;

        private void Awake() => _cutSceneManager = FindObjectOfType<CutSceneManager>();

        private void Start()
        {
            if (_cutSceneManager != null) _cutSceneManager.StartCutScene(cutSceneSO);
        }

        private void OnEnable()
        {
            if (_cutSceneManager != null) _cutSceneManager.OnCutSceneEndEvent += OnCutSceneEnd;
        }

        private void OnDisable()
        {
            if (_cutSceneManager != null) _cutSceneManager.OnCutSceneEndEvent -= OnCutSceneEnd;
        }

        private void OnCutSceneEnd() => ApplicationManager.Instance.LoadScene(nextScene);
    }
}