using Audio;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class Paragraph
    {
        [MultiLineProperty(8)]
        public string text;
        public AudioPoolSO voice;
        public Sprite frame;
    }
}