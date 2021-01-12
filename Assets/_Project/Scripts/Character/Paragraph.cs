using Audio;
using Sirenix.OdinInspector;

namespace Character
{
    [System.Serializable]
    public class Paragraph
    {
        [MultiLineProperty(8)]
        public string text;
        public AudioPoolSO voice;
    }
}