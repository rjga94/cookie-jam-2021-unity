using UnityEngine;
using Utilities;

namespace Managers
{
    [System.Serializable]
    public class CutSceneSlide
    {
        public Sprite sprite;
        public string[] sentences;
    }
    
    [CreateAssetMenu(fileName = "CutScene", menuName = ScriptableObjectConstants.cutScenesDataPath + "Cut Scene", order = 0)]
    public class CutSceneSO : ScriptableObject
    {
        public CutSceneSlide[] slides;
    }
}