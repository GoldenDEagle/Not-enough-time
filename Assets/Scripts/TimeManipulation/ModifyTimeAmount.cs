using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TimeManipulation
{
    public class ModifyTimeAmount : MonoBehaviour
    {
        [SerializeField] private float _secondsToAdd;

        // Both timers modification
        public void ModifyTotalTime()
        {
            GameSession.Instance.Data.RemainingTime += _secondsToAdd;
            GameSession.Instance.Data.TotalTime += _secondsToAdd;
        }

        // Only current timer
        public void ModifyRemainingTime()
        {
            GameSession.Instance.Data.RemainingTime += _secondsToAdd;
        }
    }
}