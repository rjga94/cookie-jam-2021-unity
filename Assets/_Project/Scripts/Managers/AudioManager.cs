using Audio;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        private AudioSource _audioSource;
        
        [SerializeField] public AudioInjectorSO AudioInjectorSO;

        public AudioSource AudioSource => _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            PlayGamePlayMusic();
        }

        public void PlayGamePlayMusic()
        {
            if (AudioInjectorSO.LevelBGM != null) AudioInjectorSO.LevelBGM.Play(_audioSource);
        }
    }
}