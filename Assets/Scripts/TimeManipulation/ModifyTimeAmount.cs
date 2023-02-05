using Assets.Scripts.Audio;
using Assets.Scripts.Data;
using Assets.Scripts.Events;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TimeManipulation
{
    public class ModifyTimeAmount : MonoBehaviour
    {
        [SerializeField] private float _secondsToAdd;

        public static event Action OnTotalTimeChanged;

        // Both timers modification
        public void ModifyTotalTime()
        {
            ModifyRemainingTime();
            GameSession.Instance.Data.TotalTime += _secondsToAdd;
            OnTotalTimeChanged.Invoke();
        }

        // Only current timer
        public void ModifyRemainingTime()
        {
            GameSession.Instance.Data.RemainingTime += _secondsToAdd;
            var clip = _secondsToAdd > 0 ? SfxSound.AddTime : SfxSound.ReduceTime;
            GameEvents.Instance.SoundPlay(clip);
        }
    }
}