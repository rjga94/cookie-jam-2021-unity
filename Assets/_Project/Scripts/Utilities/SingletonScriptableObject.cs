using UnityEngine;

namespace Utilities
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;
        
        public static T Instance
        {
            get
            {
                if (!_instance) _instance = FindObjectOfType<T>();
                if (!_instance) _instance = CreateInstance<T>();
                _instance.hideFlags = HideFlags.HideAndDontSave;
                return _instance;
            }
        }
    }
}
