using Assets.Scripts.Data;
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
        }
    }
}