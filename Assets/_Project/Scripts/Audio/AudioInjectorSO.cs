using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioInjector", menuName = ScriptableObjectConstants.audioPath + "Audio Injector", order = 0)]
    public class AudioInjectorSO : ScriptableObject
    {
        [Title("Player SFX")]
        [SerializeField] public AudioPoolSO PlayerAttack;

        [Title("Background Music")]
        [SerializeField] public AudioPoolSO BackgroundMusic;
    }
}