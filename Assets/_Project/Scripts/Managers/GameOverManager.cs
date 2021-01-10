using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameOverManager : SingletonMonoBehaviour<GameOverManager>
    {
        [SerializeField] private GameObject gameOverGO;

        public void ShowGameOverUI() => gameOverGO.SetActive(true);

        public void HideGameOverUI() => gameOverGO.SetActive(false);
    }
}