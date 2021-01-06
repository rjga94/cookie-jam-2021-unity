using Audio;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] public AudioInjectorSO AudioInjectorSO;
    }
}