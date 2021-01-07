﻿using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioInjector", menuName = ScriptableObjectConstants.audioPath + "Audio Injector", order = 0)]
    public class AudioInjectorSO : ScriptableObject
    {
        [Title("Player SFX")]
        [SerializeField, CanBeNull, LabelText("Footstep")] public AudioPoolSO PlayerFootstep;
        [SerializeField, CanBeNull, LabelText("Jump")] public AudioPoolSO PlayerJump;
        [SerializeField, CanBeNull, LabelText("Land")] public AudioPoolSO PlayerLand;
        [SerializeField, CanBeNull, LabelText("Attack")] public AudioPoolSO PlayerAttack;
        [SerializeField, CanBeNull, LabelText("Hurt")] public AudioPoolSO PlayerHurt;
        [SerializeField, CanBeNull, LabelText("Death")] public AudioPoolSO PlayerDeath;
        [SerializeField, CanBeNull, LabelText("Loot Pickup")] public AudioPoolSO PlayerLootPickup;

        [Title("Level SFX")]
        [SerializeField, CanBeNull, LabelText("Background Music")] public AudioPoolSO LevelBGM;

        [Title("StartCutScene SFX")] 
        [SerializeField, CanBeNull, LabelText("Background Music")] public AudioPoolSO CutSceneBGM;
        [SerializeField, CanBeNull, LabelText("Slide Change")] public AudioPoolSO CutSceneSlideChange;
    }
}