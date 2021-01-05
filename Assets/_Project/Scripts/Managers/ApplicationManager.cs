using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public enum GameScene
    {
        TestScene
    }
    
    public class ApplicationManager : MonoBehaviour
    {
        private float _timeScale;

        private void Awake() => _timeScale = Time.timeScale;

        private void Start()
        {
#if !UNITY_EDITOR
            LoadScene(GameScene.TestScene);
#endif
        }

        private void ResetTimeScale() => Time.timeScale = _timeScale;

        private void StopTimeScale() => Time.timeScale = 0f;
        
        public void LoadScene(GameScene scene)
        {
            print("load scene");
            if (SceneManager.GetActiveScene().name != scene.ToString())
            {
                print("things");
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