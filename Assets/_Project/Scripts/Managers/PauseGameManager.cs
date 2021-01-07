using Input;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class PauseGameManager : SingletonMonoBehaviour<PauseGameManager>
    {
        [SerializeField] private GameObject pauseMenuGO;

        private void OnEnable()
        {
            InputReader.Instance.pauseEvent += OnPauseInput;
            InputReader.Instance.cancelMenuEvent += OnCancelMenuInput;
        }

        private void OnDisable()
        {
            InputReader.Instance.pauseEvent -= OnPauseInput;
            InputReader.Instance.cancelMenuEvent -= OnCancelMenuInput;
        }

        public void OnResumeButtonClick() => ResumeGame();

        private void OnPauseInput()
        {
            if (ApplicationManager.Instance.IsGamePaused) ResumeGame();
            else PauseGame();
        }

        private void OnCancelMenuInput() => ResumeGame();

        private void PauseGame()
        {
            InputReader.Instance.EnableMenuInput();
            ApplicationManager.Instance.PauseGame();
            pauseMenuGO.SetActive(true);
        }

        private void ResumeGame()
        {
            pauseMenuGO.SetActive(false);
            ApplicationManager.Instance.ResumeGame();
            InputReader.Instance.EnableGameplayInput();
        }

        public void OnQuitGameButtonClick() => ApplicationManager.Instance.ExitApplication();
    }
}