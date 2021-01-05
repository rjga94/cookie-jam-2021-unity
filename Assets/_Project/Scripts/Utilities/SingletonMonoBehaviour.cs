using UnityEngine;

namespace Utilities
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        
        public static T Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<T>();
                if (_instance == null) _instance = new GameObject($"{typeof(T).Name} (singleton)").AddComponent<T>();

                DontDestroyOnLoad(_instance);
                _instance.hideFlags = HideFlags.HideAndDontSave;
                
                return _instance;
            }
        }
    }
}