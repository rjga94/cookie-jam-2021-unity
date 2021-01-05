using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public enum GameScene
    {
        Initialization,
        TestLevel
    }
    
    public class ApplicationManager : MonoBehaviour
    {
        private float _timeScale;

        private void Awake() => _timeScale = Time.timeScale;

        private void ResetTimeScale() => Time.timeScale = _timeScale;

        private void StopTimeScale() => Time.timeScale = 0f;
        
        public void LoadScene(GameScene scene)
        {
            if (SceneManager.GetActiveScene().name != scene.ToString())
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
            }
            ResetTimeScale();
        }
        
        public void ResumeGame() => Time.timeScale = _timeScale;

        public void PauseGame() => Time.timeScale = 0f;
        
        public void ExitApplication()
        {
#if UNITY_EDITOR         
            UnityEditor.EditorApplication.isPlaying = false;                
#else 
            Application.Quit();
#endif
        }
    }
}