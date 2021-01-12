using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioPool", menuName = ScriptableObjectConstants.audioPath + "Audio Pool", order = 0)]
    public class AudioPoolSO : ScriptableObject
    {
        public AudioClip[] samples;
        
        [Title("Settings")]

        [MinMaxSlider(0f, 100f)]
        public Vector2 volume = new Vector2(25f, 75f);
        
        [MinMaxSlider(0f, 100f)]
        public Vector2 pitch = new Vector2(25f, 75f);

        public void Play(AudioSource audioSource)
        {
            if (samples == null || samples.Length == 0) return;

            var rnd = new System.Random();
            audioSource.volume = rnd.Next((int) volume.x, (int) volume.y) * 0.01f;
            audioSource.pitch = rnd.Next((int) pitch.x, (int) pitch.y) * 0.01f;
            audioSource.clip = samples[rnd.Next(0, samples.Length)];
            audioSource.Play();
        }
        
#if UNITY_EDITOR
        [Button("Preview")]
        private void OnPlayButtonClick()
        {
            var audioSource = GameObject.Find("AudioPoolSOPreview")?.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource =
                    EditorUtility.CreateGameObjectWithHideFlags("AudioPoolSOPreview", HideFlags.HideAndDontSave,
                        typeof(AudioSource)).GetComponent<AudioSource>();
            }
            
            Play(audioSource);
        }
        
        [Button("Stop")]
        private void OnStopButtonClick()
        {
            var audioSource = GameObject.Find("AudioPoolSOPreview")?.GetComponent<AudioSource>();
            if (audioSource == null) return;

            audioSource.Stop();
        }
#endif
    }
}