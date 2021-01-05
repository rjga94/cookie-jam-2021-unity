﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    // public enum GameScene
    // {
    //     StartCutScene,
    //     TestScene
    // }
    
    public class ApplicationManager : SingletonMonoBehaviour<ApplicationManager>
    {
        private float _timeScale;

        private void Awake() => _timeScale = Time.timeScale;

        private void ResetTimeScale() => Time.timeScale = _timeScale;

        private void StopTimeScale() => Time.timeScale = 0f;
        
        // public void LoadScene(GameScene scene)
        // {
        //     if (SceneManager.GetActiveScene().name != scene.ToString())
        //     {
        //         SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        //         SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
        //     }
        //     ResetTimeScale();
        // }

        public void ResumeGame() => ResetTimeScale();

        public void PauseGame() => StopTimeScale();
        
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