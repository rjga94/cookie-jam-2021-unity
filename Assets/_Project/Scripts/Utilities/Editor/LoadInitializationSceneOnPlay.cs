using UnityEditor;
using UnityEngine.SceneManagement;

namespace Utilities.Editor
{
    [InitializeOnLoadAttribute]
    public class LoadInitializationSceneOnPlay
    {
        private static int _buildIndex = -1;

        static LoadInitializationSceneOnPlay() => SceneManager.sceneLoaded += OnSceneLoaded;

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (_buildIndex == -1)
            {
                _buildIndex = scene.buildIndex;
                if (scene.buildIndex != 0)
                {
                    SceneManager.LoadScene(0);
                    return;
                }
            }
            
            SceneManager.LoadScene(_buildIndex, LoadSceneMode.Additive);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}