using Assets.Scripts.Audio;
using System;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents Instance;

        public event Action<SfxSound> OnSoundPlay;

        private void Awake()
        {
            Instance = this;
        }

        public void SoundPlay(SfxSound id)
        {
            OnSoundPlay?.Invoke(id);
        }
    }
}