using System;
using Audio;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] private AudioSource mainAudioSource, secondaryAudioSource;
        
        [SerializeField] public AudioInjectorSO AudioInjectorSO;

        public AudioSource MainAudioSource => mainAudioSource;
        public AudioSource SecondaryAudioSource => secondaryAudioSource;

        private void Awake() => PlayGamePlayMusic();

        public void PlayGamePlayMusic()
        {
            if (AudioInjectorSO.LevelBGM != null) AudioInjectorSO.LevelBGM.Play(mainAudioSource);
        }
    }
}